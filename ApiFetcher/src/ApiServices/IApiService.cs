public interface IApiService
{
    Task<string?> GetContentAsync(string input = "");
}
