using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gade_Assignment_1
{
    abstract class Building
    {
        protected int b_xpos;
        protected int b_ypos;
        protected int b_health;
        protected int b_max_health;
        protected int b_team;
        protected string b_symbol;

        public abstract void Death(List<Building>buildings);
        public abstract void Save();

        //public override string ToString()
        //{
        //    //overriding the ToString method in C# by displaying values in class to the user
        //    return "BuildingInfo:" + "Building position :(" + xpos + "," + ypos + ")"
        //    + "\nBuilding Health: " + health
        //    + ".\nBuilding Max Health:" + max_health
        //    + ".\nBuilding team" + team
        //    + ".\nBuilding Symbol:" + symbol
        //    ;
        //}
    }
}
