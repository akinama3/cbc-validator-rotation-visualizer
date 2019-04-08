using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Models;
using UnityEngine;

namespace Utilities
{
    public static class EdgeParser
    {

        public static Dictionary<int, Dictionary<string, List<EdgeModel>>> initEdgeList(SimulationModel simulation)
        {
            Debug.Log("-------start to parse edges---");
            var edgesBySlot = new Dictionary<int, Dictionary<string, List<EdgeModel>>>();
            Debug.Log(simulation.Slots.Count);
            Debug.Log(simulation.AllMessages.Count);
            foreach (var slotKeyValue in simulation.Slots)
            {
                var slotNo = slotKeyValue.Key;
                var validatorMap = slotKeyValue.Value;
                edgesBySlot[slotNo] = new Dictionary<string, List<EdgeModel>>();
                foreach (var vKeyValue in validatorMap)
                {
                    var validatorName = vKeyValue.Key;
                    var validatorModel = vKeyValue.Value;
                    edgesBySlot[slotNo][validatorName] = new List<EdgeModel>();
                    
                    foreach (var m in validatorModel.State.Messages)
                    {
                        var srcMsg = simulation.AllMessages[m.Hash];
                        var dstMsg = m.ParentHash != null ? simulation.AllMessages[m.ParentHash] : null;
                        
                        Debug.Log("-----------");
                        Debug.Log(srcMsg.Hash);
                        Debug.Log("-----------");
                        var edgeModel = new EdgeModel(srcMsg, dstMsg);
                        Debug.Log(edgeModel.SrcMsg.Hash);
                        edgesBySlot[slotNo][validatorName].Add(edgeModel);
                    } 
                }
            }
            
            return edgesBySlot;
        }
    }
}