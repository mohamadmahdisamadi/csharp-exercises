public class CountryInfoService : ApiServiceBase<List<CountryInfoResponse>>
{
    protected override string _apiUrl => "https://restcountries.com/v3.1/name/";

    protected override string _mediaType => "application/json";

    protected override void ConfigureClient(HttpClient client)
    {
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Add("Accept", _mediaType);
    }

    protected override string ExtractContent(List<CountryInfoResponse> response)
    {
        CountryInfoResponse res = response[0];
        if (res is null)
        {
            return "No info found";
        }
        string outputMessage = $"The country is called {res.Name?.Common} in common and {res.Name?.Official} in official.{Environment.NewLine}";
        outputMessage += $"Official language(s) spoken in it: {string.Join(", ", res.Languages?.Values!)}.{Environment.NewLine}";
        outputMessage += $"Its capital is {string.Join(", ", res.Capital!)}.{Environment.NewLine}";
        outputMessage += $"It is placed on {res.Region} region and {res.Subregion} sub-region.{Environment.NewLine}";
        outputMessage += $"It has borders with {string.Join(", ", res.Borders!)}.";

        return outputMessage;
    }
}

public class CountryInfoResponse
{
    public Name? Name { get; set; }
    public List<string>? Capital { get; set; }
    public string? Region { get; set; }
    public string? Subregion { get; set; }
    public List<string?>? Borders { get; set; }
    public Dictionary<string, string>? Languages { get; set; }
}
public class Name
{
    public string? Common { get; set; }
    public string? Official { get; set; }
}
