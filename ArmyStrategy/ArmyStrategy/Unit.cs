using Android.App;
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
        int damage;
        int hp;
        string type;
        int armor;
        int visibility_range;
        float speed;
        Vector2 point;
        Queue<Vector2> trajectory;
        float speedX, speedY;

        public bool Live { get { return hp > 0; } }


        public Unit(int hp, int damage, int armor, float speed, int visibility_range, Vector2 point)
        {
            this.hp = hp;
            this.damage = damage;
            this.armor = armor;
            this.speed = speed;
            this.visibility_range = visibility_range;
            this.point = point;
            trajectory = new Queue<Vector2>(1000);
        }

        public void ReducedHealth(int damage)
        {
            hp -= damage;
        }

        public void DamageUnit(Unit unit)
        {
            unit.ReducedHealth(damage);
        }

        private void MoveToPoint(Vector2 end_point)
        {
            float dX = end_point.X - point.X;
            float dY = end_point.Y - point.Y;
            float ds = dY + dX;
            speedX = dX / ds;
            speedY = dY / ds;
            point = new Vector2(point.X + speedX * speed, point.Y + speedY * speed);
        }

/*        public void PathFinder(Vector2 reachPoint)
        {
            Line toFinalPoint = new Line(point, reachPoint);
            
            toFinalPoint.GetLine(100);
            for (int i = 0; i < ArmyStrategy.GameMap.Objects.Count; i++)
            {
                for (int j = 0; j < toFinalPoint.Points.Length; j++)
                {
                    if (((ArmyStrategy.GameMap.Objects[i].Contains(toFinalPoint.Points[j]) && (!ArmyStrategy.GameMap.Objects[i].Contains(toFinalPoint.Points[j++])))))
                    {
*//*                        double distance1 = Math.Sqrt(Math.Pow(ArmyStrategy.GameMap.Objects[i].X + toFinalPoint.Points[j].X + ArmyStrategy.GameMap.Objects[i].Width * 2, 2)
                        + Math.Pow(ArmyStrategy.GameMap.Objects[i].Y + toFinalPoint.Points[j].Y, 2));
                        double distance2 = Math.Sqrt(Math.Pow(ArmyStrategy.GameMap.Objects[i].X + toFinalPoint.Points[j].X + ArmyStrategy.GameMap.Objects[i].Width * 2, 2) + 
                        Math.Pow(ArmyStrategy.GameMap.Objects[i].Y + toFinalPoint.Points[j].Y + ArmyStrategy.GameMap.Objects[i].Height * 2, 2));*//*

                        Line originL = new Line(point, toFinalPoint.Points[j]);
                        Line leftL = new Line(point, toFinalPoint.Points[j]);
                        Line rightL = new Line(point, toFinalPoint.Points[j]);
                        originL.GetLine(100);
                        leftL.GetLine(100);
                        rightL.GetLine(100);
                        float angle = 0.2F;
                        while (true)
                        {
                            leftL.Rotate(angle, false);
                            rightL.Rotate(-angle, false);
                            for (int l = 0; l < leftL.Points.Length; l++)
                            {
                                if ((ArmyStrategy.GameMap.Objects[i].Contains(leftL.Points[l])))
                            }
                            angle += 0.2F;
                        }
                    }

                } 

            }
        }*/

        public Unit Copy()
        {
            return new Unit(hp, damage, armor, speed, visibility_range, point);
        }
    }
}
