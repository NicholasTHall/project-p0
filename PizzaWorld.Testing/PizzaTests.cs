using PizzaWorld.Domain.Models.PizzaModels;
using Xunit;

namespace PizzaWorld.Testing
{
    public class PizzaTests
    {
        [Fact]
        private void Test_MeatPizzaExists()
        {
            // arrange
            var sut = new MeatPizza();  // inferenece
            MeatPizza sut1 = new MeatPizza(); // memory allocation

            // act
            var actual = sut;

            // assert
            Assert.IsType<MeatPizza>(actual);
            Assert.NotNull(actual);
        }

        [Fact]
        private void Test_CustomPizzaExists()
        {
            // arrange
            var sut = new CustomPizza();  // inferenece
            CustomPizza sut1 = new CustomPizza(); // memory allocation

            // act
            var actual = sut;

            // assert
            Assert.IsType<CustomPizza>(actual);
            Assert.NotNull(actual);
        }
    }
}
