using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerManager: MonoBehaviour
{

    
     public static AudioPlayerManager instance = null;
      public AudioSource audio;
      public GameObject MuteButton;
    public GameObject UnMuteButton;
    public GameObject about;
      

     public void Start()
      {
         audio = GetComponent<AudioSource>();
         audio.Play();
      }
      public void Mute(){
          audio.mute=!audio.mute;
            MuteButton.SetActive(false);
            UnMuteButton.SetActive(true);       
      }
      public void UnMute(){
          audio.mute=!audio.mute;
            MuteButton.SetActive(true);
             UnMuteButton.SetActive(false);         
      }
      public void aboutApp(){
          about.SetActive(true);
      }
      public void CloseAbout(){
           about.SetActive(false);
      }
    
    public void Tishe(){
      audio.volume=0.1f;
    }
    public void gromche(){
      audio.volume=1.0f;
    }

}
