using Example.Values;

namespace Example {
    public class FeedsWalrus {
        private readonly IOpensCans _opensCans;

        public FeedsWalrus(IOpensCans opensCans) {
            _opensCans = opensCans;
        }

        public void Feed(Walrus gary, CannedWalrusFood can) {
           gary.AddToStomach(_opensCans.Open(can));
        }
    }
}