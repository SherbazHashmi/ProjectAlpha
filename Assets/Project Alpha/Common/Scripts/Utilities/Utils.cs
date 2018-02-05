using System;

namespace MoreMountains.CorgiEngine
{

    public class Utilities
    {

        protected bool havePassedDecimalPoint = false;

        public bool isWholeNumber(double num)
        {
            return ((num % 1) == 0);
        }

        public bool isWholeNumberOld(double num)
        {
            string str = num.ToString();
            string afterDecimalPoint = getAfterDecimalPoint(str);
			return (afterDecimalPoint.Equals("0") || afterDecimalPoint.Equals(""));
        }

        public string  getAfterDecimalPoint(string str)
        {
            if (str.Length > 0)
            {
                if (str[0] == '.')
                {
                    havePassedDecimalPoint = true;
                    return getAfterDecimalPoint(str.Substring(1));
                }
                else if (havePassedDecimalPoint)
                {

                    return str[0] + getAfterDecimalPoint(str.Substring(1));
                }
                else
                {
                    return getAfterDecimalPoint(str.Substring(1));
                }
            }
            else
            {
                havePassedDecimalPoint = false;
                return "";
            }
        }
        
        public class TimeCalculations
        {
            enum TUnit
            {
                Seconds, Minutes, Hours, Days
            }
            
            
            /// <summary>
            /// RemainderT takes a time value and unit of time value and produces the whole number for the next unit
            /// down accompanied by the new value below the upper limit for the current unit. Ideally should be done
            /// as a tuple, but not yet supported in Unity so using a two cell array. 
            /// </summary>
            /// <param name="time"></param>
            /// <param name="timeUnit"></param>
            /// <returns></returns>
            
            float[] RemainderT (float time, TUnit timeUnit)
            {
                float wp;
                float p;


                switch (timeUnit)
                {
                    case TUnit.Days :
                        return new float[] {0, time};
                    case TUnit.Hours :
                        p = 1 % (time / 24);
                        break;
                    default:
                        p = 1 % (time / 60);
                        break;
                }
                
                wp = time - p;

                p = p * 60;

                if (timeUnit == TUnit.Hours)
                    p = (p / 60) * 24;
                
                return new float[] {wp,p};
   
            }

            float[] secondsToTimeArr (float seconds)
            {
                float minutes;
                float hours;
                float days;

                float[] calculation = RemainderT(seconds, TUnit.Seconds);
                seconds = calculation[1];
                
                calculation = RemainderT(calculation[0], TUnit.Minutes);
                minutes = calculation[1];
                
                calculation = RemainderT(calculation[0], TUnit.Hours);
                hours = calculation[1];
                
                calculation = RemainderT(calculation[0], TUnit.Days);
                days = calculation[1];

                return new float[] {seconds, minutes, hours, days};
            }


            public string secondsToString()
            {
                return "";
            }
        }
        
        
        
        
    }
}
