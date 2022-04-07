using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Specialized;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class spawndoroga : MonoBehaviour
{
    public int i;
    public GameObject doroga1;
    public GameObject doroga2;
    public GameObject doroga3;
    public float zet;
    // Start is called before the first frame update
    void Start()
    {
        zet = transform.position.z;
        zet = Mathf.Round(zet);
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    void OnTriggerEnter(Collider col)//Если касается объекта
    {

        if (col.gameObject.tag == "Player")
        {
           
           i = UnityEngine.Random.Range(0, 3);
            if (i == 0) { Instantiate(doroga1, new Vector3(0, 1, zet + 105), Quaternion.identity); }
            if (i == 1) { Instantiate(doroga2, new Vector3(0, 1, zet + 105), Quaternion.identity); }
            if (i == 2) { Instantiate(doroga3, new Vector3(0, 1, zet + 105), Quaternion.identity); }

        }//Если объект  имеет тег Player спавнит дорогу дальше

    }
}
