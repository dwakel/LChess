using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace LaeLaChess.GamePlan
{
    public class Speech
    {
        public Speech() { }

        public static GrammarBuilder CreateGrammar()
        {
#region FirstBranch
            var gb = new GrammarBuilder[] { null, null, null, null};
            gb[0] = new GrammarBuilder();
            gb[1] = new GrammarBuilder();
            gb[2] = new GrammarBuilder();
            gb[3] = new GrammarBuilder();
            gb[0].Append("select", 0, 1);
             string[] firstAlpha = {"a", "b", "c", "d","e", "f", "g", "h"};
            //string[] firstAlpha = { "one", "two", "three", "four", "five", "six", "seven", "eight" };
            var firstAlphaChoice = new Choices();
            for (int i = 1; i <= firstAlpha.Length; i++)
            {
                firstAlphaChoice.Add(new SemanticResultValue(firstAlpha[i-1], firstAlpha[i-1]));
            }
            gb[0].Append(new SemanticResultKey("PositionHighlightCall", (GrammarBuilder)firstAlphaChoice));
            string[] secondNumber = { "one", "two", "three", "four", "five", "six", "seven", "eight" };
            var secondNumberChoice = new Choices();
            for (int i = 1; i <= secondNumber.Length; i++)
            {
                secondNumberChoice.Add(new SemanticResultValue(secondNumber[i-1], i));
            }
            gb[0].Append(new SemanticResultKey("SecondPositionHighlightCall", (GrammarBuilder)secondNumberChoice));
            #endregion

#region SecondBranch
            gb[1].Append("move to", 0, 1);

            gb[1].Append(new SemanticResultKey("firstDig", (GrammarBuilder)firstAlphaChoice));
            gb[1].Append(new SemanticResultKey("secondDig", (GrammarBuilder)secondNumberChoice));
            #endregion

#region ThirdBranch
            var promotionChoice = new Choices();
            promotionChoice.Add(new SemanticResultValue("queen", "Queen"));
            promotionChoice.Add(new SemanticResultValue("rook", "Rook"));
            promotionChoice.Add(new SemanticResultValue("bishop", "Bishop"));
            promotionChoice.Add(new SemanticResultValue("knight", "Knight"));
            gb[2].Append("promote to", 0, 1);
            gb[2].Append(new SemanticResultKey("Promotion", (GrammarBuilder)promotionChoice));

            #endregion


            #region forth reset
            gb[3].Append("reset board", 0, 1);

#endregion

            var choice = new Choices(gb);
            return new GrammarBuilder(choice);
        }


    }
}
