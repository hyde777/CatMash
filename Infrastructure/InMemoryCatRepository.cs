using Domain;

namespace Infrastructure;

public class InMemoryCatRepository : ICatRepository
{
    private Dictionary<Guid, CatEntity> _cats = new();
    
    public async Task<ICat> Get(Guid id)
    {
        return _cats[id].MapToCat(this, id);
    }

    public async Task Update(Guid id, uint currentVote)
    {
        var catEntity = _cats[id];
        catEntity.CountVote = currentVote;
        _cats[id] = catEntity;
    }

    public async Task<List<ICat>> GetRandom(int count)
    {
        Random random = new Random();
        List<ICat> cats = new List<ICat>();
        for (int i = 0; i < count; i++)
        {
            var randomIndex = random.Next(_cats.Count);
            var keyValuePair = _cats.ToList()[randomIndex];
            var randomCat = keyValuePair.Value;
            cats.Add(randomCat.MapToCat(this, keyValuePair.Key));
        }

        return cats;
    }

    public async Task Import(List<CatDtoFromApi> catDtos)
    {
        uint initialCount = 0;
        _cats = catDtos.Select(dto => new CatEntity
        {
            CountVote = initialCount,
            ImageUrl = dto.ImageUrl,
            ExternalId = dto.Id,
        }).ToDictionary(_ => Guid.NewGuid(), x => x);
    }

    public async Task<List<ICat>> GetAll()
    {
        return _cats.Select(kvp => kvp.Value.MapToCat(this,kvp.Key)).ToList();
    }
}