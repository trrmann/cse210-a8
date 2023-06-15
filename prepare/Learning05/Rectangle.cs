using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning05
{
    public class Rectangle : Shape
    {
        private Double _length;
        private Double _width;
        protected Double GetLength()
        {
            return _length;
        }
        protected void SetLength(Double length)
        {
            _length = length;
        }
        protected Double GetWidth()
        {
            return _width;
        }
        protected void SetWidth(Double width)
        {
            _width = width;
        }
        public Rectangle(String color, Double length, Double width) : base(color)
        {
            SetLength(length);
            SetWidth(width);
        }
        public override double GetArea()
        {
            return GetLength() * GetWidth();
        }
    }
}
