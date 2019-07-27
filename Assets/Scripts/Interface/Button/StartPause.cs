using UnityEngine;
using System.Collections;

public class StartPause : MonoBehaviour {

    public GameObject _object;
    private Logic logic;
    

    void Start()
    {
        logic = _object.GetComponent<Logic>();
        
    }
    // Use this for initialization
    public void start_pause()
    {
        if (logic.deltaTime == 0f)
        {
            logic.deltaTime = 0.02f;
        }
        else
        {
            logic.deltaTime = 0f;
        }

    }

    // Update is called once per frame
    void Update () {
	
	}
}
