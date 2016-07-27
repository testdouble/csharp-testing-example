using System.Collections.Generic;

namespace Example.Values {
    public class Walrus {
        private readonly ISet<WalrusFood> _stomach = new HashSet<WalrusFood>();

        public bool HasEaten(WalrusFood food) {
            return _stomach.Contains(food);
        }

        public void AddToStomach(WalrusFood food) {
            _stomach.Add(food);
        }
    }
}