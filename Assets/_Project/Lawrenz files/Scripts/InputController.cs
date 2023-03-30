using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ddr.RockPaperScissor
{
    public class InputController : MonoBehaviour
    {
         GameplayController gameplayController;
         AnimationController animationController;
        private void Awake() {

                    gameplayController = GetComponent<GameplayController>();
                    animationController = GetComponent<AnimationController>();
        }
        
        public void GetChoice(){
            string choiceName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

            HandChoices selectedChoice = HandChoices.None;

            switch(choiceName){

                case "Rock":
                        selectedChoice = HandChoices.Rock;
                       
                break;
                case "Paper":
                        selectedChoice = HandChoices.Paper;
                break;
                case "Scissor":
                        selectedChoice = HandChoices.Scissor;
                break;
            }
                 Debug.Log(selectedChoice);
                 gameplayController.SetChoice(selectedChoice);
                animationController.PlayerPicked();
        }




    }
}
