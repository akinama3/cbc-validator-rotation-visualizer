using UnityEngine;

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
    /// 初期化処理を実行する
    /// </summary>
    public static MessagePrefabController InstantiatePrefab(MessageModel messageModel)
    {
        var gameObject = Instantiate(Resources.Load<GameObject>(PrefabPath));

        var messagePrefabController = gameObject.GetComponent<MessagePrefabController>();
        
        messagePrefabController.Initialize(messageModel);

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
    }
}
