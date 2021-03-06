﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlantType))]
[RequireComponent(typeof(EventTrigger))]
public class Pick : MonoBehaviour
{
    PlantType type;
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

public static class EventExtensions1 {

	public static void AddListener(this GameObject gameObject, EventTriggerType eventTriggerType, UnityAction action) {
		EventTrigger eventTrigger = gameObject.GetComponent<EventTrigger>();

		EventTrigger.Entry entry = new EventTrigger.Entry();
		entry.eventID = eventTriggerType;
		entry.callback.AddListener(_ => action());

		eventTrigger.triggers.Add(entry);
	}

}
