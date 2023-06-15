using Learning05;
using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        Rectangle rectangle = new Rectangle("red", 2.5, 3.4);
        shapes.Add(rectangle);
        Square square = new Square("blue", 1.2);
        shapes.Add(square);
        Circle circle = new Circle("purple", 2);
        shapes.Add(circle);
        //Console.WriteLine($"Rectangle color is {rectangle.GetColor()} and area is {rectangle.GetArea()}!");
        //Console.WriteLine($"Square color is {square.GetColor()} and area is {square.GetArea()}!");
        //Console.WriteLine($"Circle color is {circle.GetColor()} and area is {circle.GetArea()}!");
        shapes.ForEach( (Shape shape) => {
            
            Console.WriteLine($"{shape.GetType()} color is {shape.GetColor()} and area is {shape.GetArea()}");
        });
    }
}