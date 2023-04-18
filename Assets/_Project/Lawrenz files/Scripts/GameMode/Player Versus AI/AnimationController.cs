using System.Collections;
using UnityEngine;
using ddr.RockPaperScissor.PlayerManager;
using TMPro;
namespace ddr.RockPaperScissor.versusAI
{
    public class AnimationController : MonoBehaviour
    {
      [SerializeField]
      PlayerData playerData;
      [SerializeField]
      GameObject instruction,handlerChoices,opponentPicked,playerPicked,playerdataHandler,
                resultHandlerText,optionButton,showOptionHandler,GameDoneHandler,PlayerTurnHandler;
      [SerializeField]
      CanvasGroup choicesHandlerCanvas,BackgroundGameDoneHandler,BackgroundOverlayOption;
      [Header("WinningStreak Instantiation")]
      [SerializeField]
      GameObject streakingParentObj;
      [SerializeField]
      GameObject winningStreakObj;
      
      string StreakingText= null;

      
      public void ResetAnimation(){

                 LeanTween.scale(handlerChoices,new Vector3(1,1,1),1).setDelay(1f).setEase(LeanTweenType.easeOutElastic).setOnComplete(CanInteractChoices);
                 LeanTween.moveLocalY(playerPicked,-825.5f,1f).setEase(LeanTweenType.easeOutQuart);
                 LeanTween.moveLocalY(opponentPicked,825.5f,1f).setEase(LeanTweenType.easeOutQuart);
                 LeanTween.scale(resultHandlerText,new Vector3(0,0,0),1f).setEase(LeanTweenType.easeOutExpo);
                 LeanTween.scale(playerdataHandler,new Vector3(1,1,1),1f).setEase(LeanTweenType.easeOutExpo);
                 LeanTween.scale(optionButton,new Vector3(1,1,1),.1f);      

      }

      public void GameStart(){
                StartCoroutine(DelayInteractHandler());
              LeanTween.scale(handlerChoices,new Vector3(1,1,1),1).setDelay(.5f).setEase(LeanTweenType.easeInOutQuart);
              LeanTween.scale(playerdataHandler,new Vector3(1,1,1),1f).setDelay(.8f).setEase(LeanTweenType.easeInOutQuart);
              LeanTween.scale(optionButton,new Vector3(1,1,1),.1f);

      }
            private void ShowPlayerTurn(){
              
            }
             private void HidePlayerTurn(){

            }
      public void ShowOption(){
              ShowOptionBackOverlay();
              LeanTween.scale(showOptionHandler,new Vector3(1.2f,1.2f,1.2f),1f).setEase(LeanTweenType.easeInOutQuart);
              LeanTween.moveLocal(showOptionHandler,new Vector3(185,160,0f),.5f);
              LeanTween.scale(optionButton,new Vector3(0,0,0),.1f);
               
      }
      public void HideOption(){
              HideOptionBackOverlay();
              LeanTween.moveLocal(showOptionHandler,new Vector3(190,461,0f),.5f);
              LeanTween.scale(showOptionHandler,new Vector3(0,0,0),.9f).setEase(LeanTweenType.easeOutExpo);
              LeanTween.scale(optionButton,new Vector3(1,1,1),.1f);
              
             
      }
            private void ShowOptionBackOverlay(){
                        CanvasGroup interactables = BackgroundOverlayOption.GetComponent<CanvasGroup>();
                              interactables.interactable = true;
                              interactables.blocksRaycasts = true;
                        LeanTween.alphaCanvas(BackgroundOverlayOption,1,.2f);
            }
            private void HideOptionBackOverlay(){
                  CanvasGroup interactables = BackgroundOverlayOption.GetComponent<CanvasGroup>();
                              interactables.interactable = false;
                              interactables.blocksRaycasts = false;
                        LeanTween.alphaCanvas(BackgroundOverlayOption,0,.2f);

            }
           IEnumerator DelayInteractHandler(){
                DisableInteractChoices();
                yield return new WaitForSeconds(1.5f);
                CanInteractChoices();
           }
     public void PlayerPicked(){

                   DisableInteractChoices();
                  LeanTween.scale(handlerChoices,new Vector3(0,0,0),.5f).setEase(LeanTweenType.easeInElastic);
                  LeanTween.scale(playerdataHandler,new Vector3(0,0,0),.5f).setEase(LeanTweenType.easeOutQuart);
                  LeanTween.scale(optionButton,new Vector3(0,0,0),.5f).setEase(LeanTweenType.easeOutQuart);
     }
    public void DisableInteractChoices(){
              choicesHandlerCanvas.interactable = false;
              choicesHandlerCanvas.blocksRaycasts = false;
    }
    public void CanInteractChoices(){
          choicesHandlerCanvas.interactable = true;
          choicesHandlerCanvas.blocksRaycasts = true;
    }
     public void ShowChoicesResult(){

                LeanTween.moveLocalY(playerPicked,-300f,1f).setEase(LeanTweenType.easeOutQuart);
                LeanTween.moveLocalY(opponentPicked,300f,1f).setEase(LeanTweenType.easeOutQuart);
     }
    public void ShowInstruction(){

             LeanTween.scale(instruction,new Vector3(1,1,1),1).setDelay(.3f).setEase(LeanTweenType.easeOutElastic);
            }
    public void HideInstruction(){
                CanvasGroup interactables = instruction.transform.GetComponentInChildren<CanvasGroup>();
                  interactables.interactable = false;
                  interactables.blocksRaycasts = false;
                LeanTween.scale(instruction,new Vector3(0,0,0),1).setEase(LeanTweenType.easeInOutElastic).setLoopClamp(0);
                
      }
     public void DelayScreen(){
          // can show any animations..
          Debug.Log("Delaying Animations");
     }
      public void ResultOverlay(){
   
                    LeanTween.scale(resultHandlerText,new Vector3(1,1,1),1f).setEase(LeanTweenType.easeOutExpo);
      }
     public void GameOverAnimation(){    
                StartCoroutine(DelayAnimationTryAgain());      
      }

      IEnumerator DelayAnimationTryAgain(){
             LeanTween.moveLocalY(playerPicked,-825.5f,1f).setEase(LeanTweenType.easeOutQuart);
             LeanTween.moveLocalY(opponentPicked,825.5f,1f).setEase(LeanTweenType.easeOutQuart);
             LeanTween.scale(optionButton,new Vector3(0,0,0),.5f);
             LeanTween.scale(handlerChoices,new Vector3(0,0,0),.5f);
             LeanTween.scale(playerdataHandler,new Vector3(0,0,0),.5f);
             LeanTween.scale(resultHandlerText,new Vector3(0,0,0),.5f);
             yield return new WaitForSeconds(1f);
            FadeOutHandler();
      }

            // Show Game Completed Window
      private void FadeOutHandler(){
                LeanTween.scale(resultHandlerText,new Vector3(0,0,0),.5f).setOnComplete(ShowGameCompletedWindow);  
      }
      private void ShowGameCompletedWindow(){
                LeanTween.alphaCanvas(BackgroundGameDoneHandler,1,.3f);
                LeanTween.scale(GameDoneHandler,new Vector3(1.3f,1.3f,1.3f),.5f).setDelay(.6f).setEase(LeanTweenType.easeInOutElastic);
      }
      
      public void HideGameCompletedWindow(){
              LeanTween.scale(GameDoneHandler,new Vector3(0,0,0),.5f).setEase(LeanTweenType.easeInOutElastic);
              LeanTween.alphaCanvas(BackgroundGameDoneHandler,0,.3f).setDelay(.7f).setOnComplete(Delay);
      }

      private void Delay(){

            StartCoroutine(AnimationReset());
      }

      IEnumerator AnimationReset(){

        yield return new WaitForSeconds(1.5f);
        ResetAnimationGame();

      }
      
      public void ResetAnimationGame(){
            LeanTween.scale(instruction,new Vector3(1,1,1),1).setDelay(.3f).setEase(LeanTweenType.easeOutElastic);
            CanvasGroup interactables = instruction.transform.GetComponentInChildren<CanvasGroup>();
                  interactables.interactable = true;
                  interactables.blocksRaycasts = true;
      }
      
      public void ShowStreakAnimation(string count){
            LeanTween.cancel(resultHandlerText);
            StartCoroutine(StreakInstantiate(count));

      }
      void Update()
      {
            StreakingText = playerData.playerStreakCount+"!";
      }
    IEnumerator StreakInstantiate(string streakcount){
            Instantiate(winningStreakObj,streakingParentObj.transform);
            TextMeshProUGUI text  = winningStreakObj.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                  text.text=StreakingText;
            yield return new WaitForEndOfFrame();
            LeanTween.scale(streakingParentObj.transform.GetChild(0).gameObject,new Vector3(2.5f,2.5f,2.5f),1f)
            .setDelay(.2f).setEase(LeanTweenType.easeOutBounce).setDestroyOnComplete(streakingParentObj.transform.GetChild(0).gameObject);
                  
      }
      public void HideStreakAnimation(){

      }


    }
      
   

  
}
