using System.Collections.Generic;
using System.Linq;
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

    public Color GetColor(float maxCliqueSize)
    {
        var globalValidatorVersion = this.SenderName.Split('.').First();
        var versionNum = int.Parse(globalValidatorVersion.Substring(1));
        var opacity = 0.1f + (0.9f / maxCliqueSize) * this.CliqueSize;
        
        if (versionNum % 3 == 0)
        {
            return new Color(229.0f / 255.0f, 152.0f / 255.0f, 102.0f / 255.0f, opacity);
        } else if (versionNum % 3 == 1)
        {
            return new Color(125.0f / 255.0f, 206.0f / 255.0f, 160.0f / 255.0f, opacity);
        }
        else
        {
            return new Color(133.0f/255.0f, 193.0f/255.0f, 233.0f/255.0f, opacity);
        }
        
    }
}
