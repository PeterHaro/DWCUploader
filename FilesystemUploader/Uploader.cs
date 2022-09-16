using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using FilesystemUploader.Models.Generic;

namespace FilesystemUploader;

//TODO: ADD REFRESH TOKEN OSV OG GJØR SKIKKLIG INPUT OUTPUT AV PASSORD OSV
public class Uploader
{
    private const string RiverFlowrateApi =
        "https://hubeau.eaufrance.fr/api/v1/hydrometrie/observations_tr.csv?grandeur_hydro=Q";

    private readonly string _endpoint;
    private readonly string _authEndpoint;
    private readonly string _authToken;
    private bool _isAuthenticated = false;
    private string _username;
    private string _password;

    private static readonly HttpClient Client = new HttpClient();

    public Uploader(string endpoint, string authToken, string username = "siaap@dwc.fr", string password = "siaap")
    {
        _endpoint = endpoint;
        _authEndpoint = "https://k-rock.xyz/oauth2/token";
        _authToken = authToken;
        _username = username;
        _password = password;
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

    public async Task AuthenticateWithRemote()
    {
        Client.DefaultRequestHeaders.Clear();
        Client.DefaultRequestHeaders.Add("Accept", "application/json");
        Client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Basic Mjk3MWM3NTMtODJhZS00YjVlLTkwN2YtOTdjNThlZGMyMzUxOjIzOWE5YjFmLTJkMzUtNDk1ZC1hNDQ4LWIwNmFkZjFjNTg5Yw==");
       // Client.DefaultRequestHeaders.Add("Content-Type", "application/x-www-form-urlencoded");
        var requestString = $"username: {_username}, password: {_password}, grant_type: password";
        AuthData authData = new AuthData();
        authData.username = _username;
        authData.password = _password;
        authData.grant_type = "password";
        var req = JsonSerializer.Serialize(authData);
        var requestContent = new StringContent(req, Encoding.UTF8, "application/x-www-form-urlencoded");
        var response = await Client.PostAsync(_authEndpoint, requestContent);
        var content = await response.Content.ReadAsStringAsync();
        Console.WriteLine(content);
    }

    public async Task UploadDataToFiware()
    {
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

    public async Task PerformPatchRequest(string data)
    {
        Client.DefaultRequestHeaders.Clear();
        Client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        Client.DefaultRequestHeaders.Add("X-Auth-Token", _authToken);

        var requestContent = new StringContent(data, Encoding.UTF8, "application/json");
        var response = await Client.PatchAsync(_endpoint, requestContent);

        var content = await response.Content.ReadAsStringAsync();
        Console.WriteLine(content);
    }
}