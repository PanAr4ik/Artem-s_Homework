using System.Xml.Linq;

namespace EX2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }

        public virtual void Attack(Character target)
        {
            Console.WriteLine($"{Name} атакует {target.Name}");
            target.Health -= this.AttackPower ;
            Console.WriteLine($"{target.Name} получил {Attack} урона. Осталось здоровья: {target.Health}");
        }

        public void PrintStatus()
        {
            Console.WriteLine($"Имя: {Name}, Здоровье: {Health}, Атака: {Attack}");
        }
    }

    public class Warrior : Character
    {
        public int Defense { get; set; }

        public override void Attack(Character target)
        {
            base.Attack(target);
            Console.WriteLine("Мощный удар воина!");
        }
    }

    public class Mage : Character
    {
        public int Mana { get; set; }

        public override void Attack(Character target)
        {
            if (Mana > 0)
            {
                base.Attack(target);
                Mana--;
                Console.WriteLine("Магическая атака!");
            }
            else
            {
                Console.WriteLine("Не хватает маны!");
            }
        }
    }

    public class Archer : Character
    {
        public int Arrows { get; set; }

        public override void Attack(Character target)
        {
            if (Arrows > 0)
            {
                base.Attack(target);
                Arrows--;
                Console.WriteLine("Стрела летит в цель!");
            }
            else
            {
                Console.WriteLine("Нет стрел!");
            }
        }
    }
}
