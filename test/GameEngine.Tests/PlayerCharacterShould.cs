using System;
using Xunit;

namespace GameEngine.Tests
{
    public class PlayerCharacterShould : IDisposable
    {
        private PlayerCharacter _sut;

        public PlayerCharacterShould()
        {
            _sut = new PlayerCharacter();
        }

        /*********************** Assertions against strings ****************************/

        [Fact]
        public void BeInexperiencedWhenNew()
        {
            //Act
            bool isNoob = _sut.isNoob;
            //Assert
            Assert.True(isNoob);
        }

        [Fact]
        public void CalculateFullName()
        {
            //Arrange
            _sut.FirstName = "Kalle";
            _sut.LastName = "Anka";
            string expected = "Kalle Anka";
            //Act
            string actual = _sut.FullName;
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateFullNameIgnoreCase()
        {
            //Arrange
            _sut.FirstName = "Kalle";
            _sut.LastName = "Anka";
            string expected = "KALLE ANKA";
            //Act
            string actual = _sut.FullName;
            //Assert
            Assert.Equal(expected, actual, ignoreCase: true);
        }

        [Fact]
        public void CalculateFullName_WithContains()
        {
            //Arrange
            _sut.FirstName = "Kalle";
            _sut.LastName = "Anka";
            string expected = "e A";
            //Act
            string actual = _sut.FullName;
            //Assert
            Assert.Contains(expected, actual);
        }

        [Fact]
        public void HaveFullNameStartingWithFirstName()
        {
            //Arrange
            _sut.FirstName = "Kalle";
            _sut.LastName = "Anka";
            string expected = "Kalle";
            //Act
            string actual = _sut.FullName;
            //Assert
            Assert.StartsWith(expected, actual);
        }

        [Fact]
        public void HaveFullNameEndingWithLastName()
        {
            //Arrange
            _sut.FirstName = "Kalle";
            _sut.LastName = "Anka";
            string expected = "Anka";
            //Act
            string actual = _sut.FullName;
            //Assert
            Assert.EndsWith(expected, actual);
        }

        [Fact]
        public void CalculateFullNameStartsFirstAndLastNameWithCapitalLetter()
        {
            //Arrange
            _sut.FirstName = "Kalle";
            _sut.LastName = "Anka";
            //Act
            string actual = _sut.FullName;
            //Assert
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", actual);
        }

        /*********************** Assertions against numbers ****************************/

        [Fact]
        public void StartWithDefaultHealth()
        {
            //Arrange
            int expected = 100;
            //Act
            int actual = _sut.Health;
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DontStartDefaultHealthWithZero()
        {
            //Arrange
            int expected = 0;
            //Act
            int actual = _sut.Health;
            //Assert
            Assert.NotEqual(expected, actual);
        }

        [Fact]
        public void IncreaseHealthAfterSleeping()
        {
            //Arrange
            //Act
            _sut.Sleep(); //Expect health increase from 1 to 100 inclusive.
            int actual = _sut.Health;
            //Assert
            Assert.InRange<int>(actual, 101, 200);
        }

        /*********************** Assertions with null values ****************************/

        [Fact]
        public void NickNameNullAsDefault()
        {
            //Act
            string actual = _sut.NickName;
            //Assert
            Assert.Null(actual);
        }

        /*********************** Assertions against Collections ****************************/

        [Fact]
        public void HaveALongBow()
        {
            //Assert
            Assert.Contains("Long Bow", _sut.Weapons);
        }

        [Fact]
        public void HaveAStaffOfWonder()
        {
            //Assert
            Assert.DoesNotContain("Staff of Wonder", _sut.Weapons);
        }

        [Fact]
        public void HaveAtLeastOneKindOfSword()
        {
            //Assert
            Assert.Contains(_sut.Weapons, weapon => weapon.Contains("Sword"));
        }

        [Fact]
        public void HaveAllExpectedWeapons()
        {
            //Arrange
            var expected = new[] {
                "Long Bow",
                "Short Bow",
                "Short Sword"
            };
            //Assert
            Assert.Equal(expected, _sut.Weapons);
        }

        [Fact]
        public void HaveNoEmptyDefaultWeapons()
        {
            //Assert
            Assert.All(_sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));
        }

        /*********************** Assertions on Raised Events ****************************/

        [Fact]
        public void RaiseSleptEvent()
        {
            //Assert

            //Generic Type: The type of the event argument.
            //First arg: The handler to attach
            //Second arg: The handler to detach
            //Third arg: The code that raises the event.
            Assert.Raises<EventArgs>(handler => _sut.PlayerSlept += handler, handler => _sut.PlayerSlept -= handler, () => _sut.Sleep());
        }

        [Fact]
        public void RaisePropertyChangedEvent()
        {
            //Assert
            //First arg: The object with the property.
            //Second arg: The name of the property that changes value.
            //Third arg: The action.
            Assert.PropertyChanged(_sut, "Health", () => _sut.TakeDamage(10));
        }

        [Theory]
        [InlineData(0, 100)]
        [InlineData(1, 99)]
        [InlineData(50, 50)]
        [InlineData(101, 1)]
        public void TakeDamage(int damage, int expectedDamage)
        {
            //Act
            _sut.TakeDamage(damage);
            //Assert
            Assert.Equal(expectedDamage, _sut.Health);
        }

        public void Dispose()
        {
            //Clean up code.
        }
    }
}
