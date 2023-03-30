using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ddr.RockPaperScissor
{
    public class AnimationController : MonoBehaviour
    {
      [SerializeField]
      Animator animationControllerHandler, choicesAnimations,waitingControllerHandler,resultHandler;

      public void ResetAnimation(){

            animationControllerHandler.Play("ShowHandler");
            choicesAnimations.Play("HideHandler");
            waitingControllerHandler.Play("ShowHandler");
            resultHandler.Play("HideHandler");


      }

     public void PlayerPicked(){
            animationControllerHandler.Play("HideHandler");
            waitingControllerHandler.Play("HideHandler");

     }

     public void ShowChoicesResult(){
            choicesAnimations.Play("ShowHandler");
     }

     public void DelayScreen(){
          Debug.Log("Delaying Animations");

     }
      
      public void ResultOverlay(){
          resultHandler.Play("ShowHandler");
  
      }
    
    }
}
