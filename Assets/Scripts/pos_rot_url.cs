using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System.Net;

public class pos_rot_url : MonoBehaviour
{
    //public Vector3 oldpos = new Vector3(0, 0, 0);
    public Vector3 newpos = new Vector3(0, 0, 0);
    //public float oldrot = 0f;
    //public float oldrot_2 = 0f;
    public float newrot = 0f;
    public float newrot_2 = 0f;
    //string path = "C:/Users/ketik/Desktop/test_record.txt";
    //string path = "http://cogmech.ucmerced.edu/~kg/game_test/record.php?";
    string path = "http://cogmech.ucmerced.edu/~kg/game_kg/record.php?";


    private string x;
    //private string privateKey = "key";
    public int uniq_key;
    public bool img;
    public bool img2;
    public float health_val;
    public int score;
    //public string score; 
    public Vector2 arrows = new Vector2(0, 0);
    public Vector4 rotate = new Vector4(0, 0, 0, 0);
    public bool neverdone = true; 


    void Update()
    {
        //Debug.Log("FixedUpdate realTime: " + Time.realtimeSinceStartup);
        img = GetComponent<onoroff>().isImgOn;
        img2 = GetComponent<end_on>().isImgOn;
        newpos = transform.position;
        newrot = transform.localRotation.eulerAngles.y;
        newrot_2 = transform.Find("FirstPersonCharacter").transform.localEulerAngles.x;
        uniq_key = GetComponent<onoroff>().key;
        health_val = GetComponent<health>().healthbarslider.value;
        score = GameObject.Find("Temples").GetComponent<count_child>().count;
        var health = health_val.ToString();
        var pos = newpos.ToString();
        var rot = newrot.ToString();
        var rot_2 = newrot_2.ToString();
        

        if (img == false && img2 == false)
        {

            //if (oldpos != transform.position || oldrot != transform.localRotation.eulerAngles.y || oldrot_2 != transform.Find("FirstPersonCharacter").transform.localEulerAngles.x)
            ///ADD A DIFF IF.. WITH INPUT KEY
            
               
                if (Input.GetKeyDown("up"))
                {
                    arrows[0] = 1;
                    string data = Time.time + "\t" + arrows + "\t" + rotate + "\t" + pos + "\t" + rot + "\t" + rot_2 + "\t" + health + "\t" + score + "\n";
                    StartCoroutine(SaveData(data));
                    

                }
                else arrows[0] = 0; 

                if (Input.GetKeyDown("down"))
                {
                    arrows[1] = 1;
                    string data = Time.time + "\t" + arrows + "\t" + rotate + "\t" + pos + "\t" + rot + "\t" + rot_2 + "\t" + health + "\t" + score + "\n";
                    StartCoroutine(SaveData(data));
                }
                else arrows[1] = 0;


                if (Input.GetKeyDown("w"))
                {
                    rotate[0] = 1;
                    string data = Time.time + "\t" + arrows + "\t" + rotate + "\t" + pos + "\t" + rot + "\t" + rot_2 + "\t" + health + "\t" + score + "\n";
                    StartCoroutine(SaveData(data));

                }
                else rotate[0] = 0;

                if (Input.GetKeyDown("s"))
                {
                    rotate[1] = 1;
                    string data = Time.time + "\t" + arrows + "\t" + rotate + "\t" + pos + "\t" + rot + "\t" + rot_2 + "\t" + health + "\t" + score + "\n";
                    StartCoroutine(SaveData(data));
                }
                else rotate[1] = 0;

                if (Input.GetKeyDown("a"))
                {
                    rotate[2] = 1;
                    string data = Time.time + "\t" + arrows + "\t" + rotate + "\t" + pos + "\t" + rot + "\t" + rot_2 + "\t" + health + "\t" + score + "\n";
                    StartCoroutine(SaveData(data));

                }
                else rotate[2] = 0;

                if (Input.GetKeyDown("d"))
                {
                    rotate[3] = 1;
                    string data = Time.time + "\t" + arrows + "\t" + rotate + "\t" + pos + "\t" + rot + "\t" + rot_2 + "\t" + health + "\t" + score + "\n";
                    StartCoroutine(SaveData(data));

                }
                else rotate[3] = 0;

                



                //var kg = hash;  

                //string data = Time.time + "\t" + arrows + "\t" + rotate + "\t" + pos + "\t" + rot + "\t" + rot_2 + "\t" + health + "\t" + score + "\n";
                //StartCoroutine(SaveData(data));
                //File.AppendAllText(path, data);



            
            //oldpos = newpos;
            //oldrot = newrot;
            //oldrot_2 = newrot_2;

        }

        if (neverdone)
        {
            if (img2 == true)
            {
                string data = Time.time + "\t" + arrows + "\t" + rotate + "\t" + pos + "\t" + rot + "\t" + rot_2 + "\t" + health + "\t" + score + "\n";
                StartCoroutine(SaveData(data));
                neverdone = false;
            }

           
        }
    }


    IEnumerator SaveData(string data)
    {


        WWW ScorePost = new WWW(path + "key=" + uniq_key + "&" + "data=" + data);
        yield return ScorePost;
        Debug.Log(data);

    }

}



