using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolCycle : MonoBehaviour
{
    Vector2 startPos;
    private void Update() {
        if(GvrControllerInput.TouchDown){
            startPos = GvrControllerInput.TouchPosCentered;
        }

        if(GvrControllerInput.TouchUp){
            Vector2 diff = GvrControllerInput.TouchPosCentered - startPos;

            if(diff.x > 0){
                //Right
            }

            if(diff.x < 0){
                //Left
            }
        }
        
    }
}

