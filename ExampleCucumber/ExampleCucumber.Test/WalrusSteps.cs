using Xunit;
using TechTalk.SpecFlow;
using Example;
using Example.Values;

namespace ExampleCucumber.Test {
    [Binding]
    public class WalrusSteps {
        private Walrus _walrus;
        private WalrusFood _food;
        private CannedWalrusFood _cannedFood;

        [Given(@"^I have a walrus$")]
        public void I_Have_A_Walrus() {
            _walrus = new Walrus();
        }

        [Given(@"^I have food$")]
        public void I_Have_Food() {
            _food = new WalrusFood();
        }

        [Given(@"^I put the food in a can$")]
        public void I_Put_The_Food_In_A_Can() {
            _cannedFood = new CannedWalrusFood(_food);
        }

        [When(@"^I have not fed the walrus$")]
        public void I_Have_Not_Fed_The_Walrus() {
            // Do nothing
        }

        [When(@"^I have fed the walrus$")]
        public void I_Have_Fed_The_Walrus() {
            _walrus.AddToStomach(_food);
        }

        [When(@"^I feed the walrus canned food$")]
        public void I_Feed_The_Walrus_Canned_Food() {
            new FeedsWalrus(new OpensCans()).Feed(_walrus, _cannedFood);
        }

        [Then(@"^the walrus's stomach should not contain any food I pass it$")]
        public void The_Walrus_Stomach_Should_Not_Contain_Any_Food_I_Pass_It() {
            Assert.False(_walrus.HasEaten(_food));
        }

        [Then(@"^the walrus's stomach should contain the food$")]
        public void The_Walrus_Stomach_Should_Contain_The_Food() {
            Assert.True(_walrus.HasEaten(_food));
        }
    }
}