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
            yield return new WaitForSeconds(1);
            startPos = GvrControllerInput.TouchPosCentered.normalized;
            
            if(startPos.x > 0.4){
                rend.material.color = Color.blue;
            }

            else if(startPos.x < -0.4){
                rend.material.color = Color.green;
            }

            StartCoroutine(Slide());
        }
    }
}

