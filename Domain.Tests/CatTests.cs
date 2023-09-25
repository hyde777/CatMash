using NSubstitute;

namespace Domain.Tests;

public class CatTests
{
    private ICatRepository _repository;

    [SetUp]
    public void Setup()
    {
        _repository = Substitute.For<ICatRepository>();
    }

    [Test]
    public async Task Should_Update_His_Current_Vote_When_He_Earn_A_Vote()
    {
        Guid id = Guid.NewGuid();
        uint currentVoteCount = 3;
        Cat cat = new Cat(_repository, id, currentVoteCount);

        await cat.EarnAVote();

        var updateVoteCount = currentVoteCount + 1;
        await _repository.Received(1).Update(id, updateVoteCount);
    }
}