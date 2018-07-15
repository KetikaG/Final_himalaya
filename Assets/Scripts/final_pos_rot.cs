using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class final_pos_rot : MonoBehaviour
{
    public Vector3 oldpos = new Vector3 (0,0,0);
    public Vector3 newpos = new Vector3(0, 0, 0);
   
    public float oldrot = 0f;
    public float oldrot_2 = 0f;
    public float newrot = 0f;
    public float newrot_2 = 0f;

   
    string path = "C:/Users/ketik/Desktop/test_record.txt";


    void FixedUpdate()
    {


        if (oldpos != transform.position || oldrot != transform.localRotation.eulerAngles.y || oldrot_2 != transform.Find("FirstPersonCharacter").transform.localEulerAngles.x)
        {
            newpos = transform.position;
           newrot = transform.localRotation.eulerAngles.y;
            newrot_2 = transform.Find("FirstPersonCharacter").transform.localEulerAngles.x; 
            var pos = newpos.ToString();
            var rot = newrot.ToString();
            var rot_2 = newrot_2.ToString();
            string appendText = Time.time + "," + pos + "," + rot + "," + rot_2 + "\n";
            File.AppendAllText(path, appendText);
        }
        oldpos = newpos;
        oldrot = newrot;
        oldrot_2 = newrot_2;



    }
}

