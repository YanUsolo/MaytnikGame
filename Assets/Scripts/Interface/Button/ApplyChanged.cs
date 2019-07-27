using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ApplyChanged : MonoBehaviour {

    public Text inputMass;
    public Text inputA;
    public Text inputL;
    public Text inputC;

    public GameObject _object;
    private Logic logic;

    // Use this for initialization
    void Start () {

        logic = _object.GetComponent<Logic>();
       

    }

    public void applychange() {
        if (!inputMass.text.Equals("")) {
            try
            {
                logic._mass = float.Parse(inputMass.text);
            }
            catch (Exception e) {
           
                logic._mass = 1f;
            }
        }

        if (!inputA.text.Equals(""))
        {
            try
            {
                logic._aplituda = float.Parse(inputA.text);
            }
            catch (Exception e)
            {
             
                logic._aplituda = 1f;
            }
        }

        if (!inputL.text.Equals(""))
        {
            try
            {
                logic._lenght = float.Parse(inputL.text);
            }
            catch (Exception e)
            {
               
                logic._lenght = 1f;
            }
        }

        if (!inputC.text.Equals(""))
        {
            try
            {
                logic._coff = float.Parse(inputC.text);
            }
            catch (Exception e)
            {
                
                logic._coff = 1f;
            }
        }


    }
	// Update is called once per frame
	void Update () {

       
		
	}
}
