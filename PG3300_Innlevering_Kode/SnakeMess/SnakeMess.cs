using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

// WARNING: DO NOT code like this. Please. EVER! 
//          "Aaaargh!" 
//          "My eyes bleed!" 
//          "I facepalmed my facepalm." 
//          Etc.
//          I had a lot of fun obfuscating this code! And I can now (proudly?) say that this is the uggliest short piece of code I've ever written!
//          (And yes, it could have been ugglier. But the idea wasn't to make it fuggly-uggly, just funny-uggly or sweet-uggly.)
//
//          -Tomas
//
namespace SnakeMess
{
	class SnakeMess
	{
		public static void Main(string[] arguments)
		{
<<<<<<< HEAD
            // Variabler
            bool isGameOver = false,
                 isPaused = false,
                 ifFoodFound = false,
                 ifVacantSpot,
                 ifBeenFound;

            // 0 = up, 1 = right, 2 = down, 3 = left
            short newDir = 2,
                  lastDir = newDir;

			int boardW = Console.WindowWidth,
                boardH = Console.WindowHeight;

			Random ranNum = new Random();
			Point ranPoint = new Point();

            // Liste over point-objekter
			List<Point> snakeList = new List<Point>();
            for(int i = 0; i < 4; i++)
                snakeList.Add(new Point(10, 10));

            // Start up funksjon
            InitializeWindow();

			while (true) {
				ranPoint.PosX = ranNum.Next(0, boardW);
                ranPoint.PosY = ranNum.Next(0, boardH);

				ifVacantSpot = true;

                if (SearchList(snakeList, ranPoint) == true)
                    ifVacantSpot = false;

				if (ifVacantSpot) {
                    ChangeConsole(ConsoleColor.Green, ranPoint.PosX, ranPoint.PosY, '$');
                    break;
				}
			}

            Stopwatch timer = new Stopwatch();
            timer.Start();
			while (!isGameOver) {
=======
			bool gg = false, pause = false, inUse = false;
			short newDir = 2; // 0 = up, 1 = right, 2 = down, 3 = left
			short last = newDir;
			int boardW = Console.WindowWidth, boardH = Console.WindowHeight;

			Random rng = new Random();
			Point app = new Point();

			List<Point> snake = new List<Point>();
			snake.Add(new Point(10, 10)); 
            snake.Add(new Point(10, 10));
            snake.Add(new Point(10, 10)); 
            snake.Add(new Point(10, 10));

			Console.CursorVisible = false;
			Console.Title = "Westerdals Oslo ACT - SNAKE";
			Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(10, 10);
            Console.Write("@");

			while (true) {
				app.X = rng.Next(0, boardW);
                app.Y = rng.Next(0, boardH);
				bool spot = true;

				foreach (Point i in snake)
					if (i.X == app.X && i.Y == app.Y) {
						spot = false;
						break;
					}

				if (spot) {
					Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(app.X, app.Y);
                    Console.Write("$");
					break;
				}
			}

			Stopwatch t = new Stopwatch();
			t.Start();

			while (!gg) {
>>>>>>> 5c4bc3d0e9197d73b7dad0534318932465f67108
				if (Console.KeyAvailable) {
					ConsoleKeyInfo cki = Console.ReadKey(true);
					if (cki.Key == ConsoleKey.Escape)
						isGameOver = true;
					else if (cki.Key == ConsoleKey.Spacebar)
						isPaused = !isPaused;
					else if (cki.Key == ConsoleKey.UpArrow && lastDir != 2)
						newDir = 0;
					else if (cki.Key == ConsoleKey.RightArrow && lastDir != 3)
						newDir = 1;
					else if (cki.Key == ConsoleKey.DownArrow && lastDir != 0)
						newDir = 2;
					else if (cki.Key == ConsoleKey.LeftArrow && lastDir != 1)
						newDir = 3;
				}

				if (!isPaused) {
					if (timer.ElapsedMilliseconds < 100)
						continue;
					timer.Restart();

					Point snakeTail = new Point(snakeList.First());
					Point snakeHead = new Point(snakeList.Last());
					Point newHead = new Point(snakeHead);

					switch (newDir) {
						case 0:
							newHead.PosY -= 1;
							break;
						case 1:
							newHead.PosX += 1;
							break;
						case 2:
							newHead.PosY += 1;
							break;
						default:
							newHead.PosX -= 1;
							break;
					}

					if (newHead.PosX < 0 || newHead.PosX >= boardW || newHead.PosY < 0 || newHead.PosY >= boardH)
						isGameOver = true;

					if (newHead.PosX == ranPoint.PosX && newHead.PosY == ranPoint.PosY) {
						if (snakeList.Count + 1 >= boardW * boardH)
							// No more room to place apples - game over.
							isGameOver = true;
						else {
							while (true) {
<<<<<<< HEAD
								ranPoint.PosX = ranNum.Next(0, boardW);
                                ranPoint.PosY = ranNum.Next(0, boardH);

								ifBeenFound = true;
                                if (SearchList(snakeList, ranPoint) == true)
                                    ifBeenFound = false;

								if (ifBeenFound) {
									ifFoodFound = false;
=======
								app.X = rng.Next(0, boardW);
                                app.Y = rng.Next(0, boardH);
								bool found = true;
								foreach (Point i in snake)
									if (i.X == app.X && i.Y == app.Y) {
										found = false;
										break;
									}
								if (found) {
									inUse = true;
>>>>>>> 5c4bc3d0e9197d73b7dad0534318932465f67108
									break;
								}
							}
						}
					}

<<<<<<< HEAD
					if (ifFoodFound) {
						snakeList.RemoveAt(0);
                        if (SearchList(snakeList, newHead) == true)
                            isGameOver = true;
					}

					if (!isGameOver) {
                        ChangeConsole(ConsoleColor.Yellow, snakeHead.PosX, snakeHead.PosY, '0');
						if (ifFoodFound) {
                            ChangeConsole(0, snakeTail.PosX, snakeTail.PosY, ' ');
						} else {
                            ChangeConsole(ConsoleColor.Green, ranPoint.PosX, ranPoint.PosY, '$');
							ifFoodFound = true;
						}
						snakeList.Add(newHead);
                        ChangeConsole(ConsoleColor.Yellow, newHead.PosX, newHead.PosY, '@');
						lastDir = newDir;
=======
					if (!inUse) {
						snake.RemoveAt(0);
						foreach (Point x in snake)
							if (x.X == newH.X && x.Y == newH.Y) {
								// Death by accidental self-cannibalism.
								gg = true;
								break;
							}
					}

					if (!gg) {
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.SetCursorPosition(head.X, head.Y);
                        Console.Write("0");

						if (!inUse) {
							Console.SetCursorPosition(tail.X, tail.Y);
                            Console.Write(" ");
						} else {
							Console.ForegroundColor = ConsoleColor.Green;
                            Console.SetCursorPosition(app.X, app.Y);
                            Console.Write("$");
							inUse = false;
						}

						snake.Add(newH);
						Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(newH.X, newH.Y);
                        Console.Write("@");
						last = newDir;
>>>>>>> 5c4bc3d0e9197d73b7dad0534318932465f67108
					}
				}
			}
		}

        // Funksjon brukt til å initialisere startup for konsoll vinduet
        public static void InitializeWindow()
        {
            Console.CursorVisible = false;
            Console.Title = "Westerdals Oslo ACT - SNAKE";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(10, 10);
            Console.Write("@");
        }

        public static bool SearchList(List<Point> snakeList, Point p)
        {
            foreach (Point i in snakeList) {
                if (i.PosX == p.PosX && i.PosY == p.PosY) {
                    return true;
                }
            }
            return false;
        }

        // Funksjon brukt til å endre forskjellige konsoll egenskaper
        public static void ChangeConsole(ConsoleColor color, int xPoint, int yPoint, char c)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(xPoint, yPoint);
            Console.Write(c);
        }
	}
}