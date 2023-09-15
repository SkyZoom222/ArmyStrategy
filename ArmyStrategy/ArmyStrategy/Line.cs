using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.ArmyStrategy
{
    internal class Line
    {
        public Vector2 point1;
        public Vector2 point2;
        int count;
        
        public Vector2[] Points;

        public double Kfunc = 0, Bfunc;



        public Line(Vector2 point1, Vector2 point2) 
        {
            this.point1 = point1;
            this.point2 = point2;
        }
        public Line(int x1, int y1, int x2, int y2)
        {
            point1 = new Vector2(x1, y1);
            point2 = new Vector2(x2, y2);
        }

        public void GetLine(int count1, bool getfunc = false)
        {
            this.count = count1;
            Vector2[] points = new Vector2[count];
            Vector2 delta = point2 - point1;
            delta.X /= count;
            delta.Y /= count;
            for(int i = 0; i<points.Length; i++)
            {
                points[i].X = point1.X + delta.X * i;
                points[i].Y = point1.Y + delta.Y * i;
            }
            Points = points;
            if (getfunc) GetFunc();
        }
        /*X = (x — x0) *cos(alpha) — (y — y0) *sin(alpha) + x0;
            Y = (x — x0) *sin(alpha) + (y — y0) *cos(alpha) + y0;*/
        public void Rotate(float angle , bool inversion)
        {
            if(inversion)
            {

                float point1x = (float)((point1.X - point2.X) * Math.Cos(angle) - (point1.Y - point2.Y) * Math.Sin(angle) + point2.X);
                float point1y = (float)((point1.X - point2.X) * Math.Sin(angle) + (point1.Y - point2.Y) * Math.Cos(angle) + point2.Y);
                point1.X = point1x;
                point1.Y = point1y;
            }
            else
            {
                float point2x = (float)((point2.X - point1.X) * Math.Cos(angle) - (point2.Y - point1.Y) * Math.Sin(angle) + point1.X);
                float point2y = (float)((point2.X - point1.X) * Math.Sin(angle) + (point2.Y - point1.Y) * Math.Cos(angle) + point1.Y);
                point2.X = point2x;
                point2.Y = point2y;
            }
            
            GetLine(count);
        }

        public void GetFunc()
        {
            Kfunc = (point1.Y - point2.Y) / (point1.X - point2.X);
            Bfunc = point1.Y - Kfunc * point1.X;
        }

        public double DifferenceY(Vector2 point)
        {
            double tempY = point.Y;

            if (point1.X - point2.X < 0)
            {
                tempY = Kfunc * point.X + Bfunc;
                return point.Y - tempY;
            }
            if (point1.X - point2.X > 0)
            {
                tempY = Kfunc * point.X + Bfunc;
                return  -point.Y + tempY;
            }
            return 0;


        }

        public double DifferenceX(Vector2 point)
        {
            double tempX = point.X;

            if (point1.Y - point2.Y > 0)
            {
                tempX = (point.Y - Bfunc) / Kfunc;
                return point.X - tempX;
            }
            if (point1.Y - point2.Y < 0)
            {
                tempX = (point.Y - Bfunc) / Kfunc;
                return tempX - point.X;
            }
            return 0;
        }


        public double GetDistanceToEnd(Vector2 point)
        {
            double dist = Math.Sqrt(Math.Pow(point.X - point2.X, 2) + Math.Pow(point.Y - point2.Y, 2));
            return dist;
        }

        public double GetDistance()
        {
            return Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2));
        }


        public double GetAngle()
        {
            return Math.Atan2(point2.X - point1.X, point2.Y - point1.Y);
        }

        public double GetAngle(Vector2 point)
        {
            return Math.Atan2(point2.X - point.X, point2.Y - point.Y);
        }



        
    }
}
