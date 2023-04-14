using UnityEngine;
using CarterGames.Assets.LeaderboardManager;

namespace ddr.RockPaperScissor.UI
{
    public class GameManager : MonoBehaviour
    {
        MainMenuAnimations animations;
        
        [SerializeField]
        OptionScript optionScript;

        void Awake()
        {
            animations = GetComponent<MainMenuAnimations>();
        }

        void Start()
        {
            if(LeaderboardManager.BoardExists("RockPaperScissorRanking"))
            {
                Debug.Log("Leaderboard Exist");
            }else{ LeaderboardManager.CreateLeaderboard("RockPaperScissorRanking");}
            
        }
        public void Options(){
            animations.ShowOption();
            optionScript.optionClicked();
        }
        public void LeaderBoard(){
            animations.ShowLeaderboard();
            LeaderboardManager.GetLeaderboard("RockPaperScissorRanking");
            LeaderboardManager.Load();
            
        }
        public void PlayerVersusAI(){
            SceneChanger.instance.FadeToNextScene(1);
        }
        public void PlayerVesusPlayer(){
             SceneChanger.instance.FadeToNextScene(2);
        }
        public void backToMainMenu(){
            animations.BackToMainMenu();
        }
        public void ResetLeaderBoard(){
                LeaderboardManager.DeleteLeaderboard("RockPaperScissorRanking");
                LeaderboardManager.CreateLeaderboard("RockPaperScissorRanking");
                

        }

    }
}
