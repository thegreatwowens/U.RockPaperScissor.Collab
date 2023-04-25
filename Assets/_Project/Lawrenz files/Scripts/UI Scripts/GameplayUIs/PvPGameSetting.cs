using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ddr.RockPaperScissor.PVP;
namespace ddr.RockPaperScissor.UI
{
    public class PvPGameSetting : MonoBehaviour
    {
        // Variables
        #region  UI Variables

      [SerializeField]
      TMP_InputField playerName1, playerName2;
      [SerializeField]
      Slider slider;
      [SerializeField]
      TextMeshProUGUI sliderText;
        # endregion
        public static int numberOfRounds;
        string _playerName1,_playerName2;
        
        private int P1Score {get;set;}
        private int P2Score {get;set;}

      public void SliderValueChanged(){
         sliderText.text = ""+slider.value;
          numberOfRounds = ((int)slider.value);
      }
    
      public string playerOneName(){
            _playerName1 = playerName1.text;

        return _playerName1;
      }
      public string playerTwoName(){

            _playerName2 = playerName2.text;

        return _playerName2;
      }
      public int NumberofRounds(){

        return numberOfRounds;
      }
        public int P1ScoreData(){
          
            return PvPScoring.ReturnCurrentPlayerScore(PvPScoring.Player.PlayerOne);
        }
         public int P2ScoreData(){
            return PvPScoring.ReturnCurrentPlayerScore(PvPScoring.Player.PlayerTwo);
        }

    }


    public class PvPScoring :PvPGameSetting {

      
         public enum Player {

            None,
            PlayerOne,
            PlayerTwo

        }
  
        
        private  static int PlayerOneScore {get; set;}
        private  static int PlayerTwoScore {get; set;}
        private static int Rounds {get; set;}
        public  static void ScoreDistribution(Player player){
                  switch (player)
                  {
                      case Player.PlayerOne:

                            PlayerOneScore ++;
                      break; 

                      case Player.PlayerTwo:
                            PlayerTwoScore++;
                      break; 

                  }
            
        }

        public static void RoundsManager(){

              if(numberOfRounds !=0){
                    InputController.Instance.UpdateGameState(GameState.NextRound);
                    return;
              }
              else{
                      // do something for GameOVer
              }

        }

        public static int ReturnCurrentPlayerScore(Player player){
              int valueReturn = 0;
              if(player == Player.PlayerOne){

                  valueReturn  = PlayerOneScore;

              }
              
              if (player == Player.PlayerOne){

                  valueReturn  = PlayerTwoScore;
              }

              return valueReturn;
              
        
        }

    }
}
