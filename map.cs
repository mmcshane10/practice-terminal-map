using System;

namespace MaffeluDemo
{
    class Program
    {
        const ConsoleColor HERO_COLOR = ConsoleColor.DarkBlue;
        const ConsoleColor BACKGROUND_COLOR = ConsoleColor.White;

        public static Coordinate Hero { get; set; } //Will represent our here that's moving around :P/>

        static void Main(string[] args)
        {
            InitGame();

            ConsoleKeyInfo keyInfo;
            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        MoveHero(0, -1);
                        break;

                    case ConsoleKey.RightArrow:
                        MoveHero(1, 0);
                        break;

                    case ConsoleKey.DownArrow:
                        MoveHero(0, 1);
                        break;

                    case ConsoleKey.LeftArrow:
                        MoveHero(-1, 0);
                        break;
                }
            }
        }

        /// <summary>
        /// Paint the new hero
        /// </summary>
        static void MoveHero(int x, int y)
        {
            Coordinate newHero = new Coordinate()
            {
                X = Hero.X + x,
                Y = Hero.Y + y
            };

            if (CanMove(newHero))
            {
                RemoveHero();

                Console.BackgroundColor = HERO_COLOR;
                Console.SetCursorPosition(newHero.X, newHero.Y);
                Console.Write(" ");

                Hero = newHero;
            }
        }

        /// <summary>
        /// Overpaint the old hero
        /// </summary>
        static void RemoveHero()
        {
            Console.BackgroundColor = BACKGROUND_COLOR;
            Console.SetCursorPosition(Hero.X, Hero.Y);
            Console.Write(" ");
        }

        /// <summary>
        /// Make sure that the new coordinate is not placed outside the
        /// console window (since that will cause a runtime crash
        /// </summary>
        static bool CanMove(Coordinate c)
        {
            if (c.X < 0 || c.X >= Console.WindowWidth)
                return false;

            if (c.Y < 0 || c.Y >= Console.WindowHeight)
                return false;

            return true;
        }

        /// <summary>
        /// Paint a background color
        /// </summary>
        /// <remarks>
        /// It is very important that you run the Clear() method after
        /// changing the background color since this causes a repaint of the background
        /// </remarks>
        static void SetBackgroundColor()
        {
            Console.BackgroundColor = BACKGROUND_COLOR;
            Console.Clear(); //Important!
        }

        /// <summary>
        /// Initiates the game by painting the background
        /// and initiating the hero
        /// </summary>
        static void InitGame()
        {
            SetBackgroundColor();

            Hero = new Coordinate()
            {
                X = 0,
                Y = 0
            };

            MoveHero(0, 0);

        }
    }

    /// <summary>
    /// Represents a map coordinate
    /// </summary>
    class Coordinate
    {
        public int X { get; set; } //Left
        public int Y { get; set; } //Top
    }
}

