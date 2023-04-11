using UnityEngine;
using TMPro;
using ddr.RockPaperScissor.PlayerManager;
namespace ddr.RockPaperScissor.UI
{
    public class GameplayUIs : MonoBehaviour
    {
        PlayerData  playerData;
        [SerializeField]
        TextMeshProUGUI scoreText, streakText;
        private void Awake() {
            playerData = GetComponent<PlayerData>();
        }
        
        public void UpdateUIText(){
                    if(scoreText != null)
                    scoreText.text = "Score: "+ playerData.Score();
                    
                    if(streakText != null)
                    streakText.text = "Streak Count: "+ playerData.playerStreakCount;
        }



    }
}
