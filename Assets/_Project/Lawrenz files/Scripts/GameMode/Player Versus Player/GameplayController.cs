using UnityEngine;
using ddr.RockPaperScissor.UI;
using UnityEngine.UI;
using System;
using System.Collections;

namespace ddr.RockPaperScissor.PVP
{


    public class GameplayController : MonoBehaviour
    {

        #region  References and variables
        //referrences
        [SerializeField]
        AnimationController animationController;
        [SerializeField]
        PvPGameSetting pvPGameSetting;
        [SerializeField]
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
        #endregion

        void Start()
        {

        }
        public void StartGame()
        {
            animationController.ShowGameSettings();
            
           
        }

        public void HandlePlayerTurnOne()
        {
                animationController.ShowTurnOverlay(pvPGameSetting.playerOneName(),"Player1",true);
        }

        public void HandlePlayerTurnTwo()
        {
                   animationController.ShowTurnOverlay(pvPGameSetting.playerTwoName(),"Player2",true); 
        }

        public void HandleDecideGame()
        {
            if (playerOnePicked == playerTwoPicked)
            {
                    animationController.ShowWinner("Draw!");
                       StartCoroutine(GameReset());
                return;
            }

            if (playerOnePicked == HandChoicesPVP.Paper && playerTwoPicked == HandChoicesPVP.Scissor
            || playerOnePicked == HandChoicesPVP.Scissor && playerTwoPicked == HandChoicesPVP.Rock || playerOnePicked == HandChoicesPVP.Rock && playerTwoPicked == HandChoicesPVP.Paper)
            {
                animationController.ShowWinner(pvPGameSetting.playerTwoName() +" Win!");
                PvPScoring.ScoreDistribution(PvPScoring.Player.PlayerTwo);
                uIHandlerController.UpdateUI();
                StartCoroutine(GameReset());
                return;
            }

            if (playerOnePicked == HandChoicesPVP.Paper && playerTwoPicked == HandChoicesPVP.Rock ||
             playerOnePicked == HandChoicesPVP.Rock && playerTwoPicked == HandChoicesPVP.Scissor || playerOnePicked == HandChoicesPVP.Scissor && playerTwoPicked == HandChoicesPVP.Paper)
            {
                animationController.ShowWinner(pvPGameSetting.playerOneName() +" Win!");
                PvPScoring.ScoreDistribution(PvPScoring.Player.PlayerOne);
                uIHandlerController.UpdateUI();
                StartCoroutine(GameReset());
                return;
            }


        }

        public void PlayerSetChoice(string player, HandChoicesPVP choice)
        {

            switch (choice)
            {
                case HandChoicesPVP.Paper:
                    if (player == "Player1")
                    {
                        _playerOneChoice.sprite = s_Paper;
                        playerOnePicked = HandChoicesPVP.Paper;
                        animationController.ChoicesInteractable("Player1", false);
                        animationController.HidePlayerChoicesPlayerOne();
                       
                        InputController.Instance.UpdateGameState(GameState.PlayerTwoTurn);
                    }

                    if (player == "Player2")
                    {
                        _PlayerTwoChoice.sprite = s_Paper;
                        playerTwoPicked = HandChoicesPVP.Paper;
                        animationController.ChoicesInteractable("Player2", false);
                        animationController.HidePlayerChoicesPlayerTwo();
                         animationController.HideRounds();
                        InputController.Instance.UpdateGameState(GameState.ResultChoices);
                    }
                    break;
                case HandChoicesPVP.Rock:
                    if (player == "Player1")
                    {
                        _playerOneChoice.sprite = s_Rock;
                        playerOnePicked = HandChoicesPVP.Rock;
                        animationController.ChoicesInteractable("Player1", false);
                        animationController.HidePlayerChoicesPlayerOne();
                        InputController.Instance.UpdateGameState(GameState.PlayerTwoTurn);
                    }

                    if (player == "Player2")
                    {
                        _PlayerTwoChoice.sprite = s_Rock;
                        playerTwoPicked = HandChoicesPVP.Rock;
                        animationController.ChoicesInteractable("Player2", false);
                        animationController.HidePlayerChoicesPlayerTwo();
                         animationController.HideRounds();
                        InputController.Instance.UpdateGameState(GameState.ResultChoices);
                    }
                    break;
                case HandChoicesPVP.Scissor:
                    if (player == "Player1")
                    {
                        _playerOneChoice.sprite = s_Scissor;
                        playerOnePicked = HandChoicesPVP.Scissor;
                        animationController.ChoicesInteractable("Player1", false);
                        animationController.HidePlayerChoicesPlayerOne();
                        InputController.Instance.UpdateGameState(GameState.PlayerTwoTurn);
                    }

                    if (player == "Player2")
                    {
                        _PlayerTwoChoice.sprite = s_Scissor;
                        playerTwoPicked = HandChoicesPVP.Scissor;
                        animationController.ChoicesInteractable("Player2", false);
                        animationController.HidePlayerChoicesPlayerTwo();
                         animationController.HideRounds();
                        InputController.Instance.UpdateGameState(GameState.ResultChoices);
                    }
                    break;

            }


        }

        public void StartGameButton(){
            animationController.GameStart();
             uIHandlerController.UpdateUI();
            InputController.Instance.UpdateGameState(GameState.ShowChoicesOverlay);
        }
        public void ShowChoices(){
                animationController.EnableChoiceshandler();
            
        }

        internal void ResultChoices()
        {
            animationController.PickedResultHandler();
                StartCoroutine(ResultOverlayDelay());
        }

        internal void HandleGameReset(){
                animationController.ResetAnimation();
                InputController.Instance.UpdateGameState(GameState.PlayerOneTurn);

        }
        
        public void RoundOverlay(){

        }
        IEnumerator ResultOverlayDelay(){

            yield return new WaitForSeconds(2f);
            InputController.Instance.UpdateGameState(GameState.DecideGame);

        }
        IEnumerator GameReset(){
                PvPScoring.RoundsManager();
            yield return new WaitForSeconds(1.5f);
          
         
        }

        internal void HandleGameOver()
        {
        // ANIMATIONS



        }
    }
}
