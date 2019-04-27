﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class PlantSeed : MonoBehaviour
{
    public GameObject seed;
    void Start() {
        gameObject.AddListener(EventTriggerType.PointerClick, plantSeed); 
    }

    public void plantSeed(){
        Debug.Log("Planted");
        GameObject center = gameObject.transform.Find("Plant").gameObject;
        GameObject temp = Instantiate(seed, center.transform.position, Quaternion.identity, center.transform);
    }
    
    IEnumerator seed1(){
        yield return new WaitForSeconds(2);
        plantSeed();
        Debug.Log("PLanted");
    }
    
}