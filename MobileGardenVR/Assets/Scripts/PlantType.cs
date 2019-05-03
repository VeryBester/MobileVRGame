using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
[RequireComponent(typeof(BoxCollider))]
public class PlantType : MonoBehaviour
{
    public string name;
    public float water;
    public float time;
    public bool ready;
    public string waterNotReady;
    public string timeNotReady;
    public float cost;
    private PlantType type;
    private void Start() {
        type = gameObject.GetComponent<PlantType>();
        gameObject.AddListener(EventTriggerType.PointerClick, makeChange);
        StartCoroutine(passTime());
        StartCoroutine(waterDry());
    }

    public void makeChange(){
        // Get current tool
        // Change water based on it
    }

    // Idle for time and water
    IEnumerator passTime(){
        yield return new WaitForSeconds(2);
        time += 0.001f;
        StartCoroutine(passTime());
    }
    IEnumerator waterDry(){
        yield return new WaitForSeconds(5);
        if(water > 0.05){
            water = 0f;
        }
        else{
            water -= 0.05f;
        }
        StartCoroutine(waterDry());
    }

    // Will be used with the UI to tell the user what is needed
    public string notReady(){
        if(water != 1 && time != 1){
            return waterNotReady + timeNotReady;
        }
        else if(water != 1){
            return waterNotReady;
        }
        else{
            return timeNotReady;
        }
    }
}
