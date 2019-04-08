using UnityEngine;
using UnityEngine.UI;

public class YamlDataLoader : MonoBehaviour
{
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
        Debug.Log("Clicked Load Button");
    }
}