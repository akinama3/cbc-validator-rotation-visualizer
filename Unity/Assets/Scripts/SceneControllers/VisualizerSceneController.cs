using System.Collections;
using System.Collections.Generic;
using System.IO;
using Models;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class VisualizerSceneController : MonoBehaviour
{
    /// <summary>
    /// YAMLファイルのロード元パス
    /// </summary>
    private static readonly string YamlLoadPath = Path.Combine(Application.streamingAssetsPath, "output.yml");
    
    /// <summary>
    /// MessageModels (Dictionary key is slot no)
    /// </summary>
    public Dictionary<int, List<MessageModel>> MessageModels { get; private set; }
    
    /// <summary>
    /// EdgeModels (Dictionary key is slot no)
    /// </summary>
    public Dictionary<int, Dictionary<string, List<EdgeModel>>> EdgeBySlot { get; private set; }
    public Dictionary<string, Dictionary<int, List<EdgeModel>>> EdgeByValidator { get; private set; }
    
    /// <summary>
    /// Simulation (Dictionary key is slot no)
    /// </summary>
    public SimulationModel SimulationModel { get; private set; }
    

    /// <summary>
    /// YAMLファイルをロードするためのボタン
    /// </summary>
    [SerializeField] private Button loadButton;

    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("Start");
    }

    public void OnClickLoadButton()
    {
        /*
        Debug.Log("-----xxx-------xxx");
        StartCoroutine(FetchDataViaHTTP());
        Debug.Log("-----xxytx--------llll");
        */
        this.SimulationModel = YamlDataLoader.LoadAllMessageModelsFromYamlFile(YamlLoadPath);
        this.SimulationModel.SetAttrsByValidator();
    }

    private static IEnumerator FetchDataViaHTTP()
    {
        Debug.Log("-----xxx");
        yield return HttpDataLoader.LoadSimulationViaHTTP();
        Debug.Log("-----xxytx");   
    }
}