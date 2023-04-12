using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public GameObject  image;

    [Header("The Higher the Range the longer for scene to fade ")]
    [Range(0,3)]
    public float fadeInDuration;
    [Range(0,3)]
    public float fadeOutDuration;

    private int indexScene;
    public static SceneChanger instance;

    void Awake()
    {
        if(instance !=null && instance != this){
            Destroy(this);
            return;
             
        }
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
    }
           

        private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1){

                    FadeFromPreviousScene();
        }
    public void FadeToNextScene(int Index){

                indexScene = Index;
            LeanTween.alphaCanvas(canvasGroup,1,fadeOutDuration).setOnComplete(OnFadeComplete);

    }

    void OnFadeComplete(){  
            SceneManager.LoadScene(indexScene);
    }

    public void FadeFromPreviousScene(){

        LeanTween.alphaCanvas(canvasGroup,0,fadeInDuration);

    }
 
}
