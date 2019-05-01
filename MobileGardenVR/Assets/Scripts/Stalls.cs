using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class Stalls : MonoBehaviour
{
    void Start() {
        gameObject.AddListener(EventTriggerType.PointerClick, sellInventory); 
    }

    public void sellInventory(){
        //Sells the inventory
    }
    
}
