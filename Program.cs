using System;
using System.Collections.Generic;
using System.IO;

namespace QATestLabGame
{
    internal class Unit
    {
        public int _hp;                             //Units hit points
        public int _attack;                         //Units attack
        public int _rangedAttack;                   //Units ranged attack
        public double _buff;                        //Units buff or debuff
        public readonly string _name;               //Units name
        public bool _upgraded = false;              //flag about upgraded group
        public Unit(string name)                    //Base constructor
        {
            _name = name;
            _hp = 100;
            _attack = 0;
            _rangedAttack = 0;
            _buff = 1;
        }
        public int Fight(int enemyHp)               //Mili attack method
        {                                               
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
        public int RangedFight(int enemyHp)         //Ranged attack method
        {                                                    
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

    internal class HumanMage: Unit                  //Class for Human Mage
    {
        public HumanMage(string name): base(name)
        {
            _attack = 4;
            _buff = 1.5;
        }
    }

    internal class HumanFighter: Unit               //Class for Human Fighter
    {
        public HumanFighter(string name): base(name)
        {
            _attack = 18;
        }
    }

    internal class HumanArcher: Unit               //Class for Human Archer
    {
        public HumanArcher(string name):base(name)
        {
            _attack = 3;
            _rangedAttack = 5;
        }  
    }

    internal class ElfMage: Unit                    //Class for Elf Mage
    {
        public ElfMage(string name): base(name)
        {
            _attack = 10;
            _buff = 1.5;
        }
    }

    internal class ElfArcher: Unit                  //Class for Elf Archer
    {
        public ElfArcher(string name) : base(name)
        {
            _attack = 3;
            _rangedAttack = 7;
        }
    }

    internal class ElfFighter: Unit                 //Class for Elf Fighter
    {
        public ElfFighter(string name) : base(name)
        {
            _attack = 15;
        }
    }

    internal class OrcMage: Unit                    //Class for Orc Mage
    {
        public OrcMage(string name) : base(name)               
        {
           _buff = 1.5;
        }
    }

    internal class OrcFighter: Unit                    //Class for Orc Fighter
    {
        public OrcFighter(string name) : base(name)
        {
            _attack = 20;
        }
    }

    internal class OrcArcher: Unit                    //Class for Orc Archer
    {
        public OrcArcher(string name) : base(name)
        {
            _attack = 2;
            _rangedAttack = 3;
        }
    }

    internal class DeadMage: Unit                    //Class for Dead Mage
    {
        public DeadMage(string name):base(name)
        {
            _attack = 5;
            _buff = 0.5;
        }
    }

    internal class DeadArcher: Unit                    //Class for Dead Archer
    {
        public DeadArcher(string name):base(name)
        {
            _attack = 2;
            _rangedAttack = 4;
        }
    }

    internal class DeadFighter: Unit                    //Class for Dead Fighter
    {
        public DeadFighter(string name):base(name)
        {
            _attack = 18;
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////

    internal static class Program
    {
        public static void Shuffle<T>(this IList<T> list)                       //Method for rindomizing list before the round
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

        public static void Main(string[] args)
        {
            try
            {
                StreamWriter sw = new StreamWriter("./GameLog.txt");             //opening log file                 
                bool continueGame = true;                                               //Flag for for continuing/ending game
                bool winner = true;                                                        //if winner == true lightside wins and opposite  !important!   
                Random rand = new Random();
                List<Unit> lightList = new List<Unit>();
                List<Unit> darkList = new List<Unit>();
                if (rand.Next(0, 2) == 0)                                                         //Creating of light side
                {
                    Console.WriteLine("Первый отряд состоит из людей.");
                    sw.WriteLine("Первый отряд состоит из людей.");
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
                    sw.WriteLine("Первый отряд состоит из эльфов.");
                    lightList.Add(new ElfMage("Эльф маг"));
                    lightList.Add(new ElfFighter("Первый эльф воин"));
                    lightList.Add(new ElfFighter("Второй эльф воин"));
                    lightList.Add(new ElfFighter("Третий эльф воин"));
                    lightList.Add(new ElfFighter("Четвертый эльф воин"));
                    lightList.Add(new ElfArcher("Первый эльф лучник"));
                    lightList.Add(new ElfArcher("Второй эльф лучник"));
                    lightList.Add(new ElfArcher("Третий эльф лучник"));
                }
                if (rand.Next(0, 2) == 0)                                                            //Creating of dark side
                {
                    Console.WriteLine("Второй отряд состоит из орков.");
                    sw.WriteLine("Второй отряд состоит из орков.");
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
                    sw.WriteLine("Второй отряд состоит из нежити.");
                    darkList.Add(new DeadMage("Некромант"));
                    darkList.Add(new DeadFighter("Первый зомби"));
                    darkList.Add(new DeadFighter("Второй зомби"));
                    darkList.Add(new DeadFighter("Третий зомби"));
                    darkList.Add(new DeadFighter("Четвертый зомби"));
                    darkList.Add(new DeadArcher("Первый охотник"));
                    darkList.Add(new DeadArcher("Второй охотник"));
                    darkList.Add(new DeadArcher("Третий охотник"));
                }

                //--------------------------------------------------------- game --------------------------------------------------------------------


                do
                {
                    Shuffle(lightList);                                         //randomizing lists
                    Shuffle(darkList);
                    foreach (var list in lightList)                             //beginning of light side round
                    {
                        int whomEnemy = rand.Next(0, darkList.Count);           //detecting of friend target
                        int whomFriend = rand.Next(0, lightList.Count);         //detecting of enemy target
                        switch (list.GetType().Name)                            //detecting unit
                        {
                            case "HumanFighter":                                //case for fighters
                            case "ElfFighter":
                                {
                                    if (darkList.Count != 0)                     //checking if dark powers are not dead
                                    {
                                        AtackUnit(list, darkList[whomEnemy], sw);
                                        if (IsDead(darkList[whomEnemy], sw))
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

                            case "HumanMage":                                   //case for light mages
                            case "ElfMage":
                                {
                                    if (darkList.Count != 0)
                                    {
                                        if (rand.Next(0, 2) == 0)                       //mage atacking
                                        {
                                            AtackUnit(list, darkList[whomEnemy], sw);
                                            if (IsDead(darkList[whomEnemy], sw))
                                            {
                                                darkList.RemoveAt(whomEnemy);
                                            }
                                        }
                                        else
                                        {                                                   //mage upgrading
                                            if (lightList[whomFriend]._upgraded == false)
                                                BuffUnit(list, lightList[whomFriend], sw);
                                            else
                                            {
                                                whomFriend = rand.Next(0, lightList.Count);
                                                BuffUnit(list, lightList[whomFriend], sw);
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
                            case "HumanArcher":                                 //case for archers
                            case "ElfArcher":
                                {
                                    if (darkList.Count != 0)
                                    {
                                        if (rand.Next(0, 2) == 0)               //detecting ranged or mili atack
                                        {
                                            AtackUnit(list, darkList[whomEnemy], sw);
                                        }
                                        else
                                        {
                                            RangedAtackUnit(list, darkList[whomEnemy], sw);
                                        }
                                        if (IsDead(darkList[whomEnemy], sw))
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
                    foreach (var list in darkList)                             //beginning of dark side round
                    {
                        int whomEnemy = rand.Next(0, lightList.Count);          //detecting of friend target
                        int whomFriend = rand.Next(0, darkList.Count);         //detecting of enemy target
                        switch (list.GetType().Name)                            //detecting unit
                        {
                            case "DeadFighter":                               //case for fighters
                            case "OrcFighter":
                                {
                                    if (lightList.Count != 0)                     //checking if light powers are not dead
                                    {
                                        AtackUnit(list, lightList[whomEnemy], sw);
                                        if (IsDead(lightList[whomEnemy], sw))
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

                            case "DeadMage":                                      //case for dead mage
                                {
                                    if (lightList.Count != 0)
                                    {
                                        if (rand.Next(0, 2) == 0)
                                        {
                                            AtackUnit(list, lightList[whomEnemy], sw);          //atacking case
                                            if (IsDead(lightList[whomEnemy], sw))
                                            {
                                                lightList.RemoveAt(whomEnemy);
                                            }
                                        }
                                        else
                                        {                                                   //debuffing case
                                            if (lightList[whomEnemy]._upgraded == false)
                                                BuffUnit(list, lightList[whomEnemy], sw);
                                            else
                                            {
                                                whomEnemy = rand.Next(0, lightList.Count);
                                                BuffUnit(list, lightList[whomEnemy], sw);
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
                            case "OrcMage":                               //case for orc mage
                                {
                                    if (lightList.Count != 0)
                                    {
                                        if (rand.Next(0, 2) == 0)
                                        {
                                            bool up = false;
                                            foreach (var l in lightList)                 //debuff case
                                            {
                                                if (l._upgraded == true)
                                                {
                                                    l._upgraded = false;
                                                    Console.WriteLine(list._name + "снял улучшение с" + l._name);
                                                    sw.WriteLine(list._name + "снял улучшение с" + l._name);
                                                    up = true;
                                                    break;
                                                }

                                            }
                                            if (up == false)
                                            {
                                                Console.WriteLine(list._name + " попытался снять улучшение, но никого не нашел.");
                                                sw.WriteLine(list._name + " попытался снять улучшение, но никого не нашел.");
                                            }
                                        }
                                        else
                                        {
                                            if (darkList[whomFriend]._upgraded == false)                        //buff case
                                                BuffUnit(list, darkList[whomFriend], sw);
                                            else
                                            {
                                                whomFriend = rand.Next(0, darkList.Count);
                                                BuffUnit(list, darkList[whomFriend], sw);
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
                            case "DeadArcher":                                  //archer case
                            case "OrcArcher":
                                {
                                    if (lightList.Count != 0)
                                    {
                                        if (rand.Next(0, 2) == 0)
                                        {
                                            AtackUnit(list, lightList[whomEnemy], sw);              //mili atack
                                        }
                                        else
                                        {
                                            RangedAtackUnit(list, lightList[whomEnemy], sw);        //ranged atack
                                        }
                                        if (IsDead(lightList[whomEnemy], sw))
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

                while (continueGame == true);                         //condition for ending game
                if (winner)                                          //detecting of winner
                {
                    Console.WriteLine("Победили силы света. ");
                    sw.WriteLine("Победили силы света. ");
                    Winner(lightList, sw);
                }
                else
                {
                    Console.WriteLine("Победили силы тьмы. ");
                    sw.WriteLine("Победили силы тьмы. ");
                    Winner(darkList, sw);
                }
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);           //exeption if there were problems with file
            }
            Console.ReadKey();

        }

        private static void AtackUnit(Unit fightingUnit, Unit targetUnit, StreamWriter sw)               //mili attack function
        {
            int attak;
            if (fightingUnit._upgraded == true)                                         //checking if unit was upgraded
            {
                attak = Convert.ToInt32(fightingUnit._attack * fightingUnit._buff);
            }
            else
            {
                attak = fightingUnit._attack;
            }
            targetUnit._hp = fightingUnit.Fight(targetUnit._hp);                        //changing of target hit points
            Console.WriteLine(fightingUnit._name + " нанёс ближнюю атаку в размере " + attak + " по юниту " + targetUnit._name + ". Хп цели: " + targetUnit._hp);
            sw.WriteLine(fightingUnit._name + " нанёс ближнюю атаку в размере " + attak + " по юниту " + targetUnit._name + ". Хп цели: " + targetUnit._hp);
        }


        private static void RangedAtackUnit(Unit fightingUnit, Unit targetUnit, StreamWriter sw)               //ranged attack function
        {
            int attak;
            if (fightingUnit._upgraded == true)                                         //checking if unit was upgraded
            {
                attak = Convert.ToInt32(fightingUnit._rangedAttack * fightingUnit._buff);
            }
            else
            {
                attak = fightingUnit._rangedAttack;
            }
            targetUnit._hp = fightingUnit.RangedFight(targetUnit._hp);                        //changing of target hit points
            Console.WriteLine(fightingUnit._name + " нанёс дальнюю атаку в размере "  + attak + " по юниту " + targetUnit._name + ". Хп цели: " + targetUnit._hp);
            sw.WriteLine(fightingUnit._name + " нанёс дальнюю атаку в размере " + attak + " по юниту " + targetUnit._name + ". Хп цели: " + targetUnit._hp);
        }


        private static void BuffUnit(Unit fightingUnit, Unit targetUnit, StreamWriter sw)               //buffing attack function
        {
            targetUnit._upgraded = true;                                                //changing buff flag of target
            targetUnit._buff = fightingUnit._buff;                                      //changing buff of target
            Console.WriteLine(fightingUnit._name + " изменил атаку юнита " + targetUnit._name + " на " + fightingUnit._buff);
            sw.WriteLine(fightingUnit._name + " изменил атаку юнита " + targetUnit._name + " на " + fightingUnit._buff);
        }

        private static bool IsDead(Unit man, StreamWriter sw)                                //function for checking if unit is dead
        {
            if (man._hp <= 0)
            {
                Console.WriteLine(man._name + " умер.");
                sw.WriteLine(man._name + " умер.");
                return true;
            }
            else
                return false;
        }

        private static void Winner(List<Unit> list, StreamWriter sw)                         //function for detecting winner
        {
            Console.WriteLine("В живых остались: ");
            sw.WriteLine("В живых остались: ");
            foreach (var a in list)
            {
                Console.WriteLine(a._name);
                sw.WriteLine(a._name);
            }
        }
        

    }
}

