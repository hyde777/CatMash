namespace Domain;

public interface ICatRepository
{
    Task<ICat> Get(Guid id);
    Task Update(Guid id, uint currentVote);
    Task<List<ICat>> GetRandom(int count);
    Task Import(List<CatDtoFromApi> catDtos);
    Task<List<ICat>> GetAll();
}