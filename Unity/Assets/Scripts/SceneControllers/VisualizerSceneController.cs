using System.Collections.Generic;
using System.IO;
using Models;
using UnityEngine;
using UnityEngine.UI;

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
    public Dictionary<int, List<MessageModel>> EdgeModels { get; private set; }
    
    /// <summary>
    /// Slots (Dictionary key is slot no)
    /// </summary>
    public Dictionary<int, Dictionary<string, ValidatorModel>> Slots { get; set; }

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
        this.Slots = YamlDataLoader.LoadAllMessageModelsFromYamlFile(YamlLoadPath);
    }
}