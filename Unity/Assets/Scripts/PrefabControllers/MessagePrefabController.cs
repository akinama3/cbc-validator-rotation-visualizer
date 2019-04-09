using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessagePrefabController : MonoBehaviour
{
    /// <summary>
    /// Prefab Path
    /// </summary>
    private const string PrefabPath = "Prefabs/MessageView";

    /// <summary>
    /// Blank Prefab Path
    /// </summary>
    private const string BlankPrefabPath = "Prefabs/MessageViewBlank";
    
    /// <summary>
    /// MessageModel
    /// </summary>
    public MessageModel MessageModel { get; private set; }

    /// <summary>
    /// Message Hash Text
    /// </summary>
    [SerializeField] private TextMeshProUGUI messageHashText;

    /// <summary>
    /// 初期化処理を実行する
    /// </summary>
    public static MessagePrefabController InstantiatePrefab(MessageModel messageModel, float maxCliqueSize)
    {
        var gameObject = Instantiate(Resources.Load<GameObject>(PrefabPath));
        var color = gameObject.GetComponent<Image>().color;
        var messagePrefabController = gameObject.GetComponent<MessagePrefabController>();
        
        messagePrefabController.Initialize(messageModel);
        var messageCliqueSize = messageModel.CliqueSize;
        var opacity = 0.1f + (0.9f / maxCliqueSize) * messageCliqueSize;
        gameObject.GetComponent<Image>().color = new Color(color.r, color.g, color.b, opacity);

        return messagePrefabController;
    }
    
    /// <summary>
    /// 初期化処理を実行する(BlankView)
    /// </summary>
    public static MessagePrefabController InstantiatePrefabBlank()
    {
        var gameObject = Instantiate(Resources.Load<GameObject>(BlankPrefabPath));

        var messagePrefabController = gameObject.GetComponent<MessagePrefabController>();

        return messagePrefabController;
    }

    /// <summary>
    /// 初期化処理を実行する
    /// </summary>
    private void Initialize(MessageModel messageModel)
    {
        this.MessageModel = messageModel;
        this.messageHashText.SetText(messageModel.Hash);
    }
    
}
