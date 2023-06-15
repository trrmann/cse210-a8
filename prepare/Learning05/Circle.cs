using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning05
{
    public class Circle : Shape
    {
        private Double _radius;
        protected Double GetRadius()
        {
            return _radius;
        }
        protected void SetRadius(Double radius)
        {
            _radius = radius;
        }
        public Circle(String color, Double radius) : base(color)
        {
            SetRadius(radius);
        }
        public override double GetArea()
        {
            return Math.Pow(Math.PI * GetRadius(), 2);
        }
    }
}
