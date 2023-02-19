using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farming : FarmOptions
{

    [SerializeField] float FarmableRange;
    [SerializeField] LayerMask FarmableLayer;

    Color color;

    [HideInInspector]
    public Transform FarmTile;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, FarmableLayer))
            {
                FarmTile=hit.transform;
                if (isFarmable(hit.transform.position))
                {
                    
                    startFarming();
                    GetComponent<PlayerMovement>().enabled=false;
                }
            }
        }

    }

    bool isFarmable(Vector3 tilePos)
    {
        Vector3 playerPos = transform.position;
        playerPos.y = 0;
        if ((tilePos - playerPos).magnitude<=FarmableRange)
        {
            return true;
        }
       
        return false;
    }


}
