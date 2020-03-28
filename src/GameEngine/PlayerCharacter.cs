namespace GameEngine
{
    public class PlayerCharacter
    {
        public PlayerCharacter()
        {
            isNoob = true;
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

        private int _health;
    }
}
