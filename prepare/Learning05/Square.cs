using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning05
{
    public class Square : Rectangle
    {
        private Double GetSide()
        {
            return GetWidth();
        }
        private void SetSide(double side)
        {
            SetWidth(side);
            SetLength(side);
        }
        public Square(String color, Double side) : base(color, side, side)
        {
        }
        public override double GetArea()
        {
            return base.GetArea();
        }
    }
}
