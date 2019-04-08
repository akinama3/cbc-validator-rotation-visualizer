using System.Collections.Generic;
using Models;

public class SimulationModel
{
    public Dictionary<int, Dictionary<string, ValidatorModel>> Slots;
    public Dictionary<string, MessageModel> AllMessages;
}
