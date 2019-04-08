using UnityEngine;

public class EdgeModel
{
    /// <summary>
    /// Message sender hash
    /// </summary>
    public MessageModel SrcMsg { get; private set; }

    /// <summary>
    /// Message receiver hash
    /// </summary>
    public MessageModel DstMsg{ get; private set; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="srcMsg">Message sender hash</param>
    /// <param name="dstMsg">Message receiver hash</param>
    public EdgeModel(MessageModel srcMsg, MessageModel dstMsg)
    {
        this.SrcMsg = srcMsg;

        this.DstMsg = dstMsg;
    }
}