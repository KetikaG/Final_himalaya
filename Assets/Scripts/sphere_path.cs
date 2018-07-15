using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;


public class sphere_path : MonoBehaviour
{

    List<string> line = new List<string>();
    //string[] onefile;
    int length = 0;
    int length_vector = 0;
    float x = 0f;
    float y = 0f;
    float z = 0f;
    List<Vector3> pos_list = new List<Vector3>();
    List<String> paths = new List<String> { "110.107.207.50.244.txt", "111.68.3.12.21.txt", "116.70.44.129.143.txt", "130.66.67.97.72.txt", "134.157.51.224.9.txt", "136.97.80.221.6.txt", "142.192.203.201.3.txt", "161.172.220.72.81.txt", "161.73.236.40.189.txt", "162.50.25.70.111.txt", "163.66.222.54.93.txt", "187.174.103.167.92.txt", "188.216.110.214.42.txt", "200.117.196.94.78.txt", "204.99.34.176.51.txt", "206.70.95.78.40.txt", "206.73.61.142.248.txt", "220.72.185.23.235.txt", "221.71.237.59.12.txt", "256.47.204.11.8.txt", "260.47.42.138.78.txt", "300.67.246.89.139.txt", "301.208.93.255.170.txt", "311.104.63.226.6.txt", "338.68.119.43.1.txt", "339.73.180.78.188.txt", "341.24.167.164.138.txt", "342.108.217.68.60.txt", "343.172.81.80.3.txt", "346.98.216.85.147.txt", "362.174.135.61.246.txt", "381.115.99.248.165.txt", "382.67.162.161.1.txt", "383.98.209.27.109.txt", "391.75.86.174.11.txt", "412.68.227.105.29.txt", "415.128.95.213.82.txt", "442.76.205.164.120.txt", "452.45.251.33.17.txt", "452.65.186.20.223.txt", "46.184.18.197.102.txt", "470.68.231.140.228.txt", "479.110.225.219.1.txt", "485.67.182.61.40.txt", "488.74.66.228.248.txt", "518.166.137.125.46.txt", "532.135.84.220.110.txt", "535.216.249.194.203.txt", "535.68.190.172.23.txt", "541.111.92.24.178.txt", "541.99.203.30.108.txt", "550.73.144.188.188.txt", "571.24.208.211.116.txt", "578.98.193.105.168.txt", "58.71.30.211.248.txt", "611.59.97.116.141.txt", "616.97.83.219.73.txt", "631.71.34.106.1.txt", "631.76.187.65.25.txt", "651.73.11.87.173.txt", "667.117.249.151.11.txt", "671.24.127.94.39.txt", "689.67.170.142.201.txt", "69.72.83.52.47.txt", "699.192.81.179.4.txt", "716.96.237.54.218.txt", "736.75.130.217.245.txt", "739.174.16.247.253.txt", "747.24.49.56.194.txt", "757.73.128.105.17.txt", "759.173.171.37.35.txt", "786.68.98.72.178.txt", "798.104.128.136.71.txt", "798.125.77.59.140.txt", "806.27.5.222.253.txt", "813.122.164.238.198.txt", "826.68.200.120.99.txt", "838.64.121.196.248.txt", "85.103.77.1.122.txt", "855.71.15.41.172.txt", "866.98.243.113.184.txt", "869.67.11.212.123.txt", "874.117.201.17.70.txt", "875.68.121.255.154.txt", "886.68.175.10.134.txt", "902.207.172.250.130.txt", "914.173.89.121.0.txt", "966.96.36.47.46.txt", "985.100.40.129.160.txt" };
    string dir = "C:/Users/ketik/Desktop/Project/Data/Firstrun_10_06/parsed/coords/unique/parsed/";
    string curline;
    GameObject[][] sphere_onefile;
    //public GameObject[] parents;



    void Start()
    {

        Trace();

    }

    void Trace()
    {
        GameObject[] parents = new GameObject[paths.Count];

        //LineRenderer lr = GetComponent<LineRenderer>();
        //lr.positionCount = length_vector;
        //lr.startColor = Color.red;
        //lr.endColor = Color.cyan;


        for (int one_file = 0; one_file < paths.Count; one_file++)
        {
            //Debug.Log(paths.Count);
            //var lines = File.ReadAllLines(dir + paths[one_file]);  //read lines from one file at a time
            parents[one_file] = new GameObject("file" + "_" + paths[one_file]);

            parents[one_file].transform.parent = this.gameObject.transform;

            System.IO.StreamReader file = new System.IO.StreamReader(dir + paths[one_file]);
            while ((curline = file.ReadLine()) != null)
            {
                line.Add(curline);
            }

            length = line.Count;
            //Debug.Log("start" + "_" + line.Count);

            float[] vectors = new float[length];
            Vector3 playerpos = new Vector3();
            //Debug.Log(length);

            ///*
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
                //Debug.Log("middleloop:" + i);

            }

            length_vector = length / 3;

            sphere_onefile = new GameObject[paths.Count][];
            GameObject[] sphere = new GameObject[length_vector];
            sphere_onefile[one_file] = sphere;

            for (int j = 0; j < length_vector; j++)

            {
                sphere_onefile[one_file][j] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere_onefile[one_file][j].transform.SetParent(parents[one_file].transform);
                sphere_onefile[one_file][j].tag = "Sphere";
                sphere_onefile[one_file][j].transform.position = pos_list[j];
                sphere_onefile[one_file][j].transform.localScale = new Vector3(2, 2, 2);
                //Debug.Log("sphere:" + j);

            }
            //Debug.Log("_"+"length_vector:" + length_vector);

            //*/


           line.Clear();
            pos_list.Clear();
         //   length = 0;
         //   length_vector = 0;
            //sphere_onefile[one_file] = null;
            //Debug.Log("end" + "_" + );

        }
       

    }
}
