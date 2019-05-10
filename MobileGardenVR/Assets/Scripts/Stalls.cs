using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(EventTrigger))]
public class Stalls : MonoBehaviour
{
    public PlayerStats pStats;

    void Start() {
        gameObject.AddListener(EventTriggerType.PointerClick, sellInventory); 
    }

    public void sellInventory(){
        int apple = pStats.appleCount;
        int plant = pStats.plantCount;
        pStats.score = pStats.score + apple * 10 + plant * 20;
        pStats.appleCount = 0;
        pStats.plantCount = 0;
    }
    
}
