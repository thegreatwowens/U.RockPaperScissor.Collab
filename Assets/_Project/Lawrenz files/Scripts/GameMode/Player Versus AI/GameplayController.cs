using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Collections;
using ddr.RockPaperScissor.PlayerManager;
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
        [Header("Testings:")]
        [SerializeField]
        TextMeshProUGUI Score_UI;
        [SerializeField]
        TextMeshProUGUI Streak_Count;
        
        private HandChoices player_picked = HandChoices.None, opponent_picked = HandChoices.None ;
    #endregion

        private void Awake() {
            animationController = GetComponent<AnimationController>();
            playerData = GetComponent<PlayerData>();
   
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
                            StartCoroutine(ContinuePlay());
                               playerData.LoseRound();
                               UpdateUI();
                        return;
                    }
                    
                    if(player_picked == HandChoices.Paper && opponent_picked == HandChoices.Rock ||
                     player_picked == HandChoices.Rock && opponent_picked == HandChoices.Scissor|| player_picked == HandChoices.Scissor && opponent_picked == HandChoices.Paper){
                         result_Info_text.text = "You Win!";
                            animationController.ResultOverlay();
                            StartCoroutine(ContinuePlay());
                            playerData.Win();
                            UpdateUI();
                        return; 

                    }

         
           }
              IEnumerator DelayResult(){
                        animationController.PlayerPicked();
                        animationController.DelayScreen();
                        yield return new WaitForSeconds(2);
                        animationController.ShowChoicesResult();
                        yield return new WaitForSeconds(.2f);
                        CheckWinner();
                        
                }
                IEnumerator ContinuePlay(){

                            // can Execute code for Scoring
                    
                    yield return new WaitForSeconds(4f);
                    animationController.ResetAnimation();
                }
                   private void UpdateUI(){

                    Score_UI.text = "Score: "+ playerData.Score();
                    Streak_Count.text = "Streak Count: "+ playerData.playerStreakCount;

            }


                
        }
           

    }


