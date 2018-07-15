using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Net;

public class health : MonoBehaviour
{

    public Slider healthbarslider;  //reference for slider
    //public Text gameOverText;   //reference for text
    //private bool isGameOver = false; //flag to see if game is over
    public Vector3 lastPosition = Vector3.zero;
    public float angle;
    // public float x = GameObject.Find("Slider").GetComponent<Slider>().value;
    public float theta;
    public bool img;
    public Text value;
   // public int uniq_key;

    //string path = "http://cogmech.ucmerced.edu/~kg/game_test/record_health.php?";
    // public Image img;
    void Awake()
    {
        healthbarslider.value = 9000;
    }

    void FixedUpdate()
    {
        img = GetComponent<onoroff>().isImgOn;
       // uniq_key = GetComponent<onoroff>().key;

        // var currentPosition = transform.position;
        // angle = GetComponent<runningaverage>().Runningaverage;
        if (img == false)
        {
            if (Input.GetKey("w") ||  Input.GetKey("s") )
            {
               // Debug.Log("key");
                if (healthbarslider.value != 0)
                {
                    //if (currentPosition != lastPosition)

                    theta = GetComponent<angles>().edit_angle;
                    if (theta != 0f) //UPHILL ANGLES 
                    {
                    healthbarslider.value -= theta * 0.35f;
                    
                     }

                    else if (theta == 0f) //treating all non-uphill movements as plain walking at 1deg 
                     {
                        healthbarslider.value -= 0.35f;
                     }
                    //value.text = "FUEL TANK:" + healthbarslider.value;
                    
                    
                }
            }
           
        }



       

    }
}

    

