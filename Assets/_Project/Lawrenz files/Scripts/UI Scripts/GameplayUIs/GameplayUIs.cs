using UnityEngine;
using TMPro;
using ddr.RockPaperScissor.PlayerManager;
using ddr.RockPaperScissor.versusAI;
namespace ddr.RockPaperScissor.UI
{
    public class GameplayUIs : MonoBehaviour
    {
        [SerializeField]
        GameplayController gameplayController;
        PlayerData  playerData;
        [SerializeField]
        TextMeshProUGUI scoreText, streakText,playerName,playerhealth;
        private void Awake() {
            playerData = GetComponent<PlayerData>();
        }
        
        public void UpdateUIText(){
                    if(scoreText != null)
                    scoreText.text = "Score: "+ playerData.Score();
                    
                    if(streakText != null)
                    streakText.text = "Streak Count: "+ playerData.playerStreakCount;
                    if(playerName !=null)
                    playerName.text = "Name: "+ playerData.playerName;
                    if(playerhealth !=null)
                    playerhealth.text = gameplayController.playerHealthvalue().ToString();
                    
        }



    }
}
