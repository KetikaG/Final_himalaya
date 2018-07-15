using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System.Net;
using UnityEngine.SceneManagement;

public class score : MonoBehaviour
{
   // public int oldcount = 0;
    public static int count = 0;
    public static int actual_score = 0;
   // public int yesorno = 0;
    public AudioSource coinsound;
    public Text blah;

    void Awake()
    {
        GameObject.Find("Stored").GetComponent<Text>().text = "R E P O R T E D : 0 ";

        GameObject.Find("Score").GetComponent<Text>().text = "R E C O R D E D : 0 ";
    }


    void OnMouseDown()
    {
        // this object was clicked - do something
        coinsound = GameObject.Find("Audio").GetComponent<AudioSource>();

        coinsound.Play();
        count = 1; 
        //actual_score++;
        GameObject.Find("Score").GetComponent<Text>().text = "R E P O R T E D :" + count ;
        Destroy(this.gameObject);
       // Debug.Log(actual_score + "," + count);
        blah.GetComponent<Text>().enabled = false;
      
        GameObject.Find("Walk").GetComponent<Text>().text = "Now click at the home base and report the temples found.";

        //&& yesorno == 0
        /*if (count == 2 )
        {
            GameObject.Find("Walk").GetComponent<Text>().text = "Now click at home and store the treasures.";
        }*/


    }

    void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //&& count == 1
                if (hit.collider.gameObject.name == "torch" && count == 1 )
                {
                    //coin_stored_oneclick = collected;
                    // actual_collected = coin_stored_oneclick + actual_score; 
                   // Debug.Log("home_clicked");
                    GameObject.Find("Stored").GetComponent<Text>().text = "R E P O R T E D : 1 " ;
                    
                    GameObject.Find("Score").GetComponent<Text>().text = "R E C O R D E D : 0 ";
                    // collected = 0; 
                    //GameObject.Find("Gameobject").GetComponent<loadscene>().yesorno = 1;
                    GameObject.Find("Walk").GetComponent<Text>().text = "Great job, you have successfully reported to the home base! Now you will be taken to the game.";

                    StartCoroutine(WaitForSceneLoad());
                    
                   /* else if (actual_score == 2)
                    {
                        GameObject.Find("Walk").GetComponent<Text>().text = "Great job! Now you will be now taken to the game.";
                        GameObject.Find("Gameobject").GetComponent<loadscene>().yesorno = 1; 
                    }*/
                }
                
            }




        }
    }

    IEnumerator WaitForSceneLoad()
    {

        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Gaila");
        //SceneManager.LoadScene(1);

    }



}
