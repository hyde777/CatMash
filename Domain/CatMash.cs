namespace Domain.Tests;

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
        cat.EarnAVote();
        await _repository.Update(cat);
    }
}