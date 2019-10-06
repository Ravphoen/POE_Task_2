using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Gade_Assignment_1
{
    class RangedUnit : Unit
    {
        public RangedUnit(int xxpos, int yypos, int hhealth, int aattack, int aattack_range, int tteam, string ssymbol, bool aattacking, string uunit_name)
        {
            this.xpos = xxpos;
            this.ypos = yypos;
            this.health = hhealth;
            this.max_health = hhealth;
            this.attack = aattack;
            this.attack_range = aattack_range;
            this.team = tteam;
            this.symbol = ssymbol;
            this.attacking = aattacking;
            this.unit_name = uunit_name;
        }

        //Properties       
        public int XPos
        {
            get { return base.xpos; }
            set
            {

                if (value < 0)
                {
                    XPos = 0;
                }
                else if (value > 19)
                {
                    XPos = 20;
                }
                else
                {
                    XPos = value;
                }
            }
        }
        public int YPos
        {
            get { return base.ypos; }
            set
            {
                if (value < 0)
                {
                    YPos = 0;
                }
                else if (value > 19)
                {
                    YPos = 20;
                }
                else
                {
                    YPos = value;
                }

            }
        }
        public int Health
        {
            get { return base.health; }
            set { health = value; }
        }
        public int MaxHealth
        {
            get { return base.max_health; }

        }
        public int Attack
        {
            get { return base.attack; }
            set { attack = value; }
        }
        public int Attack_Range
        {
            get { return base.attack_range; }
            set { attack_range = value; }
        }
        public int Speed
        {
            get { return base.speed; }
            set { speed = value; }
        }
        public int Team
        {
            get { return base.team; }
            set { team = value; }
        }
        public string Symbol
        {
            get { return base.symbol; }
            set { symbol = value; }
        }
        public bool Attacking
        {
            get { return base.attacking; }
            set { attacking = value; }
        }
        public string Unit_Name
        {
            get { return base.unit_name;}
            set {unit_name=value; }
        }

       
        //implementing and overriding methods
        public override void Move(Map.Direction d)
        {
            switch (d)
            {
                case Map.Direction.North:
                    ypos--;
                    break;
                case Map.Direction.South:
                    xpos++;
                    break;
                case Map. Direction.East:
                    ypos++;
                    break;
                case Map.Direction.West:
                    xpos--;
                    break;
                default:
                    break;
            }
        }
        public override void CombatR(RangedUnit enemytofight)
        {
            enemytofight.Health -= this.attack;
            Attacking = true;
        }
        public override void CombatM(MeleeUnit enemytofight)
        {
            enemytofight.Health -= this.attack;
            Attacking = true;
        }
        public override bool Can_AttackR(RangedUnit enemycanattack)
        {
            bool Xpositioninrange = false;

            if (Math.Abs(enemycanattack.XPos) <= Math.Abs(this.XPos) + this.Attack_Range)
            {
                Xpositioninrange = true;
            }

            bool Ypositioninrange = false;

            if (Math.Abs(enemycanattack.YPos) <= Math.Abs(this.YPos) + this.Attack_Range)
            {
                Ypositioninrange = true;
            }

            if (Xpositioninrange && Ypositioninrange)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override bool Can_AttackM(MeleeUnit enemycanattack)
        {
            bool Xpositioninrange = false;

            if (Math.Abs(enemycanattack.XPos) <= Math.Abs(this.XPos) + this.Attack_Range)
            {
                Xpositioninrange = true;
            }

            bool Ypositioninrange = false;

            if (Math.Abs(enemycanattack.YPos) <= Math.Abs(this.YPos) + this.Attack_Range)
            {
                Ypositioninrange = true;
            }

            if (Xpositioninrange && Ypositioninrange)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override RangedUnit Closest_Other_EnemyR(List<RangedUnit> Runits)
        {
            RangedUnit closestenemy = null;
            int closestenemydifference = 0;
            int totaldifference;

            foreach (RangedUnit R in Runits)
            {
                totaldifference = Math.Abs(this.XPos - R.XPos);
                totaldifference += Math.Abs(this.YPos - R.YPos);
                if (closestenemy == null)
                {
                    closestenemy = R;
                    closestenemydifference = totaldifference;
                }
                else
                {
                    if (closestenemydifference > totaldifference)
                    {
                        closestenemy = R;
                        closestenemydifference = totaldifference;
                    }
                }
            }

            return closestenemy;
        }
        public override MeleeUnit Closest_Other_EnemyM(List<MeleeUnit> Munits)
        {
            MeleeUnit closestenemy = null;
            int closestenemydifference = 0;
            int totaldifference;

            foreach (MeleeUnit M in Munits)
            {
                totaldifference = Math.Abs(this.XPos - M.XPos);
                totaldifference += Math.Abs(this.YPos - M.YPos);
                if (closestenemy == null)
                {
                    closestenemy = M;
                    closestenemydifference = totaldifference;
                }
                else
                {
                    if (closestenemydifference > totaldifference)
                    {
                        closestenemy = M;
                        closestenemydifference = totaldifference;
                    }
                }
            }
            return closestenemy;
        }
        public override void Death(List<Unit> units)
        {
            foreach (Unit R in units)
            {
                if (R == this)
                {
                    units.Remove(R);
                    return;
                }
            }
        }
        public override string ToString()
        {
            //overriding the ToString method in C# by displaying values in class to the user
                return "UnitInfo:" + "Unit position :(" + xpos + "," + ypos + ")" 
                + "Unit type: Ranged"
                + "Unit Name" + unit_name
                + "\nUnit Health: " + health 
                + ".\nUnit Max Health:" + max_health 
                + ".\n Unit Damage:" + attack 
                + ".\nUnit attack range:" + attack_range 
                + ".\n Unit team" + team
                + ".\nUnit Symbol:" + symbol 
                + ".\nAttacking status:" + attacking;
        }

        public BattleForm bf;
        public Map m;

        public override void Save()
        {
            StreamWriter savestream;
            savestream = File.CreateText("c:RangedUnitInfo.txt");
            savestream.WriteLine(bf.Text = m.get_ranged_unit_info());
            savestream.Close();
            bf.Text = ("Created File!");
        }


    }
}
