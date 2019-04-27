using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant
{
    public string type;
    public GameObject[] stages;
    public int growthTime;
    public GameObject dropFruit;

    public Plant(string type, GameObject[] stages, int growthTime, GameObject dropFruit)
    {
        this.type = type;
        this.stages = stages;
        this.growthTime = growthTime;
        this.dropFruit = dropFruit;

    }
}

public class PlantManager : MonoBehaviour
{

    public string type; // Type ID of plant
    public int stage; 
    public Plant plant;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
