using System.Collections.Generic;
using UniRx.Async;
using Unity.VectorGraphics;
using UnityEngine;

public class EdgePrefabController : MonoBehaviour
{
    /// <summary>
    /// Prefab Path
    /// </summary>
    private const string PrefabPath = "Prefabs/EdgeView";
 
    /// <summary>
    /// 起点のMessagePrefabController
    /// </summary>
    public MessagePrefabController SourceMessagePrefabController { get; private set; }

    /// <summary>
    /// 終点のMessagePrefabController
    /// </summary>
    public MessagePrefabController DestinationMessagePrefabController { get; private set; }

    /// <summary>
    /// VectorGraphics描画のためのSceneオブジェクト
    /// </summary>
    public Scene Scene;

    /// <summary>
    /// BezierPathSegments
    /// </summary>
    public BezierPathSegment[] BezierPathSegments;

    /// <summary>
    /// BezierPathSegments
    /// </summary>
    public Path VectorGraphicsPath;

    /// <summary>
    /// 初期化処理を実行する
    /// </summary>
    public static async UniTask<EdgePrefabController> InstantiatePrefabAsync(MessagePrefabController sourceMessagePrefabController, MessagePrefabController destinationMessagePrefabController)
    {
        var gameObject = Instantiate(Resources.Load<GameObject>(PrefabPath));

        var edgePrefabController = gameObject.GetComponent<EdgePrefabController>();
        
        await edgePrefabController.InitializeAysnc(sourceMessagePrefabController, destinationMessagePrefabController);

        return edgePrefabController;
    }
 
    /// <summary>
    /// 初期化処理を実行する
    /// </summary>
    public async UniTaskVoid InitializeAysnc(MessagePrefabController sourceMessagePrefabController, MessagePrefabController destinationMessagePrefabController)
    {
        await UniTask.DelayFrame(20);
        
        SourceMessagePrefabController = sourceMessagePrefabController;

        DestinationMessagePrefabController = destinationMessagePrefabController;
        
        var lineRenderer = GetComponent<LineRenderer>();

        var sourcePosition = Camera.main.WorldToViewportPoint(SourceMessagePrefabController.GetComponent<RectTransform>().position);
        
        var destinationPosition = Camera.main.WorldToViewportPoint(DestinationMessagePrefabController.GetComponent<RectTransform>().position);

        var difference = new Vector2(
            (destinationPosition.x - sourcePosition.x) * 1920,
            (destinationPosition.y - sourcePosition.y) * 1080);
        
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, Vector2.zero);
        lineRenderer.SetPosition(1, difference);

        lineRenderer.startWidth = 0.03f;
        lineRenderer.endWidth = 0.03f;
        
        transform.SetParent(SourceMessagePrefabController.transform, false);
    }
}