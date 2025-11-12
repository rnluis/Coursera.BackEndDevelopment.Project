using SharedKernel;

namespace Domain.Product;

public class Product: Entity
{

    public Product(
        Guid id,
        string name)
    {
        Id = id;
        Name = name;

    }
    
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    
}