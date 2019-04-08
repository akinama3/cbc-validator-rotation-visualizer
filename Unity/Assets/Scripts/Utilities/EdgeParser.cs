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
                foreach (var vKeyValue in validatorMap)
                {
                    var validatorName = vKeyValue.Key;
                    var validatorModel = vKeyValue.Value;
                    Debug.Log(validatorModel.State.Messages);
                    foreach (var m in validatorModel.State.Messages)
                    {
                        var srcMsg = simulation.AllMessages[m.Hash];
                        var dstMsg = simulation.AllMessages[m.ParentHash];
                        var edgeModel = new EdgeModel(srcMsg, dstMsg);
                        Debug.Log("----------------");
                        Debug.Log(validatorName);
                        Debug.Log(srcMsg.Hash);
                        Debug.Log(dstMsg.Hash);
                        Debug.Log("----------------");
                        edgesBySlot[slotNo][validatorName].Add(edgeModel);
                    } 
                }
            }
            
            return edgesBySlot;
        }
    }
}