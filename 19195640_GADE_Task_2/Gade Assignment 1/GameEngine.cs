using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gade_Assignment_1
{
    class GameEngine 
    {
        public GameEngine()
        {
            roundscompleted = 0;
            map = new Map(20,12);
            map.UnitGeneration();
            map.BuildingGeneration();
        }
        public Map map;

        private int roundscompleted;

        public int RoundsCompleted
        {
            get { return roundscompleted;}          
        }       
        public void startround()
        {
            foreach (RangedUnit R in map.rangedUnits)
            {
                Unit enemy = checkforenemies(R);
                if (enemy != null)
                {
                    if (R.Health >= 25/100*R.MaxHealth)
                    {
                        //movecloser
                        R.Move(Movecloser());
                        if (enemy is RangedUnit)
                        {
                            RangedUnit Enemy = enemy as RangedUnit;
                            if (R.Can_AttackR(Enemy))
                            {
                                R.CombatR(Enemy);
                            }
                        }
                        if (enemy is MeleeUnit)
                        {
                            MeleeUnit Enemy = enemy as MeleeUnit;
                            if (R.Can_AttackM(Enemy))
                            {
                                R.CombatM(Enemy);
                            }
                        }
                    }
                    else
                    {
                        R.Move(RunAway());
                        //run away 
                    }
                }
                else
                {
                    //do nothing
                }
            }
            foreach (MeleeUnit R in map.meleeUnits)
            {
                Unit enemy = checkforenemies(R);
                if (enemy != null)
                {
                    if (R.Health >= 25 / 100 * R.MaxHealth)
                    {
                        //movecloser
                        R.Move(Movecloser());
                        if (enemy is RangedUnit)
                        {
                            RangedUnit Enemy = enemy as RangedUnit;
                            if (R.Can_AttackR(Enemy))
                            {
                                R.CombatR(Enemy);
                            }
                        }
                        if (enemy is MeleeUnit)
                        {
                            MeleeUnit Enemy = enemy as MeleeUnit;
                            if (R.Can_AttackM(Enemy))
                            {
                                R.CombatM(Enemy);
                            }
                        }
                    }
                    else
                    {
                        R.Move(RunAway());
                        //run away 
                    }
                }
                else
                {
                    //do nothing
                }
            }
            roundscompleted++;
        }
        public void MapUpdate()
        {


        }
        public string Updateunit()
        {
            string info =
                map.get_melee_unit_info()
                +map.get_ranged_unit_info();
            return info;
            
        }
        public string Updatebuilding()
        {
            string info = 
                map.get_factory_building_info()
                + map.get_resource_building_info();
            return info;

        }
        public string Updatedisplay()
        {
            return map.DisplayMap();
        }
        public Unit checkforenemies(Unit lookingforenemies)
        {
            if (lookingforenemies is RangedUnit)
            {
                RangedUnit enemy = lookingforenemies as RangedUnit;
                enemy = lookingforenemies.Closest_Other_EnemyR(map.rangedUnits);
                return enemy;
            }
            else if (lookingforenemies is MeleeUnit)
            {
                MeleeUnit enemy = lookingforenemies as MeleeUnit;
                enemy = lookingforenemies.Closest_Other_EnemyM(map.meleeUnits);
                return enemy;
            }
            else
            {
                return null;
            }

        }
        public Map.Direction RunAway()
        {
            return Map.Direction.North;
        }
        public Map.Direction Movecloser()
        {
            return Map.Direction.West;
        }
    }
}
