using Domain;

namespace Infrastructure;

internal class CatEntity
{
    public ICat MapToCat(ICatRepository repository, Guid argKey)
    {
        return new Cat(repository, argKey, CountVote, ImageUrl);
    }

    public uint CountVote { get; set; }
    public string ImageUrl { get; set; }
    public string ExternalId { get; set; }
}