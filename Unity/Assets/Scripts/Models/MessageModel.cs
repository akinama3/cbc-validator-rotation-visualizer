using UnityEngine;

public class MessageModel
{
    /// <summary>
    /// The Hash of this message 
    /// </summary>
    public string Hash { get; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="hash">The message hash of this message</param>
    public MessageModel(string hash)
    {
        this.Hash = hash;
    }
}