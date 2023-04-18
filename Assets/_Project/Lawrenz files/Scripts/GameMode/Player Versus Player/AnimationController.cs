using System.Collections;
using UnityEngine;
namespace ddr.RockPaperScissor.PVP
{
    public class AnimationController : MonoBehaviour
    {
        [Header("UIs")]
        [SerializeField]
        GameObject gameSettingHandler;
        [SerializeField]
        GameObject PlayerTurnOverlay;
        [SerializeField]
        CanvasGroup gamesettingBackOverlay;
        [Header("Player 1 Objects")]
        [SerializeField]
        GameObject P1Data;
        [SerializeField]
        GameObject P1ChoiceHandler;
        [SerializeField]
        CanvasGroup canvasP1;
        

         [Header("Player 2 Objects")]
        [SerializeField]
        GameObject P2Data;
        [SerializeField]
         GameObject P2ChoiceHandler;
         [SerializeField]
        CanvasGroup canvasP2;


        public void ShowGameSettings(){
                LeanTween.alphaCanvas(gamesettingBackOverlay,1,.7f);
                LeanTween.scale(gameSettingHandler,new Vector3(1,1,1),1).setDelay(1f).setEase(LeanTweenType.easeInOutElastic);
        }
        public void HideGameSettings(){
                LeanTween.scale(gameSettingHandler,new Vector3(0,0,0),1).setEase(LeanTweenType.easeOutExpo);
                LeanTween.alphaCanvas(gamesettingBackOverlay,0,.7f).setDelay(1.3f).setOnComplete(FirstStart);
        }

        public void GameStart(){
                    HideGameSettings();
                    

        }
        public void FirstStart(){
                    ChoiceHandler("Start");
        }
        public void ChoiceHandler(string Handler){
                    if(Handler =="PlayerOneChoice"|| Handler == "Start")
                    {
                        LeanTween.moveLocal(P1ChoiceHandler,new Vector3(0,-233f,0),.7f);
                        LeanTween.scale(P1ChoiceHandler,new Vector3(.5f,.5f,.5f),.5f).setDelay(.3f).setEase(LeanTweenType.easeOutElastic).setOnComplete(HandlerP1FinalPos);
                       ChoicesInteractable("Player1",false);
                    }
                    if(Handler == "PlayerTwoChoice"||Handler == "Start"){
                        LeanTween.moveLocal(P2ChoiceHandler,new Vector3(0,233f,0),.7f);
                        LeanTween.scale(P2ChoiceHandler,new Vector3(.5f,.5f,.5f),.5f).setDelay(.3f).setEase(LeanTweenType.easeOutElastic).setOnComplete(HandlerP2FinalPos);
                        ChoicesInteractable("Player2",false);
                    }
        }
        public void HandlerP1FinalPos(){
                    //player1
                        LeanTween.scale(P1ChoiceHandler,new Vector3(1,1,1),.5f).setEase(LeanTweenType.easeInOutElastic).setOnComplete(ShowPlayer1Data);
        }

            
         public void HandlerP2FinalPos(){
                    //player2
                        LeanTween.scale(P2ChoiceHandler,new Vector3(1,1,1),.5f).setEase(LeanTweenType.easeInOutElastic).setOnComplete(ShowPlayer2Data);
        }
        public void ShowPlayer2Data(){
                    LeanTween.scale(P2Data,new Vector3(1,1,1),1).setEase(LeanTweenType.easeOutQuad).setOnComplete(ShowTurnOverlay);

        }
        
        public void ShowPlayer1Data(){
                    LeanTween.scale(P1Data,new Vector3(1,1,1),1).setEase(LeanTweenType.easeOutQuad);
         }        
        public void ChoicesInteractable(string player,bool value){
                    if(player =="Player1"){
                                canvasP1.interactable = value;
                                canvasP1.blocksRaycasts = value;
                            return;
                    }
                    
                    if(player =="Player2"){
                                canvasP2.interactable = value;
                                canvasP2.blocksRaycasts = value;
                            return;
                    }
        }
        
        public void PlayerTurn(string player){

                if(player == "Player1"){
                        ChoicesInteractable(player,true);
                    return;
                }
                if(player == "Player2"){
                        ChoicesInteractable(player,true);
                    return;
                }


        }
        
        public void ShowTurnOverlay(){
                LeanTween.scale(PlayerTurnOverlay,new Vector3(.5f,.5f,.5f),.5f).setOnComplete(Loopturn);           

        }
        public void HideTurnOverlay(){
            LeanTween.scale(PlayerTurnOverlay,new Vector3(0,0,0),.5f);
        }

        public void Loopturn(){
                    LeanTween.scale(PlayerTurnOverlay,new Vector3(1f,1,1),2f).setLoopClamp();
        }
    }
    
}
