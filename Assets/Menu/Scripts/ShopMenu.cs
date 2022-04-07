using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Specialized;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class ShopMenu : MonoBehaviour
{

    [System.Serializable] class ShopItem{
        public Sprite Image;
        public int Price;
        public bool IsPurchased=false;
    }

    [SerializeField] List<ShopItem> ShopItemsList; 
    [SerializeField] Animator NoCoinsAnim;
    [SerializeField] Text CoinsText;
    public GameObject ItemTemplate;
    public GameObject g;
    [SerializeField] Transform ShopScrollView;
    Button buyBtn;

    public Player shopBtn;
    public int i;
       public int MoneyMy;
    public GameObject MoneyText;
    public GameObject ShopMenuUI;
    public GameObject PlayerUI;
    public int stopUI;
    void Start(){
      
     

        ItemTemplate=ShopScrollView.GetChild(0).gameObject;
        int len =ShopItemsList.Count;
        for(int i=0; i<len; i++){
            g=Instantiate(ItemTemplate,ShopScrollView);
            g.transform.GetChild(0).GetComponent<Image>().sprite=ShopItemsList[i].Image;
            g.transform.GetChild(1).GetChild(0).GetComponent<Text>().text=ShopItemsList[i].Price.ToString();
            // buyBtn=g.transform.GetChild(2).GetComponent<Button>();
            // buyBtn.interactable=!ShopItemsList[i].IsPurchased;
            // buyBtn.AddEventListener(i,OnShopItemBtnClicked);

        }
        Destroy(ItemTemplate);
        
    }



    // void OnShopItemBtnClicked(int itemIndex){
    //     if(Game.Instance.HasEnoughCoins(ShopItemsList[itemIndex].Price)){
    //         Game.Instance.UseCoins(ShopItemsList[itemIndex].Price);
    //         ShopItemsList[itemIndex].IsPurchased=true;
    //     buyBtn=ShopScrollView.GetChild(itemIndex).GetChild(2).GetComponent<Button>();
    //     buyBtn.interactable=false;
    //     buyBtn.transform.GetChild(0).GetComponent<Text>().text="Purchased";
    //     SetCoinsUI();
    //     }else{
    //         NoCoinsAnim.SetTrigger("NoCoins");
    //         Debug.Log("You don't have enough money!!");
    //     }

    // }


    private void Load()
    {

        
        string key1 = "bank";
        if (PlayerPrefs.HasKey(key1))
        {
           
            this.MoneyMy = PlayerPrefs.GetInt(key1);


        }
    }
        public void Update()
    {
        if (stopUI != 1)
        {
            PlayerUI.SetActive(false);
        }
        Load();
        if (i == 1) { MoneyText.GetComponent<Text>().text = MoneyMy.ToString(); }
        // CoinsText.text=Game.Instance.Coins.ToString();
    }
    public void buy(){
        if(MoneyMy>=50){
            
            MoneyMy=MoneyMy-50;    
                
                string key1 = "bank";
                PlayerPrefs.SetInt(key1, this.MoneyMy);
                PlayerPrefs.Save();
           
        }
        else{
             NoCoinsAnim.SetTrigger("NoCoins");
               Debug.Log("You don't have enough money!!");
        }
    }
    
    public void ShopMenuOpen(){
    ShopMenuUI.SetActive(true);
    }
}
