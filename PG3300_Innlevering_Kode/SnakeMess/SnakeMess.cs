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
namespace SnakeMess {

    class SnakeMess {
        public static void Main()
        {
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

            Random ranNum   = new Random();
            Point ranPoint  = new Point(),
                  snakeTail = new Point(),
                  snakeHead = new Point(),
                  newHead   = new Point();

            // Liste over point-objekter
            List<Point> snakeList = new List<Point>();
            for (int i = 0; i < 4; i++)
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
                if (Console.KeyAvailable) {
                    ConsoleKeyInfo cki = Console.ReadKey(true);
                    switch(cki.Key) {
                        case (ConsoleKey.Escape):
                            isGameOver = true;
                            break;
                        case (ConsoleKey.Spacebar):
                            isPaused = !isPaused;
                            break;
                        case (ConsoleKey.UpArrow):
                            if (lastDir != 2)
                                newDir = 0;
                            break;
                        case (ConsoleKey.RightArrow):
                            if (lastDir != 3)
                                newDir = 1;
                            break;
                        case (ConsoleKey.DownArrow):
                            if (lastDir != 0)
                                newDir = 2;
                            break;
                        case (ConsoleKey.LeftArrow):
                            if (lastDir != 1)
                                newDir = 3;
                            break;
                    }
                }

                if (!isPaused) {
                    if (timer.ElapsedMilliseconds < 100)
                        continue;
                    timer.Restart();
                     
                    snakeTail = new Point(snakeList.First());
                    snakeHead = new Point(snakeList.Last());
                    newHead = new Point(snakeHead);

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
                                ranPoint.PosX = ranNum.Next(0, boardW);
                                ranPoint.PosY = ranNum.Next(0, boardH);

                                ifBeenFound = true;
                                if (SearchList(snakeList, ranPoint) == true)
                                    ifBeenFound = false;

                                if (ifBeenFound) {
                                    ifFoodFound = false;
                                    break;
                                }
                            }
                        }
                    }

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
        
        // Funksjon til å lese gjennom en point-liste og sammenligne med et annet point objekt
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
