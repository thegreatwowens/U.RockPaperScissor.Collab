using UnityEngine;
using TMPro;
using ddr.RockPaperScissor.PlayerManager;
using ddr.RockPaperScissor.versusAI;
using UnityEngine.UI;
namespace ddr.RockPaperScissor.UI
{
    public class GameplayUIs : MonoBehaviour
    {
        [SerializeField]
        GameplayController gameplayController;
        PlayerData  playerData;
        [SerializeField]
        TextMeshProUGUI scoreText, streakText,playerName,ContinueScore,leaderboardName;

        [SerializeField]
        Slider sliderValue;

        private void Awake() {
            playerData = GetComponent<PlayerData>();
        }
        
        void Start()
        {
            sliderValue.value = SoundManager.Instance.musicSource.volume;
        }
        public void UpdateUIText(){
                    if(scoreText != null)
                    scoreText.text = "Score: "+ playerData.Score();
                    
                    if(streakText != null)
                    streakText.text = "Streak Count: "+ playerData.playerStreakCount;
                    if(playerName !=null)
                    playerName.text =playerData.playerName;
                    if(ContinueScore !=null)
                    ContinueScore.text ="Your Score: "+playerData.Score();
                    if(leaderboardName !=null)
                    leaderboardName.text = "Your Name: "+playerData.playerName;

                    
        }
        public void OnSliderChange(){
            SoundManager.Instance.VolumeSlider(sliderValue.value);
        }
    



    }
}
