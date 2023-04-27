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
            SoundManager.Instance.PlaySoundFx("UIClicked2");
            animations.ShowOption();
            optionScript.optionClicked();
        }
        public void LeaderBoard(){
            SoundManager.Instance.PlaySoundFx("UIClicked");
            animations.ShowLeaderboard();
            LeaderboardManager.GetLeaderboard("RockPaperScissorRanking");
            LeaderboardManager.Load();
            
            
            
        }
        public void PlayerVersusAI(){
            SoundManager.Instance.PlaySoundFx("UIClicked2");
            SceneChanger.instance.FadeToNextScene(1);
        }
        public void PlayerVesusPlayer(){
            SoundManager.Instance.PlaySoundFx("UIClicked2");
             SceneChanger.instance.FadeToNextScene(2);
             SoundManager.Instance.PlayMusic("PVAIMusic");
        }
        public void backToMainMenu(){
            SoundManager.Instance.PlaySoundFx("UIClicked");
            animations.BackToMainMenu();
        }
        public void ResetLeaderBoard(){
            SoundManager.Instance.PlaySoundFx("UIClicked2");
                LeaderboardManager.DeleteLeaderboard("RockPaperScissorRanking");
                LeaderboardManager.CreateLeaderboard("RockPaperScissorRanking");
                

        }

    }
}
