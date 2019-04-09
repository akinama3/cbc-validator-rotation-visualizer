using System.Collections;
using System.Diagnostics;
using SimpleHTTP;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class HttpDataLoader
{
    private static string BaseURL = "http://localhost:3033";
    
    public HttpDataLoader()
    {
        
    }

    public static IEnumerator LoadSimulationViaHTTP()
    {
        var client = new Client();
        var payload = new Payload(null);
        var req = new Request(BaseURL + "/simulator").Post(RequestBody.From<Payload>(payload));
        yield return client.Send(req);

        if (client.IsSuccessful())
        {
            Response resp = client.Response ();
            SimulationResult result = JsonUtility.FromJson<SimulationResult>(resp.Body());
            Debug.Log("0-----------------");
            Debug.Log(result.output);
            Debug.Log("0-----------------");

            yield return result.output;
        }
        else
        {
            Debug.Log("failed to get simulation result");
        }
    }
}

[System.Serializable]
public class Payload
{
    private string input;

    public Payload(string input)
    {
        this.input = input;
    }
}

[System.Serializable]
public class SimulationResult
{
    public string output;
    public string status;
}