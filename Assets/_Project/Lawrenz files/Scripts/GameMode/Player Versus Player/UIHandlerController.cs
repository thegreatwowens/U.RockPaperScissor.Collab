using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ddr.RockPaperScissor.UI;
namespace ddr.RockPaperScissor.PVP
{
    public class UIHandlerController : MonoBehaviour
    {
            /// References
            GameplayController gameplayController;
            PvPGameSetting pvPGameSetting;

            ///UI references
             [SerializeField]
            TextMeshProUGUI PlayerNameOne;
             [SerializeField]
            TextMeshProUGUI PlayerNameTwo;
             [SerializeField]
            TextMeshProUGUI RoundsLeft;
            [SerializeField]
            TextMeshProUGUI TurnText;
            [Header("Scores")]
            TextMeshProUGUI PlayerOneScore;
            TextMeshProUGUI PlayerTwoScore;
            private void Awake() {
                gameplayController = GetComponent<GameplayController>();
                 pvPGameSetting = GetComponent<PvPGameSetting>();
            }
            public void UpdateUI(){
                    PlayerNameOne.text = pvPGameSetting.playerOne();
                    PlayerNameTwo.text = pvPGameSetting.playerTwo();
                    // Updates rounds
                    RoundsLeft.text = "Round "+gameplayController.returnRoundleft()+" of "+
                    pvPGameSetting.NumberofRounds();
                    //Updates Score
                    PlayerOneScore.text =""+ gameplayController.returnPlayerOneScore();
                    PlayerTwoScore.text =""+ gameplayController.returnPlayerTwoScore();
            }

    }
}
