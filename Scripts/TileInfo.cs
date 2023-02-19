using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInfo : MonoBehaviour
{

    public Vector3 Pos=new Vector3();
    public string cropType;

    public GameObject cropPrefab;
    public string harvestType;

    public float timer;

    public float health=100f;

    public bool isSC=false;

    public bool grown =false;
    

    public int reward;
    public Dictionary<string, float> dic = new Dictionary<string, float>();
    private void Start()
    {
        dic.Add("Wheat", 15f);
        dic.Add("Rice", 25f);
        dic.Add("Corn", 40f);
        Pos=transform.position;
    }

    private void Update()
    {
        
        if (cropType.Length > 0)
        {
            startTimer(dic[cropType]);
        }
        if(health<=0){
            reward=0;
            cropType="";
            Destroy(cropPrefab);
        }
    }
    void startTimer(float cropTime)
    {
        timer += Time.deltaTime;
        if (timer >= cropTime)
        {
            grown=true;
            reward = UnityEngine.Random.Range(2, 5);
            timer = 0;
            cropType = "";
        }
    }

    public void giveDamage(float damage){
        health-=damage;
    }

}
