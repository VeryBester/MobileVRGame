using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class Trees : MonoBehaviour
{
    // Start is called before the first frame update
    public TreeHarvestSpot[] children;
    //public TreeHarvestSpot child2;

    public PlayerStats player;
    void Start()
    {
        gameObject.AddListener(EventTriggerType.PointerClick, Water);
    }

    public void Water(){
        if(player.currTool.name == "Water" && player.water >= 0.2f){
            foreach (TreeHarvestSpot child in children){
                if(child.water > 1f){
                    child.water = 1.2f;
                }
                else{
                    child.water += 0.2f;
                }    
            }
            
            player.water -= 0.2f;
        }
    }
}
