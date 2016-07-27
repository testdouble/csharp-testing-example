using Example.Values;

namespace Example {
    public class OpensCans {
        public WalrusFood Open(CannedWalrusFood can) {
            return can.ExtractContents();
        }
    }
}