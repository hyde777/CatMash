namespace Domain;

public class Cat : ICat
{
    private readonly ICatRepository _repository;
    private readonly Guid _id;
    private uint _currentVote;

    public Cat(ICatRepository repository, Guid id, uint currentVote)
    {
        _repository = repository;
        _id = id;
        _currentVote = currentVote;
    }

    public async Task EarnAVote()
    {
        _currentVote++;
        await  _repository.Update(_id, _currentVote);
    }
}