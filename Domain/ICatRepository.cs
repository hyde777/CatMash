namespace Domain;

public interface ICatRepository
{
    Task<ICat> Get(Guid id);
}