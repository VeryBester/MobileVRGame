using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class CubeBehavior : MonoBehaviour {

/* 	Renderer rend;
	Color oldColor;
	Color tempColor;

	// Use this for initialization
	void Start () {
		gameObject.AddListener(EventTriggerType.PointerDown, Hold);
		gameObject.AddListener(EventTriggerType.PointerUp, Release);
		
		// Will use to change the shader of objects
		gameObject.AddListener(EventTriggerType.PointerUp, Enter);
		gameObject.AddListener(EventTriggerType.PointerUp, Exit);

		rend = GetComponent<Renderer>();
		oldColor = rend.material.color;
		tempColor = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Enter(){
		rend.material.color = tempColor;
	}

	public void Exit(){
		rend.material.color = oldColor;
	}

	public void Hold() {
		Transform pointerTransform = GvrPointerInputModule.Pointer.PointerTransform;

		transform.SetParent(pointerTransform, true);
	}

	public void Release() {
		transform.SetParent(null, true);
	}
	*/
}

public static class EventExtensions {

	public static void AddListener(this GameObject gameObject, EventTriggerType eventTriggerType, UnityAction action) {
		EventTrigger eventTrigger = gameObject.GetComponent<EventTrigger>();

		EventTrigger.Entry entry = new EventTrigger.Entry();
		entry.eventID = eventTriggerType;
		entry.callback.AddListener(_ => action());

		eventTrigger.triggers.Add(entry);
	}

}