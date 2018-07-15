using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class angles : MonoBehaviour
{

    //private runningaverage Runningaverage;

    public Vector3 lastPosition = new Vector3(6480.5f, 14724.21f, 6399.15f);
    public float angle;
    public float edit_angle;
    public bool img; 
    // public int uphill = 0;
    //public int downhill = 0;
    //var lastPosition : Vector3;

    void Update()
    {
        img = GetComponent<onoroff>().isImgOn;

        var currentPosition = transform.position;
        angle = GetComponent<runningaverage>().Runningaverage;
        if (img == false)
        {
            if (Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("left") || Input.GetKey("right"))
            {
                if (currentPosition.y > lastPosition.y) //uphill or more than 0deg in + 
                {

                    edit_angle = angle * 1f;

                }
                else if (currentPosition.y < lastPosition.y) //downhill or more than 0deg in - 
                {
                    edit_angle = angle * 0f;
                }
            }
           
        }
        




    

        lastPosition = currentPosition;
    }
}
