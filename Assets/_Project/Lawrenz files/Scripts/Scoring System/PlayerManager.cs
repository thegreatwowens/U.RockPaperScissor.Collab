using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ddr.RockPaperScissor.PlayerManager
{
    public class PlayerManager : MonoBehaviour
    {
        public string playerName = "Player";
                double score;

      public void SavePlayerName(string name){
                PlayerPrefs.SetString("SavedPlayerName",name);
                PlayerPrefs.Save();

      }
      public string  LoadPlayerName(){
            
            return PlayerPrefs.GetString("SavedPlayerName");

      }
    }
}
