using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
[RequireComponent(typeof(BoxCollider))]
public class PlantType : MonoBehaviour
{
    public float water;
    float time;
    public bool ready;
    public string waterNotReady;
    public string timeNotReady;

    public GameObject seed;
    public GameObject sprout;
    public GameObject plant;
    public PlayerStats player;

    private PlantSeed parent;

    private bool sproutPlanted, plantPlanted;
    private GameObject child;
    private void Start() {


        // Gets the parent's plantSeed
        parent = gameObject.transform.parent.gameObject.GetComponent<PlantSeed>();
        child = Instantiate(seed, gameObject.transform.position, Quaternion.identity, gameObject.transform);
        // Starts at not ready to pick
        ready = false;

        // Adds pointer controlls
        gameObject.AddListener(EventTriggerType.PointerDown, Hold);
		gameObject.AddListener(EventTriggerType.PointerUp, Release);

        // These decrease the water level and increase time as time goes on
        StartCoroutine(passTime());
        StartCoroutine(waterDry());

    }

    // Updates just checks when things are ready and changes stages
    private void Update() {
        if(water >= 1 && time >= 1){
            ready = true;
            if(!plantPlanted){
                Destroy(child);
                child = Instantiate(plant, gameObject.transform.position, Quaternion.identity, gameObject.transform);
                plantPlanted = true;
            }
        }
        else if(water >= 0.5 && time >= 0.5){
            ready = false;
            if(!sproutPlanted){
                Destroy(child);
                child = Instantiate(sprout, gameObject.transform.position, Quaternion.identity, gameObject.transform);
                sproutPlanted = true;
            }
        }
        else{
            ready = false;
        }
    }
    // For when the player waters the plant
    public void Water(){
        
        if(player.currTool.name == "Water"){
            if(water > 1f){
                water = 1.2f;
            }
            else{
                water += 0.2f;
            }
        }
    }

    public void Hold() {
        if(player.currTool.name != "Water"){
            if(ready){
                Transform pointerTransform = GvrPointerInputModule.Pointer.PointerTransform;

                transform.SetParent(pointerTransform, true);
            }
            else{
                Debug.Log(notReady());
            }
        }
	}

	public void Release() {
        if(player.currTool.name != "Water" && ready){
		    transform.SetParent(null, true);
            parent.planted = false;
            player.plantCount++;
            parent.child = null;
            Destroy(this);
            
        }
	}

    // Idle for time and water
    IEnumerator passTime(){
        yield return new WaitForSeconds(2);
        time += 0.001f;
        yield return StartCoroutine(passTime());
    }
    IEnumerator waterDry(){
        yield return new WaitForSeconds(5);
        if(water > 0.05){
            water = 0f;
        }
        else{
            water -= 0.05f;
        }
        yield return null;
        StartCoroutine(waterDry());
    }

    // Will be used with the UI to tell the user what is needed
    public string notReady(){
        if(water != 1 && time != 1){
            return waterNotReady + ". " + timeNotReady;
        }
        else if(water != 1){
            return waterNotReady;
        }
        else{
            return timeNotReady;
        }
    }
}
