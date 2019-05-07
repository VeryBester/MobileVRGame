using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
[RequireComponent(typeof(BoxCollider))]
public class Well : MonoBehaviour
{

    public PlayerStats player;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddListener(EventTriggerType.PointerClick, getWater);    
    }

    public void getWater(){
        if(player.water > 0.8f){
            player.water = 1f;
        }
        else{
            player.water += 0.2f;
        }
    }
}
