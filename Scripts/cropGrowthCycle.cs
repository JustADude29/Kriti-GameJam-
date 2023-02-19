using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cropGrowthCycle : MonoBehaviour
{
    public float growInBetweenTime;
    [SerializeField] Material cropMat;
    public bool _harvestable;

    public float currentGrowth = 0;
    private void Awake()
    {
        GetComponent<Renderer>().material = new Material(cropMat);
    }

    void Start()
    {
        GetComponent<Renderer>().material.SetFloat("_Growth", 0);
        _harvestable = false;
        InvokeRepeating("GrowCrop", growInBetweenTime, growInBetweenTime);
        
    }

    public void GrowCrop()
    {
        

        if (currentGrowth < 1)
        {
            currentGrowth += 0.25f;
            GetComponent<Renderer>().material.SetFloat("_Growth", currentGrowth);
        }
        if(currentGrowth >= 1)
            _harvestable= true;
    }
}
