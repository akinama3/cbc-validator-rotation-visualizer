using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class VisualizerSceneController : MonoBehaviour
{
    /// <summary>
    /// YAMLファイルのロード元パス
    /// </summary>
    private static readonly string YamlLoadPath = Path.Combine(Application.streamingAssetsPath, "output.yaml");
    
    /// <summary>
    /// MessageModels
    /// </summary>
    public List<MessageModel> MessageModels { get; private set; }
    
    /// <summary>
    /// EdgeModels
    /// </summary>
    public List<MessageModel> EdgeModels { get; private set; }

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
        YamlDataLoader.LoadAllMessageModelsFromYamlFile(YamlLoadPath);
    }
}