using Domain;

namespace Infrastructure;

internal class CatEntity
{
    public ICat MapToCat(Guid argKey)
    {
        throw new NotImplementedException();
    }

    public uint CountVote { get; set; }
    public string ImageUrl { get; set; }
    public string ExternalId { get; set; }
}