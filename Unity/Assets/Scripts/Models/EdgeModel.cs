using UnityEngine;

public class EdgeModel : MonoBehaviour
{
    /// <summary>
    /// Message sender hash
    /// </summary>
    public MessageModel Sender { get; private set; }

    /// <summary>
    /// Message receiver hash
    /// </summary>
    public MessageModel Receiver { get; private set; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="sender">Message sender hash</param>
    /// <param name="receiver">Message receiver hash</param>
    public EdgeModel(MessageModel sender, MessageModel receiver)
    {
        this.Sender = sender;

        this.Receiver = receiver;
    }
}