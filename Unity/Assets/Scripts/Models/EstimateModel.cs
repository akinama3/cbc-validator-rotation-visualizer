using System.Collections.Generic;
using System.Threading;

namespace Models
{
    public class EstimateModel
    {
        public string Hash { set; get; }
        public string ParentHash { set; get; }
        
        public List<string> ActiveValidators { getl; set; }

        public int Height { get; set; }

        public EstimateModel(string hash, string parentHash, int height, List<string> activeValidators)
        {
            this.Hash = hash;
            this.ParentHash = parentHash;
            this.Height = height;
            this.ActiveValidators = activeValidators;
        }
    }
}