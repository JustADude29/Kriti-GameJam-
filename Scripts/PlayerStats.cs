using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats: MonoBehaviour
{
    public float Energy=100f;
    public Vector3 position=new Vector3();

    public int[] SeedCount={2,2,2};

    public int SCcount=1;

    public int money;

    public float baseEnergyGain;

    public int currProgression = 0;

    private void Start() {
        
    }
    private void Update() {
        position=transform.position;
    }
    public void EnergyConsume(float consume){

        Energy-=consume;
    }
    public float GetEnergy(){
        return Energy;
    }

    public void ConsumeFood(int index)
    {
        if (SeedCount[index] > 0)
        {
            Energy += (index + 1) * baseEnergyGain;
            Energy = Mathf.Clamp(Energy, 0, 100);
            SeedCount[index]--;
        }
    }

    public void progress()
    {
        currProgression++;
    }
   
}
