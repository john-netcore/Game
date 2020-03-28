using Xunit;

namespace GameEngine.Tests
{
    public class PlayerCharacterShould
    {

        /*********************** Assertions against strings ****************************/

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
        public void CalculateFullName_WithContains()
        {
            //Arrange
            PlayerCharacter sut = new PlayerCharacter();
            sut.FirstName = "Kalle";
            sut.LastName = "Anka";
            string expected = "e A";
            //Act
            string actual = sut.FullName;
            //Assert
            Assert.Contains(expected, actual);
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

        [Fact]
        public void CalculateFullNameStartsFirstAndLastNameWithCapitalLetter()
        {
            //Arrange
            PlayerCharacter sut = new PlayerCharacter();
            sut.FirstName = "Kalle";
            sut.LastName = "Anka";
            //Act
            string actual = sut.FullName;
            //Assert
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", actual);
        }

        /*********************** Assertions against numbers ****************************/

        [Fact]
        public void StartWithDefaultHealth()
        {
            //Arrange
            PlayerCharacter sut = new PlayerCharacter();
            int expected = 100;
            //Act
            int actual = sut.Health;
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DontStartDefaultHealthWithZero()
        {
            //Arrange
            PlayerCharacter sut = new PlayerCharacter();
            int expected = 0;
            //Act
            int actual = sut.Health;
            //Assert
            Assert.NotEqual(expected, actual);
        }

        [Fact]
        public void IncreaseHealthAfterSleeping()
        {
            //Arrange
            PlayerCharacter sut = new PlayerCharacter();
            //Act
            sut.Sleep(); //Expect health increase from 1 to 100 inclusive.
            int actual = sut.Health;
            //Assert
            Assert.InRange<int>(actual, 101, 200);
        }

        /*********************** Assertions with null values ****************************/

        [Fact]
        public void NickNameNullAsDefault()
        {
            //Arrange
            PlayerCharacter sut = new PlayerCharacter();
            //Act
            string actual = sut.NickName;
            //Assert
            Assert.Null(actual);
        }

        /*********************** Assertions with collections ****************************/

        [Fact]
        public void HaveALongBow()
        {
            //Arrange
            PlayerCharacter sut = new PlayerCharacter();
            //Assert
            Assert.Contains("Long Bow", sut.Weapons);
        }

        [Fact]
        public void HaveAStaffOfWonder()
        {
            //Arrange
            PlayerCharacter sut = new PlayerCharacter();
            //Assert
            Assert.DoesNotContain("Staff of Wonder", sut.Weapons);
        }

        [Fact]
        public void HaveAtLeastOneKindOfSword()
        {
            //Arrange
            PlayerCharacter sut = new PlayerCharacter();
            //Assert
            Assert.Contains(sut.Weapons, weapon => weapon.Contains("Sword"));
        }
    }
}
