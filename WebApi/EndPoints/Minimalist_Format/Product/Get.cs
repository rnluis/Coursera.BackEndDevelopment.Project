using System.ComponentModel.DataAnnotations;
using Application.Abstractions.Messaging;
using Application.Product.Create;
using Microsoft.AspNetCore.Authorization;
using SharedKernel;
using WebApi.Extensions;
using WebApi.Infrastructure;

namespace WebApi.EndPoints.Minimalist_Format.Product;

internal sealed class Get: IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("product/{id:guid}", async (
                Guid id,
                IQueryHandler<GetProductCommand,ProductDto> handler,
                CancellationToken cancelationToken) =>
            {

                var command = new GetProductCommand(id);
                
                Result<ProductDto> result = await handler.Handle(command,cancelationToken);;

                return result.Match(Results.Ok, CustomResults.Problem);

            }
        ).WithName("GetProduct")
        .WithTags("Product");
    }
}