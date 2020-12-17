using PizzaWorld.Domain.Models;
using Xunit;

namespace PizzaWorld.Testing
{
    public class UserTests
    {
        [Fact]
        private void Test_UserExists()
        {
            // arrange
            var sut = new User();  // inferenece
            User sut1 = new User(); // memory allocation

            // act
            var actual = sut;
            
            // assert
            Assert.IsType<User>(actual);
            Assert.NotNull(actual);
        }
    }
}