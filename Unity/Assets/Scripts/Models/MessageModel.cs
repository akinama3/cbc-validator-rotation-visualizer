using System.Collections.Generic;
using Models;
using UnityEngine;

public class MessageModel
{
    /// <summary>
    /// The Hash of this message 
    /// </summary>
    public string Hash { get; set; }
    // NOTE: this should be an instance of BlockModel or so?
    public EstimateModel Estimate { get; set; }

    public string SenderName;
    public string ParentHash { get; set; }
    public int ReceiverSlot { get; set; }
    public int SenderSlot { get; set; }
    
    // the size of Clique
    public float CliqueSize { get; set; }
    public List<MessageModel> Justification { get; set; }
    
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="hash">The message hash of this message</param>
    public MessageModel(string hash, string senderName, string parentHash, int receiverSlot, int senderSlot, EstimateModel estimate, List<MessageModel> JustificationMessages)
    {
        this.Hash = hash;
        this.Estimate = estimate;
        this.SenderName = senderName;
        this.ParentHash = parentHash;
        this.ReceiverSlot = receiverSlot;
        this.SenderSlot = senderSlot;
        this.Justification = JustificationMessages;
    }

    public MessageModel(string hash, string senderName)
    {
        this.Hash = hash;
        this.SenderName = senderName;
    }
}
