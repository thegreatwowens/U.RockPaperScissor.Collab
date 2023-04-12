using System.Collections;
using UnityEngine;
using DentedPixel;
namespace ddr.RockPaperScissor.versusAI
{
    public class AnimationController : MonoBehaviour
    {
      [SerializeField]
      GameObject instruction,handlerChoices,opponentPicked,playerPicked,playerdataHandler,resultHandlerText,exit;
      [SerializeField]
      CanvasGroup choicesHandlerCanvas;

      [SerializeField]
      GameObject  waitingPlayerpick;

      
      public void ResetAnimation(){


                 LeanTween.scale(handlerChoices,new Vector3(1,1,1),1).setDelay(1f).setEase(LeanTweenType.easeOutElastic).setOnComplete(CanInteractChoices);
                 LeanTween.moveLocalY(playerPicked,-825.5f,1f).setEase(LeanTweenType.easeOutQuart);
                 LeanTween.moveLocalY(opponentPicked,825.5f,1f).setEase(LeanTweenType.easeOutQuart);
                 LeanTween.scale(resultHandlerText,new Vector3(0,0,0),1f).setEase(LeanTweenType.easeOutExpo);
                 LeanTween.moveLocalY(playerdataHandler,-473f,.5F).setEase(LeanTweenType.easeInOutQuart);
                 exit.SetActive(true);
                 

      }

      public void GameStart(){

              LeanTween.scale(handlerChoices,new Vector3(1,1,1),1).setDelay(.5f).setEase(LeanTweenType.easeOutElastic);
              LeanTween.moveLocalY(playerdataHandler,-473f,.5f).setDelay(.5f).setEase(LeanTweenType.easeInOutQuart);
              exit.SetActive(true);
            //  StartCoroutine(delayWaitingPlayerPick());

      }
     public void PlayerPicked(){

                   DisableInteractChoices();
                  LeanTween.scale(handlerChoices,new Vector3(0,0,0),.5f).setEase(LeanTweenType.easeInElastic);
                  LeanTween.moveLocalY(playerdataHandler,-875f,1).setEase(LeanTweenType.easeInOutQuart);
                  exit.SetActive(false);
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
              LeanTween.scale(instruction,new Vector3(0,0,0),1).setEase(LeanTweenType.easeInOutElastic).setDestroyOnComplete(true);
      }
     public void DelayScreen(){
          // can show any animations..
          Debug.Log("Delaying Animations");
     }
      public void ResultOverlay(){
   
                    LeanTween.scale(resultHandlerText,new Vector3(1,1,1),1f).setEase(LeanTweenType.easeOutExpo);
      }
        IEnumerator delayWaitingPlayerPick(){

            yield return new WaitForSeconds(.5f);
              waitingPlayerpick.SetActive(true);
        }  
    }

  
}
