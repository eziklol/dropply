using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Specialized;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Destroy : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z-40);
    }

    void OnTriggerEnter(Collider col) //Если касается объекта
    {
        if (col.gameObject.tag != "Player") { Destroy(col.gameObject, 0f); }//Если объект не имеет тега Player он уничтожается
    
    }
}
