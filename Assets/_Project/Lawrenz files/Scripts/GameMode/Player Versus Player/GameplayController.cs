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
        [SerializeField]
        Slider volumeSlider;

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
void Awake()
{
     Application.targetFrameRate=90;
}
        
        void Start()
        {
               
                volumeSlider.value = SoundManager.Instance.musicSource.volume;
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
            StartCoroutine(GetComponent<AnimationController>().Interactables(pvPGameSetting.playerOneName(),"Player1",true,5f,GameState.PlayerOneTurn));
                animationController.EnableOptionButton();
        }
        public void HandlePlayerTurnTwo()
        {
             StartCoroutine(GetComponent<AnimationController>().Interactables(pvPGameSetting.playerTwoName(),"Player2",true,2.5f,GameState.PlayerTwoTurn));
                        animationController.FlipRounds();
                          
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
                       SoundManager.Instance.PlaySoundFx("UIClicked");
                        InputController.Instance.UpdateGameState(GameState.PlayerTwoTurn);
                    }

                    if (player == "Player2")
                    {
                        _PlayerTwoChoice.sprite = s_Paper;
                        playerTwoPicked = HandChoicesPVP.Paper;
                        animationController.ChoicesInteractable("Player2", false);
                        animationController.HidePlayerChoicesPlayerTwo();
                        SoundManager.Instance.PlaySoundFx("UIClicked");
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
                         SoundManager.Instance.PlaySoundFx("UIClicked");
                        InputController.Instance.UpdateGameState(GameState.PlayerTwoTurn);
                    }

                    if (player == "Player2")
                    {
                        _PlayerTwoChoice.sprite = s_Rock;
                        playerTwoPicked = HandChoicesPVP.Rock;
                        animationController.ChoicesInteractable("Player2", false);
                        animationController.HidePlayerChoicesPlayerTwo();
                        SoundManager.Instance.PlaySoundFx("UIClicked");
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
                         SoundManager.Instance.PlaySoundFx("UIClicked");
                        InputController.Instance.UpdateGameState(GameState.PlayerTwoTurn);
                    }

                    if (player == "Player2")
                    {
                        _PlayerTwoChoice.sprite = s_Scissor;
                        playerTwoPicked = HandChoicesPVP.Scissor;
                        animationController.ChoicesInteractable("Player2", false);
                        animationController.HidePlayerChoicesPlayerTwo();
                       SoundManager.Instance.PlaySoundFx("UIClicked");
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
            SoundManager.Instance.PlaySoundFx("UIClicked2");
        }
        public void ExitGameSetting(){
            SceneChanger.instance.FadeToNextScene(1);
        }
        public void HandleShowPlayerChoices()
        {
             SoundManager.Instance.PlaySoundFx("ShowhandlerPVA");
            animationController.EnableChoiceshandler();
          
        }

        internal void HandlePlayerPickedHandsResult()
        {
            animationController.DisableOptionButton();
            animationController.PickedResultHandler();
            SoundManager.Instance.PlaySoundFx("PickedHandlerPVA");
            StartCoroutine(ResultOverlayDelay());
        }

        IEnumerator ResultOverlayDelay()
        {
            yield return new WaitForSeconds(2.5f);
             SoundManager.Instance.PlaySoundFx("ShowhandlerPVA");
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
            SoundManager.Instance.PlayMusic("GameOverSoundPVP",false);
            animationController.ShowGameOverPanel();
            uIHandlerController.ResultUI();

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
            yield return new WaitForSeconds(2f);
            InputController.Instance.UpdateGameState(GameState.GameOver);
        }

        internal void HandleNextRound()

        {
            currentRound++;
            uIHandlerController.UpdateUI();
            animationController.ResetAnimation();
            InputController.Instance.UpdateGameState(GameState.PlayerOneTurn);
        }

        public void CLickedOption(){
            SoundManager.Instance.PlaySoundFx("UIClicked2");
            animationController.ShowOptionPanel();

        }

        public void OptionResetGame(){
            SceneChanger.instance.FadeToNextScene(3);

        }
        public void OptionBackToGame(){
                 SoundManager.Instance.PlaySoundFx("UIClicked2");
                animationController.HideOptionPanel();
        }
        public void OptionBackToMainMenu(){
                SoundManager.Instance.PlaySoundFx("UIClicked");
                SceneChanger.instance.FadeToNextScene(1);
        }

        public void OnVolumeChanged(){
                SoundManager.Instance.VolumeSlider(volumeSlider.value);
        }

        public void GameOverPanelReset(){
                currentRound = 1;
                pvPGameSetting.ResetScore();
                SoundManager.Instance.PlaySoundFx("UIClicked");
            animationController.HideGameOverPanel();
            SceneChanger.instance.FadeToNextScene(3);


        }


    }
        
}
