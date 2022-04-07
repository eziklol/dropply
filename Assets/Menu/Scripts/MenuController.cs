using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using GoogleMobileAds.Api;

public class MenuController : MonoBehaviour
{
    public GameObject menuButtons;

    private Vector3 mainCameraPosition;
    private Vector3 startCameraPosition;
    private bool wait = true;
    float moveSpeed = 0.1f;
    // Start is called before the first frame update

    void Start()
    {

        // Initialize the Google Mobile Ads SDK.
        //MobileAds.Initialize(initStatus => { });

        mainCameraPosition = new Vector3(transform.position.x, 2.7f, transform.position.z);
        startCameraPosition = new Vector3(transform.position.x, 8, transform.position.z);
        StartCoroutine(WaitBeforeMoveCamera());
    }

    // Update is called once per frame
    void Update()
    {

        float cameraToCharacterDistance = Vector3.Distance(mainCameraPosition, transform.position);

        if (cameraToCharacterDistance > 0.1)
        {
            if (!wait && moveSpeed < 1f)
            {
                moveSpeed += 0.1f;
            }

            //Debug.Log(moveSpeed);

            transform.position = Vector3.Lerp(transform.position, mainCameraPosition, Time.deltaTime * moveSpeed);
        }

        if (!menuButtons.activeInHierarchy && cameraToCharacterDistance < 0.4)
        {
            //Debug.Log("ACTIVATE BUTTONS");
            menuButtons.SetActive(true);
        }
    }

    IEnumerator WaitBeforeMoveCamera()
    {
        yield return new WaitForSeconds(2);
        wait = false;
    }
}
