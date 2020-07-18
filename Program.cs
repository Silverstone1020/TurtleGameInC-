using System;

namespace TurtleGame
{
    class Program6
    {
        static void Main()
        {
            Turtle t = new Turtle();
            t.FillRoom();
            t.Order();
        }
    }

    class Turtle
    {
        public char[,] room = new char[12, 12];

        public void FillRoom()
        {
            for (int i = 0; i <= room.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= room.GetUpperBound(1); j++)
                {
                    room[i, j] = '0';
                }
            }
            room[0, 0] = '*';
        }


        private int posX = 0;
        private int posY = 0;
        public int PosY
        {
            get { return posY; }
            set
            {
                if (value > 11)
                {
                    posY = 11;
                }
                else if (value < 0)
                {
                    posY = 0;
                }
                else
                    posY = value;
            }
        }

        public int PosX
        {
            get { return posX; }
            set
            {
                if (value > 11)
                {
                    posX = 11;
                }
                else if (value < 0)
                {
                    posX = 0;
                }
                else
                    posX = value;
            }
        }

        private bool canWrite;

        public void UpPen()
        {
            canWrite = false;
        }

        public void DownPen()
        {
            canWrite = true;
        }

        private int direction = 0;

        public void TurnRight()
        {
            direction += 1;
        }

        public void TurnLeft()
        {
            direction -= 1;
        }

        public void Draw()
        {
            if (canWrite)
            {
                this.room[this.PosX, this.PosY] = '*';
            }
            //else
            //    this.room[this.PosX, this.PosY] = '0';
        }

        public void Move()
        {
            if (direction % 4 == 0)
            {
                PosY++;
            }
            else if (direction % 4 == 1)
            {
                PosX++;

            }
            else if (direction % 4 == 2)
            {
                PosY--;
            }
            else if (direction % 4 == 3)
            {
                PosX--;
            }

        }

        public void MoveOrDraw(int x)
        {

            for (int i = 0; i < x; i++)
            {
                Move();
                Draw();
            }
            Show();

        }

        public void Show()
        {
            for (int i = 0; i <= room.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= room.GetUpperBound(1); j++)
                {
                    Console.Write($"{ room[i, j],2}");
                }
                Console.WriteLine();
            }
        }

        public void ShowPrompt()
        {
            Console.WriteLine("!!! Welcome to the turtle game !!!");
            Console.WriteLine("You will see the trace by your control " +
                "on the turtle which sits on the left top of the following grids facing right");
            Console.WriteLine();
            Show();
            Console.WriteLine();
            Console.WriteLine("Please choose an order in the following list: ");
            Console.WriteLine("1) draw nothing;");
            Console.WriteLine("2) ready to draw '*';");
            Console.WriteLine("3) turn rignt;");
            Console.WriteLine("4) turn left;");
            Console.WriteLine("5,x) move by x in the current direction and begin to draw," +
                "\n\tthe comma ',' should be in English input mode," +
                "\n\tx value can be any none negative integer;");
            Console.WriteLine("6) show trace;");
            Console.WriteLine("9) exit game.");
            Console.WriteLine();
        }

        public void Order()
        {
            ShowPrompt();

            string order = Console.ReadLine();

            while (order != "9")
            {
                string orderChar = order.Substring(0, 1);
                switch (orderChar)
                {
                    case "1":
                        UpPen();
                        break;
                    case "2":
                        DownPen();
                        break;
                    case "3":
                        TurnRight();
                        break;
                    case "4":
                        TurnLeft();
                        break;
                    case "5":
                        string orderChar2 = order.Split(',')[1];
                        MoveOrDraw(int.Parse(orderChar2));
                        break;
                    case "6":
                        Show();
                        break;
                    default:
                        Console.WriteLine("Please input integers in [1,6] and 9");
                        break;
                }

                order = Console.ReadLine();

            }
        }
    }
}
