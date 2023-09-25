using Domain;

namespace Infrastructure;

public class InMemoryCatRepository : ICatRepository
{
    private Dictionary<Guid, CatEntity> _cats = new();

    public Task<ICat> Get(Guid id)
    {
        return _cats[id].MapToCat();
    }

    public Task Update(Guid id, uint currentVote)
    {
        throw new NotImplementedException();
    }
}