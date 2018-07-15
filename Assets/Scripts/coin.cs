using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System.Net;

public class coin : MonoBehaviour
{
    public int oldcount = 0;
    public static int collected = 0;
    public static int actual_score = 0;
    public static int coin_stored_coinclick = 0;
    public AudioSource coinsound;
    
    //string path = "C:/Users/ketik/Desktop/test_record.txt";
  //string path = "http://cogmech.ucmerced.edu/~kg/game_test/score.php?";
    //string path_report = "http://cogmech.ucmerced.edu/~kg/game_test/score_report.php?";
    string path = "http://cogmech.ucmerced.edu/~kg/game_kg/score.php?";
    string path_report = "http://cogmech.ucmerced.edu/~kg/game_kg/score_report.php?";
    public int uniq_key;
    public Vector3 pos_temple;
    public Vector3 check_pos;
    public Vector3 pos;
    public static bool img;
    public static bool img2;

    // public string score; 



    void Awake()
    {
        SphereCollider myCollider = transform.GetComponent<SphereCollider>();
        myCollider.radius = 60f;

        coinsound = GameObject.Find("Audio").GetComponent<AudioSource>();
        GameObject.Find("Stored").GetComponent<Text>().text = "R E P O R T E D : 0 ";

        GameObject.Find("Score").GetComponent<Text>().text = "R E C O R D E D : 0 ";
        img = GameObject.Find("Player").GetComponent<onoroff>().isImgOn;
        img2 = GameObject.Find("Player").GetComponent<end_on>().isImgOn;
}



    void OnMouseDown()
    {
        // this object was clicked - do something


        coinsound.Play();
        collected++;
        actual_score++;
       //Debug.Log("checkpoint" + "|" + Time.deltaTime + "|" + collected + actual_score);
        GameObject.Find("Score").GetComponent<Text>().text = "R E C O R D E D : " + collected;
        check_pos = this.gameObject.transform.position;
        //Debug.Log("checkpoint" + check_pos);
        Destroy(this.gameObject);
        uniq_key = GameObject.Find("Player").GetComponent<onoroff>().key;
       

        if (img == false && img2 == false)
        {
            if (oldcount != actual_score)
            {
               var score = actual_score.ToString();
                //var collected = (GameObject.Find("Home").GetComponent<stored>().actual_score).ToString();

                string data = Time.time + "\t" + check_pos + "\t" + pos + "\t" + score + "\n";
                // File.AppendAllText(path, data);
                StartCoroutine(SaveData(data, path ));

            } 
            oldcount = actual_score;
        } 


    }
    void Update()
    {
        pos = GameObject.Find("Player").transform.position;
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name == "torch" && collected != 0)
                {
                    //coin_stored_oneclick = collected;
                   // actual_collected = coin_stored_oneclick + actual_score; 
                    //Debug.Log("home_clicked");
                    uniq_key = GameObject.Find("Player").GetComponent<onoroff>().key;
                    GameObject.Find("Stored").GetComponent<Text>().text = "R E P O R T E D : " + actual_score;
                    collected = 0;
                   GameObject.Find("Score").GetComponent<Text>().text = "R E C O R D E D : " + collected;
                    //collected = 0; 

                    var total_recorded = actual_score.ToString();
                    //var collected = (GameObject.Find("Home").GetComponent<stored>().actual_score).ToString();

                    string data = Time.time + "\t" + check_pos + "\t" + pos + "\t" + total_recorded + "\n";
                    // File.AppendAllText(path, data);
                    StartCoroutine(SaveData(data, path_report));

                }
            }
            



        }
    }
    IEnumerator SaveData(string data, string path)
    {

        // string hash = Md5Sum(data1 + privateKey);
        WWW ScorePost = new WWW(path + "key=" + uniq_key + "&" + "data=" + data);
        yield return ScorePost;
    }
}
