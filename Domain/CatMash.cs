namespace Domain;

public class CatMash
{
    private readonly ICatRepository _repository;

    public CatMash(ICatRepository repository)
    {
        _repository = repository;
    }

    public async Task Vote(Guid id)
    {
        var cat = await _repository.Get(id);
        await cat.EarnAVote();
    }

    public async Task<(ICat, ICat)> Mash()
    {
        var random = await _repository.GetRandom(2);
        return (random[0], random[1]);
    }

    public async Task Initialise()
    {
        throw new NotImplementedException();
    }
}