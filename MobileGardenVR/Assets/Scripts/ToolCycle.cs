using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolCycle : MonoBehaviour
{
    private void Update() {
        if(GvrControllerInput.IsTouching){
            //TODO: Find way to handle and detect swipes
            /*
            Swipe direction plan:
            right --> next tool
            left --> previous tool
            up --> next type if given (e.g differnt type of seed)
            down --> previous type if given (e.g differnt type of seed)
             */
        }
        
    }
}
