using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning05
{
    public class Shape
    {
        private String _color;
        public String GetColor()
        {
            return _color;
        }
        public void SetColor(String color)
        {
            _color = color;
        }
        public Shape(String color)
        {
            SetColor(color);
        }
        public virtual Double GetArea()
        {
            return 0;
        }
    }
}
