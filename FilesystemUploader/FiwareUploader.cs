using System.Globalization;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using FilesystemUploader.Models;
using FilesystemUploader.Models.Generic;

namespace FilesystemUploader;

//This class performs various requests to the /entity endpoints in FIWARE
public class FiwareUploader
{
    private const string RiverFlowrateApi =
        "https://hubeau.eaufrance.fr/api/v1/hydrometrie/observations_tr.csv?grandeur_hydro=Q";

    private const string EntitiesEndpoint = "v2/entities/";
    private readonly string _endpoint;
    private readonly string _authEndpoint;
    private readonly string _authToken;
    private AuthResponse _authResponse;
    
    private string _username;
    private string _password;
    
    private static SemaphoreSlim AccessTokenSemaphore;
    private static readonly HttpClient Client = new HttpClient();


    public FiwareUploader(string endpoint, string authToken="Mjk3MWM3NTMtODJhZS00YjVlLTkwN2YtOTdjNThlZGMyMzUxOjIzOWE5YjFmLTJkMzUtNDk1ZC1hNDQ4LWIwNmFkZjFjNTg5Yw==", string username = "siaap@dwc.fr",
        string password = "siaap")
    {
        _endpoint = endpoint;
        _authEndpoint = "https://k-rock.xyz/oauth2/token";
        _authToken = authToken;
        _username = username;
        _password = password;
        AccessTokenSemaphore = new SemaphoreSlim(1, 1);
    }

    public async Task<WolfgangWaterObserved?> PerformGet(string requestId)
    {
        var accessToken = await GetAccessToken();
        Client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.AccessToken);
        var retval = await Client.GetAsync(_endpoint  + EntitiesEndpoint + requestId);
        retval.EnsureSuccessStatusCode();
        await using var responseContentStream = await retval.Content.ReadAsStreamAsync();
        return await JsonSerializer.DeserializeAsync<WolfgangWaterObserved>(responseContentStream);
    }

    public async Task PerformPatch(WaterObservedEden entity)
    {
        var accessToken = await GetAccessToken();
        var request = new HttpRequestMessage(HttpMethod.Patch, $"{_endpoint + EntitiesEndpoint + entity.id}/attrs");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.AccessToken);

        WaterObservedPatchRequest patchRequest = new WaterObservedPatchRequest
        {
            dateObserved = entity.dateObserved,
            flow = entity.flow
        };
        var jeiiiison = JsonSerializer.Serialize(patchRequest);
        Console.WriteLine(jeiiiison);
        request.Content = new StringContent(jeiiiison, Encoding.UTF8, "application/json");
        request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        using var response = await Client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
        response.EnsureSuccessStatusCode();
        await using var responseContentStream = await response.Content.ReadAsStreamAsync();
        
        var validation = await PerformGet(entity.id);
        if (Math.Abs(validation!.flow.value - entity.flow.value) < 0.01)
        {
            Console.WriteLine($"Successfull patch for entity with id: {entity.id}");
        }
        else
        {
            Console.WriteLine($"COULD NOT PATCH ENTITY: {entity} successfully");
        }
    }
    

    public async Task<AuthResponse> GetAccessToken()
    {
        if (_authResponse is { Expired: false })
        {
            return _authResponse;
        }

        _authResponse = await AuthenticateWithRemote();
        return _authResponse;
    }

    public async Task<AuthResponse> AuthenticateWithRemote()
    {
        try
        {
            await AccessTokenSemaphore.WaitAsync();
            var request = new HttpRequestMessage(HttpMethod.Post, _authEndpoint)
            {
                Content = new FormUrlEncodedContent(new KeyValuePair<string?, string?>[]
                {
                    new("username", $"{_username}"),
                    new("password", _password),
                    new("grant_type", "password")
                
                })
            };
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", _authToken);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            
        
            using var response = await Client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            await using var responseContentStream = await response.Content.ReadAsStreamAsync();
            StreamReader reader = new StreamReader(responseContentStream);
            var help = await reader.ReadToEndAsync();
            
            //For some reason this does not work!
            //var authenticationResponse = await JsonSerializer.DeserializeAsync<AuthResponse>(responseContentStream);
            JsonObject? jsonObject = JsonSerializer.Deserialize<JsonObject>(help);
            AuthResponse authenticationResponse = new AuthResponse
            {
                AccessToken = (string)jsonObject["access_token"]!,
                TokenType = (string)jsonObject["token_type"]!,
                ExpiresIn = (int)jsonObject["expires_in"]!,
                RefreshToken = (string)jsonObject["refresh_token"]!
            };

            return authenticationResponse ??
                   throw new Exception("Failed to deserialize authentication data from the Fiware instance");
        }
        finally
        {
            AccessTokenSemaphore.Release(1);
        }
    }
}