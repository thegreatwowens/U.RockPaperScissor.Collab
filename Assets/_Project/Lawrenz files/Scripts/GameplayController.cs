using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace ddr.RockPaperScissor
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
        private TextMeshProUGUI Info_text;

        private HandChoices player_picked = HandChoices.None, opponent_picked = HandChoices.None ;
    #endregion

        private void Awake() {
            animationController = GetComponent<AnimationController>();
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

        private void DecideWinner(){
            
           }
        }
           

    }


