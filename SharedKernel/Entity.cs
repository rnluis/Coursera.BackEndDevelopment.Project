using System;

namespace SharedKernel;

public abstract class Entity
{
    public Guid Id { get; protected set; }
}