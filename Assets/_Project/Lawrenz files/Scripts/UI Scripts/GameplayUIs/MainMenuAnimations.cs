using UnityEngine;

namespace ddr.RockPaperScissor.UI
{
    public class MainMenuAnimations : MonoBehaviour
    {
        [SerializeField]
        CanvasGroup mainMenu,leaderboard,options;
        
      private bool interactables;
       void Awake()
       {
          Application.targetFrameRate=90;
       }

      public void PlayerVersusAI(){
               
       }
      public void PlayerVersusPlayer(){

       }
      public void ShowOption(){
                    interactables =true;
                    LeanTween.alphaCanvas(options,1,.2f).setOnComplete(canInteractOption);
       }
      public void ShowLeaderboard(){
                    interactables =true;
                    LeanTween.alphaCanvas(leaderboard,1,.2f).setOnComplete(canInteractLeaderboard);
      }
      public void BackToMainMenu(){
               interactables = false;
               LeanTween.alphaCanvas(leaderboard,0,.2f).setOnComplete(canInteractLeaderboard);
               LeanTween.alphaCanvas(options,0,.2f).setOnComplete(canInteractOption);
               
               
      }
      public void canInteractLeaderboard(){
                    if(interactables)
                    {
                    leaderboard.interactable = true;
                    leaderboard.blocksRaycasts = true;
                    }
                    if(!interactables)
                    {
                       leaderboard.interactable = false;
                       leaderboard.blocksRaycasts = false;  
                    }

          }
      public void canInteractOption(){
                    if(interactables)
                    {
                       options.interactable = true;
                       options.blocksRaycasts = true; 

                    }
                    if(!interactables)
                    {
                         options.interactable = false;
                         options.blocksRaycasts = false; 

                    }
      }

    }
}
