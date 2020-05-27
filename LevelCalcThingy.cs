using System;
using System.Collections.Generic;
using System.Text;
using static ADOFAIAutoPlayer.OfficialLevels.WorldXOX;
using static ADOFAIAutoPlayer.Angles;

namespace ADOFAIAutoPlayer
{
    public class LevelCalcThingy
    {
        public static bool doMatch(string tileValue, char textBoxName)
        {
            return textBoxName.ToString().ToUpper().Equals(tileValue.ToUpper());
        }
        public static decimal ConvertTile(char textBoxName, bool classforL)
        {

            decimal result = 0;
            // on pathData mode and No L
            if (!classforL)
            {
                if (doMatch("L", textBoxName)) result = AbsoluteTileAngles.Left;
                if (doMatch("Q", textBoxName)) result = AbsoluteTileAngles.LeftUp;
                if (doMatch("U", textBoxName)) result = AbsoluteTileAngles.Up;
                if (doMatch("E", textBoxName)) result = AbsoluteTileAngles.RightUp;
                if (doMatch("R", textBoxName)) result = AbsoluteTileAngles.Right;
                if (doMatch("C", textBoxName)) result = AbsoluteTileAngles.RightDown;
                if (doMatch("D", textBoxName)) result = AbsoluteTileAngles.Down;
                if (doMatch("Z", textBoxName)) result = AbsoluteTileAngles.LeftDown;
                if (doMatch("H", textBoxName)) result = AbsoluteTileAngles.T1LeftUp;
                if (doMatch("G", textBoxName)) result = AbsoluteTileAngles.T2LeftUp;
                if (doMatch("T", textBoxName)) result = AbsoluteTileAngles.T1RightUp;
                if (doMatch("J", textBoxName)) result = AbsoluteTileAngles.T2RightUp;
                if (doMatch("M", textBoxName)) result = AbsoluteTileAngles.T1RightDown;
                if (doMatch("B", textBoxName)) result = AbsoluteTileAngles.T2RightDown;
                if (doMatch("F", textBoxName)) result = AbsoluteTileAngles.T1LeftDown;
                if (doMatch("N", textBoxName)) result = AbsoluteTileAngles.T2LeftDown;
                if (doMatch("5", textBoxName)) result = AbsoluteTileAngles.F5R1;
                if (doMatch("55", textBoxName)) result = AbsoluteTileAngles.F5R2;
                if (doMatch("555", textBoxName)) result = AbsoluteTileAngles.F5R3;
                if (doMatch("5555", textBoxName)) result = AbsoluteTileAngles.F5R4;
                if (doMatch("7", textBoxName)) result = AbsoluteTileAngles.F7R1;
                if (doMatch("77", textBoxName)) result = AbsoluteTileAngles.F7R2;
                if (doMatch("777", textBoxName)) result = AbsoluteTileAngles.F7R3;
                if (doMatch("7777", textBoxName)) result = AbsoluteTileAngles.F7R4;
                if (doMatch("77777", textBoxName)) result = AbsoluteTileAngles.F7R5;
                if (doMatch("777777", textBoxName)) result = AbsoluteTileAngles.F7R6;
            }
            else
            {
                if (doMatch("L", textBoxName)) result = _AngleLib.Left;
                if (doMatch("Q", textBoxName)) result = _AngleLib.LeftUp;
                if (doMatch("U", textBoxName)) result = _AngleLib.Up;
                if (doMatch("E", textBoxName)) result = _AngleLib.RightUp;
                if (doMatch("R", textBoxName)) result = _AngleLib.Right;
                if (doMatch("C", textBoxName)) result = _AngleLib.RightDown;
                if (doMatch("D", textBoxName)) result = _AngleLib.Down;
                if (doMatch("Z", textBoxName)) result = _AngleLib.LeftDown;
                if (doMatch("H", textBoxName)) result = _AngleLib.T1LeftUp;
                if (doMatch("G", textBoxName)) result = _AngleLib.T2LeftUp;
                if (doMatch("T", textBoxName)) result = _AngleLib.T1RightUp;
                if (doMatch("J", textBoxName)) result = _AngleLib.T2RightUp;
                if (doMatch("M", textBoxName)) result = _AngleLib.T1RightDown;
                if (doMatch("B", textBoxName)) result = _AngleLib.T2RightDown;
                if (doMatch("F", textBoxName)) result = _AngleLib.T1LeftDown;
                if (doMatch("N", textBoxName)) result = _AngleLib.T2LeftDown;
                if (doMatch("5", textBoxName)) result = _AngleLib.F5R1;
                if (doMatch("55", textBoxName)) result = _AngleLib.F5R2;
                if (doMatch("555", textBoxName)) result = _AngleLib.F5R3;
                if (doMatch("5555", textBoxName)) result = _AngleLib.F5R4;
                if (doMatch("7", textBoxName)) result = _AngleLib.F7R1;
                if (doMatch("77", textBoxName)) result = _AngleLib.F7R2;
                if (doMatch("777", textBoxName)) result = _AngleLib.F7R3;
                if (doMatch("7777", textBoxName)) result = _AngleLib.F7R4;
                if (doMatch("77777", textBoxName)) result = _AngleLib.F7R5;
                if (doMatch("777777", textBoxName)) result = _AngleLib.F7R6;
            }
            result = (result / 180) * gimmemillis();
            return result;
        }
        public static decimal GetRelativeAngle(decimal ThisTile, decimal NextTile)
        {
            decimal result = NextTile - ThisTile + gimmemillis();
            if (result > 2 * gimmemillis())
            {
                Console.WriteLine("[RelativeAngleFunction] value above " + gimmemillis() + ", fixing!");
                try
                {

                    result -= Decimal.Floor(result / (2 * gimmemillis())) * (2 * gimmemillis());
                    Console.WriteLine("[RelativeAngleFunction] value now fixed to " + result);
                }
                catch (DivideByZeroException err)
                {
                    Console.WriteLine("[RelativeAngleFunction] exception occurred, fixing to 0");
                    if (err != null)
                    {

                    }
                    result = 0;
                }
                if (result < 0) result += 2 * gimmemillis();
            }
            if (result < 0) result = Math.Abs(result);
            result = Math.Abs(result);
            return result;
        }
        public static decimal gimmemillis()
        {
            decimal yeet = (60000 / (BPM * speed) - Convert.ToDecimal(1.2));
            return yeet;
        }
    }
}
