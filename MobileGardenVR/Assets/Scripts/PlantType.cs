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
    float water;
    float time;
    public bool ready;
    public string waterNotReady;
    public string timeNotReady;
    public float cost;
    private PlantType type;

    public PlayerStats player;

    private void Start() {

        type = gameObject.GetComponent<PlantType>();
        gameObject.AddListener(EventTriggerType.PointerClick, makeChange);
        ready = false;
        StartCoroutine(passTime());
        StartCoroutine(waterDry());
    }

    private void Update() {
        if(water >= 1 && time >= 1){
            ready = true;
        }
        else{
            ready = false;
        }
    }
    public void makeChange(){
        
        if(player.currTool.name == "Water"){
            if(water > 1f){
                water = 1.2f;
            }
            else{
                water += 0.2f;
            }
        }
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
