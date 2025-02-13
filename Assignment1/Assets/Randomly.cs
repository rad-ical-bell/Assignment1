// UMD IMDM290 
// Sofija Radovanovic
// Instructor: Myungin Lee

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomly : MonoBehaviour
{
    GameObject[] cubes;
    static int numcube = 100; 
    float time = 0f;
    Vector3[] initPos;
    public float pulseSpeed = 2f;
    public float pulseAmount = 0.2f;
    void Start()
    {
        cubes = new GameObject[numcube];
        initPos = new Vector3[numcube];

        for (int i =0; i < numcube; i++){
            float r = 1.5f; // Modified size of the cube
            //Create cubes
            cubes[i] = GameObject.CreatePrimitive(PrimitiveType.Cube); 
            // Modified random positioning
            initPos[i] = new Vector3(r * Random.Range(-30f, 30f), r * Random.Range(-30f, 20f), 30f);
            cubes[i].transform.position = initPos[i];
            Renderer cubeRenderer = cubes[i].GetComponent<Renderer>();
            // hsv color space: https://en.wikipedia.org/wiki/HSL_and_HSV
            float hue = (float)Random.Range(0.75f, 1f); // Modified hue cycles through 0.75 to 1
            Color color = Color.HSVToRGB(hue, 0.8f, 1f); // Modified with lower saturation
            cubeRenderer.material.color = color;
        }
    }

    void Update()
    {
        foreach (GameObject cube in cubes)
        {
            //Checking that the cube exists
            if (cube != null)
            {
                //The sine value oscillates between -1 and 1.
                //Using Time.time instead of Time.deltaTime; Time.time makes code work as intended instead of causing the cubes to rapidly shake.
                float scale = 1 + Mathf.Sin(Time.time * pulseSpeed) * pulseAmount; 
                cube.transform.localScale = new Vector3(scale, scale, scale);
            }
        }
    }
}