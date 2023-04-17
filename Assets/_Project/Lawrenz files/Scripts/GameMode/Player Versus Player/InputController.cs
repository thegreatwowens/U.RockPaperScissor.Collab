using UnityEngine;
    

namespace ddr.RockPaperScissor.PVP
{
    public class InputController : MonoBehaviour
    {   
        [SerializeField]
        GameplayController gameplayController;

              public void GetChoice(string player){
            string choiceName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

            GameplayController.HandChoicesPVP selectedChoice = GameplayController.HandChoicesPVP.None;
            switch(choiceName){

                case "Rock":
                        selectedChoice = GameplayController.HandChoicesPVP.Rock;
                break;
                case "Paper":
                        selectedChoice = GameplayController.HandChoicesPVP.Paper;
                break;
                case "Scissor":
                        selectedChoice = GameplayController.HandChoicesPVP.Scissor;
                break;
            }        
                    Debug.Log(player+"picked: "+choiceName);
                    gameplayController.PlayerSetChoice(player,selectedChoice);
        }


    }
}
