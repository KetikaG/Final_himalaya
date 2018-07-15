using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updownhill : MonoBehaviour {

    //private runningaverage Runningaverage;

    public Vector3 lastPosition = Vector3.zero;
    public float angle;
   // public int uphill = 0;
    //public int downhill = 0;
    //var lastPosition : Vector3;
 
void FixedUpdate()
    {
        var currentPosition = transform.position;
       angle = GetComponent<runningaverage>().Runningaverage;
            if (currentPosition.y > lastPosition.y)
            {

            angle = angle * 1f;

            }
           else if (currentPosition.y < lastPosition.y)
            {
                angle = angle * 0f; 
            }

       // }
        //else if (currentPosition.y == lastPosition.y)
        
        //        GameObject.Find("Hill").GetComponent<Text>().text = "Plane";
        
        

        lastPosition = currentPosition;
    }
}
