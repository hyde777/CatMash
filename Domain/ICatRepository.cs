namespace Domain;

public interface ICatRepository
{
    Task<ICat> Get(Guid id);
    Task Update(Guid id, uint currentVote);
}