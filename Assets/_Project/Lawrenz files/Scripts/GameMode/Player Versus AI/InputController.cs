using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ddr.RockPaperScissor.versusAI
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
                 Debug.Log("Player Selected: "+selectedChoice);
                 gameplayController.SetChoice(selectedChoice);              
        }

             

    }
}
