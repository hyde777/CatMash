using NSubstitute;
using NSubstitute.ReceivedExtensions;

namespace Domain.Tests;

public class CatMashTests
{
    private ICatRepository _repository;
    private CatMash _catmash;

    [SetUp]
    public void Setup()
    {
        _repository = Substitute.For<ICatRepository>();
        _catmash = new CatMash(_repository);
    }

    [Test]
    public async Task Should_Vote_A_Cat_By_His_Id()
    {
        ICat cat = Substitute.For<ICat>();
        Guid id = Guid.NewGuid();
        _repository.Get(id).Returns(cat);

        await _catmash.Vote(id);

        cat.Received(1).EarnAVote();
        await _repository.Received(1).Update(cat);
    }
}