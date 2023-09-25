using NSubstitute;
using NSubstitute.ReceivedExtensions;

namespace Domain.Tests;

public class CatMashTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task RenameMe()
    {
        ICat cat = Substitute.For<ICat>();
        ICatRepository repository = Substitute.For<ICatRepository>();
        Guid id = Guid.NewGuid();
        repository.Get(id).Returns(cat);
        CatMash catmash = new CatMash(repository);

        await catmash.Vote(id);

        cat.Received(1).EarnAVote();
        await repository.Received(1).Update(cat);
    }
}

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

public interface ICatRepository
{
    Task Update(ICat cat);
    Task<ICat> Get(Guid id);
}

public interface ICat
{
    void EarnAVote();
}