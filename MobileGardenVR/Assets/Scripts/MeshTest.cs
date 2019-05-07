using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshTest : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject test;
    MeshFilter mf;
    void Start()
    {
        mf = test.GetComponent<MeshFilter>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator test1(){
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<MeshFilter>().mesh = mf.mesh;
    }
}
