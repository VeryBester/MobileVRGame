using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ToolCycle : MonoBehaviour
{
    Vector2 startPos;

    Renderer rend;
    private void Start() {
        rend = GetComponent<Renderer>();
    }

    private void Update() {
        if(GvrControllerInput.TouchDown){
            StartCoroutine(Slide());
        }        
    }

    IEnumerator Slide(){
        if(GvrControllerInput.TouchDown){
            yield return new WaitForSeconds(0.5f);
            startPos = GvrControllerInput.TouchPosCentered.normalized;
            
            if(startPos.x > 0.4f){
                rend.material.color = Color.blue;
            }

            else if(startPos.x < -0.4f){
                rend.material.color = Color.green;
            }

            StartCoroutine(Slide());
        }
    }
}

