using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ddr.RockPaperScissor.PlayerManager
{
    public class PlayerData : MonoBehaviour
    {
        public string playerName = "Player";
                [SerializeField]
                double playercurrentScore = 0;

                // standard value per correct answer vs CPU
                int normalScore = 25;
                public int playerStreakCount = 0;

      public void SavePlayerName(string name){
                PlayerPrefs.SetString("SavedPlayerName",name);
                PlayerPrefs.Save();

      }
      public string  LoadPlayerName(){
            
            return PlayerPrefs.GetString("SavedPlayerName");

      }
      public double Score(){

        return playercurrentScore;
      }

      private void IncrementScore(){
            playercurrentScore = normalScore +playercurrentScore;
            playerStreakCount++;
    }
        public void Win(){
                IncrementScore();
                return;
        }
          public void LoseRound(){
            if(playerStreakCount !=0)
            playerStreakCount = 0;

            return;
    }   


  
    }
    

}
