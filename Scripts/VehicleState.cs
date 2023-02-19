using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VehicleState : MonoBehaviour
{

    public bool hasTire=false;
    public GameObject Tire;

    public bool hasEngine=false;
    public GameObject Seats;

    public bool hasCarrier=false;
    public GameObject Carrier;

    public bool hasWindshield=false;
    public GameObject Windshield;


    private void Start()
    {
        hasTire = false;
        hasEngine = false;
        hasCarrier = false;
        hasWindshield = false;
    }

    private void Update()
    {
        if(hasTire)
           Tire.SetActive(true);
        else
            Tire.SetActive(false);

        if(hasEngine)
           Seats.SetActive(true);
        else
            Seats.SetActive(false);

        if (hasCarrier)
            Carrier.SetActive(true);
        else
            Carrier.SetActive(false);

        if (hasWindshield)
            Windshield.SetActive(true);
        else
            Windshield.SetActive(false);
    }

    public void restorePart(int index)
    {
        if(index==0)
            hasTire= true;
        else if (index == 1)
            hasEngine = true;
        else if (index == 2)
            hasCarrier = true;
        else if (index == 3)
            hasWindshield = true;
    }

}
