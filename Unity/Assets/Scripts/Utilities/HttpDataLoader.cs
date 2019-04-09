using System.Reflection;

public class HttpDataLoader
{
    public static string BaseURL = "http://localhost:3033";
    
    public HttpDataLoader()
    {
        
    }

    public static void LoadSimulationViaHTTP()
    {
        //var client = new
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
