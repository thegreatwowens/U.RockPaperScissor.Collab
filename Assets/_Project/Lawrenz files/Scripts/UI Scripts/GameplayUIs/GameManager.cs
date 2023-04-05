using UnityEngine;
using UnityEngine.SceneManagement;
namespace ddr.RockPaperScissor.UI
{
    public class GameManager : MonoBehaviour
    {
        MainMenuAnimations animations;

        void Awake()
        {
            animations = GetComponent<MainMenuAnimations>();
        }


        public void Options(){
                animations.ShowOption();
        }
        public void LeaderBoard(){
                animations.ShowLeaderBoard();
        }
        public void PlayerVersusAI(){
                animations.StartGame();
                 SceneManager.LoadScene("GameScreen PlayerVersusAI");
        }
        public void PlayerVesusPlayer(){
            animations.StartGame();
            SceneManager.LoadScene("GameScreen PlayerVersusPlayer");

        }

    }
}
