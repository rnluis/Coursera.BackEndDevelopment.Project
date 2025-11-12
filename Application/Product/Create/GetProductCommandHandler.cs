using Application.Abstractions.Messaging;
using SharedKernel;

namespace Application.Product.Create;

internal sealed class GetProductCommandHandler : IQueryHandler<GetProductCommand,ProductDto>
{
    public async Task<Result<ProductDto>> Handle(GetProductCommand command, CancellationToken cancellationToken)
    {
        List<string> products = new List<string>(["Teste Product"]);
        
        Console.WriteLine(command.id);

        Console.WriteLine("Showing all the products before creation:");

        ProductDto productDto = new ProductDto(command.id, "Is my Product Being Created?");

        return productDto;
    }
}