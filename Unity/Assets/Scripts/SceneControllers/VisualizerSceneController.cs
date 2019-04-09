using System.Collections.Generic;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.UI;
using Utilities;
using Path = System.IO.Path;
using Models;

public class VisualizerSceneController : MonoBehaviour
{
    /// <summary>
    /// YAMLファイルのロード元パス
    /// </summary>
    private static readonly string YamlLoadPath = Path.Combine(Application.streamingAssetsPath, "output.yml");

    /// <summary>
    /// Simulation (Dictionary key is slot no)
    /// </summary>
    public SimulationModel SimulationModel { get; private set; }

    /// <summary>
    /// YAMLファイルをロードするためのボタン
    /// </summary>
    [SerializeField] private Button loadButton;

    /// <summary>
    /// ValidatorViewを配置するルートTransform
    /// </summary>
    [SerializeField] private Transform validatorViewsTransform;

    /// <summary>
    /// Click Event Function
    /// </summary>
    public void OnClickLoadButton()
    {
        this.SimulationModel = YamlDataLoader.LoadAllMessageModelsFromYamlFile(YamlLoadPath);
        
        this.SimulationModel.SetAttrsByValidator();

        var validatorViewPrefabController = ValidatorViewPrefabController.InstantiatePrefab(MessageModels, EdgeBySlot);

        validatorViewPrefabController.transform.SetParent(validatorViewsTransform, false);
    }
}
