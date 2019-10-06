using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Gade_Assignment_1
{
    class ResourceBuilding : Building
    {
        public ResourceBuilding(int xxpos, int yypos, int hhealth, int tteam, string ssymbol)
        {
            this.b_xpos = xxpos;
            this.b_ypos = yypos;
            this.b_health = hhealth;
            this.b_max_health= hhealth;
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


        //new resource bulding fields
        string resource_type;
        int resources_generated;
        int resources_per_round;//will generate 1 per round
        int remaning_resources;
       

        public void ResourceGeneration()
        {
            resources_generated = 1;
            if(resources_generated != 0)
            {
                resources_generated++;
                remaning_resources = resources_generated;
            }
            else if(resources_generated == 0)
            {
               //do nothing 
            }
        }

        //implementing and overriding methods
        public override void Death(List<Building>buildings)
        {

            foreach (Building RB in buildings)
            {
                if (RB == this)
                {
                    buildings.Remove(RB);
                    return;
                }
            }
        }
        public override string ToString()
        {
            //overriding the ToString method in C# by displaying values in class to the user
            return "BuildingInfo:" + "Building position :(" + b_xpos + "," + b_ypos + ")"
            + "Building type: Resource Building"
            + "\nBuilding Health: " + b_health
            + ".\nBuilding Max Health:" + b_max_health
            + ".\nBuilding team" + b_team
            + ".\nBuilding Symbol:" + b_symbol
            ;
        }

        public Map m;
        BattleForm bf = new BattleForm();

        public override void Save()
        {
            StreamWriter savestream;
            savestream = File.CreateText("c:ResourceBuildingInfo.txt");
            savestream.WriteLine(bf.Text = m.get_resource_building_info());
            savestream.Close();
            bf.Text = ("Created File!");
        }
    }
}
