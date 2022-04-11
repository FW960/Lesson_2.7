using System;

namespace Lesson_2._7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Figure figure = new Rectangle(ConsoleColor.Cyan, true, 10, 10);

            Figure.Interact(figure);


        }
    }
    public abstract class Figure
    {
        protected char visualFigureType;

        protected string Attributes;

        protected ConsoleColor figureColor;

        protected bool isVisible;

        protected int yPosition;

        protected int xPosition;

        public void ChangeColor(ConsoleColor? figureColor)
        {
            if (figureColor.HasValue)
            {
                this.figureColor = figureColor.Value;

                return;
            }

            Console.WriteLine();

            Console.WriteLine("1. - Красный цвет. 2. - Синий цвет. 3 - Зеленый цвет. 4 - Розовый");

            string ChangeColor = Console.ReadLine();

            if (ChangeColor == "1")
            {
                figureColor = ConsoleColor.Red;
            }
            else if (ChangeColor == "2")
            {
                figureColor = ConsoleColor.Blue;
            }
            else if (ChangeColor == "3")
            {
                figureColor = ConsoleColor.Green;
            }
            else if (ChangeColor == "4")
            {
                figureColor = ConsoleColor.Magenta;
            }
        }
        public Figure(ConsoleColor figureColor, bool isVisible)
        {
            this.figureColor = figureColor;

            this.isVisible = isVisible;
        }
        public void MoveY(ConsoleKey key)
        {
            if (key == ConsoleKey.UpArrow)
            {
                ++yPosition;
            }
            if (key == ConsoleKey.DownArrow)
            {
                --yPosition;
            }
        }
        public void MoveX(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow)
            {
                --xPosition;
            }
            if (key == ConsoleKey.RightArrow)
            {
                ++xPosition;
            }
        }
        protected abstract void initializeAttributes();
        protected void ShowAttributes()
        {
            initializeAttributes();

            for (int i = 0; i < Attributes.Length; i++)
            {
                if (Attributes[i] == visualFigureType && isVisible == true)
                {
                    Console.ForegroundColor = figureColor;

                    Console.Write(Attributes[i]);

                    Console.ResetColor();

                    continue;
                }
                else if (Attributes[i] == visualFigureType && isVisible == false)
                {
                    continue;
                }
                Console.Write(Attributes[i]);
            }
        }
        public static void Interact(Figure figure)
        {
            ConsoleKeyInfo move;
            do
            {
                Console.Clear();

                figure.ShowAttributes();

                move = Console.ReadKey();

                switch (move.Key)
                {
                    case ConsoleKey.UpArrow:
                        figure.MoveY(move.Key); figure.ShowAttributes();
                        break;
                    case ConsoleKey.DownArrow:
                        figure.MoveY(move.Key); figure.ShowAttributes();
                        break;
                    case ConsoleKey.LeftArrow:
                        figure.MoveX(move.Key); figure.ShowAttributes();
                        break;
                    case ConsoleKey.RightArrow:
                        figure.MoveX(move.Key); figure.ShowAttributes();
                        break;
                    case ConsoleKey.C:
                        figure.ChangeColor(null);
                        break;
                    default:
                        break;
                }
            } while (move.Key != ConsoleKey.Escape);
        }
    }
    public class Point : Figure
    {
        protected override void initializeAttributes()
        {
            Attributes = $@"Y coordinate: {yPosition}
X coordinate: {xPosition}
Color: {visualFigureType}";
        }
        public Point(ConsoleColor color, bool isVisible) : base(color, isVisible)
        {
            visualFigureType = '.';
        }

    }
    public class Circle : Point
    {
        protected override void initializeAttributes()
        {
            Attributes = $@"Y coordinate: {yPosition}
X coordinate: {xPosition}
Color: {visualFigureType}
Radius: {radius}
Square: {square}";
        }

        public int radius;

        public float square;
        public Circle(ConsoleColor color, bool isVisible, int radius) : base(color, isVisible)
        {
            this.radius = radius;

            this.square = (float)Math.PI * radius * radius;

            visualFigureType = '●';
        }
    }
    public class Rectangle : Point
    {
        protected override void initializeAttributes()
        {
            Attributes = $@"Y coordinate: {yPosition}
X coordinate: {xPosition}
Color: {visualFigureType}
Lenght: {length}
Hight: {hight}
Square: {square}";
        }

        public int length;

        public int hight;

        public float square;
        public Rectangle(ConsoleColor color, bool isVisible, int length, int hight) : base(color, isVisible)
        {
            this.length = length;

            this.hight = hight;

            this.square = length * hight;

            visualFigureType = '▬';
        }
    }
}

