namespace Domain;

public class CatMash
{
    private readonly ICatRepository _repository;
    private readonly ICatMashApi _catMashApi;

    public CatMash(ICatRepository repository, ICatMashApi catMashApi)
    {
        _repository = repository;
        _catMashApi = catMashApi;
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
        var catDtos = await _catMashApi.GetAll();
        await _repository.Import(catDtos);
    }

    public async Task<List<CatDto>> GetAll()
    {
        var cats = (await _repository.GetAll());
        return cats.Select(c => c.ToDto()).ToList();
    }
}