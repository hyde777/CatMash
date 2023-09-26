using Domain;

namespace Infrastructure;

public class InMemoryCatRepository : ICatRepository
{
    private Dictionary<Guid, CatEntity> _cats = new();
    
    public async Task<ICat> Get(Guid id)
    {
        return _cats[id].MapToCat();
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
            var randomCat = _cats.ToList()[randomIndex].Value;
            cats.Add(randomCat.MapToCat());
        }

        return cats;
    }

    public async Task Import(List<CatDto> catDtos)
    {
        _cats = catDtos.Select(dto => new CatEntity
        {
            CountVote = 0,
            ImageUrl = dto.Image,
            ExternalId = dto.Id,
        }).ToDictionary(_ => Guid.NewGuid(), x => x);
    }
}