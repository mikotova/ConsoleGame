using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                enemyHp -= Convert.ToInt32(_attack * _buff);                            //wrong buff
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
    class HumanMage:Unit
    {
        public HumanMage(string name) : base(name)
        {
            _attack = 10;
            _buff = 1.5;
        }
    }
    class HumanFighter: Unit {
        public HumanFighter(string name):base(name)
        {
            _attack = 15;
        }
    }
    class HumanArcher : Unit{
        public HumanArcher(string name):base(name)
        {
            _attack = 3;
            _rangedAttack = 7;
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
    class DeadMage : Unit {
        public DeadMage(string name):base(name)
        {
            _attack = 5;
            _buff = 0.5;
        }
    }
    class DeadArcher: Unit {
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
            List<Unit> lightList = new List<Unit>();
            List<Unit> darkList = new List<Unit>();
            //   if (rand.Next(0, 2) == 0)                                   //Создание силы света
            if (true)
            {
                Console.WriteLine("Первый отряд состоит из людей.");
                mage1 = new HumanMage("Человек маг");
                fighter1 = new HumanFighter("Первый человек воин");
                fighter2 = new HumanFighter("Второй человек воин");
                fighter3 = new HumanFighter("Третий человек воин");
                fighter4 = new HumanFighter("Четвертый человек воин");
                archer1 = new HumanArcher("Первый человек лучник");
                archer2 = new HumanArcher("Второй человек лучник");
                archer3 = new HumanArcher("Третий человек лучник");
                lightList.Add(mage1);                                                               //todo доработать
                lightList.Add(fighter1);
                lightList.Add(fighter2);
                lightList.Add(fighter3);
                lightList.Add(fighter4);
                lightList.Add(archer1);
                lightList.Add(archer2);
                lightList.Add(archer3);
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
            //           if (rand.Next(0, 2) == 0)                               //создание силы тьмы
            if(false)
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
                Console.WriteLine("Второй отряд состоит из нежити.");
                dmage1 = new DeadMage("Некромант");
                dfighter1 = new DeadFighter("Первый зомби");
                dfighter2 = new DeadFighter("Второй зомби");
                dfighter3 = new DeadFighter("Третий зомби");
                dfighter4 = new DeadFighter("Четвертый зомби");
                darcher1 = new DeadArcher("Первый охотник");
                darcher2 = new DeadArcher("Второй охотник");
                darcher3 = new DeadArcher("Третий охотник");
                darkList.Add(dmage1);                                                               //todo доработать
                darkList.Add(dfighter1);
                darkList.Add(dfighter2);
                darkList.Add(dfighter3);
                darkList.Add(dfighter4);
                darkList.Add(darcher1);
                darkList.Add(darcher2);
                darkList.Add(darcher3);
            }

            /////////////////////////////////////////////////////////////////////////////// game ////////////////////////////////////////////////////////////////////////////////////////
            do
            {
                foreach (var list in lightList)
                {
                    int whom = rand.Next(0, 8);
                    switch (list.GetType().Name)
                    {
                        case "HumanFighter":
                            {
                                AtackUnit(list, darkList[whom]);
                                
                                break;                                                      //todo: death
                            }

                        case "HumanMage":
                            {
                                if (rand.Next(0, 2) == 0)
                                {
                                    AtackUnit(list, darkList[whom]);
                                }
                                else
                                {
                                    if (lightList[whom]._upgraded == false)
                                        BuffUnit(list, lightList[whom]);
                                    else
                                    {
                                        whom = rand.Next(0, 8);
                                        BuffUnit(list, lightList[whom]);
                                    }
                                }
                                break;
                            }
                        case "HumanArcher":
                            {
                                if (rand.Next(0, 2) == 0)
                                {
                                    AtackUnit(list, darkList[whom]);
                                }
                                else
                                {
                                    RangedAtackUnit(list, darkList[whom]);
                                }
                                break;
                            }
                    }
                }
                foreach (var list in darkList)
                {
                    int whom = rand.Next(0, 8);
                    switch (list.GetType().Name)
                    {
                        case "DeadFighter":
                            {
                                AtackUnit(list, lightList[whom]);
                                break;
                            }

                        case "DeadMage":
                            {
                                if (rand.Next(0, 2) == 0)
                                {
                                    AtackUnit(list, lightList[whom]);
                                }
                                else
                                {
                                    if (lightList[whom]._upgraded == false)
                                        BuffUnit(list, lightList[whom]);
                                    else
                                    {
                                        whom = rand.Next(0, 8);
                                        BuffUnit(list, lightList[whom]);
                                    }
                                }
                                break;
                            }
                        case "DeadArcher":
                            {
                                if (rand.Next(0, 2) == 0)
                                {
                                    AtackUnit(list, lightList[whom]);
                                }
                                else
                                {
                                    RangedAtackUnit(list, lightList[whom]);
                                }
                                break;
                            }
                    }
                }
            }
            while (lightList[0]._hp > 0);

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
        static void AtackUnit(Unit fightingUnit, Unit targetUnit)               //функция для атаки
        {
            targetUnit._hp = fightingUnit.fight(targetUnit._hp);
            Console.WriteLine(fightingUnit._name + " нанёс ближнюю атаку по " + targetUnit._name + ". Хп цели: " + targetUnit._hp);
        }

        static void RangedAtackUnit(Unit fightingUnit, Unit targetUnit)               //функция для дальней атаки
        {
            targetUnit._hp = fightingUnit.rangedFight(targetUnit._hp);
            Console.WriteLine(fightingUnit._name + " нанёс дальнюю атаку по " + targetUnit._name + ". Хп цели: " + targetUnit._hp);
        }

        static void BuffUnit(Unit fightingUnit, Unit targetUnit)               //функция для улучшения атаки
        {
            targetUnit._upgraded = true;
            targetUnit._buff = fightingUnit._buff;
            Console.WriteLine(fightingUnit._name + " изменил атаку " + targetUnit._name + " на " + fightingUnit._buff);
        }
        
    }
}

