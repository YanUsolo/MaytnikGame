using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Controller : MonoBehaviour {

    Logic logic;

    
    public Text X;
    public Text Y;
    public Text W;
    public Text B;
    public Text Time;
    public Text Angle;

    // Use this for initialization
    void Start () {

        logic =  GameObject.Find("Sphere").GetComponent<Logic>();
		
	}
	
	// Update is called once per frame
	void Update () {

        X.text = "X = " +  logic.x;
        Y.text = "Y = " + logic.y;
        W.text = "W = " + logic.w;
        B.text = "B = " + logic.b;
        Time.text = "Time = " + logic.time;
        Angle.text = "Angle = " + logic.angel;



    }

    
}
