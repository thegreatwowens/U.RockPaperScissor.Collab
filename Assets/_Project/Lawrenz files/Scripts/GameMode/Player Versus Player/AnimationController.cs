using System.Collections;
using UnityEngine;
using System.Threading.Tasks;
using TMPro;
using UnityEngine.UI;

namespace ddr.RockPaperScissor.PVP
{
    public class AnimationController : MonoBehaviour
    {
        #region  Variables
        [SerializeField]
        GameplayController gameplayController;
        [Header("UIs")]
        [SerializeField]
        RectTransform gameSettingHandler;
        [SerializeField]
        RectTransform PlayerTurnOverlay;
        [SerializeField]
        RectTransform WinnerOverlay;
        [SerializeField]
        GameObject RoundsHandler;
        [SerializeField]
        CanvasGroup gamesettingBackOverlay;
        [SerializeField]
        RectTransform GameOverPanel;
        [SerializeField]
        CanvasGroup gameOverBackOverlay;
        [SerializeField]
        RectTransform OptionPanel;
        [SerializeField]
        CanvasGroup optionPanelBackOverlay;
        [SerializeField]
        Button optionButton;
        [Header("Player 1 Objects")]
        [SerializeField]
        RectTransform PickedPlayer1;
        [SerializeField]
        RectTransform P1Data;
        [SerializeField]
        RectTransform P1ChoiceHandler;
        [SerializeField]
        CanvasGroup canvasP1;
        [Header("Player 2 Objects")]
        [SerializeField]
        RectTransform PickedPlayer2;
        [SerializeField]
        RectTransform P2Data;
        [SerializeField]
        RectTransform P2ChoiceHandler;
        [SerializeField]
        CanvasGroup canvasP2;
        [SerializeField]
        CanvasGroup RoundText;
        #endregion
        public void ShowGameSettings()
        {
            CanvasGroup panel = gameSettingHandler.GetComponent<CanvasGroup>();
            panel.interactable = true;
            LeanTween.alphaCanvas(gamesettingBackOverlay, 1, .7f);
            LeanTween.scale(gameSettingHandler, new Vector3(1, 1, 1), 1).setDelay(1f).setEase(LeanTweenType.easeOutElastic);
        }
        public void HideGameSettings()
        {
            CanvasGroup panel = gameSettingHandler.GetComponent<CanvasGroup>();
            panel.interactable = false;
            LeanTween.scale(gameSettingHandler, new Vector3(0, 0, 0), 1).setEase(LeanTweenType.easeInElastic);
            LeanTween.alphaCanvas(gamesettingBackOverlay, 0, .7f).setDelay(1.3f);

        }
        public void GameStart()
        {
            HideGameSettings();

        }
        public void ShowRounds()
        {   
            LeanTween.scale(RoundsHandler, new Vector3(1, 1, 1), 1).setDelay(1.6f).setEase(LeanTweenType.easeOutElastic).setOnComplete(RoundFlip);
        }

        private void RoundFlip(){
                    LeanTween.scale(RoundsHandler, new Vector3(-1,-1, 1), 1).setOnComplete(HideRounds);
        }
        public void HideRounds()
        {
            LeanTween.scale(RoundsHandler, new Vector3(0, 0, 0), 1).setDelay(1f).setOnComplete(RoundTextShow);


        }
        public void RoundTextShow(){
                
                    LeanTween.alphaCanvas(RoundText,1,.5f);
                 
                    
        }
        public void RoundTextHide(){
                    LeanTween.alphaCanvas(RoundText,0,.5f);
        }
        public void FlipRounds(){
               if(InputController.Instance.ReturnCurrentState() == GameState.PlayerTwoTurn){
                       LeanTween.scale(RoundText.gameObject,new Vector3(-1,-1,1),.1f);
                    }
        }
        public void ShowChoicesHandler()
        {
            LeanTween.move(P1ChoiceHandler, new Vector2(0, 160), 1f).setDelay(1).setEase(LeanTweenType.easeInOutExpo).setOnComplete(ShowPlayer1Data);
            LeanTween.move(P2ChoiceHandler, new Vector2(0, -160), 1f).setDelay(1.6f).setEase(LeanTweenType.easeInOutExpo).setOnComplete(ShowPlayer2Data);
        }
        public void EnableChoiceshandler()
        {
            ChoicesInteractable("Both", false);
            LeanTween.scale(P1ChoiceHandler, new Vector3(1, 1, 1), 1f).setDelay(1f).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(P2ChoiceHandler, new Vector3(1, 1, 1), 1f).setDelay(1.7f).setEase(LeanTweenType.easeOutElastic).setOnComplete(ShowPlayerData);
        }
        public void DisableChoiceshandler(){
            LeanTween.scale(P1ChoiceHandler, new Vector3(0, 0, 0), .3f).setEase(LeanTweenType.easeOutElastic);
            LeanTween.scale(P2ChoiceHandler, new Vector3(0, 0, 0), .3f).setEase(LeanTweenType.easeOutElastic);
        }
        public void PickedResultHandler()
        {
            LeanTween.move(PickedPlayer1, new Vector2(0, 150f), 1f).setDelay(2f).setEase(LeanTweenType.easeInOutExpo);
            LeanTween.move(PickedPlayer2, new Vector2(0, -150f), 1f).setDelay(2f).setEase(LeanTweenType.easeInOutExpo);
        }
        public void HidePickedResultHandler()
        {
            LeanTween.move(PickedPlayer1, new Vector2(0, -300), 1f).setDelay(1f).setEase(LeanTweenType.easeInOutExpo);
            LeanTween.move(PickedPlayer2, new Vector2(0, 300), 1f).setDelay(1f).setEase(LeanTweenType.easeInOutExpo);
        }

        public void ShowWinner(string name)
        {
            TextMeshProUGUI text = WinnerOverlay.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            text.text = name;
            LeanTween.scale(WinnerOverlay, new Vector3(1, 1, 1), 1f).setDelay(.8f).setEase(LeanTweenType.easeOutExpo).setOnComplete(HideWinner);
        }
        private void HideWinner()
        {
            LeanTween.scale(WinnerOverlay, new Vector3(0, 0, 0), .3f);
        }
            public async void ShowPlayerData()
        {
            await Task.Delay(500);
            EnablePlayer1Data();
            EnablePlayer2Data();
            CallForPlayerOneTurn();
            
        }
        public void EnablePlayer2Data()
        {
            LeanTween.scale(P2Data, new Vector3(1, 1, 1), 1).setEase(LeanTweenType.easeOutQuad);

        }
        public void EnablePlayer1Data()
        {

            LeanTween.scale(P1Data, new Vector3(1, 1, 1), 1).setEase(LeanTweenType.easeOutQuad);
        }
        public void HidePlayer1Data()
        {
            LeanTween.move(P1Data, new Vector2(0, -200f), .6f).setEase(LeanTweenType.easeInOutExpo);
        }
        public void HidePlayer2Data()
        {
            LeanTween.move(P2Data, new Vector2(0, 215f), .6f).setEase(LeanTweenType.easeInOutExpo);
        }
        public void ShowPlayer1Data()
        {
            LeanTween.move(P1Data, new Vector2(0, 104f), 1f).setEase(LeanTweenType.easeInOutExpo);
        }
        public void ShowPlayer2Data()
        {
            LeanTween.move(P2Data, new Vector2(0, -104), 1f).setEase(LeanTweenType.easeInOutExpo);
        }

        public void ChoicesInteractable(string player, bool value)
        {
            if (player == "Player1")
            {
                canvasP1.interactable = value;
                canvasP1.blocksRaycasts = value;
            }

            if (player == "Player2")
            {
                canvasP2.interactable = value;
                canvasP2.blocksRaycasts = value;
            }
            if (player == "Both")
            {
                canvasP2.interactable = value;
                canvasP2.blocksRaycasts = value;
                canvasP1.interactable = value;
                canvasP1.blocksRaycasts = value;

            }
        }
        
        public IEnumerator Interactables(string PlayerName,string Player, bool value,float Overridetime, GameState state)
        {
           
            ShowTurn(PlayerName,Player);
            if(state ==GameState.PlayerOneTurn){
                    ShowRounds();
            }
            yield return new WaitForSeconds(Overridetime);
            ChoicesInteractable(Player, value);
            StopCoroutine(Interactables(PlayerName,Player,value,Overridetime,state));
        }


        public void ShowTurn(string PlayerName,string Player){
                        TextMeshProUGUI name = PlayerTurnOverlay.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
                            name.text = PlayerName;
                            if(Player == "Player1"){
                                    LeanTween.scale(PlayerTurnOverlay,new Vector3(1.5f,1.5f,1.5f),1f)
                                    .setEase(LeanTweenType.easeOutBounce).setDelay(.5f).setOnComplete(HideTurnOverlay);
                            }else{
                                LeanTween.scale(PlayerTurnOverlay,new Vector3(-1.5f,-1.5f,1.5f),1f)
                                    .setEase(LeanTweenType.easeOutBounce).setDelay(.5f).setOnComplete(HideTurnOverlay);
                            }
                            
             

        }
        public void HideTurnOverlay()
        {
            
            LeanTween.scale(PlayerTurnOverlay, new Vector3(0, 0, 0),.1f).setEase(LeanTweenType.easeInBack);
        }

        public void CallForPlayerOneTurn()
        {
            InputController.Instance.UpdateGameState(GameState.PlayerOneTurn);
        }
        public void CallForPlayerTwoTurn()
        {
            InputController.Instance.UpdateGameState(GameState.PlayerTwoTurn);
        }
        public void HidePlayerChoicesPlayerOne()
        {
            LeanTween.move(P1ChoiceHandler, new Vector2(0, -300f), 1f).setEase(LeanTweenType.easeInOutExpo);
            HidePlayer1Data();
        }
        public void HidePlayerChoicesPlayerTwo()

        {
            LeanTween.move(P2ChoiceHandler, new Vector2(0, 300f), 1f).setEase(LeanTweenType.easeInOutExpo);
            HidePlayer2Data();
            LeanTween.delayedCall(.5f,DisableOptionButton).setOnComplete(RoundTextHide);
        }
        public void ResetAnimation()
        {
            HidePickedResultHandler();
            ShowChoicesHandler();
        }
        public void ShowGameOverPanel(){
                 LeanTween.alphaCanvas(gameOverBackOverlay,1,.6f);
                 LeanTween.scale(GameOverPanel,new Vector3(1,1,1),1f).setDelay(.7f).setEase(LeanTweenType.easeOutElastic);
                 GameOverCanvas(true);
        }
        private void GameOverCanvas(bool value){
                CanvasGroup canvas = GameOverPanel.GetComponent<CanvasGroup>();
                    canvas.interactable = value;     
        }
        public void HideGameOverPanel(){
                
                 LeanTween.scale(GameOverPanel,new Vector3(0,0,0),1f).setEase(LeanTweenType.easeInElastic);
                 LeanTween.alphaCanvas(gameOverBackOverlay,1,.6f).setDelay(.7f);
                        GameOverCanvas(false);
        }

        public void ShowOptionPanel(){
                   
                    DisableOptionButton();
                    optionPanelBackOverlay.blocksRaycasts = true;
                    LeanTween.alphaCanvas(optionPanelBackOverlay,1,.2f);
                    LeanTween.scale(OptionPanel,new Vector3(1,1,1),.5f).setEase(LeanTweenType.easeInExpo);
                    LeanTween.move(OptionPanel,new Vector2(-29,68),.5f);
        }

        public void HideOptionPanel(){
                    EnableOptionButton();
                    optionPanelBackOverlay.blocksRaycasts = false;
                    LeanTween.scale(OptionPanel,new Vector3(0,0,0),.5f).setEase(LeanTweenType.easeOutExpo);
                    LeanTween.move(OptionPanel,new Vector2(-50,-52),.6f);
                    LeanTween.alphaCanvas(optionPanelBackOverlay,0,.3f).setDelay(.5f);
        }
        
        public void EnableOptionButton(){
                    LeanTween.scale(optionButton.gameObject,new Vector3(1,1,1),.2f);
                    optionButton.interactable = true;
        }
       public void DisableOptionButton(){
                    LeanTween.scale(optionButton.gameObject,new Vector3(0,0,0),.2f);
                     optionButton.interactable = false;
        }
    }


}
