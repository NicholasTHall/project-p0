using PizzaWorld.Domain.Models;
using Xunit;

namespace PizzaWorld.Testing
{
    public class StoreTests
    {
        [Fact]
        private void Test_StoreExists()
        {
            // arrange
            var sut = new Store();  // inferenece
            Store sut1 = new Store(); // memory allocation

            // act
            var actual = sut;
            
            // assert
            Assert.IsType<Store>(actual);
            Assert.NotNull(actual);
        }
    }
}