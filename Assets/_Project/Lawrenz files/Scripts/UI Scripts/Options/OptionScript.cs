using UnityEngine;
using UnityEngine.Events;
using TMPro;
using ddr.RockPaperScissor.PlayerManager;
using UnityEngine.UI;

public class OptionScript : MonoBehaviour
{
        [Header("For SceneChanger")]
        public int SceneIndex;

        public TMP_InputField nameInput;
        public UnityEvent executeSomething; 

        public Slider slider;
        void Start()
        {
                if(nameInput.text == null)
                        {
                               if(PlayerPrefs.GetString("SavedPlayerName")== null)
                                        nameInput.text = "Player";
                                else
                                        PlayerPrefs.GetString("SavedPlayerName");
                        }

                        slider.value = SoundManager.Instance.musicSource.volume;
        }

        public void VolumeChanged(){
                SoundManager.Instance.VolumeSlider(slider.value);

        }
        public void ChangeScene(){
            
            SceneChanger.instance.FadeToNextScene(SceneIndex);

                    if(executeSomething!=null)
                        executeSomething.Invoke();                        
        }

        public void updateName(){
                      PlayerData.SavePlayerName(nameInput.text);
                      Debug.Log("Player Named: "+nameInput.text+" is Saved!");
        }
        
        public void optionClicked(){
                nameInput.text = PlayerPrefs.GetString("SavedPlayerName");
        }
}
