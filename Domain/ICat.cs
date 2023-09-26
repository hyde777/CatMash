namespace Domain;

public interface ICat
{
    Task EarnAVote();
    CatDto ToDto();
}