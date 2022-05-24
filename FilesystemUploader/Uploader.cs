using System.Net.Http.Headers;
using System.Text;

namespace FilesystemUploader;

public class Uploader
{
    private readonly string _endpoint;
    private readonly string _authToken;
    
    private static readonly HttpClient Client = new HttpClient();

    public Uploader(string endpoint, string authToken)
    {
        _endpoint = endpoint;
        _authToken = authToken;
    }

    public async Task PerformGetRequest()
    {
        // just to validate that we can connect
        Client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        Client.DefaultRequestHeaders.Add("X-Auth-Token", _authToken);
        
        var retval = await Client.GetAsync(_endpoint + "1024e64a-0283-472c-9b62-dbf77291503e");
        Console.WriteLine(retval);
    }


    public async Task PerformPostRequest(string data)
    {
        // Assume we are receiving a JSON serialized string
        Client.DefaultRequestHeaders.Clear();
        Client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        Client.DefaultRequestHeaders.Add("X-Auth-Token", _authToken);
        
        var requestContent = new StringContent(data, Encoding.UTF8, "application/json");
        var response = await Client.PostAsync(_endpoint, requestContent);
        //response.EnsureSuccessStatusCode();
        
        var content = await response.Content.ReadAsStringAsync();
        Console.WriteLine(content);
        //var createdCompany = JsonSerializer.Deserialize<CompanyDto>(content, _options);
    }

    public void PerformPatchRequest()
    {
        
    }
}