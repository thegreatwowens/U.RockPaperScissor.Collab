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
                    scoreText.text = "Score: "+ playerData.Score();
                    streakText.text = "Streak Count: "+ playerData.playerStreakCount;
        }



    }
}
