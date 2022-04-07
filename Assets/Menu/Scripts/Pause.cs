using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Specialized;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
     
    public GameObject PauseMenuUI;
    public GameObject Pl;
    public GameObject GameMenu;
    public AudioSource audio;
   
    

    public void PauseGame(){
        Pl.GetComponent<Player>().save = 1;
        Debug.Log("ss");
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameMenu.SetActive(false);
        

            }
    public void ResumeGame(){
        Time.timeScale=1f;
        GameMenu.SetActive(true);
       

    }
    public void RestartGame(){
        Pl.GetComponent<Player>().hp = 1;
        PauseMenuUI.SetActive(false);
        SceneManager.LoadScene(1);
        Time.timeScale=1f;
        GameMenu.SetActive(true);
    }

    
    }
