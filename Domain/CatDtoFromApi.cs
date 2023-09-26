using Newtonsoft.Json;

namespace Domain;

public class CatDtoFromApi
{
    public string Id { get; set; }
    [JsonProperty("url")]
    public string ImageUrl { get; set; }
}

public class CatDtos
{
    [JsonProperty("Images")]
    public List<CatDtoFromApi> dtos { get; set; }
}