using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour {

    public GameObject _object;
    private Logic logic;

    // Use this for initialization
    void Start()
    {
        logic = _object.GetComponent<Logic>();

    }

    public void restart() {

        logic.Starting();

    }
    // Update is called once per frame
    void Update () {
		
	}
}
