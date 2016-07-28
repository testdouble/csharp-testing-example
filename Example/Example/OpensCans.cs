using Example.Values;

namespace Example {
    public class OpensCans : IOpensCans {
        public WalrusFood Open(CannedWalrusFood can) {
            return can.ExtractContents();
        }
    }
}