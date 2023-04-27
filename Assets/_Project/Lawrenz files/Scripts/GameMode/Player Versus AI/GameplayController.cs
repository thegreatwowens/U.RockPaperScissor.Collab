using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Collections;
using ddr.RockPaperScissor.PlayerManager;
using ddr.RockPaperScissor.UI;
using System.Collections.Generic;
using UnityEngine.Events;

namespace ddr.RockPaperScissor.versusAI
{
    public enum HandChoices
    {
        None,
        Rock,
        Paper,
        Scissor

    }
    public class GameplayController : MonoBehaviour
    {

        #region Variables
        AnimationController animationController;
        PlayerData playerData;
        GameplayUIs gameplayUIs;

        [Header("Sprites(icon) that is to instantiated")]
        [SerializeField]
        Sprite s_Rock;
        [SerializeField]
        Sprite s_Paper;
        [SerializeField]
        Sprite s_Scissor;
        [Space]
        [Header("Displayed after picked Do not edit:(Runtime Only)")]
        [SerializeField]
        Image img_PlayerPicked;
        [SerializeField]
        Image img_OpponentPicked;

        [SerializeField]
        private TextMeshProUGUI result_Info_text;

        [SerializeField]
        private int playerHealth { get; set; }
        [Header("Health System/Variables")]
        [SerializeField]
        GameObject HealthContainer;
        [SerializeField]
        GameObject lifeToBeInstantiated;
        [SerializeField]
        List<GameObject> playerHealthObj;

        public UnityEvent onGameFinished;
        [SerializeField]
        int streakingCount;

        private HandChoices player_picked = HandChoices.None, opponent_picked = HandChoices.None;

        #endregion

        private void Awake()
        {
        
            animationController = GetComponent<AnimationController>();
            playerData = GetComponent<PlayerData>();
            gameplayUIs = GetComponent<GameplayUIs>();
            Application.targetFrameRate = 90;

        }

        void Start()
        {

            animationController.ShowInstruction();

        }

        public void GameStart()
        {
            SoundManager.Instance.PlaySoundFx("UIClicked");
            playerHealth = 2;
            animationController.HideInstruction();
            animationController.GameStart();
            gameplayUIs.UpdateUIText();
            InstantiateHealth();
            SetOpponentChoice();
            playerData.playerStreakCount = 0;
            


        }
        public void InstantiateHealth()
        {
            for (int i = 0; i <= playerHealth; i++)
            {
                //LeanTween.scale(playerHealthObj.Add(Instantiate(lifeToBeInstantiated,HealthContainer.transform))),new Vector3(1,1,1),.3f).setDelay(.2f).setEase(LeanTweenType.easeInOutElastic);
                playerHealthObj.Add(Instantiate(lifeToBeInstantiated, HealthContainer.transform));
            }
        }

        public int playerHealthvalue()
        {
            return playerHealth;
        }
        private void SetOpponentChoice()
        {
            int rnd = Random.Range(0, 3);
            switch (rnd)
            {
                case 0:
                    opponent_picked = HandChoices.Rock;
                    img_OpponentPicked.sprite = s_Rock;
                    break;
                case 1:
                    opponent_picked = HandChoices.Paper;
                    img_OpponentPicked.sprite = s_Paper;
                    break;
                case 2:
                    opponent_picked = HandChoices.Scissor;
                    img_OpponentPicked.sprite = s_Scissor;
                    break;
            }
        }
        public void SetChoice(HandChoices picked)
        {

            switch (picked)
            {

                case HandChoices.Rock:
                    img_PlayerPicked.sprite = s_Rock;
                    player_picked = HandChoices.Rock;

                    break;
                case HandChoices.Paper:
                    img_PlayerPicked.sprite = s_Paper;
                    player_picked = HandChoices.Paper;
                    break;
                case HandChoices.Scissor:
                    img_PlayerPicked.sprite = s_Scissor;
                    player_picked = HandChoices.Scissor;
                    break;
            }
            
            StartCoroutine(DelayResult());
        }

        IEnumerator DelayResult()
        {
            animationController.PlayerPicked();
            animationController.DelayScreen();
            yield return new WaitForSeconds(1f);
            animationController.ShowChoicesResult();
            yield return new WaitForSeconds(.5f);
            CheckWinner();
        }

        private void DecreaseHealth()
        {

            DestroyImmediate(HealthContainer.transform.GetChild(playerHealth).gameObject);
            playerHealthObj.RemoveAt(playerHealth);
            playerHealth--;
            if (playerHealth < 0)
            {
                StartCoroutine(GameOver());
            }
            else{
                StartCoroutine(ContinuePlay());
                }
        }
        private void CheckWinner()
        {

            if (player_picked == opponent_picked)
            {
                result_Info_text.text = "Draw!";
                animationController.ResultOverlay();
                StartCoroutine(ContinuePlay());
                return;
            }

            if (player_picked == HandChoices.Paper && opponent_picked == HandChoices.Scissor
            || player_picked == HandChoices.Scissor && opponent_picked == HandChoices.Rock || player_picked == HandChoices.Rock && opponent_picked == HandChoices.Paper)
            {
                result_Info_text.text = "CPU Win!";
                animationController.ResultOverlay();
                playerData.LoseRound();
                
                DecreaseHealth();
                return;
            }

            if (player_picked == HandChoices.Paper && opponent_picked == HandChoices.Rock ||
             player_picked == HandChoices.Rock && opponent_picked == HandChoices.Scissor || player_picked == HandChoices.Scissor && opponent_picked == HandChoices.Paper)
            {
                result_Info_text.text = playerData.playerName + " Win!";
                animationController.ResultOverlay();
                playerData.Win();
                streakingCount = playerData.ReturnCurrentStreak();
                StartCoroutine(CheckStreaking());
                StartCoroutine(ContinuePlay());
                return;
            }
        }
        
        IEnumerator CheckStreaking()
        {
            if(streakingCount >=3 && player_picked != opponent_picked){
                animationController.ShowStreakAnimation(streakingCount.ToString());
            }
            
            yield return new WaitForSeconds(1f);
        }

        IEnumerator GameOver(){

            yield return new WaitForSeconds(1f);
            animationController.GameOverAnimation();
            GameFinished();

        }
        IEnumerator ContinuePlay()
        {
            gameplayUIs.UpdateUIText();
            // can Execute code for Scoring
            yield return new WaitForSeconds(1.5f);
            animationController.ResetAnimation();
            yield return new WaitForSeconds(1f);
            SetOpponentChoice();
            StopAllCoroutines();
        }
        void Update()
        {
            streakingCount = playerData.playerStreakCount;
        }

        public void GameFinished()
        {
            playerData.SubmitScore();
            if (onGameFinished != null)
                onGameFinished.Invoke();
        }

        public void ExitToMainMenu()
        {
            SceneChanger.instance.FadeToNextScene(1);

        }
        public void ClickedOption()
        {
            animationController.ShowOption();
            SoundManager.Instance.PlaySoundFx("UIClicked");
        }
        public void TryAgain()
        {
            animationController.HideGameCompletedWindow();
        }


    }


}


