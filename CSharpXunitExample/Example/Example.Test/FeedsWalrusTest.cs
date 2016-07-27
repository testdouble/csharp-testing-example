using Example.Values;
using Xunit;
using Moq;

namespace Example.Test {
    public class FeedsWalrusTest {

        [Fact]
        public void Test() {
            var gary = new Walrus();
            var can = new CannedWalrusFood();
            var food = new WalrusFood();
            var mock = new Mock<IOpensCans>();
            mock.Setup(m => m.Open(can)).Returns(food);
            var opensCans = mock.Object;
            var subject = new FeedsWalrus(opensCans);

            subject.Feed(gary, can);

            Assert.True(gary.HasEaten(food));
        }
    }
}
