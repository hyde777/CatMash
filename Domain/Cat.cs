namespace Domain;

public class Cat : ICat
{
    private readonly ICatRepository _repository;
    
    private readonly Guid _id;
    private uint _currentVote;
    private string _imageUrl;

    public Cat(ICatRepository repository, Guid id, uint currentVote, string imageUrl)
    {
        _repository = repository;
        _id = id;
        _currentVote = currentVote;
        _imageUrl = imageUrl;
    }

    public async Task EarnAVote()
    {
        _currentVote++;
        await  _repository.Update(_id, _currentVote);
    }

    public CatDto ToDto()
    {
        return new CatDto
        {
            Image = _imageUrl,
            Votes = _currentVote,
            Id = _id
        };
    }
}