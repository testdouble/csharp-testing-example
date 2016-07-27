namespace Example.Values {
    public class CannedWalrusFood {
        private WalrusFood _food;

        public CannedWalrusFood() {}

        public CannedWalrusFood(WalrusFood food) {
            _food = food;
        }

        public WalrusFood ExtractContents() {
            var contents = _food;
            _food = null;
            return contents;
        }
    }
}