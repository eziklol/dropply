using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trubaleft : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
        // transform.rotation.eulerAngles = new Vector3(0f, 90f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion.Euler(0f, 90f, 0f);
    }
}
