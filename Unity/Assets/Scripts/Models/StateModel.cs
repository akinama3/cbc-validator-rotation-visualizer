using System.Collections.Generic;
    public class StateModel
    {
        public List<MessageModel> Messages { get; set; }

        public StateModel(List<MessageModel> messages)
        {
            this.Messages = messages;
        }
    }


namespace Models
{}
