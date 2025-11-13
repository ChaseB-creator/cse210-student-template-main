using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
    
        Square s = new Square("Red", 5);
        Console.WriteLine($"Square Color: {s.GetColor()}");
        Console.WriteLine($"Square Area: {s.GetArea()}");

   
        Rectangle r = new Rectangle("Blue", 4, 6);
        Console.WriteLine($"Rectangle Color: {r.GetColor()}");
        Console.WriteLine($"Rectangle Area: {r.GetArea()}");

        Circle c = new Circle("Green", 3);
        Console.WriteLine($"Circle Color: {c.GetColor()}");
        Console.WriteLine($"Circle Area: {c.GetArea()}");

    
        List<Shape> shapes = new List<Shape>();
        shapes.Add(s);
        shapes.Add(r);
        shapes.Add(c);

        Console.WriteLine("\n--- Shape List ---");
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()} | Area: {shape.GetArea()}");
        }
    }
}
