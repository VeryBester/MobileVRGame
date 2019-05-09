using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class ToolCycle : MonoBehaviour
{
    
    Vector2 startPos;
    public Tools[] tools;
    public GameObject hand;
    public PlayerStats player;
    int currIndex;
    //Renderer rend;
    private void Start() {
        //rend = GetComponent<Renderer>();
        player.currTool = tools[1];
        currIndex = 0;
    }

    private void Update() {
        if(GvrControllerInput.TouchDown){
            StartCoroutine(Slide());
        }        
    }

    IEnumerator Slide(){
        if(GvrControllerInput.TouchDown){
            yield return new WaitForSeconds(0.25f);
            startPos = GvrControllerInput.TouchPosCentered.normalized;
            
            if(startPos.x > 0.4f){

                if(currIndex + 1 < tools.Length){
                    currIndex++;
                    player.currTool = tools[currIndex];
                }
                else{
                    currIndex = 0;
                    player.currTool = tools[0];
                }

                //rend.material.color = Color.blue;
            }

            else if(startPos.x < -0.4f){

                if(currIndex - 1 >= 0){
                    currIndex--;
                    player.currTool = tools[currIndex];
                }
                else{
                    currIndex = tools.Length;
                    player.currTool = tools[tools.Length - 1];
                }

                //rend.material.color = Color.green;
            }

            StartCoroutine(Slide());
        }

        GameObject[] heldItems = GameObject.FindGameObjectsWithTag("heldItem");
        foreach (GameObject heldItem in heldItems)
        {
            Destroy(heldItem);
        }

        GameObject handItem = player.currTool.model;
        handItem.tag = "heldItem";
        handItem.transform.parent = hand.transform;

    }
}

