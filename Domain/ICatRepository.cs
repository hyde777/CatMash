namespace Domain;

public interface ICatRepository
{
    Task<ICat> Get(Guid id);
    Task Update(Guid id, uint currentVote);
    Task<List<ICat>> GetRandom(int count);
}