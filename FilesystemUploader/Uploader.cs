using System.Net.Http.Headers;
using System.Text;

namespace FilesystemUploader;

public class Uploader
{
    private const string RiverFlowrateApi =
        "https://hubeau.eaufrance.fr/api/v1/hydrometrie/observations_tr.csv?grandeur_hydro=Q";
    private readonly string _endpoint;
    private readonly string _authToken;
    
    private static readonly HttpClient Client = new HttpClient();

    public Uploader(string endpoint, string authToken)
    {
        _endpoint = endpoint;
        _authToken = authToken;
    }

    public async Task PerformGetRequest(string requestId)
    {
        // just to validate that we can connect
        Client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        Client.DefaultRequestHeaders.Add("X-Auth-Token", _authToken);
        
        var retval = await Client.GetAsync(_endpoint + requestId);
        Console.WriteLine(retval);
    }

    public async Task FetchHydrometryDataFromEden(List<string> extraProperties)
    {
        HttpResponseMessage retval;
        if (!extraProperties.Any())
        {
            retval = await Client.GetAsync(RiverFlowrateApi);
        }
        else
        {
            var query = RiverFlowrateApi;
            foreach (var prop in extraProperties)
            {
                query += "&" + prop;
            }

            retval = await Client.GetAsync(query);
        }
        
        
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