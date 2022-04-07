using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Specialized;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class spawnerdropa : MonoBehaviour
{
    public int i;
    public int m;
    public GameObject money;
    public GameObject kaplya;
    public GameObject truba1;
    public GameObject truba2;
    public GameObject truba3;
    public GameObject kamen;
    public float zet;
    public float zet1;
    public float ix;
    public int storona;
    // Start is called before the first frame update
    void Start()
    {
        zet = transform.position.z;
        zet = Mathf.Round(zet);
        i = UnityEngine.Random.Range(0, 13); 
        if ((i >= 0) && (i<=3)) { m = UnityEngine.Random.Range(2, 6);}
        if ((i > 3) && (i <= 4)) { Instantiate(kaplya, new Vector3(ix, 0.6f, zet), Quaternion.identity); }
        if ((i > 4) && (i <= 5)) { if (storona == 1) { Instantiate(truba1, new Vector3(-4.25f, 3, zet), Quaternion.Euler(0f, 90f, 180f)); } }
        if ((i > 5) && (i <= 6)) { if (storona == 2) { Instantiate(truba2, new Vector3(ix, 2, zet), Quaternion.Euler(0f, 90f, 0f)); } }
        if ((i > 6) && (i <= 7)) { if (storona == 3) { Instantiate(truba3, new Vector3(4.25f, 3, zet), Quaternion.Euler(0f, -90f, 180f)); } }
        if ((i > 7) && (i <= 12)) { Instantiate(kamen, new Vector3(ix, 1, zet), Quaternion.identity); }

    }

    // Update is called once per frame
    void Update()
    {
        if (m > 0) { Instantiate(money, new Vector3(ix, 1, zet + zet1), Quaternion.identity); zet1 = zet1 + 3; m = m - 1; }
    }
}
