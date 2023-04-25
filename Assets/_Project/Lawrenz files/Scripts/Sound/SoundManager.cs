using UnityEngine;
using ddr.RockPaperScissor.Sound;
using System;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public Sound[] musicSound,soundFx;
    public AudioSource musicSource,soundFxSource;
    
    public float fadeSpeed =1;

    public static SoundManager Instance;

    void Awake()
    {
        if(Instance == null){
              Instance = this;
        DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
      
    }
    void Start()
    {
            PlayMusic("MainMenuMusic");
    }



    public void PlayMusic(string name){
         Sound sound =  Array.Find(musicSound,x => x.name == name);
            
            if(sound == null){
                
                print ("No sound Named: "+ name+" at "+ musicSound.ToString());

            } 
            else{

                musicSource.clip = sound.clip;
                musicSource.Play();
            }

    }
    public void PlaySoundFx(string name){
        Sound sound =  Array.Find(soundFx,x => x.name == name);
            
            if(sound == null){
                
                print ("No sound Named: "+ name+" at "+ soundFx.ToString());

            } 
            else{

                soundFxSource.PlayOneShot(sound.clip);
            }
        
    }
    
    public void VolumeSlider (float volume){
                musicSource.volume = volume;
                soundFxSource.volume = volume;
            
    }
    
 

         
    


}
