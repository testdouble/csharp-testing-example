using Example.Values;
using Xunit;

namespace Example.Test.Values {
    public class WalrusTest {

        private readonly Walrus _subject = new Walrus();

        [Fact]
        public void WrongFood() {
            var someFood = new WalrusFood();
            var moreFood = new WalrusFood();

            _subject.AddToStomach(someFood);

            Assert.False(_subject.HasEaten(moreFood));
        }

        [Fact]
        public void RightFood() {
            var food = new WalrusFood();

            _subject.AddToStomach(food);

            Assert.True(_subject.HasEaten(food));
        }
    }
}