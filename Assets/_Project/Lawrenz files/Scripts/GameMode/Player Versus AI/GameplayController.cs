using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Collections;
using ddr.RockPaperScissor.PlayerManager;
using ddr.RockPaperScissor.UI;
using System.Collections.Generic;


namespace ddr.RockPaperScissor.versusAI
{
      public enum HandChoices{
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
        
        private HandChoices player_picked = HandChoices.None, opponent_picked = HandChoices.None;

        [SerializeField]
        GameObject healthIcon;
        [SerializeField]
        private int playerHealth = 3;
        [SerializeField]
        List<GameObject> Health;
        [SerializeField]
        GameObject HealthParent;
    #endregion

        private void Awake() {
            animationController = GetComponent<AnimationController>();
            playerData = GetComponent<PlayerData>();
            gameplayUIs = GetComponent<GameplayUIs>();
   
        }

            void Start()
            {
               
                animationController.ShowInstruction();
            }

            public void GameStart(){
             
               animationController.HideInstruction();
                animationController.GameStart();
                PopulateHealth();
            }

            public void PopulateHealth(){

                        for(int i=0;i<=playerHealth-1;i++){

                         Health.Add(Instantiate(healthIcon,HealthParent.transform));
                    }
                  
                    
            }
            private void SetOpponentChoice(){
                    int rnd = Random.Range(0,3);
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
        public void SetChoice(HandChoices picked){

            switch (picked){
                    
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
                SetOpponentChoice();
                StartCoroutine(DelayResult());
            }
            
              IEnumerator DelayResult(){
                        animationController.PlayerPicked();
                        animationController.DelayScreen();
                        yield return new WaitForSeconds(1f);
                        animationController.ShowChoicesResult();
                        yield return new WaitForSeconds(.5f);
                        CheckWinner();
                }
        private void CheckWinner(){
            
                    if(player_picked == opponent_picked){
                            result_Info_text.text = "Draw!";
                            animationController.ResultOverlay();
                            StartCoroutine(ContinuePlay());
                        return;
                    }

                    if(player_picked == HandChoices.Paper && opponent_picked == HandChoices.Scissor 
                    || player_picked == HandChoices.Scissor && opponent_picked == HandChoices.Rock|| player_picked == HandChoices.Rock && opponent_picked == HandChoices.Paper){
                        result_Info_text.text = "You Lose!";
                            animationController.ResultOverlay();
                            playerData.LoseRound();
                            gameplayUIs.UpdateUIText();
                            StartCoroutine(ContinuePlay());        
                        return;
                    }
                    
                    if(player_picked == HandChoices.Paper && opponent_picked == HandChoices.Rock ||
                     player_picked == HandChoices.Rock && opponent_picked == HandChoices.Scissor|| player_picked == HandChoices.Scissor && opponent_picked == HandChoices.Paper){
                         result_Info_text.text = "You Win!";
                            animationController.ResultOverlay();
                            playerData.Win();
                            gameplayUIs.UpdateUIText();
                            StartCoroutine(ContinuePlay());
                        return; 
                    }
           }
                IEnumerator ContinuePlay(){

                            // can Execute code for Scoring
                    
                    yield return new WaitForSeconds(1f);
                    animationController.ResetAnimation();
                }

                public void GameFinished(){
                    playerData.SubmitScore();       
                }
                
        }
           

    }


