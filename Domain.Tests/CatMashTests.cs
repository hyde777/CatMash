using FluentAssertions;
using NSubstitute;
using NSubstitute.ReceivedExtensions;

namespace Domain.Tests;

public class CatMashTests
{
    private ICatRepository _repository;
    private CatMash _catmash;
    private ICatMashApi _api;

    [SetUp]
    public void Setup()
    {
        _api = Substitute.For<ICatMashApi>();
        _repository = Substitute.For<ICatRepository>();
        _catmash = new CatMash(_repository, _api);
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
    public async Task Should_Give_A_Cat_Mash()
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

    [Test]
    public async Task Should_Initialize_Datas()
    {
        string idFromApi = "azerty";
        string urlOfCat = "http://25.media.tumblr.com/tumblr_m2p6dxhxul1qdvz31o1_500.jpg";
        var catDtos = new List<CatDtoFromApi>
        {
            new CatDtoFromApi
            {
                Id = idFromApi,
                ImageUrl = urlOfCat
            }
        };
        _api.GetAll().Returns(catDtos);

        await _catmash.Initialise();

        await _repository.Received(1).Import(catDtos);
    }
}