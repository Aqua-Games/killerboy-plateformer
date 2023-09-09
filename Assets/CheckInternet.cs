using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CheckInternet : MonoBehaviour
{
    public GameObject noInternetCanvas;
    private void Start()
    {
        StartCoroutine(CheckRoutine());
    }

    // Start is called before the first frame 
    private void FixedUpdate()
    {
        
    }

    IEnumerator CheckRoutine()
    {
        while (true)
        {
            
            UnityWebRequest request = new UnityWebRequest("https://www.google.com/");
            yield return request.SendWebRequest();
 
            if (string.IsNullOrEmpty(request.error))
            {
                Debug.Log("yes");
                noInternetCanvas.SetActive(false);
                 Time.timeScale = 1;
                
            }
            else
            {
                Debug.Log("No");
                noInternetCanvas.SetActive(true);
                Time.timeScale = 0;
            }
            Debug.Log("iiii");

            yield return new WaitForSecondsRealtime(1f);
        }
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        StopAllCoroutines();
        StartCoroutine(CheckRoutine());
    }

    private void OnApplicationQuit()
    {
        StopAllCoroutines();
        StartCoroutine(CheckRoutine());
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        StopAllCoroutines();
        StartCoroutine(CheckRoutine());
    }
   
}