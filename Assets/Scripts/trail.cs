using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class trail : MonoBehaviour
{
    public List<Vector3> playerPos;
    public List<Vector3> vectors = new List<Vector3>();
 
   /* void Update()
    {
        var input = new List<int>();
        // Open the text file using a stream reader.
        try {
            using (StreamReader sr = new StreamReader(@"C:/Users/ketik/Desktop/Project/Data/Firstrun_10_06/parsed/test_path_forunity.txt"))
            {
                // Read the stream to a string, and write the string to the console.
                String line = sr.ReadToEnd();
                Debug.Log(line);
                
             
                    int i = 0;
                    if (int.TryParse(line, out i))
                    {
                        input.Add(i);
                        Debug.Log(i);
                    }

                }
            }
        
       */
        /*Debug.Log("Editor causes this Awake");
        string line; //current line
        var input = new List<int>();
        System.IO.StreamReader file = new System.IO.StreamReader(@"C:/Users/ketik/Desktop/Project/Data/Firstrun_10_06/parsed/test_path_forunity.txt");
        Debug.Log(file);
        while ((line = file.ReadLine()) != null)
        {
            int i = 0;
            if (int.TryParse(line, out i))
            {
                input.Add(i);
                
            }
            //playerPos.Add(curline);
        }


        for (int index = 0; index < input.Count; index += 3)
        {
            vectors.Add(new Vector3(input[index], input[index + 1], input[index + 2]));
        }
        //List<Vector3> playerPos = new List<Vector3>();

        //Store players positions somewhere
        //playerPos.Add(pPos);
        //playerPos.Add(pPos); 
        //playerPos.Add(pPos);


        Color red = Color.red;
        //LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        GameObject obj = new GameObject("line");
        LineRenderer lineRenderer = obj.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        lineRenderer.useWorldSpace = true;
        //lineRenderer.SetWidth(0.5f, 0.5f);
        //lineRenderer.SetColors(Color.blue, Color.blue);

        //lineRenderer.startColor(red);

        //lineRenderer.SetWidth(0.2F, 0.2F);

        //Change how mant points based on the mount of positions is the List
        lineRenderer.positionCount = vectors.Count;

        for (int i = 0; i < playerPos.Count; i++)
        {
            //Change the postion of the lines
            lineRenderer.SetPosition(i, vectors[i]);
        }

        
    } */
}

