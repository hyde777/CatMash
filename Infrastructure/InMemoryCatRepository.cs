using Domain;

namespace Infrastructure;

public class InMemoryCatRepository : ICatRepository
{
    private Dictionary<Guid, CatEntity> _cats = new();

    public Task<ICat> Get(Guid id)
    {
        throw new NotImplementedException();
    }
}

internal class CatEntity
{
}