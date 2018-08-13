using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QATestLabGame
{
    class HumanMage
    {
        public int hp=100;
        public int atack = 10;
        public bool upgraded = false;
        public int fight(int enemyHp){              //метод атаки по сопернику
            return enemyHp - atack;
        }
        public double upgrade(int friendAtack)             //метод улучшения союзника
        {
            return friendAtack*1.5;
        }
    }
    class HumanFighter {
        public int hp = 100;
        public int atack = 15;
        public bool upgraded = false;
        public int fight(int enemyHp)
        {                                               //метод атаки по сопернику
            return enemyHp - atack;
        }
    }
    class HumanArcher {
        public int hp = 100;
        public bool upgraded = false;
        public int miliAtack = 3;
        public int rangedAtack = 7;
        public int miliFight(int enemyHp)
        {                                                    //метод ближней атаки по сопернику
            return enemyHp - miliAtack;
        }
        public int rangedFight(int enemyHp)
        {                                                    //метод дальней атаки по сопернику
            return enemyHp - rangedAtack;
        }
        
    }
    class ElfMage { }
    class ElfArcher { }
    class ElfFighter { }
    class OrcMage
    {
    
    }
    class OrcFighter { }
    class OrcArcher { }
    class DeadMage {
        public int hp = 100;
        public int atack = 5;
        public bool upgraded = false;
        public int fight(int enemyHp)
        {
            return enemyHp - atack;
        }
        public double downgrade(int enemyAtack)             //метод проклятия врага
        {
            return enemyAtack * 0.5;
        }
    }
    class DeadArcher {
        public int hp = 100;
        public bool upgraded = false;
        public int miliAtack = 2;
        public int rangedAtack = 4;
        public int miliFight(int enemyHp)
        {                                                    //метод ближней атаки по сопернику
            return enemyHp - miliAtack;
        }
        public int rangedFight(int enemyHp)
        {                                                    //метод дальней атаки по сопернику
            return enemyHp - rangedAtack;
        }
    }
    class DeadFighter {
        public int hp = 100;
        public int atack = 18;
        public bool upgraded = false;
        public int fight(int enemyHp)
        {                                               //метод атаки по сопернику
            return enemyHp - atack;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            DeadMage dmage1 = new DeadMage();
            Random rand = new Random();
            Init(rand.Next(1));
            
            if (rand.Next(1) == 0)
            {
                Console.WriteLine("Второй отряд состоит из орков.");
            }
            else
            {
                Console.WriteLine("Второй отряд состоит из некромантов.");
            }
            while ( mage1.hp > 0 && dmage1.hp > 0)
            {
                mage1.hp = dmage1.fight(mage1.hp);
                Console.WriteLine($"Некромант нанес атаку магу. ХП мага: {mage1.hp}" );
                dmage1.hp = mage1.fight(dmage1.hp);
                Console.WriteLine($"Маг нанес атаку некроманту. ХП некроманта: {dmage1.hp}");
            }
            Console.ReadKey();
        }
        static int StartGame()
        {
            return 0;
        }
        static void Init(int i) {
            if (i == 0)
            {
                Console.WriteLine("Первый отряд состоит из людей.");
                HumanMage mage1 = new HumanMage();
                HumanFighter fighter1 = new HumanFighter();
                HumanFighter fighter2 = new HumanFighter();
                HumanFighter fighter3 = new HumanFighter();
                HumanFighter fighter4 = new HumanFighter();
                HumanArcher archer1 = new HumanArcher();
                HumanArcher archer2 = new HumanArcher();
                HumanArcher archer3 = new HumanArcher();
            }
            else
            {
                Console.WriteLine("Первый отряд состоит из людей.");
                HumanMage mage1 = new HumanMage();
                HumanFighter fighter1 = new HumanFighter();
                HumanFighter fighter2 = new HumanFighter();
                HumanFighter fighter3 = new HumanFighter();
                HumanFighter fighter4 = new HumanFighter();
                HumanArcher archer1 = new HumanArcher();
                HumanArcher archer2 = new HumanArcher();
                HumanArcher archer3 = new HumanArcher();
            }
           
        }
    }
    }
}
