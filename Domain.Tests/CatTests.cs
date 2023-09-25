using Infrastructure;
using NSubstitute;

namespace Domain.Tests;

public class CatTests
{
    [Test]
    public async Task RenameMe()
    {
        Guid id = Guid.NewGuid();
        uint currentVote = 3;
        ICatRepository repository = Substitute.For<ICatRepository>();
        Cat cat = new Cat(repository, id, currentVote);

        await cat.EarnAVote();

        await repository.Received(1).Update(id, currentVote + 1);
    }
}