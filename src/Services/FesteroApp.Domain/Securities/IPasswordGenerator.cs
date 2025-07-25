namespace FesteroApp.Domain.Securities;

public interface IPasswordGenerator
{
    string Generate(int length = 12);
}