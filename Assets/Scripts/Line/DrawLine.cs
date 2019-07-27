using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Отрисовка нити маятника
public class DrawLine : MonoBehaviour {

    // Use this for initialization
    public GameObject _object;
    public Logic logic;
    LineRenderer lr;

    void Start()
    { 
        lr = this.gameObject.GetComponent<LineRenderer>();
        Debug.Log("LineRenderer" + lr);
        lr.material.color = Color.red;
       // lr.receiveShadows = false;
    }

    // Update is called once per frame
    void Update () {
        
       // lr.SetColors(Color.red, Color.red);
        lr.SetWidth(0.1f, 0.1f);
        lr.SetPosition(0, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y,0f));
        lr.SetPosition(1, new Vector3(logic.x, logic.y));
        Debug.Log("Vector" + new Vector3(logic.x, logic.y));

    }
}
