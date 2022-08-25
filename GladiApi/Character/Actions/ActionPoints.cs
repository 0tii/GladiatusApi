using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiApi
{
    public class ActionPoints
    {
        private int _currentPoints;
        private int _maxPoints;
        private int _timeToNextPoint;

        public ActionPoints(int currentPoints, int maxPoints, int timeToNextPoint)
        {
            _currentPoints = currentPoints;
            _maxPoints = maxPoints;
            _timeToNextPoint = timeToNextPoint; 
        }

        public int CurrentPoints { get => _currentPoints; set => _currentPoints = value; }
        public int MaxPoints { get => _maxPoints; set => _maxPoints = value; }
        public int TimeToNextPoint { get => _timeToNextPoint; set => _timeToNextPoint = value; }
    }
}
