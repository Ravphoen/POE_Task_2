using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gade_Assignment_1
{
    //enum storing directions
    
    abstract class Unit
    {
        protected int xpos;
        protected int ypos;
        protected int health;
        protected int max_health;
        protected int speed;
        protected int attack;
        protected int attack_range;
        protected int team;
        protected string symbol;
        protected bool attacking;
        protected string unit_name;

        //method to move it around
        public abstract void Move(Map.Direction d);
        public abstract void CombatM(MeleeUnit enemytofight);
        public abstract void CombatR(RangedUnit enemytofight);
        public abstract bool Can_AttackM(MeleeUnit enemycanattack);
        public abstract bool Can_AttackR(RangedUnit enemycanattack);
        public abstract RangedUnit Closest_Other_EnemyR(List<RangedUnit> rangedUnits);
        public abstract MeleeUnit Closest_Other_EnemyM(List<MeleeUnit> meleeUnits);
        public abstract void Death(List<Unit> units);
        public abstract void Save();

        //public override string ToString()
        //{
        //    return 
        //        "Unit position :(" + xpos + "," + ypos + ")" 
        //        +"\nUnit Health: " + health 
        //        +".\nUnit Max Health:"+max_health
        //        +".\n Unit Damage:" + attack 
        //        +".\nUnit attack range:"+attack_range
        //        +".\n Unit team"+team
        //        +".\nUnit Symbol:"+symbol
        //        +".\nAttacking status:"+attacking;
        //}

    }
}
