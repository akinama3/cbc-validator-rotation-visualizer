using System.Collections.Generic;
using System.Linq;
using TMPro;
using UniRx.Async;
using UnityEngine;

public class ValidatorViewPrefabController : MonoBehaviour
{
    /// <summary>
    /// Prefab Path
    /// </summary>
    private const string PrefabPath = "Prefabs/ValidatorView";

    /// <summary>
    /// Prefab Path
    /// </summary>
    private const string VerticalLayoutPrefabPath = "Prefabs/ValidatorVerticalLayoutGroup";

    /// <summary>
    /// MessageModels (Dictionary key is slot no)
    /// </summary>
    public Dictionary<int, List<MessageModel>> MessageModels { get; private set; }

    /// <summary>
    /// EdgeModels (Dictionary key is slot no)
    /// </summary>
    public Dictionary<int, List<EdgeModel>> EdgeBySlot { get; private set; }

    /// <summary>
    /// Current Slot
    /// </summary>
    private int currentSlot;

    /// <summary>
    /// HorizontalLayoutGroupTransform
    /// </summary>
    [SerializeField] private Transform horizontalLayoutGroupTransform;

    /// <summary>
    /// VerticalLayoutGroups
    /// </summary>
    [SerializeField] private List<GameObject> verticalLayoutGroups;

    /// <summary>
    /// Message Prefab Controllers
    /// </summary>
    [SerializeField] private List<MessagePrefabController> messagePrefabControllers;
    
    /// <summary>
    /// Edge Prefab Controllers
    /// </summary>
    [SerializeField] private List<EdgePrefabController> edgePrefabControllers;
    
    /// <summary>
    /// Validator Name
    /// </summary>
    [SerializeField] private TextMeshProUGUI validatorName;
    
    /// <summary>
    /// Message fork count
    /// </summary>
    private Dictionary<string, int> messageForkCounts = new Dictionary<string, int>();
    
    /// <summary>
    /// Validator ViewのInstantiate
    /// </summary>
    public static ValidatorViewPrefabController InstantiatePrefab(string validatorName, int slot, Dictionary<int, List<MessageModel>> messageModels, Dictionary<int, List<EdgeModel>> edgeBySlot)
    {
        var gameObject = Instantiate(Resources.Load<GameObject>(PrefabPath));

        var validatorViewPrefabController = gameObject.GetComponent<ValidatorViewPrefabController>();

        validatorViewPrefabController.Initialize(validatorName, slot, messageModels, edgeBySlot);

        return validatorViewPrefabController;
    }

    /// <summary>
    /// 初期化処理を行う
    /// </summary>
    private void Initialize(string validatorName, int slot, Dictionary<int, List<MessageModel>> messageModels, Dictionary<int, List<EdgeModel>> edgeBySlot)
    {
        this.validatorName.SetText(validatorName);

        currentSlot = slot;
        
        MessageModels = messageModels;
        
        EdgeBySlot = edgeBySlot;

        UpdateBySlot(slot).Forget();
    }

    /// <summary>
    /// 特定スロットの状態にViewをアップデートする
    /// </summary>
    public async UniTaskVoid UpdateBySlot(int slot)
    {
        messageForkCounts.Clear();
        
        foreach (var verticalLayoutGroup in verticalLayoutGroups)
        {
            Destroy(verticalLayoutGroup);
        }
        
        verticalLayoutGroups.Clear();
       
        foreach (var edgePrefabController in edgePrefabControllers)
        {
            Destroy(edgePrefabController.gameObject);
        }
        
        edgePrefabControllers.Clear();
 
        foreach (var messagePrefabController in messagePrefabControllers)
        {
            Destroy(messagePrefabController.gameObject);
        }
        
        messagePrefabControllers.Clear();
       
        foreach (var messageModel in MessageModels[slot])
        {
            var verticalLayoutGroupGameObject = Instantiate(Resources.Load<GameObject>(VerticalLayoutPrefabPath));
            
            verticalLayoutGroupGameObject.transform.SetParent(horizontalLayoutGroupTransform, false);
            
            verticalLayoutGroups.Add(verticalLayoutGroupGameObject);

            if (messageForkCounts.ContainsKey(messageModel.Hash))
            {
                messageForkCounts[messageModel.Hash]++;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(messageModel.ParentHash))
                {
                    messageForkCounts[messageModel.Hash] = 0;
                }
                else
                {
                    messageForkCounts[messageModel.Hash] = messageForkCounts[messageModel.ParentHash];

                    messageForkCounts[messageModel.ParentHash]++;
                }
            }

            for (int index = 0; index < messageForkCounts[messageModel.Hash]; index++)
            {
                var messagePrefabControllerBlank = MessagePrefabController.InstantiatePrefabBlank();
                
                messagePrefabControllerBlank.transform.SetParent(verticalLayoutGroupGameObject.transform, false);
                
                messagePrefabControllers.Add(messagePrefabControllerBlank);
            }

            var messagePrefabController = MessagePrefabController.InstantiatePrefab(messageModel);
            
            messagePrefabControllers.Add(messagePrefabController);
            
            messagePrefabController.transform.SetParent(verticalLayoutGroupGameObject.transform, false);
        }

        messagePrefabControllers = messagePrefabControllers.Where(prefabController => prefabController.MessageModel != null).ToList();
        
        foreach (var edgeModel in EdgeBySlot[slot])
        {
            foreach (var messagePrefabController in messagePrefabControllers.Where(prefabController => prefabController.MessageModel.Hash == edgeModel.SrcMsg.Hash))
            {
                if (edgeModel.DstMsg == null)
                {
                    continue;
                }
                
                var destinationMessagePrefabController = messagePrefabControllers.FirstOrDefault(prefabController => prefabController.MessageModel.Hash == edgeModel.DstMsg.Hash);

                if (destinationMessagePrefabController == null)
                {
                    continue;
                }

                var edgePrefabController = await EdgePrefabController.InstantiatePrefabAsync(messagePrefabController, destinationMessagePrefabController);
                
                edgePrefabControllers.Add(edgePrefabController);
            }
        }
    }
}