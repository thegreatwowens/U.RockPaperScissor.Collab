using System;
using UnityEngine;


namespace ddr.RockPaperScissor.PVP
{
    public enum HandChoicesPVP
    {
        None,
        Rock,
        Paper,
        Scissor

    }

    public enum GameState
    {
        GameStart,
        ShowPlayersChoices,
        TurnOverlay,
        PlayerOneTurn,
        PlayerTwoTurn,
        HandsResult,
        JudgeWinner,
        CheckScores,
        NextRound,
        GameOver
    }
    public class InputController : MonoBehaviour
    {
        public static InputController Instance;
        void Awake()
        {
                Instance = this;
        }
         void Start()
        {
                UpdateGameState(GameState.GameStart);
        }
        public static event Action<GameState> OnGameStateChanged;
        [SerializeField]
        GameplayController gameplayController;
        public GameState State;

        public void GetChoice(string player)
        {
            string choiceName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

            HandChoicesPVP selectedChoice = HandChoicesPVP.None;
            switch (choiceName)
            {

                case "Rock":
                    selectedChoice = HandChoicesPVP.Rock;
                    break;
                case "Paper":
                    selectedChoice = HandChoicesPVP.Paper;
                    break;
                case "Scissor":
                    selectedChoice = HandChoicesPVP.Scissor;
                    break;
            }
            Debug.Log(player + "picked: " + choiceName);
            gameplayController.PlayerSetChoice(player, selectedChoice);
        }
        public void UpdateGameState(GameState newState)
        {
            State = newState;

            switch (newState)
            {
                case GameState.GameStart:
                    gameplayController.GameStart();
                    
                    break;
                case GameState.PlayerOneTurn:
                    gameplayController.HandlePlayerTurnOne();
                    
                    break;
                case GameState.PlayerTwoTurn:
                     gameplayController.HandlePlayerTurnTwo();
                    break;    

                case GameState.ShowPlayersChoices:
                        gameplayController.HandleShowPlayerChoices();
                        break;

                case GameState.HandsResult:
                        gameplayController.HandlePlayerPickedHandsResult();
                     break;
                case GameState.JudgeWinner:
                        gameplayController.HandleJudgeRoundWinner();

                    break;
                case GameState.CheckScores:
                                gameplayController.HandleCheckScores();
                    break;
                 case GameState.NextRound:
                                gameplayController.HandleNextRound();
                    break;

               case GameState.GameOver: 
                                gameplayController.HandleGameOver();
                                
                        break;

            }
            OnGameStateChanged?.Invoke(newState);

        }
        

    }
}
