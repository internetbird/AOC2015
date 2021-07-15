namespace AOC2015.Logic.Models
{
    public class RPGWeapon
    {

        public int Price { get; private set; }
        public int Damage { get; private set; }
        public string Name { get; private set; }


        public RPGWeapon(string name, int damage, int price) 
        {
            Name = name;
            Damage = damage;
            Price = price;
        }
    }
}