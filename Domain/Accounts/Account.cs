using SharedKernel;

namespace Domain.Account;

public class Account : Entity
{

    public Account(Guid id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }
    
    public Account(string name, string email)
    {
        Id = new Guid();
        Name = name;
        Email = email;
    }

    public Guid Id;
    public string Name;
    public string Email;
    

}