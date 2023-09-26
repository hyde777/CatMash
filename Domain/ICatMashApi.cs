namespace Domain;

public interface ICatMashApi
{
    Task<List<CatDtoFromApi>> GetAll();
}