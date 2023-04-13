using UnityEngine;
using CarterGames.Assets.LeaderboardManager;

namespace ddr.RockPaperScissor.PlayerManager
{
    public class PlayerData : MonoBehaviour
    {
        public string playerName {get;set;}

                [SerializeField]
                double playercurrentScore = 0;

                // standard value per correct answer vs CPU
                int normalScore = 25;
                // Streaking multiplier

                int streakingScore = 50;
                public int playerStreakCount = 0;

                void Awake()
                {
                   playerName = LoadPlayerName();
                }
      public static void SavePlayerName(string name){
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
                        if(playerStreakCount <= 3){
                                playercurrentScore = normalScore +playercurrentScore;
                                playerStreakCount++;
                                return;
                        }
                        

                        if(playerStreakCount >4){
                                 playercurrentScore = streakingScore +playercurrentScore;
                                 playerStreakCount++;
                                 return;
                        }
    }
        public void Win(){
                IncrementScore();
        }
          public void LoseRound(){

            if(playerStreakCount !=0)
            playerStreakCount = 0;
    }   
        public void SubmitScore(){
                  LeaderboardManager.AddEntryToBoard("RockPaperScissorRanking",playerName,playercurrentScore);
                  LeaderboardManager.Save();
                  playercurrentScore = 0;
        }
        



  
    }
    

}
