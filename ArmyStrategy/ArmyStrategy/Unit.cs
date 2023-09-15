using Android.App;
using Java.Util;
using Java.Util.Concurrent;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrategyGame.ArmyStrategy
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
        Queue<Vector2> Trajectory;
        float speedX, speedY;

        //pathFinder
        int sens = 50;
        int ObjSize = 50;
        int MaxLines = 20;

        Vector2 nextpoint;

        bool moveTo = false;

        public bool Live { get { return hp > 0; } }


        public Unit(int hp, int damage, int armor, float speed, int visibility_range, Vector2 point)
        {
            this.hp = hp;
            this.damage = damage;
            this.armor = armor;
            this.speed = speed;
            this.visibility_range = visibility_range;
            this.point = point;
            Trajectory = new Queue<Vector2>(1000);
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

        private void PathFinder1(Vector2 end)
        {
            Trajectory = new Queue<Vector2>(MaxLines);

            Line MasterLine = new Line(point, end);
            Line Temp = PathFinder1Helper(MasterLine);

            for (int i = 0; i < MaxLines; i++)
            {
                if (Temp.point2.X == end.X && Temp.point2.Y == end.Y)
                {
                    Trajectory.Enqueue(Temp.point2);
                    return;
                }
                else
                {
                    Trajectory.Enqueue(Temp.point2);
                    Temp = new Line(Temp.point1, Temp.point2);
                    Vector2 Vtemp = Temp.point2;
                    Temp.point2 = end;
                    Temp.point1 = Vtemp;
                    Temp = PathFinder1Helper(Temp);
                }
            }

        }

        private Line PathFinder1Helper(Line MasterLine)
        {
            MasterLine.GetLine(sens);
            bool ObjEndFlag = false;
            for (int i = 0; i < ArmyStrategy.GameMap.Objects.Count; i++)
            {

                int startP = 0;
                for (int p = 0; p < MasterLine.Points.Length; p++)
                {
                    if (new Rectangle(ArmyStrategy.GameMap.Objects[i].Location, new Point(ObjSize)).Contains(MasterLine.Points[p]))
                    {
                        //if (!ObjEndFlag) startP = p;
                        ObjEndFlag = true;
                    }
                    else if (ObjEndFlag)
                    {
                        MasterLine.point2 = MasterLine.Points[p];
                        break;
                    }
                }
                if (ObjEndFlag) break;
            }
            if (!ObjEndFlag) return MasterLine;
            MasterLine.GetLine(sens);
            Line LineL = new Line(MasterLine.point1, MasterLine.point2);
            Line LineR = new Line(MasterLine.point1, MasterLine.point2);
            LineL.GetLine(sens);
            LineR.GetLine(sens);

            int ind = 0;
            while (true)
            {
                ind++;
                if (ind > 100) break;
                LineR.Rotate(0.1f, false);
                LineL.Rotate(-0.1f, false);

                bool RBreak = false;
                bool LBreak = false;


                for (int R = 0; R < ArmyStrategy.GameMap.Objects.Count; R++)
                {
                    foreach (var p in LineR.Points)
                    {
                        if (new Rectangle(ArmyStrategy.GameMap.Objects[R].Location, new Point(ObjSize)).Contains(p)) RBreak = true;
                        if (RBreak) break;
                    }
                    if (RBreak) break;
                }

                for (int L = 0; L < ArmyStrategy.GameMap.Objects.Count; L++)
                {
                    foreach (var p in LineL.Points)
                    {
                        if (new Rectangle(ArmyStrategy.GameMap.Objects[L].Location, new Point(ObjSize)).Contains(p)) LBreak = true;
                        if (LBreak) break;
                    }
                    if (LBreak) break;
                }

                if (!LBreak) return LineL;
                else if (!RBreak) return LineR;

            }

            return MasterLine;
        }

        public void GoTo(Vector2 end)
        {
            PathFinder1(end);
            moveTo = true;
        }

        public void Update()
        {
            if(moveTo)
            {
                if (point.X < nextpoint.X + 5 && point.X > nextpoint.X - 5 &&
                    point.Y < nextpoint.Y + 5 && point.Y < nextpoint.Y - 5)
                {
                    try
                    {
                        nextpoint = Trajectory.Dequeue();
                    }
                    catch
                    {
                        moveTo = false;
                    }
                }
                else MoveToPoint(nextpoint);
            }
        }

        public Unit Copy()
        {
            return new Unit(hp, damage, armor, speed, visibility_range, point);
        }
    }
}
