using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantType : MonoBehaviour
{
    public string name;
    public float water;
    public float time;
    public bool ready;
    public string waterNotReady;
    public string timeNotReady;
    public float cost;

    public string notReady(){
        if(water != 1 && time != 1){
            return waterNotReady + timeNotReady;
        }
        else if(water != 1){
            return waterNotReady;
        }
        else{
            return timeNotReady;
        }
    }
}
