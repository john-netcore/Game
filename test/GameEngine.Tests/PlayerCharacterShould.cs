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

        [Fact]
        public void CalculateFullName()
        {
            //Arrange
            PlayerCharacter sut = new PlayerCharacter();
            sut.FirstName = "Kalle";
            sut.LastName = "Anka";
            string expected = "Kalle Anka";
            //Act
            string actual = sut.FullName;
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
