using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static ADOFAIAutoPlayer.OfficialLevels.WorldXOX;
using static ADOFAIAutoPlayer.LevelCalcThingy;

namespace ADOFAIAutoPlayer
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            int arri = 0;
            string fulltxt = "";
            string path = @"D:\YeetMacro\OneForgottenNightS1.mcr";
            int numbetiles = 0;
            char tileP = 'R';
            Console.WriteLine("[FinalResult] hello!");
            foreach(char tile in pathdata)
            {
                if (($"{tileP}{tile}" == "DU")|| ($"{tileP}{tile}" == "UD"))
                {
                    fulltxt += $"Keyboard : {key} : KeyDown\nKeyboard : {key} : KeyUp\nDELAY : {Convert.ToInt32(2*gimmemillis())}\n";
                }
                else
                {
                    bool flag = tileP.ToString().ToUpper() != "L";
                    if (flag)
                    {
                        fulltxt += $"Keyboard : {key} : KeyDown\nKeyboard : {key} : KeyUp\nDELAY : {Convert.ToInt32(GetRelativeAngle(ConvertTile(tileP, false), ConvertTile(tile, false)))}\n";
                    }
                    else
                    {
                        fulltxt += $"Keyboard : {key} : KeyDown\nKeyboard : {key} : KeyUp\nDELAY : {Convert.ToInt32(GetRelativeAngle(ConvertTile(tileP, true), ConvertTile(tile, true)))}\n";
                    }
                }
                tileP = tile;
                numbetiles++;
                if (floorbpms[arri]==numbetiles)
                {
                    arri++;
                    BPM = floorbpms[arri]*Convert.ToInt32(speed);
                    arri++;
                    if (arri >= floorbpms.Length)
                    {
                        arri = 0;
                    }
                }
            }
            fulltxt += $"Keyboard : {key} : KeyDown\nKeyboard : {key} : KeyUp";
            using var sw = new StreamWriter(path);
            sw.WriteLine(fulltxt);
            Console.WriteLine("data written to file");
        }
    }
}
