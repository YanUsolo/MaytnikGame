using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationChel : MonoBehaviour {

    public GameObject chelObject;
    public float deltaTime;
    public Animator animator;
    // Use this for initialization

    private void Awake()
    {

       // animator.StopPlayback();
       

       
    }
    void Start ()
    {
        //while (true)
        //{
            StartCoroutine(MyF());
        //}
    }
	
	// Update is called once per frame
	void Update () {

        
    }

    private void FixedUpdate()
    {
        //foWardFix();

    }
    public IEnumerator MyF()
    {
       
        yield return new WaitForSeconds(10.0f);
        startAnimation();
        //DoStuff
    }

    public void startAnimation()
    {
        animator.Play("step");
       // StartCoroutine(stopPlay());
    }

    public IEnumerator stopPlay()
    {
        startAnimation();
        yield return new WaitForSeconds(2.833f);
        //DoStuff
    }


}
