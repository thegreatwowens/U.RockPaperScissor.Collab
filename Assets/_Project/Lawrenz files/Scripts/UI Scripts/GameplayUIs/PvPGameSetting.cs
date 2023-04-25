using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ddr.RockPaperScissor.PVP;
namespace ddr.RockPaperScissor.UI
{
         public enum Player {
            None,
            PlayerOne,
            PlayerTwo
        }
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
        public int bestOfRounds = 1;
        string _playerName1,_playerName2;
        
        private int P1Score {get;set;}
        private int P2Score {get;set;}
        
        void Start()
        {
            slider.value = 1;
            bestOfRounds = 1;
        }
      public void SliderValueChanged(){
         sliderText.text = ""+slider.value;
          bestOfRounds = ((int)slider.value);
      }
      public string playerOneName(){
            _playerName1 = playerName1.text;

        return _playerName1;
      }
      public string playerTwoName(){

            _playerName2 = playerName2.text;

        return _playerName2;
      }

        public int P1ScoreData(){
        
            return P1Score;
        }
         public int P2ScoreData(){
           
            return P2Score;
        }
        
        public void  ScoreDistribution(Player player){
                switch(player){
                        case Player.PlayerOne:
                                    P1Score++;
                                break;

                        case Player.PlayerTwo:
                                    P1Score++;
                                break;

                }

        }
        public void ResetScore(){
                    P1Score = 0;
                    P2Score = 0;
        }


    }


    public class PvPScoring :MonoBehaviour {

      
     


    }
}
