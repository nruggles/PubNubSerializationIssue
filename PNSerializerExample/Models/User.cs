namespace PNSerializerExample.Models;

public class User: IEquatable<User>
{
    public Guid Id { get; set; }
    public UserType UserType { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    public bool Equals(User? other)
    {
        if (other is null)
            return false;
        
        return Id == other.Id && 
               UserType == other.UserType &&
               string.Equals(FirstName, other.FirstName, StringComparison.OrdinalIgnoreCase) &&
               string.Equals(LastName, other.LastName, StringComparison.OrdinalIgnoreCase);
    }

    public override bool Equals(object? obj)
    {
        return obj is User user && Equals(user);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, (int)UserType, FirstName, LastName);
    }
}