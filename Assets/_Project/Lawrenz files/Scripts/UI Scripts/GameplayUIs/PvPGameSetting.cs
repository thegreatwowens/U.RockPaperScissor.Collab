using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
        int numberOfRounds;
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
            return P1Score;
        }
         public int P2ScoreData(){
            return P2Score;
        }

    }
}
