using System.Collections;
using UnityEngine;
using System.Threading.Tasks;
using TMPro;
namespace ddr.RockPaperScissor.PVP
{
    public class AnimationController : MonoBehaviour
    {

#region  Variables
        [SerializeField]
        GameplayController gameplayController;
        [Header("UIs")]
        [SerializeField]
        GameObject gameSettingHandler;
        [SerializeField]
        GameObject PlayerTurnOverlay;
        [SerializeField]
        GameObject WinnerOverlay;
        [SerializeField]
        CanvasGroup gamesettingBackOverlay;
        [Header("Player 1 Objects")]
        [SerializeField]
        GameObject PickedPlayer1;
        [SerializeField]
        GameObject P1Data;
        [SerializeField]
        GameObject P1ChoiceHandler;
        [SerializeField]
        CanvasGroup canvasP1;
         [Header("Player 2 Objects")]
         [SerializeField]
         GameObject PickedPlayer2;
        [SerializeField]
        GameObject P2Data;
        [SerializeField]
         GameObject P2ChoiceHandler;
         [SerializeField]
        CanvasGroup canvasP2;
        [HideInInspector]
        public bool _animationDone;
    #endregion
        public void ShowGameSettings(){
            LeanTween.alphaCanvas(gamesettingBackOverlay,1,.7f);
            LeanTween.scale(gameSettingHandler,new Vector3(1,1,1),1).setDelay(1f).setEase(LeanTweenType.easeOutElastic);
         }
        public void HideGameSettings(){
                LeanTween.scale(gameSettingHandler,new Vector3(0,0,0),1).setEase(LeanTweenType.easeInElastic);
                LeanTween.alphaCanvas(gamesettingBackOverlay,0,.7f).setDelay(1.3f);
        }
        public void GameStart(){
                    HideGameSettings();
                                      
        }
        public void ShowChoicesHandler(){
                    LeanTween.moveLocalY(P1ChoiceHandler, -215f, 1f).setDelay(1).setEase(LeanTweenType.easeInOutExpo).setOnComplete(ShowPlayer1Data);
                    LeanTween.moveLocalY(P2ChoiceHandler,215f, 1f).setDelay(1.6f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(ShowPlayer2Data);
        }
         public void HideChoicesHandler(){
                    LeanTween.moveLocalY(P1ChoiceHandler, -600f, 1f).setEase(LeanTweenType.easeInOutExpo);
                    LeanTween.moveLocalY(P2ChoiceHandler,600f, 1f).setEase(LeanTweenType.easeInOutExpo);
        }

        public void EnableChoiceshandler(){
                    ChoicesInteractable("Both",false);
                    LeanTween.scale(P1ChoiceHandler,new Vector3(1,1,1),1f).setDelay(1f).setEase(LeanTweenType.easeOutElastic);
                    LeanTween.scale(P2ChoiceHandler,new Vector3(1,1,1),1f).setDelay(1.7f).setEase(LeanTweenType.easeOutElastic).setOnComplete(ShowPlayerData);
                    
        }
        public void PickedResultHandler(){
                LeanTween.moveLocalY(PickedPlayer1, -100f, 1f).setDelay(2f).setEase(LeanTweenType.easeInOutExpo);
                LeanTween.moveLocalY(PickedPlayer2,100f, 1f).setDelay(2f).setEase(LeanTweenType.easeInOutExpo);
        }
         public void HidePickedResultHandler(){
                LeanTween.moveLocalY(PickedPlayer1, -600f, 1f).setDelay(1f).setEase(LeanTweenType.easeInOutExpo);
                LeanTween.moveLocalY(PickedPlayer2,600f, 1f).setDelay(1f).setEase(LeanTweenType.easeInOutExpo);
        }

        public void ShowWinner(string name){
                    TextMeshProUGUI text = WinnerOverlay.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                        text.text = name;
                    LeanTween.scale(WinnerOverlay,new Vector3(1,1,1),1f).setDelay(.8f).setEase(LeanTweenType.easeOutExpo).setOnComplete(HideWinner);
        }
        private void HideWinner(){
                LeanTween.scale(WinnerOverlay,new Vector3(0,0,0),.3f);
        }
        public async void ShowPlayerData(){
            await Task.Delay(500);
                EnablePlayer1Data();
                EnablePlayer2Data();
                CallForPlayerOneTurn();
        }
        public void EnablePlayer2Data(){
                    LeanTween.scale(P2Data,new Vector3(1,1,1),1).setEase(LeanTweenType.easeOutQuad);

        }        
        public void EnablePlayer1Data(){
                    LeanTween.scale(P1Data,new Vector3(1,1,1),1).setEase(LeanTweenType.easeOutQuad);
         }  
          public void HidePlayer1Data(){
                    LeanTween.moveLocalY(P1Data, -600f, .6f).setEase(LeanTweenType.easeInOutExpo);
         } 
          public void HidePlayer2Data(){
                    LeanTween.moveLocalY(P2Data, 600f, .6f).setEase(LeanTweenType.easeInOutExpo);
         }  
           public void ShowPlayer1Data(){
                LeanTween.moveLocalY(P1Data, -300f, 1f).setEase(LeanTweenType.easeInOutExpo);
           }
           public void ShowPlayer2Data(){
                 LeanTween.moveLocalY(P2Data, 300f, 1f).setEase(LeanTweenType.easeInOutExpo);
           }
               
        public void ChoicesInteractable(string player,bool value){
                    if(player =="Player1"){
                                canvasP1.interactable = value;
                                canvasP1.blocksRaycasts = value;
                    }
                    
                    if(player =="Player2"){
                                canvasP2.interactable = value;
                                canvasP2.blocksRaycasts = value;
                    }
                    if( player == "Both"){
                                canvasP2.interactable = value;
                                canvasP2.blocksRaycasts = value;
                                canvasP1.interactable = value;
                                canvasP1.blocksRaycasts = value;
                    }
        }
        public void ShowTurnOverlay(string Name,string Player, bool value){
                TextMeshProUGUI text = PlayerTurnOverlay.transform.GetComponentInChildren<TextMeshProUGUI>();
                    text.text = Name+" Turn!";
                LeanTween.moveLocalX(PlayerTurnOverlay,0,2f).setEase(LeanTweenType.easeInOutElastic).setOnComplete(HideTurnOverlay);        
                if(Player == "Player2"){
                    LeanTween.scale(PlayerTurnOverlay,new Vector3(-1,-1,1),.1f);
                }
                StartCoroutine(Interactables(Player,value));
        }
        private IEnumerator Interactables(string Player, bool value){

            yield return new WaitForSeconds(2f);
            ChoicesInteractable(Player,value);
        }
        public void HideTurnOverlay(){
            LeanTween.moveLocalX(PlayerTurnOverlay,400,.5f).setDelay(.5f).setEase(LeanTweenType.easeInBack); 
            LeanTween.scale(PlayerTurnOverlay,new Vector3(1,1,1),.1f);
        }

        public void CallForPlayerOneTurn(){
            InputController.Instance.UpdateGameState(GameState.PlayerOneTurn);
        }
        public void CallForPlayerTwoTurn(){
            InputController.Instance.UpdateGameState(GameState.PlayerTwoTurn);
        }
        public void HidePlayerChoicesPlayerOne()
        {
            LeanTween.moveLocalY(P1ChoiceHandler, -600f, 1f).setEase(LeanTweenType.easeInOutExpo);
            HidePlayer1Data();
        }
        public void HidePlayerChoicesPlayerTwo()

        {
            LeanTween.moveLocalY(P2ChoiceHandler, 600f, 1f).setEase(LeanTweenType.easeInOutExpo);
            HidePlayer2Data();
        }
          public void ResetAnimation(){
                HidePickedResultHandler();
                ShowChoicesHandler();
        }
    
    }

      
}
