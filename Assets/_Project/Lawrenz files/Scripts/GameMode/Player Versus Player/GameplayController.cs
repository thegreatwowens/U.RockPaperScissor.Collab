using UnityEngine;
using ddr.RockPaperScissor.UI;
using UnityEngine.UI;
namespace ddr.RockPaperScissor.PVP
{
    public class GameplayController : MonoBehaviour
    {

            public enum HandChoices{
        None,
        Rock,
        Paper,
        Scissor

    }
            //referrences
            AnimationController animationController;
            PvPGameSetting pvPGameSetting;
            UIHandlerController uIHandlerController;
            //UI References
            //variables
            int playerOneScore;
            int playerTwoScore;
             
            int currentRound;

         
            [Header("Sprite to be instantiated")]
            [SerializeField]
            Sprite s_Rock;
            [SerializeField]
            Sprite s_Scissor;
            [SerializeField]
            Sprite s_Paper;
            
                [Header("Players Choices Image")]
                [SerializeField]
                Image _playerOneChoice;
                [SerializeField]
                Image _PlayerTwoChoice;

           // private HandChoices ChoicePlayerOne = HandChoices.None, ChoicePlayerTwo = HandChoices.None;

                
            void Awake()
            {
                animationController = GetComponent<AnimationController>();
                pvPGameSetting = GetComponent<PvPGameSetting>();
                uIHandlerController = GetComponent<UIHandlerController>();            }

            public void StartGame(){
                        // Initialize Game
                        uIHandlerController.UpdateUI();
                        currentRound = 1;
                        playerOneScore = 0;
                        playerTwoScore = 0;
                        uIHandlerController.UpdateUI();  
                                  
            }

            

            //return roundslefts
            public int returnRoundleft(){
                    
                    return currentRound;
            }
            // returns playerScore one
            public int returnPlayerOneScore(){

                return playerOneScore;
            }
            // returns playerScore two
            public int returnPlayerTwoScore(){

                return playerTwoScore;
            }



            
    }
}
