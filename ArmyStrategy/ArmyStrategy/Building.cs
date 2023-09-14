using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyStrategy.ArmyStrategy
{
    internal class Building
    {

        public int price;

        public Type type;

        public Queue<Unit> _unitQueue;

        public Unit EnqueueUnit { set { _unitQueue.Enqueue(value); } }
    }
}
