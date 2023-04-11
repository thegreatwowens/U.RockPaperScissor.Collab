using System.Collections;
using UnityEngine;
using DentedPixel;
namespace ddr.RockPaperScissor.versusAI
{
    public class AnimationController : MonoBehaviour
    {
      [SerializeField]
      GameObject instruction,handlerChoices,opponentPicked,playerPicked,playerdataHandler,resultHandlerText;
      [SerializeField]
      CanvasGroup choicesHandlerCanvas;

      [SerializeField]
      GameObject  waitingPlayerpick;
      public bool isTween;

      
      public void ResetAnimation(){

            if(isTween){
                 LeanTween.scale(handlerChoices,new Vector3(1,1,1),1).setDelay(1f).setEase(LeanTweenType.easeOutElastic).setOnComplete(CanInteractChoices);
                 LeanTween.moveLocalY(playerPicked,-825.5f,1f).setEase(LeanTweenType.easeOutQuart);
                 LeanTween.moveLocalY(opponentPicked,825.5f,1f).setEase(LeanTweenType.easeOutQuart);
                 LeanTween.scale(resultHandlerText,new Vector3(0,0,0),1f).setEase(LeanTweenType.easeOutExpo);
            }
      }

      public void GameStart(){
        
          if(isTween){
              LeanTween.scale(handlerChoices,new Vector3(1,1,1),1).setDelay(.5f).setEase(LeanTweenType.easeOutElastic);
            //  StartCoroutine(delayWaitingPlayerPick());
          }
      }
     public void PlayerPicked(){

              if(isTween)
              {
                  DisableInteractChoices();
                  LeanTween.scale(handlerChoices,new Vector3(0,0,0),.5f).setEase(LeanTweenType.easeInElastic);
              }
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

            if(isTween){
                LeanTween.moveLocalY(playerPicked,-300f,1f).setEase(LeanTweenType.easeOutQuart);
                LeanTween.moveLocalY(opponentPicked,300f,1f).setEase(LeanTweenType.easeOutQuart);
            }
     }
    public void ShowInstruction(){
          if(isTween)
             {
             LeanTween.scale(instruction,new Vector3(1,1,1),1).setDelay(.3f).setEase(LeanTweenType.easeOutElastic);
             }

            }
    public void HideInstruction(){
        if(isTween)
        {
              LeanTween.scale(instruction,new Vector3(0,0,0),1).setEase(LeanTweenType.easeInOutElastic);
        }
      }
     public void DelayScreen(){
          // can show any animations..

          Debug.Log("Delaying Animations");
     }
      public void ResultOverlay(){
            if(isTween){
                    LeanTween.scale(resultHandlerText,new Vector3(1,1,1),1f).setEase(LeanTweenType.easeOutExpo);
            }  
      }
        IEnumerator delayWaitingPlayerPick(){

            yield return new WaitForSeconds(.5f);
              waitingPlayerpick.SetActive(true);
        }  
    }

  
}
