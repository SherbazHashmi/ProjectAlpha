using System.Web;
using MoreMountains.Tools;
using UnityEngineInternal;
using MoreMountains;

namespace MoreMountains.CorgiEngine
{
    public class IMButtonExtended : MMInput.IMButton
    {
        
        public IMButtonExtended(string playerID, string buttonID, ButtonDownMethodDelegate btnDown, ButtonPressedMethodDelegate btnPressed, ButtonUpMethodDelegate btnUp) : base(playerID, buttonID, btnDown, btnPressed, btnUp)
        {
           
        }
        
        
        


        public void changeButtonID(string buttonID)
        {
            string playerID = getPlayerID(ButtonID);
            ButtonID = playerID + "_" + buttonID;


        }


        public string getPlayerID(string ButtonID)
        {
            if (ButtonID.Equals("_"))
            {
                return "";
            }
            else
            {
                return ButtonID[0] + getPlayerID(ButtonID.Substring(1));

            }
        }
    }
}