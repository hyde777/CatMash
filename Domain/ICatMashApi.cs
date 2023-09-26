namespace Domain;

public interface ICatMashApi
{
    Task<List<CatDto>> GetAll();
}