using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QATestLabGame
{
    class HumanMage
    {
        public string name;
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
        public string name;
        public int hp = 100;
        public int atack = 15;
        public bool upgraded = false;
        public int fight(int enemyHp)
        {                                               //метод атаки по сопернику
            return enemyHp - atack;
        }
    }
    class HumanArcher {
        public string name;
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
        public string name;
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
        public string name;
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
        public string name;
        public int hp = 100;
        public int atack = 18;
        public bool upgraded = false;
        public int fight(int enemyHp)
        {                                               //метод атаки по сопернику
            return enemyHp - atack;
        }
    }

////////////////////////////////////////////////////////////////////////////////////////////////////////

    class Program
    {
        static void Main(string[] args)
        {
            HumanMage mage1 = null;
            HumanFighter fighter1 = null;
            HumanFighter fighter2 = null;
            HumanFighter fighter3 = null;
            HumanFighter fighter4 = null;
            HumanArcher archer1 = null;
            HumanArcher archer2 = null;
            HumanArcher archer3 = null;
            ElfMage elfmage1 = null;
            ElfFighter elffighter1 = null;
            ElfFighter elffighter2 = null;
            ElfFighter elffighter3 = null;
            ElfFighter elffighter4 = null;
            ElfArcher elfarcher1 = null;
            ElfArcher elfarcher2 = null;
            ElfArcher elfarcher3 = null;
            DeadMage dmage1 = null;
            DeadFighter dfighter1 = null;
            DeadFighter dfighter2 = null;
            DeadFighter dfighter3 = null;
            DeadFighter dfighter4 = null;
            DeadArcher darcher1 = null;
            DeadArcher darcher2 = null;
            DeadArcher darcher3 = null;
            OrcMage orcmage1 = null;
            OrcFighter orcfighter1 = null;
            OrcFighter orcfighter2 = null;
            OrcFighter orcfighter3 = null;
            OrcFighter orcfighter4 = null;
            OrcArcher orcarcher1 = null;
            OrcArcher orcarcher2 = null;
            OrcArcher orcarcher3 = null;
            Random rand = new Random();
            if (rand.Next(0, 2) == 0)                                   //Создание силы света
            {
                Console.WriteLine("Первый отряд состоит из людей.");
                mage1 = new HumanMage();
                fighter1 = new HumanFighter();
                fighter2 = new HumanFighter();
                fighter3 = new HumanFighter();
                fighter4 = new HumanFighter();
                archer1 = new HumanArcher();
                archer2 = new HumanArcher();
                archer3 = new HumanArcher();
            }
            else
            {
                Console.WriteLine("Первый отряд состоит из эльфов.");
                elfmage1 = new ElfMage();
                elffighter1 = new ElfFighter();
                elffighter2 = new ElfFighter();
                elffighter3 = new ElfFighter();
                elffighter4 = new ElfFighter();
                elfarcher1 = new ElfArcher();
                elfarcher2 = new ElfArcher();
                elfarcher3 = new ElfArcher();
            }
                if (rand.Next(0, 2) == 0)                               //создание силы тьмы
            {
                Console.WriteLine("Второй отряд состоит из орков.");
                orcmage1 = new OrcMage();
                orcfighter1 = new OrcFighter();
                orcfighter2 = new OrcFighter();
                orcfighter3 = new OrcFighter();
                orcfighter4 = new OrcFighter();
                orcarcher1 = new OrcArcher();
                orcarcher2 = new OrcArcher();
                orcarcher3 = new OrcArcher();
            }
            else
            {
                Console.WriteLine("Второй отряд состоит из некромантов.");
                dmage1 = new DeadMage();
                dfighter1 = new DeadFighter();
                dfighter2 = new DeadFighter();
                dfighter3 = new DeadFighter();
                dfighter4 = new DeadFighter();
                darcher1 = new DeadArcher();
                darcher2 = new DeadArcher();
                darcher3 = new DeadArcher();
            }
            //todo: геймплей
            //while (mage1.hp > 0 && dmage1.hp > 0)
            //{
            //    mage1.hp = dmage1.fight(mage1.hp);
            //    Console.WriteLine($"Некромант нанес атаку магу. ХП мага: {mage1.hp}");
            //    dmage1.hp = mage1.fight(dmage1.hp);
            //    Console.WriteLine($"Маг нанес атаку некроманту. ХП некроманта: {dmage1.hp}");
            //}

            Console.ReadKey();
        }
        static int StartGame()
        {
            return 0;
        }
       
    }
}

