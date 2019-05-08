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
    public PlantType child;

    public PlayerStats player;

    void Start() {
        gameObject.AddListener(EventTriggerType.PointerClick, plantSeed);
        child = null;
        planted = false;
        //StartCoroutine(seed1()); 
    }

    // Command for click
    // Plants seed if none planted, and waters if tool is on water
    public void plantSeed(){
        //Debug.Log("Planted");
        if(!planted){
            GameObject center = gameObject.transform.Find("Plant").gameObject;
            GameObject temp = Instantiate(seed, center.transform.position, Quaternion.identity, center.transform);
            child = temp.GetComponent<PlantType>();
            planted = true;
        }
        else{
            Water();
        }
    }
    
    public void Water(){
        
        if(player.currTool.name == "Water" && player.water >= 0.2f){
            if(child.water > 1f){
                child.water = 1.2f;
            }
            else{
                child.water += 0.2f;
            }
            if(player.water < 0.2f){
                player.water = 0f;
            }
            else{
                player.water -= 0.2f;
            }
        }
    }

    IEnumerator seed1(){
        plantSeed();
        yield return new WaitForSeconds(2);
        plantSeed();
        Debug.Log("PLanted");
    }
}
