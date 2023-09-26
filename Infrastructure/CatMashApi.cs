using System.Text.Json;
using Domain;
using Newtonsoft.Json;

namespace Infrastructure;

public class CatMashApi : ICatMashApi
{
    private readonly HttpClient _client;

    public CatMashApi(HttpClient client)
    {
        _client = client;
    }
    
    public async Task<List<CatDtoFromApi>> GetAll()
    {
        var getAll = "https://latelier.co/data/cats.json";
        HttpResponseMessage httpResponseMessage = await _client.GetAsync(getAll);
        var readAsStreamAsync = await httpResponseMessage.Content.ReadAsStringAsync();
        var catDtoFromApis = JsonConvert.DeserializeObject<CatDtos>(readAsStreamAsync);
        return catDtoFromApis.dtos;
    }
}