using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class PlantSeed : MonoBehaviour
{
    public bool planted;
    public GameObject seed;

    void Start() {
        gameObject.AddListener(EventTriggerType.PointerClick, plantSeed);
        planted = false; 
    }

    public void plantSeed(){
        Debug.Log("Planted");
        if(!planted){
            GameObject center = gameObject.transform.Find("Plant").gameObject;
            GameObject temp = Instantiate(seed, center.transform.position, Quaternion.identity, center.transform);
        }
    }
    
    IEnumerator seed1(){
        yield return new WaitForSeconds(2);
        plantSeed();
        Debug.Log("PLanted");
    }
}
