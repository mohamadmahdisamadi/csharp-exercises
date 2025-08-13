public abstract class ApiServiceBase<TResponse> : IApiService where TResponse : class
{
    protected static readonly HttpClient _httpClient = new HttpClient();
    protected abstract string _apiUrl { get; }
    protected abstract string _mediaType { get; }

    public async Task<string?> GetContentAsync(string input)
    {
        ConfigureClient(_httpClient);

        string apiUrl = _apiUrl + input;
        try
        {
            var response = await _httpClient.GetFromJsonAsync<TResponse>(apiUrl);
            return ExtractContent(response!);
        }
        catch (Exception ex)
        {
            WriteLine($"Error fetching data from {apiUrl}: {ex.Message}");
            return null;
        }
    }

    protected abstract string ExtractContent(TResponse response);
    protected abstract void ConfigureClient(HttpClient client);
    protected virtual async Task<string> GetResponse(string input = "")
    {
                // protected override async Task<string> GetResponse(string input = "")
        return await this.GetContentAsync(this._apiUrl) ?? "No response";
    }
}