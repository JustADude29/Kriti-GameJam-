
using System.Collections.Generic;
[System.Serializable]
public class GameState 
{
    public float energy;
    public float[] PlayerPos;
    public int[] SeedCount;
    public int SCcount;
    public int money;

    public float time;

    public string[] Crops;

    public string[] Harvests;

    public bool[] isSC;
    public float[] CropTimer;

    public float[] CropHealth;

    public bool[] vehicleState;

    public bool[] grown;

    public float[,] tilePos;
    public GameState(PlayerStats stats, List<TileInfo> tiles, VehicleState vstate){
        energy=stats.GetEnergy();
        PlayerPos=new float[3];
        PlayerPos[0]=stats.position.x;
        PlayerPos[1]=stats.position.y;
        PlayerPos[2]=stats.position.z;
        SeedCount=new int[3];
        SeedCount[0]=stats.SeedCount[0];
        SeedCount[1]=stats.SeedCount[1];
        SeedCount[2]=stats.SeedCount[2];
        SCcount=stats.SCcount;
        money=stats.money;
        Crops=new string[tiles.Count];
        Harvests=new string[tiles.Count];
        CropTimer=new float[tiles.Count];
        CropHealth=new float[tiles.Count];
        isSC = new bool[tiles.Count];
        tilePos = new float[tiles.Count,3];
        grown = new bool[tiles.Count];
        for(int i=0;i<tiles.Count;i++){
            Crops[i]=tiles[i].cropType;
            Harvests[i]=tiles[i].harvestType;
            CropTimer[i]=tiles[i].timer;
            CropHealth[i]=tiles[i].health;
            tilePos[i,0]=tiles[i].Pos.x;
            tilePos[i,1]=tiles[i].Pos.y;
            tilePos[i,2]=tiles[i].Pos.z;
            isSC[i]=tiles[i].isSC;
            grown[i]=tiles[i].grown;
        }
        vehicleState=new bool[4];
        vehicleState[0]=vstate.hasTire;
        vehicleState[1]=vstate.hasEngine;
        vehicleState[2]=vstate.hasCarrier;
        vehicleState[3]=vstate.hasWindshield;

    }

}
