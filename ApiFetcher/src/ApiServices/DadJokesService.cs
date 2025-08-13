public class DadJokesService : ApiServiceBase<DadJokeResponse>
{
    protected override string _apiUrl => "https://icanhazdadjoke.com/";
    protected override string _mediaType => "application/json";
    protected override void ConfigureClient(HttpClient client)
    {
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Add("Accept", _mediaType);
    }
    protected override string ExtractContent(DadJokeResponse response)
    {
        return response.Joke ?? "No joke found.";
    }
}

public class DadJokeResponse
{
    public string? Id { get; set; }
    public string? Joke { get; set; }
    public int Status { get; set; }
}