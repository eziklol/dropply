using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject MenuUI;
   public Sprite Pressed1;
   public Sprite Pressed2;
   public Button button;
    public GameObject PlayerUI;
    public GameObject GameMenu;
    public int stopUI;
    public void ChangeImage(){
       button.image.sprite=Pressed1;
   }
   public void ChangeImage2(){
        button.image.sprite=Pressed2;
   }
   public void Menu(){
        MenuUI.SetActive(true);
   }
   public void Close() {
        if (stopUI != 1) { PlayerUI.SetActive(false); }
    MenuUI.SetActive(false);
   }
   public void ExitButton(){
        Application.Quit ();
   }
    public void LoadMainMenu(){
        SceneManager.LoadScene(0);
    }
}


