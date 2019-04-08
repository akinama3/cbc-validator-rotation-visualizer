using System.Runtime.CompilerServices;

namespace Models
{
    public class ValidatorModel
    {
        public string Name { get; set; }
        public StateModel State { get; set; }

        public ValidatorModel(string name, StateModel state)
        {
            this.Name = name;
            this.State = state;
        }
    }
}

/*
    name: v0
    state:
      messages:
      - estimate:
          hash: 9915581204423
          parent_hash: null
        hash: 29882788823379
        justification: []
        parent_hash: null
        receiver_slot: 0
        sender: v1
        sender_slot: 0
        */
        