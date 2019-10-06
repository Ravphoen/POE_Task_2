using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Gade_Assignment_1
{
    class FactoryBuilding:Building
    {
        public bool destroyed { get; set; }
        public FactoryBuilding(int xxpos, int yypos, int hhealth, int tteam, string ssymbol)
        {
            this.b_xpos = xxpos;
            this.b_ypos = yypos;
            this.b_health = hhealth;
            this.b_max_health = hhealth;
            this.b_team = tteam;
            this.b_symbol = ssymbol;
        }
        //properties
        public int XPos
        {
            get { return base.b_xpos; }
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
            get { return base.b_ypos; }
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
            get { return base.b_health; }
            set { b_health = value; }
        }
        public int MaxHealth
        {
            get { return base.b_max_health; }
        }
        public int Team
        {
            get { return base.b_team; }
            set { b_team = value; }
        }
        public string Symbol
        {
            get { return base.b_symbol; }
            set { b_symbol = value; }
        }

        //new factory building fields.
        
        public int production_speed//
        {
            get { return production_speed; }
        }

        int spawn_point;


        public override void Death(List<Building>buildings)
        {
            foreach (Building FB in buildings)
            {
                if (FB == this)
                {
                    buildings.Remove(FB);
                    return;
                }
            }
        }
        public override string ToString()
        {
            string info = "";
            info += "Factory Building";
            if (Unit_type == 0)
            {
                info += "Producing Melee Units";
            }
            else
            {
                info += "Producing Ranged Units";
            }
            info += "{" + base.symbol + "}";
            info += "(" + xpos + "," + ypos + ")";
            info += (IsDead ? " This building is destroyed" : " This building is fully operational");
            return info;
        }

        public BattleForm bf;
        public Map m;


        public override void Save()
        {

            //StreamWriter savestream;
            //savestream = File.CreateText("c:FactoryBuildingInfo.txt");
            //savestream.WriteLine(bf.Text = m.get_factory_building_info());
            //savestream.Close();
            //bf.Text = ("Created File!");
        }
        //
        public Map map;
        Random r = new Random();

        public void UnitSpawner()
        {

        }
    }
}
