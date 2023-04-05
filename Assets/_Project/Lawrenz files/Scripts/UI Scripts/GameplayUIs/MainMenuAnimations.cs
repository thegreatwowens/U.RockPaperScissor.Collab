using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ddr.RockPaperScissor.UI
{
    public class MainMenuAnimations : MonoBehaviour
    {
        [SerializeField]
        Animator mainMenuAnimator;
       
       public void ShowLeaderBoard(){
            mainMenuAnimator.Play("ShowLeaderboard");
       }
       public void ShowOption(){
            mainMenuAnimator.Play("ShowOptions");
       }
       public void StartGame(){
            mainMenuAnimator.Play("PlayGame");
       }
    }
}
