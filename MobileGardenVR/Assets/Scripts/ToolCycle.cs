using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolCycle : MonoBehaviour
{
    Vector2 startPos;

    Renderer rend;
    private void Start() {
        rend = GetComponent<Renderer>();
    }

    private void Update() {
        if(GvrControllerInput.TouchDown){
            startPos = GvrControllerInput.TouchPosCentered;
        }

        if(GvrControllerInput.TouchUp){
            Vector2 diff = GvrControllerInput.TouchPosCentered - startPos;

            if(diff.x > 0){
                rend.material.color = Color.blue;
            }

            if(diff.x < 0){
                rend.material.color = Color.green;
            }
        }
        
    }
}

