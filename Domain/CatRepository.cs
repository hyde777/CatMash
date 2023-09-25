namespace Domain.Tests;

public class CatRepository : ICatRepository
{
    public Task Update(ICat cat)
    {
        throw new NotImplementedException();
    }

    public Task<ICat> Get(Guid id)
    {
        throw new NotImplementedException();
    }
}