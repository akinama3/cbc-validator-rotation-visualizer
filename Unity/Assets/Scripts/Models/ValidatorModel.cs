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
