using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace GameEngine
{
    public class PlayerCharacter : INotifyPropertyChanged
    {
        public PlayerCharacter()
        {
            isNoob = true;
            CreateStartingWeapons();
        }
        public event EventHandler<EventArgs> PlayerSlept;
        public event PropertyChangedEventHandler PropertyChanged;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string NickName { get; set; }
        public int Health
        {
            get => _health;
            set { _health = value; OnPropertyChanged(this, "Health"); }
        }
        public bool isNoob { get; set; }
        public List<string> Weapons { get; set; }

        public void TakeDamage(int damage)
        {
            Health = Math.Max(1, Health -= damage);
        }

        public void Sleep()
        {
            Health += CalculateHealthIncrease();

            OnPlayerSlept(EventArgs.Empty);
        }

        protected virtual void OnPropertyChanged(object sender, string propertyName)
        {
            PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPlayerSlept(EventArgs e)
        {
            PlayerSlept?.Invoke(this, e);
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
