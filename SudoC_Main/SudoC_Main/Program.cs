﻿using System;
using SudoC_Main.Compiler;
using SudoC_Main;
using System.Diagnostics;
using System.IO;

namespace SudoC
{
 public class Program
    {
        static void Main(string[] args)
        {
            App app = new App();
            app.StartCompiler(args);
        }

    }
}
