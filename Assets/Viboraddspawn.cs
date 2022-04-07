using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Specialized;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Viboraddspawn : MonoBehaviour
{
    public int i;
    public GameObject spawner1;
    public GameObject spawner2;
    public GameObject spawner3;
  
    // Start is called before the first frame update
    void Start()
    {
      
        i = UnityEngine.Random.Range(0, 3);
        if (i == 0) { spawner1.SetActive(true); }
        if (i == 1) { spawner2.SetActive(true); }
        if (i == 2) { spawner3.SetActive(true); }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
