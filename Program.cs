using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
//using static ADOFAIAutoPlayer.OfficialLevels.WorldXOX;
using static ADOFAIAutoPlayer.LevelCalcThingy;

namespace ADOFAIAutoPlayer
{
    public class Program
    {
        public static string pathdata = "ERRRERRRERRRERRREURREURREURREURRERELDRERELDRERELDRERELDRERELDRERRRULDRRRULDRRRREULLLQURRREULLLQURRREULLLQURRRUQQQLDRULLLZZDRULZZDRULZZDRULZZDRULZZDRULZZDRULZZDRULZZDLTBDLLLLLLDLDLLLLQECDLLQECDLLQECDLLQECDLLQECDLLQECDLLLLLLULLLQLLLQURRREULLLQURDLLLQRDLLLQRDLLQLLLQLLLQURRRERULQRQRQRQRRDZZZLURDLLLQQURDLQQURDLQQURDLQQURDLQQURDLQQURDLQQURDLQQUR";
        public static decimal BPM = 84.94m;
        public static decimal speed = 1;
        public static string key = "K";
        public static decimal[] floorbpms = {33, 140, 79, 84.95m, 110, 140, 167, 84.94m, 172, 21.235m, 176, 42.47m, 182, 140, 226, 84.94m, 245, 140, 258, 84.94m, 276, 140, 296, 156, 320, 174};
        public static int[] twirls = {84, 89, 94, 99, 104, 109, 166, 235, 240, 271, 276};
        static void Main(string[] args)
        {
            bool twirled = false;
            bool setspeed = true;
            bool twirlmax = false;
            int arri = 0;
            int arrri = 0;
            string fulltxt = "";
            string path = @"D:\YeetMacro\World4butCPNigh.mcr";
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
                    if (!twirled)
                    {
                        if (flag)
                        {
                            fulltxt += $"Keyboard : {key} : KeyDown\nKeyboard : {key} : KeyUp\nDELAY : {Convert.ToInt32(GetRelativeAngle(ConvertTile(tileP, false), ConvertTile(tile, false)))}\n";
                        }
                        else
                        {
                            fulltxt += $"Keyboard : {key} : KeyDown\nKeyboard : {key} : KeyUp\nDELAY : {Convert.ToInt32(GetRelativeAngle(ConvertTile(tileP, true), ConvertTile(tile, true)))}\n";
                        }
                    }
                    else
                    {
                        if (flag)
                        {
                            if ((2 * gimmemillis() - GetRelativeAngle(ConvertTile(tileP, false), ConvertTile(tile, false)))==0)
                            {
                                fulltxt += $"Keyboard : {key} : KeyDown\nKeyboard : {key} : KeyUp\nDELAY : {Convert.ToInt32(2 * gimmemillis())}\n";
                            }
                            else
                            {
                                fulltxt += $"Keyboard : {key} : KeyDown\nKeyboard : {key} : KeyUp\nDELAY : {Convert.ToInt32(2 * gimmemillis() - GetRelativeAngle(ConvertTile(tileP, false), ConvertTile(tile, false)))}\n";
                            }
                        }
                        else
                        {
                            if((2 * gimmemillis() - GetRelativeAngle(ConvertTile(tileP, true), ConvertTile(tile, true))) == 0)
                            {
                                fulltxt += $"Keyboard : {key} : KeyDown\nKeyboard : {key} : KeyUp\nDELAY : {Convert.ToInt32(2 * gimmemillis())}\n";
                            }
                            else
                            {
                                fulltxt += $"Keyboard : {key} : KeyDown\nKeyboard : {key} : KeyUp\nDELAY : {Convert.ToInt32(2*gimmemillis()-GetRelativeAngle(ConvertTile(tileP, true), ConvertTile(tile, true)))}\n";
                            }
                            
                        }
                    }
                }
                tileP = tile;
                numbetiles++;
                if ((floorbpms[arri]==(numbetiles+1))&&setspeed)
                {
                    arri++;
                    BPM = floorbpms[arri]*Convert.ToInt32(speed);
                    arri++;
                    if (arri >= floorbpms.Length)
                    {
                        setspeed = false;
                        arri = 0;
                    }
                }
                if (twirls[arrri] == (numbetiles + 1)&&!twirlmax)
                {
                    if (twirled)
                    {
                        twirled = false;
                    }
                    else
                    {
                        twirled = true;
                    }
                    arrri++;
                    if (arrri >= twirls.Length)
                    {
                        arrri = 0;
                        twirlmax = true;
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
