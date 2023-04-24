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
        ShowChoicesOverlay,
        TurnOverlay,
        PlayerOneTurn,
        PlayerTwoTurn,
        ResultChoices,
        DecideGame,
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
                    gameplayController.StartGame();
                    
                    break;
                case GameState.PlayerOneTurn:
                    gameplayController.HandlePlayerTurnOne();
                    
                    break;
                case GameState.ShowChoicesOverlay:
                        gameplayController.ShowChoices();
                        break;

                case GameState.PlayerTwoTurn:
                     gameplayController.HandlePlayerTurnTwo();
                    break;
                case GameState.ResultChoices:
                        gameplayController.ResultChoices();
                     break;
                case GameState.DecideGame:
                        gameplayController.HandleDecideGame();

                    break;
                case GameState.NextRound:
                                gameplayController.HandleGameReset();
                    break;
               case GameState.GameOver: 
                                gameplayController.HandleGameOver();
                                
                        break;

            }
            OnGameStateChanged?.Invoke(newState);

        }
        

    }
}
