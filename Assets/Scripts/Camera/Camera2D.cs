using UnityEngine;
using System.Collections;

public class Camera2D : MonoBehaviour {

    public GameObject _object;
    private Logic logic;


    void Start()
    {
        logic = _object.GetComponent<Logic>();

    }

    // Update is called once per frame
    public void Update() {

        gameObject.transform.position = new Vector3(0, (-1)*logic.lenthThread/2 , ((-1) *(logic.lenthThread +1.5f)));
	
	}
}
