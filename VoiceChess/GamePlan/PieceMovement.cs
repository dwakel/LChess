using System;
using System.Collections.Generic;

namespace VoiceChess.GamePlan
{
    public class PieceMovement
    {
        protected Dictionary<string, int> BoardTranscription = new Dictionary<string, int>();

        
        public PieceMovement()
        {
            BoardTranscription.Add("A", 1);
            BoardTranscription.Add("B", 2);
            BoardTranscription.Add("C", 3);
            BoardTranscription.Add("D", 4);
            BoardTranscription.Add("E", 5);
            BoardTranscription.Add("F", 6);
            BoardTranscription.Add("G", 7);
            BoardTranscription.Add("H", 8);

        }
      
        public virtual List<string>  HighlightMovementPath()
        {
            var list = new List<string>();
           
            var ret = (list);

            //This method is overriden for individual movement of chess piecess
            return ret;
        }

        public static void AssignPosition(Object position)
        {

        }

    }
}
