using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class CubeBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.AddListener(EventTriggerType.PointerDown, Hold);
		gameObject.AddListener(EventTriggerType.PointerUp, Release);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Hold() {
		Transform pointerTransform = GvrPointerInputModule.Pointer.PointerTransform;

		transform.SetParent(pointerTransform, true);
	}

	public void Release() {
		transform.SetParent(null, true);
	}
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