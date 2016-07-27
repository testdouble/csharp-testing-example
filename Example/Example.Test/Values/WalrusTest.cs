using Example.Values;
using Xunit;

namespace Example.Test.Values {
    public class WalrusTest {

        Walrus subject = new Walrus();

        [Fact]
        public void WrongFood() {
            var someFood = new WalrusFood();
            var moreFood = new WalrusFood();

            subject.AddToStomach(someFood);

            Assert.False(subject.HasEaten(moreFood));
        }

        [Fact]
        public void RightFood() {
            var food = new WalrusFood();

            subject.AddToStomach(food);

            Assert.True(subject.HasEaten(food));
        }
    }
}