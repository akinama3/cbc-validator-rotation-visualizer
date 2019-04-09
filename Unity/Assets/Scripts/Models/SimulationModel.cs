using System.Collections.Generic;
using Models;
using UnityEngine.Rendering;

public class SimulationModel
{
    public Dictionary<int, Dictionary<string, ValidatorModel>> Slots;
    public Dictionary<string, MessageModel> AllMessages;
    public Dictionary<string, Dictionary<string, bool>> MessageHashBySender;
}
