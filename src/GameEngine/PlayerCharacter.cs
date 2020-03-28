using System;
using System.Collections.Generic;

namespace GameEngine
{
    public class PlayerCharacter
    {
        public PlayerCharacter()
        {
            isNoob = true;
            CreateStartingWeapons();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string NickName { get; set; }
        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }
        public bool isNoob { get; set; }
        public List<string> Weapons { get; set; }

        public void Sleep()
        {
            Health += CalculateHealthIncrease();
        }

        private int CalculateHealthIncrease()
        {
            var rnd = new Random();
            int healthIncrease = rnd.Next(1, 101);
            return healthIncrease;
        }

        private void CreateStartingWeapons()
        {
            Weapons = new List<string>()
            {
                "Long Bow",
                "Short Bow",
                "Short Sword"
            };
        }

        private int _health = 100;
    }
}
