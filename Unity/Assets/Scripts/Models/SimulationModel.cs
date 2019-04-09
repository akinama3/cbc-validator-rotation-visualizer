using System.Collections.Generic;
using System.Threading;
using Models;
using UnityEngine;
using UnityEngine.Rendering;

public class SimulationModel
{
    public Dictionary<int, Dictionary<string, ValidatorModel>> Slots;
    public Dictionary<string, MessageModel> AllMessages;
    public Dictionary<string, Dictionary<string, bool>> MessageHashBySender;

    public Dictionary<string, Dictionary<int, List<EdgeModel>>> EdgeByValidator;
    public Dictionary<string, Dictionary<int, List<MessageModel>>> MessageByValidator;
    public Dictionary<string, bool> AllValidatorNames;
    public Dictionary<int, List<string>> ValidatorNamesBySlot;

    public void SetAttrsByValidator()
    {
        var edgeByValidator = new Dictionary<string, Dictionary<int, List<EdgeModel>>>();
        var messageByValidator = new Dictionary<string, Dictionary<int, List<MessageModel>>>();
        
        foreach (var slotKeyValue in this.Slots)
        {
            var slotNo = slotKeyValue.Key;
            var validatorMap = slotKeyValue.Value;
            
            foreach (var validatorKeyValue in validatorMap)
            {
                var validatorName = validatorKeyValue.Key;
                var validatorModel = validatorKeyValue.Value;
                
                if (!edgeByValidator.ContainsKey(validatorName))
                {
                    edgeByValidator[validatorName] = new Dictionary<int, List<EdgeModel>>();
                }

                if (!messageByValidator.ContainsKey(validatorName))
                {
                    messageByValidator[validatorName] = new Dictionary<int, List<MessageModel>>();
                }
                
                edgeByValidator[validatorName][slotNo] = new List<EdgeModel>();
                messageByValidator[validatorName][slotNo] = new List<MessageModel>();
                
                foreach (var m in validatorModel.State.Messages)
                {
                    var srcMsg = this.AllMessages[m.Hash];
                    var dstMsg = m.ParentHash != null ? this.AllMessages[m.ParentHash] : null;
                        
                    var edgeModel = new EdgeModel(srcMsg, dstMsg);
                    Debug.Log(edgeModel.SrcMsg.Hash);
                    edgeByValidator[validatorName][slotNo].Add(edgeModel);
                    messageByValidator[validatorName][slotNo].Add(m);
                } 
            }
        }

        this.EdgeByValidator = edgeByValidator;
        this.MessageByValidator = messageByValidator;
        Debug.Log("---finished----");
    }

    public void DebugPrint()
    {
        Debug.Log("-----xxxxxxxxxxxxxxxx-----------");
        foreach (var keyValuePair in this.AllMessages)
        {
            var messageHash = keyValuePair.Key;
            var message = keyValuePair.Value;
            Debug.Log("----message---");
            Debug.Log(messageHash);
            Debug.Log(message.CliqueSize);
            Debug.Log(message.Estimate.Height);
            Debug.Log(message.Estimate.ActiveValidators.Count);
            Debug.Log("----message---");
        }
        Debug.Log("-----xxxxxxxxxxxxxxxx-----------");
    }
}
