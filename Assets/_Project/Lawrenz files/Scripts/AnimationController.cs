using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ddr.RockPaperScissor
{
    public class AnimationController : MonoBehaviour
    {
      [SerializeField]
      Animator animationControllerHandler, choicesAnimations,waitingControllerHandler;

      public void ResetAnimation(){

            animationControllerHandler.Play("ShowHandler");
            choicesAnimations.Play("HideHandler");
            waitingControllerHandler.Play("ShowHandler");


      }

     public void PlayerPicked(){
            animationControllerHandler.Play("HideHandler");
            choicesAnimations.Play("ShowHandler");
            waitingControllerHandler.Play("HideHandler");

     }
    
    }
}
