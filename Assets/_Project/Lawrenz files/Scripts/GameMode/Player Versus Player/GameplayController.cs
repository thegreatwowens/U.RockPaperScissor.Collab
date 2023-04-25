using UnityEngine;
using ddr.RockPaperScissor.UI;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

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
        public void GameStart()
        {
            animationController.ShowGameSettings();
        }
        public int returnRound(){

                return currentRound;
        }
        public void HandlePlayerTurnOne()
        {
            animationController.ShowTurnOverlay(pvPGameSetting.playerOneName(), "Player1", true);
                                LeanTween.delayedCall(1.5f,animationController.ShowRounds);
        }
        public void HandlePlayerTurnTwo()
        {
            animationController.ShowTurnOverlay(pvPGameSetting.playerTwoName(), "Player2", true);
        }
        public void HandleJudgeRoundWinner()
        {
            if (playerOnePicked == playerTwoPicked)
            {
                animationController.ShowWinner("Draw!");
                StartCoroutine(CheckScores());
                return;
            }

            if (playerOnePicked == HandChoicesPVP.Paper && playerTwoPicked == HandChoicesPVP.Scissor
            || playerOnePicked == HandChoicesPVP.Scissor && playerTwoPicked == HandChoicesPVP.Rock ||
             playerOnePicked == HandChoicesPVP.Rock && playerTwoPicked == HandChoicesPVP.Paper)
            {
                animationController.ShowWinner(pvPGameSetting.playerTwoName() + " Win!");
                pvPGameSetting.ScoreDistribution(Player.PlayerTwo);
                StartCoroutine(CheckScores());
                return;
            }

            if (playerOnePicked == HandChoicesPVP.Paper && playerTwoPicked == HandChoicesPVP.Rock ||
             playerOnePicked == HandChoicesPVP.Rock && playerTwoPicked == HandChoicesPVP.Scissor ||
             playerOnePicked == HandChoicesPVP.Scissor && playerTwoPicked == HandChoicesPVP.Paper)
            {
                animationController.ShowWinner(pvPGameSetting.playerOneName() + " Win!");
                pvPGameSetting.ScoreDistribution(Player.PlayerOne);
                StartCoroutine(CheckScores());
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
                        
                        InputController.Instance.UpdateGameState(GameState.HandsResult);
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
                        InputController.Instance.UpdateGameState(GameState.HandsResult);
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
                       
                        InputController.Instance.UpdateGameState(GameState.HandsResult);
                    }
                    break;

            }


        }

        public void StartGameButton()
        {
            animationController.GameStart();
            currentRound =1;
            uIHandlerController.UpdateUI();
            InputController.Instance.UpdateGameState(GameState.ShowPlayersChoices);
        }
        public void HandleShowPlayerChoices()
        {
            animationController.EnableChoiceshandler();
        }

        internal void HandlePlayerPickedHandsResult()
        {
            animationController.PickedResultHandler();
            StartCoroutine(ResultOverlayDelay());
        }

        IEnumerator ResultOverlayDelay()
        {
            yield return new WaitForSeconds(1.3f);
            InputController.Instance.UpdateGameState(GameState.JudgeWinner);
        }
        IEnumerator CheckScores()
        {
            yield return new WaitForSeconds(1.5f);
            InputController.Instance.UpdateGameState(GameState.CheckScores);


        }

        internal void HandleGameOver()
        {
            // ANIMATIONS
            animationController.ShowGameOverPanel();
            currentRound = 1;
            pvPGameSetting.ResetScore();
        }

        internal void HandleCheckScores()
        {
            if(pvPGameSetting.P1ScoreData() == pvPGameSetting.bestOfRounds||
             pvPGameSetting.P2ScoreData() == pvPGameSetting.bestOfRounds)
             {
                        StartCoroutine(DelayGameOver());
            }
            else{
                    InputController.Instance.UpdateGameState(GameState.NextRound);
            }
            
            
        }

        IEnumerator DelayGameOver(){

            animationController.HidePickedResultHandler();
            yield return new WaitForSeconds(.8f);
            InputController.Instance.UpdateGameState(GameState.GameOver);
        }

        internal void HandleNextRound()

        {
            currentRound++;
            uIHandlerController.UpdateUI();
            animationController.ResetAnimation();
            InputController.Instance.UpdateGameState(GameState.PlayerOneTurn);
        }


    }
        
}
