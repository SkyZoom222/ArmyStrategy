using Java.Util.Concurrent;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArmyStrategy.ArmyStrategy
{
    internal class Unit
    {
        int damage { get; }
        int hp;
        string type;
        int armor;
        int visibility_range;
        float speed;
        Vector2 point;
        Random rnd;

        public bool Live { get { return hp > 0; } }


        public Unit(int hp, int damage, int armor, float speed, int visibility_range, Vector2 point)
        {
            this.hp = hp;
            this.damage = damage;
            this.armor = armor;
            this.speed = speed;
            this.visibility_range = visibility_range;
            this.point = point;
            rnd = new Random();
        }

        public void ReducedHealth(int damage)
        {
            hp -= damage;
        }
        public void Moving()
        {

        }

        public Unit Copy()
        {
            return new Unit(hp, damage, armor, speed, visibility_range, point);
        }

    }
}
