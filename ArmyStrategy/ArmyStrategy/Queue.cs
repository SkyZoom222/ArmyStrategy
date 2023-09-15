using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame.ArmyStrategy
{
    internal class Queue<T>
    {
        T[] _data;
        int _capacity;
        int _count;

        int indexIn = -1;
        int indexOut = 0;

        public int Count
        { get { return _count; } }

        public int Capacity
        { get { return _capacity; } }

        public T[] Data
        {
            get
            {
                if (_count == 0) throw new Exception();
                T[] temp = new T[_count];
                for (int i = indexOut; i < indexOut + _count; i++)
                {
                    if (i >= _capacity) temp[i - indexOut] = _data[i - _capacity];
                    else temp[i - indexOut] = _data[i];
                }
                return temp;
            }
        }


        public Queue(int cap)
        {
            _capacity = cap;
            _data = new T[cap];
            _count = 0;
        }

        public void Enqueue(T val)
        {
            if (_count == _capacity) throw new Exception("Queue Overflow!");

            if (indexIn == _capacity - 1) indexIn = 0;
            else indexIn++;

            _data[indexIn] = val;
            _count++;
        }

        public T Dequeue()
        {
            if (_count == 0) throw new Exception("Queue Empty!");
            _count--;
            T temp = _data[indexOut];
            _data[indexOut] = default(T);
            indexOut++;
            if (indexOut == Capacity) indexOut = 0;
            return temp;
        }

        public T Peek()
        {
            if (_count == 0)
                throw new Exception("Queue Empty!");
            return _data[indexOut];
        }
    }
}
