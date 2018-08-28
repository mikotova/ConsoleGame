using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using NLog;

namespace QATestLabGame
{
    class Unit
    {
        public int _hp;
        public int _attack;
        public int _rangedAttack;
        public double _buff;
        public readonly string _name;
        public bool _upgraded = false;
        public Unit(string name)
        {
            _name = name;
            _hp = 100;
            _attack = 0;
            _rangedAttack = 0;
            _buff = 1;
        }
        public int fight(int enemyHp)
        {                                               //метод атаки по сопернику
            if (_upgraded == true)
            {
                enemyHp -= Convert.ToInt32(_attack * _buff);                            
                _upgraded = false;
            }
            else
            {
                enemyHp -= _attack;
            }
            return enemyHp;
        }
        public int rangedFight(int enemyHp)
        {                                                    //метод дальней атаки по сопернику
            if (_upgraded == true)
            {
                enemyHp -= Convert.ToInt32(_rangedAttack * _buff);
                _upgraded = false;
            }
            else
            {
                enemyHp -= _rangedAttack;
            }
            return enemyHp;
        }
    }
    class HumanMage: Unit
    {
        public HumanMage(string name) : base(name)
        {
            _attack = 4;
            _buff = 1.5;
        }
    }
    class HumanFighter: Unit
    {
        public HumanFighter(string name):base(name)
        {
            _attack = 18;
        }
    }
    class HumanArcher: Unit
    {
        public HumanArcher(string name):base(name)
        {
            _attack = 3;
            _rangedAttack = 5;
        }  
    }
    class ElfMage: Unit
    {
        public ElfMage(string name) : base(name)
        {
            _attack = 10;
            _buff = 1.5;
        }
    }
    class ElfArcher: Unit
    {
        public ElfArcher(string name) : base(name)
        {
            _attack = 3;
            _rangedAttack = 7;
        }
    }
    class ElfFighter:Unit
    {
        public ElfFighter(string name) : base(name)
        {
            _attack = 15;
        }
    }
    class OrcMage: Unit
    {
        public OrcMage(string name) : base(name)                //todo: debuff
        {
           _buff = 1.5;
        }
    }
    class OrcFighter: Unit
    {
        public OrcFighter(string name) : base(name)
        {
            _attack = 20;
        }
    }
    class OrcArcher: Unit
    {
        public OrcArcher(string name) : base(name)
        {
            _attack = 2;
            _rangedAttack = 3;
        }
    }
    class DeadMage : Unit
    {
        public DeadMage(string name):base(name)
        {
            _attack = 5;
            _buff = 0.5;
        }
    }
    class DeadArcher: Unit
    {
        public DeadArcher(string name):base(name)
        {
            _attack = 2;
            _rangedAttack = 4;
        }
    }
    class DeadFighter: Unit{
        public DeadFighter(string name):base(name)
        {
            _attack = 18;
        }
    }

////////////////////////////////////////////////////////////////////////////////////////////////////////

    static class Program
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            Random rnd = new Random();
            while (n > 1)
            {
                int k = (rnd.Next(0, n) % n);
                n--;
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        private static Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            
            bool continueGame = true;
            bool winner=true;                                                                //по умолчанию победитель - свет
            Random rand = new Random();
            List<Unit> lightList = new List<Unit>();
            List<Unit> darkList = new List<Unit>();
            _logger.Info("Game Started!");
            if (rand.Next(0, 2) == 0)                                                         //Создание силы света
            {
                Console.WriteLine("Первый отряд состоит из людей.");
                lightList.Add(new HumanMage("Человек маг"));                                                               
                lightList.Add(new HumanFighter("Первый человек воин"));
                lightList.Add(new HumanFighter("Второй человек воин"));
                lightList.Add(new HumanFighter("Третий человек воин"));
                lightList.Add(new HumanFighter("Четвертый человек воин"));
                lightList.Add(new HumanArcher("Первый человек арбалетчик"));
                lightList.Add(new HumanArcher("Второй человек арбалетчик"));
                lightList.Add(new HumanArcher("Третий человек арбалетчик"));
            }
            else
            {
                Console.WriteLine("Первый отряд состоит из эльфов.");
                lightList.Add(new ElfMage("Эльф маг"));
                lightList.Add(new ElfFighter("Первый эльф воин"));
                lightList.Add(new ElfFighter("Второй эльф воин"));
                lightList.Add(new ElfFighter("Третий эльф воин"));
                lightList.Add(new ElfFighter("Четвертый эльф воин"));
                lightList.Add(new ElfArcher("Первый эльф лучник"));
                lightList.Add(new ElfArcher("Второй эльф лучник"));
                lightList.Add(new ElfArcher("Третий эльф лучник"));
            }
            if(rand.Next(0, 2) == 0)                                                            //создание силы тьмы
            {
                Console.WriteLine("Второй отряд состоит из орков.");
                darkList.Add(new OrcMage("Шаман"));
                darkList.Add(new OrcFighter("Первый гоблин"));
                darkList.Add(new OrcFighter("Второй гоблин"));
                darkList.Add(new OrcFighter("Третий гоблин"));
                darkList.Add(new OrcFighter("Четвертый гоблин"));
                darkList.Add(new OrcArcher("Первый орк лучник"));
                darkList.Add(new OrcArcher("Второй орк лучник"));
                darkList.Add(new OrcArcher("Третий орк лучник"));
            }
            else
            {
                Console.WriteLine("Второй отряд состоит из нежити.");
                darkList.Add(new DeadMage("Некромант"));                                                               
                darkList.Add(new DeadFighter("Первый зомби"));
                darkList.Add(new DeadFighter("Второй зомби"));
                darkList.Add(new DeadFighter("Третий зомби"));
                darkList.Add(new DeadFighter("Четвертый зомби"));
                darkList.Add(new DeadArcher("Первый охотник"));
                darkList.Add(new DeadArcher("Второй охотник"));
                darkList.Add(new DeadArcher("Третий охотник"));
            }

            /////////////////////////////////////////////////////////////////////////////// game ////////////////////////////////////////////////////////////////////////////////////////

            
            do
            {
                Shuffle(lightList);
                Shuffle(darkList);
                foreach (var list in lightList)
                {
                    int whomEnemy = rand.Next(0, darkList.Count);
                    int whomFriend = rand.Next(0, lightList.Count);
                    switch (list.GetType().Name)
                    {
                        case "HumanFighter":
                        case "ElfFighter":
                            {
                                if(darkList.Count != 0)
                                {
                                    AtackUnit(list, darkList[whomEnemy]);
                                    if (IsDead(darkList[whomEnemy]))
                                    {
                                        darkList.RemoveAt(whomEnemy);
                                    }
                                }
                                else
                                {
                                    winner = true;
                                    continueGame = false;
                                }
                                break;                                                      
                            }

                        case "HumanMage":
                        case "ElfMage":
                            {
                                if (darkList.Count != 0)
                                {
                                    if (rand.Next(0, 2) == 0)
                                    {
                                        AtackUnit(list, darkList[whomEnemy]);
                                        if (IsDead(darkList[whomEnemy]))
                                        {
                                            darkList.RemoveAt(whomEnemy);
                                        }
                                    }
                                    else
                                    {
                                        if (lightList[whomFriend]._upgraded == false)
                                            BuffUnit(list, lightList[whomFriend]);
                                        else
                                        {
                                            whomFriend = rand.Next(0, lightList.Count);
                                            BuffUnit(list, lightList[whomFriend]);
                                        }
                                    }
                                }
                                else
                                {
                                    winner = true;
                                    continueGame = false;
                                }
                                break;
                            }
                        case "HumanArcher":
                        case "ElfArcher":
                            {
                                if (darkList.Count != 0)
                                {
                                    if (rand.Next(0, 2) == 0)
                                    {
                                        AtackUnit(list, darkList[whomEnemy]);
                                    }
                                    else
                                    {
                                        RangedAtackUnit(list, darkList[whomEnemy]);
                                    }
                                    if (IsDead(darkList[whomEnemy]))
                                    {
                                        darkList.RemoveAt(whomEnemy);
                                    }
                                }
                                else
                                {
                                    winner = true;
                                    continueGame = false;
                                }
                                break;
                            }
                    }
                }
                foreach (var list in darkList)
                {
                    int whomEnemy = rand.Next(0, lightList.Count);
                    int whomFriend = rand.Next(0, darkList.Count);
                    switch (list.GetType().Name)
                    {
                        case "DeadFighter":
                        case "OrcFighter":
                            {
                                if (lightList.Count != 0)
                                {
                                    AtackUnit(list, lightList[whomEnemy]);
                                    if (IsDead(lightList[whomEnemy]))
                                    {
                                        lightList.RemoveAt(whomEnemy);
                                    }
                                }
                                else
                                {
                                    winner = false;
                                    continueGame = false;
                                }
                                break;
                            }

                        case "DeadMage":
                            {
                                if (lightList.Count != 0)
                                {
                                    if (rand.Next(0, 2) == 0)
                                    {
                                        AtackUnit(list, lightList[whomEnemy]);
                                        if (IsDead(lightList[whomEnemy]))
                                        {
                                            lightList.RemoveAt(whomEnemy);
                                        }
                                    }
                                    else
                                    {
                                        if (lightList[whomEnemy]._upgraded == false)
                                            BuffUnit(list, lightList[whomEnemy]);
                                        else
                                        {
                                            whomEnemy = rand.Next(0, lightList.Count);
                                            BuffUnit(list, lightList[whomEnemy]);
                                        }
                                    }
                                }
                                else
                                {
                                    winner = false;
                                    continueGame = false;
                                }
                                break;
                            }
                        case "OrcMage":
                            {
                                if (lightList.Count != 0)
                                {
                                    if (rand.Next(0, 2) == 0)                                               //снятие улучшения
                                    {
                                        bool up = false;
                                        foreach(var l in lightList)
                                        {
                                            if (l._upgraded==true)
                                            {
                                                l._upgraded = false;
                                                Console.WriteLine(list._name + "снял улучшение с" + l._name);
                                                up = true;
                                                break;
                                            }
                                            
                                        }
                                        if (up == false)
                                                Console.WriteLine(list._name + " попытался снять улучшение, но никого не нашел.");
                                    }
                                    else
                                    {
                                        if (darkList[whomFriend]._upgraded == false)                        //улучшение
                                            BuffUnit(list, darkList[whomFriend]);
                                        else
                                        {
                                            whomFriend = rand.Next(0, darkList.Count);
                                            BuffUnit(list, darkList[whomFriend]);
                                        }
                                    }
                                }
                                else
                                {
                                    winner = false;
                                    continueGame = false;
                                }
                                break;
                            }
                        case "DeadArcher":
                        case "OrcArcher":
                            {
                                if (lightList.Count != 0)
                                {
                                    if (rand.Next(0, 2) == 0)
                                    {
                                        AtackUnit(list, lightList[whomEnemy]);
                                    }
                                    else
                                    {
                                        RangedAtackUnit(list, lightList[whomEnemy]);
                                    }
                                    if (IsDead(lightList[whomEnemy]))
                                    {
                                        lightList.RemoveAt(whomEnemy);
                                    }
                                }
                                else
                                {
                                    winner = false;
                                    continueGame = false;
                                 }
                                break;
                            }
                    }
                } 
            }
            
            while (continueGame==true);
           if (winner)
                {
                    Console.WriteLine("Победили силы света. ");
                    Winner(lightList);
                }
                else
                {
                    Console.WriteLine("Победили силы тьмы. ");
                    Winner(darkList);
                 }
            _logger.Info("Game finished!");
            Console.ReadKey();
        }

        public static Random rng = new Random();



        static void AtackUnit(Unit fightingUnit, Unit targetUnit)               //функция для атаки
        {
            int attak;
            if (fightingUnit._upgraded == true)
                attak = Convert.ToInt32(fightingUnit._attack * fightingUnit._buff);
            else
                attak = fightingUnit._attack;
            targetUnit._hp = fightingUnit.fight(targetUnit._hp);
            Console.WriteLine(fightingUnit._name + " нанёс ближнюю атаку в размере " + attak + " по " + targetUnit._name + ". Хп цели: " + targetUnit._hp);
        }

        static void RangedAtackUnit(Unit fightingUnit, Unit targetUnit)               //функция для дальней атаки
        {
            int attak;
            if (fightingUnit._upgraded == true)
                attak = Convert.ToInt32(fightingUnit._rangedAttack * fightingUnit._buff);
            else
                attak = fightingUnit._rangedAttack;
            targetUnit._hp = fightingUnit.rangedFight(targetUnit._hp);
            Console.WriteLine(fightingUnit._name + " нанёс дальнюю атаку в размере "  + attak + " по " + targetUnit._name + ". Хп цели: " + targetUnit._hp);
        }

        static void BuffUnit(Unit fightingUnit, Unit targetUnit)               //функция для улучшения атаки
        {
            targetUnit._upgraded = true;
            targetUnit._buff = fightingUnit._buff;
            Console.WriteLine(fightingUnit._name + " изменил атаку " + targetUnit._name + " на " + fightingUnit._buff);
        }

        static bool IsDead(Unit man)
        {
            if (man._hp <= 0)
            {
                Console.WriteLine(man._name + " умер.");
                return true;
            }
            else
                return false;
        }

        static void Winner(List<Unit> list)
        {
            Console.WriteLine("В живых остались: ");
            foreach(var a in list)
            {
                Console.WriteLine(a._name);
            }
        }
        

    }
}

