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

        [Fact]
        public void CalculateFullNameIgnoreCase()
        {
            //Arrange
            PlayerCharacter sut = new PlayerCharacter();
            sut.FirstName = "Kalle";
            sut.LastName = "Anka";
            string expected = "KALLE ANKA";
            //Act
            string actual = sut.FullName;
            //Assert
            Assert.Equal(expected, actual, ignoreCase: true);
        }

        [Fact]
        public void HaveFullNameStartingWithFirstName()
        {
            //Arrange
            PlayerCharacter sut = new PlayerCharacter();
            sut.FirstName = "Kalle";
            sut.LastName = "Anka";
            string expected = "Kalle";
            //Act
            string actual = sut.FullName;
            //Assert
            Assert.StartsWith(expected, actual);
        }

        [Fact]
        public void HaveFullNameEndingWithLastName()
        {
            //Arrange
            PlayerCharacter sut = new PlayerCharacter();
            sut.FirstName = "Kalle";
            sut.LastName = "Anka";
            string expected = "Anka";
            //Act
            string actual = sut.FullName;
            //Assert
            Assert.EndsWith(expected, actual);
        }
    }
}
