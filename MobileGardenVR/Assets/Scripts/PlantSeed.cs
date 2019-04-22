using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlantSeed : MonoBehaviour
{
    public GameObject seed;
    void Start() {
        Debug.Log("Working");
        StartCoroutine(seed1());
        //gameObject.AddListener(EventTriggerType.PointerClick, plantSeed);    
    }

    public void plantSeed(){
        GameObject center = gameObject.transform.Find("center").gameObject;
        GameObject temp = Instantiate(seed, center.transform);
    }
    
    IEnumerator seed1(){
        yield return new WaitForSeconds(10);
        plantSeed();
        Debug.Log("PLanted");
    }
}
