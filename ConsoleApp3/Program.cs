using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class Program
{
    static int screenWidth = 60;
    static int screenHeight = 20;
    static int score = 0;
    static bool gameOver = false;

    static List<Position> snake = new List<Position>();
    static Position food = new Position();
    static Position direction = new Position(1, 0);

    static void Main(string[] args)
    {
        Console.SetWindowSize(screenWidth, screenHeight);
        Console.SetBufferSize(screenWidth, screenHeight);

        InitGame();

        while (!gameOver)
        {
            Input();
            Logic();
            Draw();
            Thread.Sleep(90);
        }

        Console.SetCursorPosition(0, screenHeight - 1);
        Console.WriteLine("Game Over! Final Score: " + score);
        Console.ReadLine();
    }

    static void InitGame()
    {
        snake.Clear();
        snake.Add(new Position(10, 10));
        snake.Add(new Position(9, 10));
        snake.Add(new Position(8, 10));

        score = 0;
        gameOver = false;

        food = GenerateFood();
    }

    static void Input()
    {
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow && direction.Y != 1)
                direction = new Position(0, -1);
            else if (key == ConsoleKey.DownArrow && direction.Y != -1)
                direction = new Position(0, 1);
            else if (key == ConsoleKey.LeftArrow && direction.X != 1)
                direction = new Position(-1, 0);
            else if (key == ConsoleKey.RightArrow && direction.X != -1)
                direction = new Position(1, 0);
        }
    }

    static void Logic()
    {
        Position newHead = new Position(snake.First().X + direction.X, snake.First().Y + direction.Y);

        if (newHead.X < 0 || newHead.X >= screenWidth || newHead.Y < 0 || newHead.Y >= screenHeight)
        {
            gameOver = true;
            return;
        }

        if (snake.Any(p => p.X == newHead.X && p.Y == newHead.Y))
        {
            gameOver = true;
            return;
        }

        snake.Insert(0, newHead);

        if (newHead.X == food.X && newHead.Y == food.Y)
        {
            score += 10;
            food = GenerateFood();
        }
        else
        {
            snake.RemoveAt(snake.Count - 1);
        }
    }

    static void Draw()
    {
        Console.Clear();

        for (int i = 0; i < screenWidth; i++)
        {
            Console.SetCursorPosition(i, 0);
            Console.Write("#");
            Console.SetCursorPosition(i, screenHeight - 1);
            Console.Write("#");
        }

        for (int i = 0; i < screenHeight; i++)
        {
            Console.SetCursorPosition(0, i);
            Console.Write("#");
            Console.SetCursorPosition(screenWidth - 1, i);
            Console.Write("#");
        }

        foreach (var pos in snake)
        {
            Console.SetCursorPosition(pos.X, pos.Y);
            Console.Write("■");
        }

        Console.SetCursorPosition(food.X, food.Y);
        Console.Write("★");

        Console.SetCursorPosition(2, screenHeight - 2);
        Console.Write("Score: " + score);
    }

    static Position GenerateFood()
    {
        Random rand = new Random();
        int x = rand.Next(1, screenWidth - 1);
        int y = rand.Next(1, screenHeight - 1);

        return new Position(x, y);
    }
}

struct Position
{
    public int X;
    public int Y;

    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }
}
