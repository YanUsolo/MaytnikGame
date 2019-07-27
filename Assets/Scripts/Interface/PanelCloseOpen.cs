using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelCloseOpen : MonoBehaviour {

    public GameObject text1;
    public GameObject text2;

    public GameObject MainCamera;
    public GameObject SecomdCamera;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Close()
    {
        gameObject.SetActive(false);
        text1.SetActive(true);
        text2.SetActive(true);
    }

    public void closeCamera()
    {
        SecomdCamera.SetActive(true);
        MainCamera.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
