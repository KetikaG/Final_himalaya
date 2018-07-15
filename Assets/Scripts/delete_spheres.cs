using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class delete_spheres : MonoBehaviour
{
    // public GameObject[] parents;
    int x = 3; 


    void Start()
    {
        /*
        foreach (var obj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {
            if (obj.name == "Sphere")
                GameObject.DestroyImmediate(obj);
        }
        */
        Test();

    }

    void Test()
    {
        GameObject[] sphere = new GameObject[3];
        GameObject[] parents = new GameObject[3];
        for (int i = 0; i < x; i++)
        {
            Debug.Log("outer:" + i);
            parents[i] = new GameObject("emptyparent" + i);
            parents[i].transform.parent = this.gameObject.transform;



            for (int j = 0; j < 9; j += 3)
            {
                Debug.Log("inner_three:" + "_" + j);
            }

            for (int k = 0; k < 3; k++)
            {
                Debug.Log("innermost:" + "_" + k);
                sphere[k] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere[k].transform.SetParent(parents[i].transform);
                sphere[k].tag = "Sphere";
            }

        }
    }
}

