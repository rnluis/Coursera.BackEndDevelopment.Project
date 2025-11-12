using SharedKernel;
using System;
using System.Collections.Generic;

namespace Application.Abstractions.DataAccess;

/// <summary>
/// Generic data access abstraction used by application handlers.
/// Synchronous, generic methods (no Task) as requested.
/// </summary>
public interface IDatabaseService
{
    /// <summary>
    /// Gets all entities of type T.
    /// </summary>
    List<T> GetAll<T>()
        where T : Entity;

    /// <summary>
    /// Gets a single entity by id.
    /// </summary>
    T? GetById<T>(Guid id)
        where T : Entity;

    /// <summary>
    /// Adds the given entity and returns the assigned id.
    /// The caller should map/construct a domain entity first (e.g. User.Create(...)).
    /// </summary>
    Guid Add<T>(T entity)
        where T : Entity;

    /// <summary>
    /// Updates the given entity (partial or full update semantics are up to the implementation).
    /// </summary>
    void Update<T>(T entity)
        where T : Entity;

    /// <summary>
    /// Deletes the entity with the given id.
    /// </summary>
    void Delete<T>(Guid id)
        where T : Entity;
}