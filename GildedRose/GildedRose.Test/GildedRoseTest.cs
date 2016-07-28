using Xunit;

namespace GildedRose.Test {
    public class GildedRoseTest {
        [Fact]
        public void ItemHasName() {
            var item = new Item {Name = "Bread"};
            Assert.Equal("Bread", item.Name);
        }
    }
}