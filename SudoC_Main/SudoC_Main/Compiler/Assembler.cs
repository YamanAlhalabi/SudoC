﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SudoC_Main.Compiler
{
    public class sudoC_Assembler
    {
        private string Assembled = string.Empty;


        /// <summary>
        /// Converts InnerEzC to C
        /// </summary>
        /// <param name="Lexxed_Code"></param>
        /// <returns>C Code</returns>
        /// 
        public string Assemble(SudoC_Pair[] Lexxed_Code)
        {
            foreach (SudoC_Pair Pair in Lexxed_Code)
            {
                switch (Pair.InnerCode)
                {
                    case SudoCInnerCode.copy:
                        Assembled += Pair.Args[0];
                        break;
                    ///Print Function
                    case SudoCInnerCode.print:
                        if (Pair.Args[0].StartsWith("\"") && Pair.Args[0].EndsWith("\""))
                        {
                            Assembled += "printf(" + Pair.Args[0] + ");";
                        }
                        // printf("%s", variable);
                        else
                        {
                            Assembled += "printf(\"%s\", " + Pair.Args[0] + ");";
                        }
                        Assembled += Environment.NewLine;
                        break;
                    case SudoCInnerCode.vstring:
                        if (Pair.Args[1] != string.Empty)
                        {
                            Assembled += "char " + Pair.Args[0] + "[2056] = \"" + Pair.Args[1] + "\";";
                        }
                        else
                        {
                            Assembled += "char " + Pair.Args[0] + "[2056];";
                        }
                        Assembled += Environment.NewLine;
                        break;
                    case SudoCInnerCode.scan:
                        //scanf("%s", myString);
                        Assembled += "scanf(\"%s\"," + Pair.Args[0] + ");";
                        Assembled += Environment.NewLine;
                        break;
                    case SudoCInnerCode.equalize:
                        Assembled += Pair.Args[0] + " = " + Pair.Args[1] + ';';
                        Assembled += Environment.NewLine;
                        break;
                    case SudoCInnerCode.def:
                        Statics.dDefines.Add(Pair.Args[1], Pair.Args[0]);
                        break;
                    case SudoCInnerCode.context:
                        Statics.dContexts.Add(Pair.Args[1], Pair.Args[0]);
                        break;
                    case SudoCInnerCode.fetch:
                        Assembled+=Statics.dContexts[Pair.Args[0]];
                        break;

                }
            }
            foreach (KeyValuePair<string, string> defs in Statics.dDefines)
            {
                Assembled = Assembled.Replace(defs.Key, defs.Value);
            }
            return Assembled;
        }
    }
}
