using UnityEngine;
using ddr.RockPaperScissor.UI;
using UnityEngine.UI;
namespace ddr.RockPaperScissor.PVP
{
    public class GameplayController : MonoBehaviour
    {

            public enum HandChoicesPVP{
        None,
        Rock,
        Paper,
        Scissor

    }
            //referrences
            [SerializeField]
            AnimationController animationController;
            PvPGameSetting pvPGameSetting;
            UIHandlerController uIHandlerController;
            //UI References
            //variables
            int playerOneScore;
            int playerTwoScore;
             
            int currentRound;

            [HideInInspector]
            public string PlayerCurrentTurn;
         
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
            HandChoicesPVP playerOnePicked;
            HandChoicesPVP playerTwoPicked;
           // private HandChoices ChoicePlayerOne = HandChoices.None, ChoicePlayerTwo = HandChoices.None;

                
            void Start()
            {
                animationController.ShowGameSettings();
            }

            public void StartGame(){  
                animationController.GameStart();
            }

            public void PlayerOneTurn(){
                animationController.PlayerTurn("Player1");
            }
            public void PlayerSetChoice(string player, HandChoicesPVP choice){
                       
                       switch (choice){
                            case HandChoicesPVP.Paper:
                                        if(player == "Player1"){
                                            _playerOneChoice.sprite = s_Paper;
                                            playerOnePicked = HandChoicesPVP.Paper;
                                            animationController.ChoicesInteractable("player",false);
                                        }
                                        
                                        if(player == "Player2"){
                                            _PlayerTwoChoice.sprite = s_Paper;
                                            playerTwoPicked = HandChoicesPVP.Paper;
                                            animationController.ChoicesInteractable("player",false);
                                        }
                                 break;
                            case HandChoicesPVP.Rock:
                                        if(player == "Player1"){
                                            _playerOneChoice.sprite = s_Rock;
                                            playerOnePicked = HandChoicesPVP.Rock;
                                            animationController.ChoicesInteractable("player",false);
                                        }

                                        if(player == "Player2"){
                                            _PlayerTwoChoice.sprite = s_Rock;
                                            playerTwoPicked = HandChoicesPVP.Rock;
                                            animationController.ChoicesInteractable("player",false);
                                        }
                                 break;
                            case HandChoicesPVP.Scissor:
                                        if(player == "Player1"){
                                            _playerOneChoice.sprite = s_Scissor;
                                            playerOnePicked = HandChoicesPVP.Scissor;
                                            animationController.ChoicesInteractable("player",false);
                                        }
                                        
                                        if(player == "Player2"){
                                            _PlayerTwoChoice.sprite = s_Scissor;
                                            playerTwoPicked = HandChoicesPVP.Scissor;
                                            animationController.ChoicesInteractable("player",false);
                                        }
                                 break;

                       }

            }
            
            public void CheckWinner(){
                        if (playerOnePicked == playerTwoPicked)
            {
               
                return;
            }

            if (playerOnePicked == HandChoicesPVP.Paper && playerTwoPicked == HandChoicesPVP .Scissor
            || playerOnePicked == HandChoicesPVP .Scissor && playerTwoPicked == HandChoicesPVP .Rock || playerOnePicked == HandChoicesPVP .Rock && playerTwoPicked == HandChoicesPVP .Paper)
            {
                
                return;
            }

            if (playerOnePicked == HandChoicesPVP .Paper && playerTwoPicked == HandChoicesPVP .Rock ||
             playerOnePicked == HandChoicesPVP .Rock && playerTwoPicked == HandChoicesPVP .Scissor || playerOnePicked == HandChoicesPVP .Scissor && playerTwoPicked == HandChoicesPVP .Paper)
            {
                
                return;
            }

            

            }
    }
}
