// UMD IMDM290 
// Sofija Radovanovic
// Instructor: Myungin Lee
    // [a <-----------> b]
    // Lerp : Linearly interpolates between two points. 
    // https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Vector3.Lerp.html


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp : MonoBehaviour
{
    GameObject[] heartObjects;
    static int numSphere = 500; 
    float time = 0f;
    Vector3[] initPos;
    Vector3[] startPosition, endPosition;
    float lerpFraction; // Lerp point between 0~1
    float t;


    void Start()
    {

        heartObjects = new GameObject[numSphere];
        initPos = new Vector3[numSphere]; // Start positions
        startPosition = new Vector3[numSphere]; 
        endPosition = new Vector3[numSphere]; 
        
        // Define target positions. Start = random, End = heart 
        for (int i =0; i < numSphere; i++){
            // Random start positions
            float r = 15f;
            startPosition[i] = new Vector3(r * Random.Range(-1f, 1f), r * Random.Range(-1f, 1f), r * Random.Range(-1f, 1f));        
            // Heart shape end position
            t = i* 2 * Mathf.PI / numSphere;
            endPosition[i] = new Vector3( 
                        5f*Mathf.Sqrt(2f) * Mathf.Sin(t) *  Mathf.Sin(t) *  Mathf.Sin(t),
                        5f* (- Mathf.Cos(t) * Mathf.Cos(t) * Mathf.Cos(t) - Mathf.Cos(t) * Mathf.Cos(t) + 2 *Mathf.Cos(t)) + 3f,
                        10f + Mathf.Sin(time));
        }

        for (int i =0; i < numSphere; i++){
            float r = 1.5f; // Modified radius of the heartObjects
            
            //Check if even to alternate between sphere and cube objects
            if(i % 2 == 0) {
                heartObjects[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere); 
            } else {
                heartObjects[i] = GameObject.CreatePrimitive(PrimitiveType.Cube); 
            }


            // Position
            initPos[i] = startPosition[i];
            heartObjects[i].transform.position = initPos[i];
            //Created random rotation for each heartObjects (only works for cubes)
            float random = (float)Random.Range(0,360);
            heartObjects[i].transform.rotation = Quaternion.Euler(0, 0, random);

            // Color
            Renderer sphereRenderer = heartObjects[i].GetComponent<Renderer>();
            float hue = (float)i / numSphere; 
            Color color = Color.HSVToRGB(hue, 1f, 1f); 
            sphereRenderer.material.color = color;
        }
    }

    void Update()
    {
        // Measure Time 
        time += Time.deltaTime; 
        for (int i =0; i < numSphere; i++){
            
            lerpFraction = Mathf.Sin(time) * .60f + 0.9f; //Modified the oscillation

           
            t = i* 2 * Mathf.PI / numSphere;
            heartObjects[i].transform.position = Vector3.Lerp(startPosition[i], endPosition[i], lerpFraction);

            // Color Update over time
            Renderer sphereRenderer = heartObjects[i].GetComponent<Renderer>();
            float hue = (float)i / numSphere; 
            Color color = Color.HSVToRGB(Mathf.Abs(hue * Mathf.Sin(time)), 0.75f, 2f + Mathf.Cos(time)); 
            sphereRenderer.material.color = color;
        }
    }
}