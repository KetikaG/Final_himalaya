using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class runningaverage : MonoBehaviour
{

    private GroundChecker angle;
    public float lastangle = 0f;
    public float Runningaverage = 0f;




    //public float[] fiveangles;
    void Awake()
    {
        
        // Get component on the same GameObject
        angle = GetComponent<GroundChecker>();
       //Debug.Log("Runningavgscript did not find an angle.");
    }

    
  

    // Update is called once per frame
    void Update()
    {
        //var currentPosition = transform.position;
        if (Input.GetKey("w") || Input.GetKey("s"))  {
            //fiveangles[0] = lastangle;
            float currentangle = Mathf.Round(angle.groundSlopeAngle);
            float secondaverage = ((0.1f * currentangle) + (Runningaverage * 0.9f));
            secondaverage = Mathf.Round(secondaverage);
            lastangle = currentangle;
            Runningaverage = secondaverage;

        }
      

             
    }



       




}
    



   






      