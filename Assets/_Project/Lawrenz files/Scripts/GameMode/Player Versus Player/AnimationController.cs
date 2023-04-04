using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ddr.RockPaperScissor.PVP
{
    public class AnimationController : MonoBehaviour
    {
        [SerializeField]
        Animator playerOneHandler,playerTwoHandler, GameSettingsHandler;


       
            private void Start() {
                GameSettingsHandler.Play("ShowHandler");
                    }


    //Functions
        public void ChoicesClicked(string type)
        {
            switch(type)
            {
                case "player1":
                            playerOneHandler.Play("ChoicePicked");
                        break;
                case "player2":
                            playerTwoHandler.Play("ChoicePicked");
                        break;

            }

          

        }

        // GameSetting Method
         public void StartButtonClicked(){
                        GameSettingsHandler.Play("HideHandler");
                        playerOneHandler.Play("ShowHandler");
                        playerTwoHandler.Play("ShowHandler");

            }
         public void ExitClicked(){

            
           }



            
        public void CheckWinner(){

                playerOneHandler.Play("HideHandler");
                playerTwoHandler.Play("HideHandler");
        }

    }

    
}
