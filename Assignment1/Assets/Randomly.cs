// UMD IMDM290 
// Instructor: Myungin Lee

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomly : MonoBehaviour
{
    GameObject[] spheres;
    static int numSphere = 100; 
    float time = 0f;
    Vector3[] initPos;
    void Start()
    {
        spheres = new GameObject[numSphere];
        initPos = new Vector3[numSphere];
        
        //foreach (GameObject sphere in spheres){
            // sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            // This will cause an error. Why?
            // foreach is a read only iterator that iterates dynamically classes that implement IEnumerable, each cycle in foreach will call the IEnumerable to get the next item, the item you have is a read only reference,
        //}

        for (int i =0; i < numSphere; i++){
            float r = 1.5f; // Modified size of the cube
            //Create cubes
            spheres[i] = GameObject.CreatePrimitive(PrimitiveType.Cube); 
            // Modified random positioning
            initPos[i] = new Vector3(r * Random.Range(-30f, 30f), r * Random.Range(-30f, 30f), 30f);
            spheres[i].transform.position = initPos[i];
            Renderer sphereRenderer = spheres[i].GetComponent<Renderer>();
            // hsv color space: https://en.wikipedia.org/wiki/HSL_and_HSV
            float hue = (float)Random.Range(0.75f, 1f); // Modified hue cycles through 0.75 to 1
            Color color = Color.HSVToRGB(hue, 0.8f, 1f); // Modified with lower saturation
            sphereRenderer.material.color = color;
        }
    }
}