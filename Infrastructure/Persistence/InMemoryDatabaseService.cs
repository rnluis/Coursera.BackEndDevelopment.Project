using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Application.Abstractions.DataAccess;
using Domain.Users;
using SharedKernel;

namespace Infrastructure.Persistence
{
    /// <summary>
    /// In-memory implementation of <see cref="IDatabaseService"/>.
    /// Stores entities in a type-keyed ConcurrentDictionary of lists and supports basic CRUD operations.
    /// Intended for development/tests only (not for production concurrency guarantees).
    /// </summary>
    public sealed class InMemoryDatabaseService : IDatabaseService
    {
        private readonly ConcurrentDictionary<Type, List<Entity>> _store = new();

        public InMemoryDatabaseService()
        {
            // seed users for convenience
            var users = new List<Entity>
            {
                User.Create("John", "Doe", "john.doe@example.com"),
                User.Create("Jane", "Smith", "jane.smith@example.com")
            };

            _store[typeof(User)] = users;
        }

        public List<T> GetAll<T>() where T : Entity
        {
            var type = typeof(T);
            if (_store.TryGetValue(type, out var list))
            {
                return list.Cast<T>().ToList();
            }

            return new List<T>();
        }

        public T? GetById<T>(Guid id) where T : Entity
        {
            var type = typeof(T);
            if (_store.TryGetValue(type, out var list))
            {
                return list.Cast<T>().FirstOrDefault(e => e.Id == id);
            }

            return default;
        }

        public Guid Add<T>(T entity) where T : Entity
        {
            var type = typeof(T);
            var list = _store.GetOrAdd(type, _ => new List<Entity>());
            list.Add(entity);
            return entity.Id;
        }

        public void Update<T>(T entity) where T : Entity
        {
            var type = typeof(T);
            var list = _store.GetOrAdd(type, _ => new List<Entity>());
            var idx = list.FindIndex(e => e.Id == entity.Id);
            if (idx >= 0)
            {
                list[idx] = entity;
            }
            else
            {
                list.Add(entity);
            }
        }

        public void Delete<T>(Guid id) where T : Entity
        {
            var type = typeof(T);
            if (_store.TryGetValue(type, out var list))
            {
                list.RemoveAll(e => e.Id == id);
            }
        }
    }
}
