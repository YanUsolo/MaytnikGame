using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GamePlay : MonoBehaviour {

    public struct PositionForTarget
    {
        public float x;
        public float y;
        public float z;
    }

    public GameObject GlobalObject;
  
    public int MaxTarget = 2;

    public Text howGoodText;
    public Text scoreText;

    public int score;
    public int targetMiss;

    public Logic maytnikLogic;
    public GameObject maytnikGameObject;

    public LinkedList<GameObject> targets;

    public GameObject[] arrayTargets;

    public LinkedList<PositionForTarget> posTargets = new LinkedList<PositionForTarget>();

    public int layerMask = 1 << 8;

    private bool flag_ForPosition;
    private float localDeltaTime = 0.01f;
    private bool pauseOn = true;
    private bool blockMenu = true;

    public GameObject[] objectStart;

    public AudioSource AudioSource;
   // public AudioClip snowSound;

    public void Awake()
    {
        //AudioSource.Cli = snowSound;
        AudioSource.Play();
    }

    public void initTarget_ByCount()
    {
        for (int i = 0; i < MaxTarget; i++)
        {
            //ToDo
        }
    }

    public void newPositionTarget()
    {
        posTargets.Clear();

        for (int i = 0; i < MaxTarget; i++)
        {
            float time = Random.Range(0f, 2.5f);
            PositionForTarget tempPos = maytnikLogic.position_ByTime(time);
            posTargets.AddLast(tempPos);
        }
        
    }

    public void set_NewPositionTearget()
    {
        int i = 0;
        foreach (PositionForTarget position in posTargets)
        {
            arrayTargets[i].transform.localPosition = new Vector3(position.x, position.y, position.z);
            i++;
        }

    }

    public void MainPackMech()
    {
        RaycastHit hit;
        //  player.transform.position -= player.transform.forward * speed * Time.deltaTime;
        if (checkTarget(out hit))
        {
            hit.collider.gameObject.transform.parent.parent.gameObject.SetActive(false);
            score += 25;
            targetMiss--;
            scoreText.text = "Score : " + score;
            howGoodText.color =  Color.green;
            howGoodText.text = "Good";
        }
        else
        {

            score -= 50;
            scoreText.text = "Score : " + score;
            howGoodText.color = Color.red;
            howGoodText.text = "Bad";
        }

    }

    public void START_GAME()
    {
        AudioSource.Stop();

        for (int i = 0; i < objectStart.Length; i++)
        {
            objectStart[i].SetActive(true);
        }

        targetMiss = MaxTarget;
        newPositionTarget();

        set_NewPositionTearget();

        blockMenu = false;
        Pause();
       // maytnikLogic.deltaTime = 0.01f;
    }


    public void SecondPackMech()
    {
        if (targetMiss == 0)
        {
            newPasitionTargetOPack();
            targetMiss = MaxTarget;
        }

    }

    public void newPasitionTargetOPack()
    {
        newPositionTarget();

        set_NewPositionTearget();

        for (int i = 0; i < MaxTarget; i++)
        {
            arrayTargets[i].transform.parent.gameObject.SetActive(true);
        }

        maytnikLogic.deltaTime += 0.001f;

    }

    public bool checkTarget(out RaycastHit  hit)
    {
        Vector3 forward = maytnikGameObject.transform.TransformDirection(Vector3.forward) * 10;
      //  Debug.DrawRay(new Vector3(maytnikGameObject.transform.position.x, maytnikGameObject.transform.position.y, -5f), new Vector3(maytnikGameObject.transform.position.x, maytnikGameObject.transform.position.y, 10), Color.yellow);
       
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(new Vector3(maytnikGameObject.transform.position.x, maytnikGameObject.transform.position.y, maytnikGameObject.transform.position.z - 2f), forward, out hit, Mathf.Infinity, LayerMask.GetMask("GamePlayLayer") ))
        {    
            Debug.Log("Did Hit");
            return true;
        }
        else
        { 
            Debug.Log("НИЧЕГО!!!!!!!!!!!!");
            return false;
        }
      
    }



   
    // Use this for initialization
   /* void Start ()
    {

        targetMiss = MaxTarget;
        newPositionTarget();
      
        set_NewPositionTearget();
      
    }
    */
    // Update is called once per frame
    void Update()
    {
        Vector3 forward = maytnikGameObject.transform.TransformDirection(Vector3.forward * 10);
        Debug.DrawRay(new Vector3(maytnikGameObject.transform.position.x, maytnikGameObject.transform.position.y, maytnikGameObject.transform.position.z - 2f), forward, Color.yellow);
        if (!pauseOn)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                MainPackMech();
            }
        }
        if (!blockMenu)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                Pause();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Exit();
        }

    }
    
    public void Pause()
    {
        if (!pauseOn)
        {
            pauseOn = true;
            localDeltaTime = maytnikLogic.deltaTime;
            maytnikLogic.deltaTime = 0;
        }
        else
        {
            maytnikLogic.deltaTime = localDeltaTime;
            pauseOn = false;
        }

    }

    public void Exit()
    {
        Application.Quit();
    }

     private void FixedUpdate()
     {
        if (!pauseOn)
        {
            SecondPackMech();
        }
     }
     


}
