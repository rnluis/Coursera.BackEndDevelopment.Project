using Application.Abstractions.Messaging;

namespace Application.Product.Create;

public sealed record GetProductCommand(Guid id) : IQuery<ProductDto>;