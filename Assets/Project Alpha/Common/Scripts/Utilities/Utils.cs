namespace MoreMountains.CorgiEngine
{

    public class Utilities
    {

        protected bool havePassedDecimalPoint = false; 

        public bool isWholeNumber(double num)
        {
            string str = num.ToString();
            string afterDecimalPoint = getAfterDecimalPoint(str);
            return (afterDecimalPoint.Equals("0"));
        }

        public string getAfterDecimalPoint(string str)
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
    }
}
