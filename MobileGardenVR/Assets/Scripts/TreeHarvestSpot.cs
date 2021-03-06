﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class TreeHarvestSpot : MonoBehaviour
{
    // Start is called before the first frame update
    public float water;
    float time;
    public GameObject blossom;
    public GameObject apple;
    public PlayerStats player;
    public bool ready;
    GameObject child;
    bool applePlanted, blossomPlanted;
    AudioSource aS;
    void Start()
    {
        aS = gameObject.GetComponent<AudioSource>();
        gameObject.AddListener(EventTriggerType.PointerClick, pick);
		//gameObject.AddListener(EventTriggerType.PointerUp, Release);
        StartCoroutine(passTime());
        StartCoroutine(waterDry());
    }

    private void Update() {
        if(!ready){
            if(water >= 1 && time >= 1){
                ready = true;
                if(!applePlanted){
                    Destroy(child);
                    child = Instantiate(apple, gameObject.transform.position, Quaternion.identity, gameObject.transform);
                    applePlanted = true;
                }
            }
            else if(water >= 0.5 && time >= 0.5){
                ready = false;
                if(!blossomPlanted){
                    Destroy(child);
                    child = Instantiate(blossom, gameObject.transform.position, Quaternion.identity, gameObject.transform);
                    blossomPlanted = true;
                }
            }
            else{
                ready = false;
            }
        }
    }

    public void pick(){
        if(ready){
            time = 0f;
            water = 0f;
            ready = false;
            player.appleCount++;
            aS.Play();
            Destroy(child);
        }
    }
    public void Hold() {
        if(player.currTool.name != "Water"){
            if(ready){
                Transform pointerTransform = GvrPointerInputModule.Pointer.PointerTransform;

                transform.SetParent(pointerTransform, true);
            }
            else{
                //Debug.Log(notReady());
            }
        }
	}

	public void Release() {
        if(player.currTool.name != "Water" && ready){
		    transform.SetParent(null, true);
            player.appleCount++;
            applePlanted = false;
            blossomPlanted = false;
            water = 0;
            time = 0;
            Destroy(child);
            child = null;
            
        }
	}

    // Idle for time and water
    IEnumerator passTime(){
        yield return new WaitForSeconds(2);
        time += 0.02f;
        yield return StartCoroutine(passTime());
    }
    IEnumerator waterDry(){
        yield return new WaitForSeconds(20);
        if(water > 0.05){
            water -= 0.05f;
        }
        else{
            water = 0f;
        }
        yield return StartCoroutine(waterDry());
    }
}
