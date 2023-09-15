using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.ArmyStrategy
{

    internal class Team
    {
        List<Unit> _units;
        List<Building> _buildings;

        int _money;

        int _MaxUnits; //проработать для разных типов

        Color _teamColor;

        Type _teamType;

        public List<Building> Buildings { get { return _buildings; } }
        public List<Unit> Units { get { return _units; } }
        public Unit AddUnit { set { _units.Add(value); } }

        public enum Type
        {
            Ork,
            People,
            Alien
        }

        public Team(Color color, Type type, int money)
        {
            _teamColor = color;
            _teamType = type;

            _units.Add(new Unit(10,10,10,10,10,new Vector2(0,0)));
        }



        public void SellBuilding(int id)
        {
            _money += _buildings[id].price / 2;
            _buildings.RemoveAt(id);

        }

        public void SellBuilding(Building building)
        {
            _money += building.price / 2;
            _buildings.Remove(building);
        }



        public bool Build(Building building)
        {
            if(building.price <= _money)
            {
                _buildings.Add(building);
                _money -= building.price;
                return true;
            }
            return false;
        }

        public bool CreateUnit(Unit unit)
        {
            foreach(var build in _buildings)
            {
                /*if(build.type == unit.type)
                {
                    build.EnqueueUnit = unit;
                }*/  //add type to unit
            }
            return false;
        }

    }
}
