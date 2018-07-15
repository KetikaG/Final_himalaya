using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

//[ExecuteInEditMode]
public class trace : MonoBehaviour {

    //List<vector3> positions = new List<vector3>();
    List<string> line = new List<string>();
    public string[] onefile; 
    public int length = 0;
    public int length_vector = 0;
    float x = 0f;
    float y = 0f;
    float z = 0f;
    //bool isDoorOpen;
    //List<StreamReader> files = new List<StreamReader>();

    //public Vector3[] array_pos = new Vector3[28];
    List<Vector3> pos_list = new List<Vector3>();
    List<String> paths = new List<String> { "736.75.130.217.245.txt", "838.64.121.196.248.txt" };
    string dir = "C:/Users/ketik/Desktop/Project/Data/Firstrun_10_06/parsed/coords/unique/parsed/";
    public GameObject[] parents; 




    void Start()
    {
        string curline;
        //string curfile;


        //var path = "736.75.130.217.245.txt"; 

        // var path = "C:/Users/ketik/Desktop/Project/Data/Firstrun_10_06/parsed/coords/unique/parsed/736.75.130.217.245.txt";
        //System.IO.StreamReader file = new System.IO.StreamReader(@"C:/Users/ketik/Desktop/Project/Data/Firstrun_10_06/parsed/coords/unique/parsed/path.txt.txt");
        GameObject[] parents = new GameObject[paths.Count];
       for (int x = 0; x < paths.Count; x++)
        {
            var lines = File.ReadAllLines(dir + paths[x]);  //read lines from one file at a time
            parents[x]  = new GameObject("emptyparent"+ "_" + paths[x]);
            parents[x].transform.parent = this.gameObject.transform;

            System.IO.StreamReader file = new System.IO.StreamReader(dir + paths[x]);
              while ((curline = file.ReadLine()) != null)
                {
                     //Debug.Log("line" + x + "\t" + curline);
                    line.Add(curline);
                 }

                 // Debug.Log(lines);





             length = line.Count;
             length_vector = length / 3;
             Debug.Log(length);



            Trace();


       }

        //  }

        //string path = @"C:/Users/ketik/Desktop/Project/Data/Firstrun_10_06/parsed/coords/unique/parsed/736.75.130.217.245.txt";
        //System.IO.StreamReader file = new System.IO.StreamReader();
        //while ((curfile = file.ReadLine()) != null)
        /*
        foreach (string line in lines)
        {

            //System.IO.StreamReader onefile = new System.IO.StreamReader(curfile);

            String path_onefile = line;
            Debug.Log("line" + path_onefile);
            using (StreamReader blah = new StreamReader(path_onefile)) {

                //var lines_onefile = File.ReadAllLines(path_onefile, System.Text.Encoding.ASCII);
                // foreach (string curline in blah)
                while ((curline = blah.ReadLine()) != null)
                {
                    Debug.Log("line" + curline);
                }
            }

        } */

       

    }

   
   

    void Trace()
    {
        GameObject[] sphere = new GameObject[length_vector];

        LineRenderer lr = GetComponent<LineRenderer>();
            lr.positionCount = length_vector;
            lr.startColor = Color.red;
            lr.endColor = Color.cyan;

            
        ////adding each line into a vector--playerpos, and then making a list of vectors--post_list////// 
            float[] vectors = new float[length];
            Vector3 playerpos = new Vector3();
            for (int i = 0; i < length; i += 3)
            {
                float.TryParse(line[i], out x);
                float.TryParse(line[i + 1], out y);
                float.TryParse(line[i + 2], out z);

                vectors[0] = x;
                vectors[1] = y;
                vectors[2] = z;
                //Debug.Log("vector" + vectors[1]);

                playerpos.x = vectors[0];
                playerpos.y = vectors[1];
                playerpos.z = vectors[2];

                pos_list.Add(playerpos);
            Debug.Log("no." + i);
        }
           // Debug.Log("no."+ i);

            for (int j = 0; j < length_vector; j++)

            {
                sphere[j] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
               //sphere[j].transform.SetParent(parents[x].transform);
                sphere[j].tag = "Sphere";
                sphere[j].transform.position = pos_list[j];
            sphere[j].transform.localScale = new Vector3(10, 10, 10);
                
                //Debug.Log(sphere[j].transform.position);
                //  Debug.Log(GameObject.FindGameObjectsWithTag("Sphere").Length);
                //lr.SetPosition(j, pos_list[j]);



            }
        }
                
    
       

    
}

