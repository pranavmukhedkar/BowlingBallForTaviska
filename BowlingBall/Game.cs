using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall
{
    public class InputGame
    {
        public int Chance { get; set; }
        public int[] PinsFall { get; set; }
    }
    public class Game
    {
        List<InputGame> pinInputs = new List<InputGame>() {
            new InputGame { Chance=1,PinsFall=new[]{ 10 } },
            new InputGame { Chance=2,PinsFall=new[]{9,1 } },
            new InputGame { Chance=2,PinsFall=new[]{5,5 } },
            new InputGame { Chance=2,PinsFall=new[]{7,2 } },
            new InputGame { Chance=1,PinsFall=new[]{10 } },
            new InputGame { Chance=1,PinsFall=new []{10 } },
            new InputGame { Chance=1,PinsFall=new []{10 } },
            new InputGame { Chance=2,PinsFall=new []{9,1 } },
            new InputGame { Chance=2,PinsFall=new []{8,2 } },
        };
        public void Roll(int pins)
        {

            // Add your logic here. Add classes as needed.
        }

        public int GetScore()
        {
            int recordStrike = 0;
            List<int> scoreArray = new List<int>();
            for (int i = 0; i < 10; i++)
            {


                scoreArray.Add(pinInputs[i].PinsFall.Sum());


                if (scoreArray.Count >= 2)
                {

                    if (pinInputs[i - 1].Chance == 1 && pinInputs[i - 1].PinsFall.Sum() == 10)
                    {
                        //logic for strike
                        scoreArray[i - 1] = scoreArray[i - 1] + pinInputs[i].PinsFall.Sum();
                        scoreArray[i] = scoreArray[i] + scoreArray[i - 1];
                        recordStrike++;
                    }
                    else if (pinInputs[i - 1].Chance >= 1 && pinInputs[i - 1].Chance <= 2 && pinInputs[i - 1].PinsFall.Sum() == 10)
                    {
                        //logic for spare
                        scoreArray[i - 1] = scoreArray[i - 1] + pinInputs[i].PinsFall[0];
                        scoreArray[i] = scoreArray[i] + scoreArray[i - 1];
                        recordStrike = 0;
                    }
                    else
                    {
                        // when there is no spare and no strike
                        scoreArray[i] = scoreArray[i] + scoreArray[i - 1];
                        recordStrike = 0;
                    }
                    reolveFutureStrike(ref scoreArray, ref recordStrike,pinInputs[i].PinsFall[0]);
                }

            }
            // Returns the final score of the game.
            return 0;
        }
        private void reolveFutureStrike(ref List<int> scoreArray,ref int recordStrike,int value)
        {
            if (recordStrike > 1)
            {
                for (int i = recordStrike; i > 0; i--)
                {
                    scoreArray[scoreArray.Count - i] = scoreArray[scoreArray.Count - i] + value;
                }
               // recordStrike--;
            }
        }

    }
}
