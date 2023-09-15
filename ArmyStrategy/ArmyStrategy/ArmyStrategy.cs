using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.ArmyStrategy
{

    public enum Type
    {
        Base,
        Melee,
        Range,
        Tank,
        Shield,
        Turret,
        House
    }


    internal class ArmyStrategy
    {

        public static Map GameMap;

        public static Team Team1;


        public ArmyStrategy()
        {
            Team1 = new Team(Color.Red, Team.Type.People, 10000);
        }

        public void Update()
        {
            
        }
    }
}
