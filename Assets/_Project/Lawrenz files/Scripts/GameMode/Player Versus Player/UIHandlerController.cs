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
            [SerializeField]
            TextMeshProUGUI PlayerOneScore;
            [SerializeField]    
            TextMeshProUGUI PlayerTwoScore;
            [SerializeField]
            TextMeshProUGUI RoundStatic;

            private void Awake() {
                gameplayController = GetComponent<GameplayController>();
                 pvPGameSetting = GetComponent<PvPGameSetting>();
            }
        
            public void UpdateUI(){
                        
                    PlayerNameOne.text = pvPGameSetting.playerOneName();
                    PlayerNameTwo.text = pvPGameSetting.playerTwoName();
                    PlayerOneScore.text ="Score: "+pvPGameSetting.P1ScoreData().ToString();
                    PlayerTwoScore.text ="Score: "+pvPGameSetting.P2ScoreData().ToString();
                    RoundsLeft.text = "Round " +gameplayController.returnRound()+" Race to "+pvPGameSetting.bestOfRounds;
                    RoundStatic.text = "Round "+gameplayController.returnRound();
                    
                   
            }


    }
}
