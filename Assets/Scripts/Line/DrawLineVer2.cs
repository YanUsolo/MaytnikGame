using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLineVer2 : MonoBehaviour {

    public GameObject PointZero;
    public GameObject PointSecond;
    public float Width;
   
    //public Logic logic;
    public LineRenderer lr;

    void Start()
    {
      //  logic = _object.GetComponent<Logic>();
       // lr = this.gameObject.GetComponent<LineRenderer>();
      //  Debug.Log("LineRenderer" + lr);
        lr.material.color = Color.red;
        lr.SetWidth(Width, Width);
        // lr.receiveShadows = false;
    }

    // Update is called once per frame
    void Update()
    {

        // lr.SetColors(Color.red, Color.red);
        //lr.SetWidth(0.1f, 0.1f);
        //lr.
        lr.SetPosition(0, new Vector3(PointZero.transform.position.x, PointZero.transform.position.y, PointZero.transform.position.z));
        lr.SetPosition(1, new Vector3(PointSecond.transform.position.x, PointSecond.transform.position.y, PointSecond.transform.position.z));

/*
        lr.SetPosition(0, new Vector3(PointZero.transform.localPosition.x, PointZero.transform.localPosition.y, PointZero.transform.localPosition.z));
        lr.SetPosition(1, new Vector3(PointSecond.transform.localPosition.x, PointSecond.transform.localPosition.y, PointSecond.transform.localPosition.z));
        */
        // Debug.Log("Vector  "  +  PointZero.transform.position.z  + "  --  " + PointZero.transform.position.y);
        //   Debug.Log("Vector  " + PointSecond.transform.position.z + "  --  " + PointSecond.transform.position.y);

    }
}
