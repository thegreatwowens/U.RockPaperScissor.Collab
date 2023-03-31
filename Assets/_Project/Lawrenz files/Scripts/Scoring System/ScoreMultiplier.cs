using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ddr.RockPaperScissor.PlayerManager
{
    public class ScoreMultiplier : PlayerData
    {
        public int streakcount = 0;
       bool onStreak =false;

    private void Update() {
        streakcount = playerStreakCount;
    }

        public void CheckStreakCount(){

                if(streakcount >=3){

                    Score();
                }

        }

       public void StreakMultiplier(){


       }
       public double ReturnNewScore(){

        return Score();
       }
    }
}
