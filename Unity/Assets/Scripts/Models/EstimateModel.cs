using System.Threading;

namespace Models
{
    public class EstimateModel
    {
        public string Hash { set; get; }
        public string ParentHash { set; get; }

        public EstimateModel(string hash, string parentHash)
        {
            this.Hash = hash;
            this.ParentHash = parentHash;
        }
    }
}