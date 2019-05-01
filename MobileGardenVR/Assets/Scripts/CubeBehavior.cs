using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class CubeBehavior : MonoBehaviour {

 	Renderer rend;
	Color oldColor;
	Color tempColor;

	// Use this for initialization
	void Start () {
		gameObject.AddListener(EventTriggerType.PointerDown, Hold);
		gameObject.AddListener(EventTriggerType.PointerUp, Release);
		
		// Will use to change the shader of objects
		gameObject.AddListener(EventTriggerType.PointerEnter, Enter);
		gameObject.AddListener(EventTriggerType.PointerExit, Exit);

		rend = GetComponent<Renderer>();
		oldColor = rend.material.color;
		tempColor = Color.red;
	}
	
	
	public void Enter(){
		oldColor = rend.material.color;
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
	
}
