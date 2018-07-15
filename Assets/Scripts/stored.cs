using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System.Net;

public class stored : MonoBehaviour
{
    public static int collected = 0;
    public static int coin_stored = 0;
    public int actual_score = 0;
   //public AudioSource coinsound;
    public static bool img;
    public static bool img2;
    public static int count_temple;
    //string path = "C:/Users/ketik/Desktop/test_record.txt";
    //string path = "http://cogmech.ucmerced.edu/~kg/game_test/score.php?";
    public int uniq_key;
    public AudioSource coinsound;

    void Awake()
    {
       

        coinsound = GameObject.Find("Audio").GetComponent<AudioSource>();
       // SphereCollider myCollider = GamObject.Find(")GetComponent<SphereCollider>();
       // myCollider.radius = 60f;
    }


    /* void OnMouseDown()
     {
         // this object was clicked - do something


         //coinsound.Play();
         //count++;
         if ()
         coin_stored =  (GameObject.Find("Temples").GetComponent<count_child>().count);
         actual_score = coin_stored + oldcount; 

         Debug.Log("checkpoint" + coin_stored + oldcount + actual_score);
         GameObject.Find("Stored").GetComponent<Text>().text = "S T O R E D : " + actual_score ;
         oldcount = coin_stored;

         coin_stored = 0;
         GameObject.Find("Score").GetComponent<Text>().text = "C O L L E C T E D : " + coin_stored;


                 img = GameObject.Find("Player").GetComponent<onoroff>().isImgOn;
         img2 = GameObject.Find("Player").GetComponent<end_on>().isImgOn;
         uniq_key = GameObject.Find("Player").GetComponent<onoroff>().key;


         if (img == false && img2 == false)
         {


             var score = coin_stored.ToString();
             var total = actual_score.ToString();
             string data = Time.time + "\t" + coin_stored + "\t" + total + "\n";
             // File.AppendAllText(path, data);
             StartCoroutine(SaveData(data));



         }


     } */

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 200f))
            {
                if ((hit.collider.gameObject.name == "Temples"))
                {
                    coinsound.Play();
                    collected++;
                    actual_score++;
                    Debug.Log("checkpoint" + collected + actual_score);
                    GameObject.Find("Score").GetComponent<Text>().text = "C O L L E C T E D : " + collected;
                
                    // Destroy(this.gameObject);
                }
                if (hit.collider.gameObject.name == "Home")
                {
                    coin_stored = collected;
                    Debug.Log("home_clicked");
                    GameObject.Find("Stored").GetComponent<Text>().text = "S T O R E D : " + actual_score;
                    collected = 0; 

                }
                //check_pos = this.gameObject.transform.position;
            }

        }
    }

   /* IEnumerator SaveData(string data)
    {

        // string hash = Md5Sum(data1 + privateKey);
        WWW ScorePost = new WWW(path + "key=" + uniq_key + "&" + "data=" + data);
        yield return ScorePost;
    }

    */


}
