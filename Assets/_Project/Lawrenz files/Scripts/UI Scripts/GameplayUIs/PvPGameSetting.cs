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

        void Update()
        {
           sliderText.text = ""+slider.value;
        }
      public string playerOne(){
            _playerName1 = playerName1.text;

        return _playerName1;
      }
      public string playerTwo(){

            _playerName2 = playerName2.text;

        return _playerName2;
      }
      public int NumberofRounds(){

        return numberOfRounds;
      }


    
    }
}
