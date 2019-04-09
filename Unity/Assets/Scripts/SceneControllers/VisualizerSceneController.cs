using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Path = System.IO.Path;

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
    /// Slot Slider
    /// </summary>
    [SerializeField] private Slider slotSlider;

    /// <summary>
    /// Validator View Prefab Controllers
    /// </summary>
    [SerializeField] private List<ValidatorViewPrefabController> validatorViewPrefabControllers;

    /// <summary>
    /// Click Event Function
    /// </summary>
    public void OnClickLoadButton()
    {
        SimulationModel = YamlDataLoader.LoadAllMessageModelsFromYamlFile(YamlLoadPath);

        SimulationModel.SetAttrsByValidator();

        slotSlider.minValue = SimulationModel.Slots.First()
            .Key;
        slotSlider.maxValue = SimulationModel.Slots.Last()
            .Key;
        slotSlider.wholeNumbers = true;

        foreach (var validatorName in SimulationModel.AllValidatorNames)
        {
            var validatorViewPrefabController = ValidatorViewPrefabController.InstantiatePrefab(validatorName.Key, SimulationModel.Slots.First()
                .Key, SimulationModel.MessageByValidator[validatorName.Key], SimulationModel.EdgeByValidator[validatorName.Key]);

            validatorViewPrefabControllers.Add(validatorViewPrefabController);

            validatorViewPrefabController.transform.SetParent(validatorViewsTransform, false);
        }
    }

    /// <summary>
    /// Slot Slider Event
    /// </summary>
    public void OnChangedSlotSlider()
    {
        foreach (var validatorViewPrefabController in validatorViewPrefabControllers)
        {
            validatorViewPrefabController.UpdateBySlot((int)slotSlider.value);
        }
    }

    private static IEnumerator FetchDataViaHTTP()
    {
        Debug.Log("-----xxx");
        yield return HttpDataLoader.LoadSimulationViaHTTP();
        Debug.Log("-----xxytx");
    }
}