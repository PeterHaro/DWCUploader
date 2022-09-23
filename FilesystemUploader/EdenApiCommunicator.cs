using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace FilesystemUploader;

public class EdenApiCommunicator
{
    private string[] stations = new[]
        { "F700000103", "F490000104", "F700000103", "F664000404", "F664000104", "F447000302" };

    private static readonly HttpClient Client = new HttpClient();

    public async Task FetchStationData()
    {
        var currentDate = DateTime.UtcNow.ToString("yyyy-MM-dd");
        foreach (var station in stations)
        {
            var currentRequest =
                $"https://hubeau.eaufrance.fr/api/v1/hydrometrie/observations_tr?code_entite={station}&date_debut_obs={currentDate}&date_fin_obs={currentDate}&grandeur_hydro=Q&size=20";
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await Client.GetAsync(currentRequest);
            response.EnsureSuccessStatusCode();
            await using var responseContentStream = await response.Content.ReadAsStreamAsync();
            JsonObject? jsonObject = JsonSerializer.Deserialize<JsonObject>(responseContentStream);
            
            //PATCH/POST/WHATEVER TO WOLFYBOIIIIIIIIIIIIIIIIIIIIIIIII
            
            
        }
    }
}