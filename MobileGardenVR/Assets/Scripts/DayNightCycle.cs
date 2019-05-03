using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    // Holds the different skyboxes
    public Material[] skyboxes = new Material[5];
    
    void Start()
    {
        // Starts teh Day-Night Cycle
        // TODO: make sure doesnt cause a stack overflow in long term
        StartCoroutine(startDay());
    }

    IEnumerator startDay(){
        RenderSettings.skybox = skyboxes[0];
        yield return new WaitForSeconds(20); //240
        yield return StartCoroutine(startDayBreak());

    }
    IEnumerator startDayBreak(){
        RenderSettings.skybox = skyboxes[1];
        yield return new WaitForSeconds(5); //60
        yield return StartCoroutine(startNight());
    }
    IEnumerator startNight(){
        RenderSettings.skybox = skyboxes[2];
        yield return new WaitForSeconds(20); //240
        yield return StartCoroutine(startSunRise1());
    }

    IEnumerator startSunRise1(){
        RenderSettings.skybox = skyboxes[3];
        yield return new WaitForSeconds(5); //60
        yield return StartCoroutine(startSunRise2());
    }

    IEnumerator startSunRise2(){
        RenderSettings.skybox = skyboxes[4];
        yield return new WaitForSeconds(5); //60
        yield return StartCoroutine(startDay());
    }
}
