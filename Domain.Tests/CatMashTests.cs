using FluentAssertions;
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

        await cat.Received(1).EarnAVote();
    }

    [Test]
    public async Task GiveAChoice()
    {
        var cat1 = Substitute.For<ICat>();
        var cat2 = Substitute.For<ICat>();
        _repository.GetRandom(2).Returns(new List<ICat>
        {
            cat1,
            cat2
        });
        
        (ICat, ICat) mash = await _catmash.Mash();

        mash.Should().Be((cat1, cat2));
    }
}