public class CatFactsService : ApiServiceBase<CatFactResponse>
{
    protected override string _apiUrl => "https://catfact.ninja/fact";
    protected override string _mediaType => "application/json";

    protected override void ConfigureClient(HttpClient client)
    {
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Add("Accept", _mediaType);
    }

    protected override string ExtractContent(CatFactResponse response)
    {
        return response.Fact ?? "No fact found.";
    }
}

public class CatFactResponse
{
    public string? Fact { get; set; }
    public int Length { get; set; }
}
