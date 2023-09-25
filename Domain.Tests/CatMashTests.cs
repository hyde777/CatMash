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
        ICatRepository repository = new CatRepository();
        Guid id = Guid.NewGuid();
        repository.Get(id).Returns(cat);
        CatMash catmash = new CatMash();

        await catmash.Vote(id);

        cat.Received(1).EarnAVote();
        await repository.Received(1).Update(cat);
    }
}

public class CatMash
{
    public async Task Vote(Guid id)
    {
        throw new NotImplementedException();
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