using Domain;

namespace Infrastructure;

public class Cat : ICat
{
    public Cat(ICatRepository repository, Guid id, uint currentVote)
    {
        throw new NotImplementedException();
    }

    public void EarnAVote()
    {
        throw new NotImplementedException();
    }
}