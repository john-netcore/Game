using Xunit;

namespace GameEngine.Tests
{
    public class PlayerCharacterShould
    {
        [Fact]
        public void BeInexperiencedWhenNew()
        {
            //Arrange
            PlayerCharacter sut = new PlayerCharacter();
            //Act
            bool isNoob = sut.isNoob;
            //Assert
            Assert.True(isNoob);

        }
    }
}
