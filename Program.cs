﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Hangman_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            CapitalManager _capitalManager = new CapitalManager();
            var cap = _capitalManager.SelectRandomCapital();
            Console.ReadKey();
        }
    }
}