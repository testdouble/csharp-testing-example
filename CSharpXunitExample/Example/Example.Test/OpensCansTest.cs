using Example.Values;
using Xunit;

namespace Example.Test {
    public class OpensCansTest {

        OpensCans subject = new OpensCans();

        [Fact]
        public void Test() {
            var food = new WalrusFood();
            var can = new CannedWalrusFood(food);

            var result = subject.Open(can);

            Assert.Equal(result, food);
        }
    }
}