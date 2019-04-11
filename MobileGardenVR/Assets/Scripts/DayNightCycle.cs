using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Material[] skyboxes = new Material[10];
    
    int index;
    void Start()
    {
        index = 0;
        RenderSettings.skybox = skyboxes[index];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            index++;
            if(index > skyboxes.Length - 1){
                index = 0;
            }
            RenderSettings.skybox = skyboxes[index];
            Debug.Log("working" + index);
        }
    }
}
