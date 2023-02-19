using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject InstructionMenu;
    [SerializeField] GameObject GameAim;
    [SerializeField] GameObject EndGame;

    [SerializeField] GameObject Player;
    [SerializeField] List<TileInfo> Tiles=new List<TileInfo>();
    [SerializeField] GameObject tilesParent;
    [SerializeField] VehicleState vstate;

    [SerializeField] GameObject[] CropPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
        InstructionMenu.SetActive(false);
        MainMenu.SetActive(true);
        Player=GameObject.FindGameObjectWithTag("Player");
        Player.GetComponent<PlayerMovement>().enabled=false;
        // GameObject[] temp=tilesParent.transform.GetChild;
        // for(int i=0;i<temp.Length;i++){
        //     Tiles.Add(temp[i].GetComponent<TileInfo>());
        // }
        for(int i=1;i<tilesParent.transform.childCount;i++){
            Tiles.Add(tilesParent.transform.GetChild(i).gameObject.GetComponent<TileInfo>());
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(MainMenu.activeSelf){
            Time.timeScale=0;
        }
        if(Input.GetKeyDown(KeyCode.Escape)&&!MainMenu.activeSelf){
            Time.timeScale=0;
            Player.GetComponent<PlayerMovement>().enabled=false;
            PauseMenu.SetActive(true);
        }
        if(vstate.hasCarrier&&vstate.hasEngine&&vstate.hasTire&&vstate.hasWindshield)
        {
            Time.timeScale = 0;
            Player.GetComponent<PlayerMovement>().enabled = false;
            EndGame.SetActive(true);
        }
    }

    public void SaveGame(){
        SaveSystem.SaveState(Player.GetComponent<PlayerStats>(),Tiles, vstate);
        PauseMenu.SetActive(false);
        Player.GetComponent<PlayerMovement>().enabled=true;
        Time.timeScale=1f;
    }
    public void LoadGame(){
       GameState loadState =  SaveSystem.LoadState();
       if(loadState!=null){

        Player.transform.position = new Vector3(loadState.PlayerPos[0],loadState.PlayerPos[1],loadState.PlayerPos[2]);
        PlayerStats stats = Player.GetComponent<PlayerStats>();
        stats.Energy = loadState.energy;
        stats.SeedCount[0] = loadState.SeedCount[0];
        stats.SeedCount[1] = loadState.SeedCount[1];
        stats.SeedCount[2] = loadState.SeedCount[2];
        stats.SCcount = loadState.SCcount;
        stats.money = loadState.money;

        for(int i = 0;i<Tiles.Count;i++){
            Tiles[i].timer = loadState.CropTimer[i];
            Tiles[i].cropType = loadState.Crops[i];
            Tiles[i].harvestType=loadState.Crops[i];
            Tiles[i].grown = loadState.grown[i];
            if(Tiles[i].cropType=="Wheat"){
                GameObject temp = Instantiate(CropPrefabs[0],new Vector3(loadState.tilePos[i,0],loadState.tilePos[i,1],loadState.tilePos[i,2]), Quaternion.identity);
                if(Tiles[i].grown)
                temp.GetComponent<cropGrowthCycle>().currentGrowth = 1f;
                else
                temp.GetComponent<cropGrowthCycle>().currentGrowth = Tiles[i].timer/15f;
            }
            else if(Tiles[i].cropType=="Rice"){
                GameObject temp = Instantiate(CropPrefabs[1],new Vector3(loadState.tilePos[i,0],loadState.tilePos[i,1],loadState.tilePos[i,2]), Quaternion.identity);
                if(Tiles[i].grown)
                temp.GetComponent<cropGrowthCycle>().currentGrowth = 1f;
                else
                temp.GetComponent<cropGrowthCycle>().currentGrowth = Tiles[i].timer/25f;
            }
            else if(Tiles[i].cropType=="Corn"){
                GameObject temp = Instantiate(CropPrefabs[2],new Vector3(loadState.tilePos[i,0],loadState.tilePos[i,1],loadState.tilePos[i,2]), Quaternion.identity);
                if(Tiles[i].grown)
                temp.GetComponent<cropGrowthCycle>().currentGrowth = 1f;
                else
                temp.GetComponent<cropGrowthCycle>().currentGrowth = Tiles[i].timer/40f;
            }
            Tiles[i].health = loadState.CropHealth[i];
            Tiles[i].isSC = loadState.isSC[i];
        }
        vstate.hasTire=loadState.vehicleState[0];
        vstate.hasEngine=loadState.vehicleState[1];
        vstate.hasCarrier=loadState.vehicleState[2];
        vstate.hasWindshield=loadState.vehicleState[3];
       }
        MainMenu.SetActive(false);
        Player.GetComponent<PlayerMovement>().enabled=true;
        Time.timeScale=1f;
        
    }

    public void newStart(){
        MainMenu.SetActive(false);
        GameAim.SetActive(true);
        Player.GetComponent<PlayerMovement>().enabled=true;
        
    }
    public void exit(){
        Application.Quit();
    }
    public void resume(){
        PauseMenu.SetActive(false);
        Player.GetComponent<PlayerMovement>().enabled=true;
        Time.timeScale=1f;
    }
    public void goToMenu(){
        MainMenu.SetActive(true);
        PauseMenu.SetActive(false);
    }
    public void showInstructions(){
        InstructionMenu.SetActive(true);


    }


    public void closeInstruction(){
        InstructionMenu.SetActive(false);
    }


    public void closeShowaim(){
        Time.timeScale=1f;
        GameAim.SetActive(false);
    }
}
