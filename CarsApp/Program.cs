﻿using System;

namespace CarsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var game = new Game();
            game.Start();
        }
    }
}