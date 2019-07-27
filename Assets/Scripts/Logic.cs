using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//Механика поведения маятника
public class Logic : MonoBehaviour {



    public GameObject Sphere;

    

    public float g = 9.8f;
    public const float e = 2.71f;

    private bool flag = false;

    public float mass = 1;
    public float lenthThread;
    public float aplituda;
    public float b;
    public float time;
    public float angel;
    public float w;
    public float coff;
    public float x;
    public float y;

    public float sdfsdfsdfsd;
    public float _mass;
    public float _aplituda;
    public float _lenght;
    public float _coff;

    public float deltaTime = 0.02f;
    

    /*
      private GameObject waypointPrefab;

    private void DrawPath(List<Vector3> path)
    {
        foreach (var position in path)
        {
            Instantiate(waypointPrefab, position, Quaternion.identity);
        }
    }
    */

   
    public void BuildLaser() {

  

   

    }

 
    

    void Start()
    {
        //gameObject.transform.position = new Vector3(0, (-1) * lenthThread, 0.5f);

       Starting();

    }
    
    void FixedUpdate()
    {
        //BuildLaser();
        if (!flag)
        {

        }
        else
        {

            PackForFixed();
        }


    }


    
    void Update() {



        if (!flag)
        {
            Sphere.transform.localPosition = new Vector3(0, lenthThread, 0);
        }
        else
        {

            Sphere.transform.localPosition = new Vector3(x, y, 0.0f);
        }




    }

    //Первый кадр работы маятника
    public void Starting()
    {
        time = 0;
        first_find_y();


        Sphere.transform.localPosition = new Vector3(x, y, 0.5f);
        find_w();
        find_b();
        find_x();
     //   find_Angel();

        flag = true;


    }
     void PackForFixed()
    {
        
            time += deltaTime;
            find_w();
            find_b();
            find_x();
            find_y();
           // find_Angel();
        
    }


    //Нахождение угла отклонения
    private void find_Angel()
    {
        float sin_angel = y / lenthThread;
        float angel_rd = Mathf.Asin(sin_angel);
        if (x > 0)
        {
            angel = (180 + (angel_rd * 180) / 3.14f);
        }
        else
        {

            angel = (-1) * (180 + (angel_rd * 180) / 3.14f);

        }
      //  Debug.Log("sin_angel = " + sin_angel);
     //   Debug.Log("angel = " + angel);

    }

    //Нахождение кофф. сопротивления
    void find_b() {

        try
        {
            b = coff / (2 * mass * w);
     //       Debug.Log("B= " + b);
        }
        catch
        {

      //      Debug.Log("Error B");

        }



    }

    //Нахождение координат позиции маятника
    public int find_x() {

        try
        {
            x = aplituda * (Mathf.Pow(e, (-b * time))) * (Mathf.Cos((w * time)));
    //        Debug.Log("X= " + x);
        }
        catch {

    //        Debug.Log("Error X");

        }

        return 1;
    }

    //Нахождение координат позиции маятника
    public int find_y() {
        try
        {
            y = Mathf.Sqrt(Mathf.Abs((lenthThread - x) * (lenthThread + x)))*(-1);
      //      Debug.Log(" Y = " + y);
        }
        catch {

      //      Debug.Log("Error Y");

        }
        return 1;
    }

    public int first_find_y() {

        try
        {
            y = Mathf.Sqrt(Mathf.Abs((lenthThread - aplituda) * (lenthThread + aplituda)))*(-1);
        //    Debug.Log(" Y(first) = " + y);
        }
        catch
        {

       //     Debug.Log("Error Y(first)");

        }
        return 1;




    }

    public int find_w() {

        try
        {
            w = Mathf.Sqrt(g / lenthThread);
      //      Debug.Log(" W = " + w);
        }
        catch (MissingReferenceException e) {

     //       Debug.Log("Not Find ==w==  ------" + e);
            return 0;
        }
        return 1;
   
    }


    public int find_aplituda() {

        try
        {
            aplituda = Mathf.Sin(angel) * lenthThread;
      //      Debug.Log(" Aplituda = " + aplituda);
        }
        catch (MissingReferenceException e ) {

      //      Debug.Log("Not Find ==aplituda==  ------" + e);
            return 0;
        }

        return 1;

    }

    public float find_w_local()
    {
        float w = 0;
        try
        {
           w = Mathf.Sqrt(g / lenthThread);
      //      Debug.Log(" W = " + w);
        }
        catch (MissingReferenceException e)
        {

     //       Debug.Log("Not Find ==w==  ------" + e);
           
        }
        return w;

    }

    public float find_x_local(float Time,float W,float B)
    {
        float x = 0;
        try
        {
           x = aplituda * (Mathf.Pow(e, (-B * Time))) * (Mathf.Cos((W * Time)));
   //         Debug.Log("X= " + x);
        }
        catch
        {
        
     //       Debug.Log("Error X");

        }

        return x;
    }

  

    float find_b_local(float W)
    {
        float b = 0;
        try
        {
            b = coff / (2 * mass * W);
       //     Debug.Log("B= " + b);
        }
        catch
        {
          
     //       Debug.Log("Error B");

        }

        return b;


    }

    public float find_y_local(float X)
    {
        float y = 0;
        try
        {
            y = Mathf.Sqrt(Mathf.Abs((lenthThread - X) * (lenthThread + X))) * (-1);
    //        Debug.Log(" Y = " + y);
        }
        catch
        {
          
  //          Debug.Log("Error Y");

        }
        return y;
    }

    public GamePlay.PositionForTarget position_ByTime(float time)
    {
        float W = find_w_local();
        float B = find_b_local(W);
        float X = find_x_local(time,W,B);
        float Y = find_y_local(X);
        GamePlay.PositionForTarget temp = new GamePlay.PositionForTarget();
        temp.x = X;
        temp.y = Y;
        temp.z = 0;
        return temp;
    }
    
    
    
}

