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
    public MessageModel Estimate { get; set; }

    public ValidatorModel Sender;
    public string ParentHash { get; set; }
    public int ReceiverSlot { get; set; }
    public int SenderSlot { get; set; }
    public List<MessageModel> Justification { get; set; }
    
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="hash">The message hash of this message</param>
    public MessageModel(string hash, ValidatorModel sender, string parentHash, int receiverSlot, int senderSlot, MessageModel estimate, List<MessageModel> messages)
    {
        this.Hash = hash;
        this.Estimate = estimate;
        this.Sender = sender;
        this.ParentHash = parentHash;
        this.ReceiverSlot = receiverSlot;
        this.SenderSlot = senderSlot;
        this.Justification = messages;
    }
}

// YAML
/*
 *       - estimate:
          hash: 92689018377936
          parent_hash: null
        hash: 24381726710723
        justification: []
        parent_hash: null
        receiver_slot: 0
        sender: v1
        sender_slot: 0
*/