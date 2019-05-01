using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlantType))]
[RequireComponent(typeof(EventTrigger))]
public class Pick : MonoBehaviour
{
    PlantType type;
    bool ready = true;
    // Start is called before the first frame update
    void Start()
    {
        type = gameObject.GetComponent<PlantType>();
        gameObject.AddListener(EventTriggerType.PointerDown, Hold);
		gameObject.AddListener(EventTriggerType.PointerUp, Release);   
    }

    public void Hold() {
        if(type.ready){
            Transform pointerTransform = GvrPointerInputModule.Pointer.PointerTransform;

            transform.SetParent(pointerTransform, true);
        }
        else{
            displayMessage();
        }
	}

	public void Release() {
		transform.SetParent(null, true);
	}

    public void displayMessage(){
        Debug.Log(type.notReady());
    }
}
