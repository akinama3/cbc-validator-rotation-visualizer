using System.Collections.Generic;
using System.Linq;
using Models;
using UnityEngine;

namespace Utilities
{
    public static class EdgeParser
    {

        public static Dictionary<int, Dictionary<string, List<EdgeModel>>> initEdgeList(SimulationModel simulation)
        {
            var edgesBySlot = new Dictionary<int, Dictionary<string, List<EdgeModel>>>();
            foreach (var slotKeyValue in simulation.Slots)
            {
                var slotNo = slotKeyValue.Key;
                var validatorMap = slotKeyValue.Value;
                foreach (var vKeyValue in validatorMap)
                {
                    var validatorName = vKeyValue.Key;
                    var validatorModel = vKeyValue.Value;
                    foreach (var m in validatorModel.State.Messages)
                    {
                        var srcMsg = simulation.AllMessages[m.Hash];
                        var dstMsg = simulation.AllMessages[m.ParentHash];
                        var edgeModel = new EdgeModel(srcMsg, dstMsg);
                        edgesBySlot[slotNo][validatorName].Append(edgeModel);
                    } 
                }
            }

            return edgesBySlot;
        }
    }
}