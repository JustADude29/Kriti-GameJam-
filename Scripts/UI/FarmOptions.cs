using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmOptions : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject SeedType;

    [SerializeField] GameObject[] cropPrefabs;
    [SerializeField] GameObject scareCrow;

    PlayerStats stats;

    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        stats = player.GetComponent<PlayerStats>();
        SeedType.SetActive(false);
    }

    // Update is called once per frame
    public void startFarming()
    {

        SeedType.SetActive(true);

    }





    public void isWheat()
    {
        if (stats.SeedCount[0] > 0)
        {

            // player.GetComponent<Farming>().FarmTile.GetComponent<Renderer>().material.color = new Color(204f / 255, 119f / 255, 34f / 255, 1);
            player.GetComponent<Farming>().FarmTile.GetComponent<TileInfo>().cropPrefab = Instantiate(cropPrefabs[0], player.GetComponent<Farming>().FarmTile.transform.position, Quaternion.identity, player.GetComponent<Farming>().FarmTile);
            stats.EnergyConsume(10);
            stats.SeedCount[0]--;
            player.GetComponent<Farming>().FarmTile.GetComponent<TileInfo>().cropType = "Wheat";
            player.GetComponent<Farming>().FarmTile.GetComponent<TileInfo>().harvestType = "Wheat";
        }
        SeedType.SetActive(false);
        player.GetComponent<PlayerMovement>().enabled = true;


    }
    public void isRice()
    {
        if (stats.SeedCount[1] > 0)
        {

            // player.GetComponent<Farming>().FarmTile.GetComponent<Renderer>().material.color = new Color(220f / 255, 220f / 255, 220f / 255, 1);
            player.GetComponent<Farming>().FarmTile.GetComponent<TileInfo>().cropPrefab = Instantiate(cropPrefabs[1], player.GetComponent<Farming>().FarmTile.transform.position, Quaternion.identity, player.GetComponent<Farming>().FarmTile);
            player.GetComponent<PlayerStats>().EnergyConsume(20);
            stats.SeedCount[1]--;
            player.GetComponent<Farming>().FarmTile.GetComponent<TileInfo>().cropType = "Rice";
            player.GetComponent<Farming>().FarmTile.GetComponent<TileInfo>().harvestType = "Rice";
        }
        player.GetComponent<PlayerMovement>().enabled = true;
        SeedType.SetActive(false);

    }
    public void isCorn()
    {
        if (stats.SeedCount[2] > 0)
        {

            // player.GetComponent<Farming>().FarmTile.GetComponent<Renderer>().material.color = new Color(225f / 255, 225f / 255, 224f / 255, 1);
            player.GetComponent<Farming>().FarmTile.GetComponent<TileInfo>().cropPrefab = Instantiate(cropPrefabs[2], player.GetComponent<Farming>().FarmTile.transform.position, Quaternion.identity, player.GetComponent<Farming>().FarmTile);
            player.GetComponent<PlayerStats>().EnergyConsume(30);
            stats.SeedCount[2]--;
            player.GetComponent<Farming>().FarmTile.GetComponent<TileInfo>().cropType = "Corn";
            player.GetComponent<Farming>().FarmTile.GetComponent<TileInfo>().harvestType = "Corn";
        }
        player.GetComponent<PlayerMovement>().enabled = true;
        SeedType.SetActive(false);

    }


    public void Harvest()
    {
        if (player.GetComponent<Farming>().FarmTile.GetComponent<TileInfo>().reward > 0)
        {

            string type = player.GetComponent<Farming>().FarmTile.GetComponent<TileInfo>().harvestType;
            Destroy(player.GetComponent<Farming>().FarmTile.GetComponent<TileInfo>().cropPrefab, 0.1f);
            if (type == "Wheat")
            {
                stats.SeedCount[0] += player.GetComponent<Farming>().FarmTile.GetComponent<TileInfo>().reward;
                player.GetComponent<Farming>().FarmTile.GetComponent<TileInfo>().reward=0;
                player.GetComponent<Farming>().FarmTile.GetComponent<TileInfo>().harvestType = "";
            }
            else if (type == "Rice")
            {
                stats.SeedCount[1] += player.GetComponent<Farming>().FarmTile.GetComponent<TileInfo>().reward;
                player.GetComponent<Farming>().FarmTile.GetComponent<TileInfo>().reward=0;
                player.GetComponent<Farming>().FarmTile.GetComponent<TileInfo>().harvestType = "";
            }
            else if (type == "Corn")
            {
                stats.SeedCount[2] += player.GetComponent<Farming>().FarmTile.GetComponent<TileInfo>().reward;
                player.GetComponent<Farming>().FarmTile.GetComponent<TileInfo>().reward=0;
                player.GetComponent<Farming>().FarmTile.GetComponent<TileInfo>().harvestType = "";
            }
             player.GetComponent<Farming>().FarmTile.GetComponent<TileInfo>().grown=false;
        }
        player.GetComponent<PlayerMovement>().enabled = true;
        SeedType.SetActive(false);
    }

    public void addDefense()
    {
        if (stats.SCcount > 0)
        {

            Instantiate(scareCrow, player.GetComponent<Farming>().FarmTile.transform.position, Quaternion.identity, player.GetComponent<Farming>().FarmTile);
            player.GetComponent<Farming>().FarmTile.GetComponent<TileInfo>().isSC = true;
            stats.SCcount--;
        }
        player.GetComponent<PlayerMovement>().enabled = true;
        SeedType.SetActive(false);
    }

    public void closeOptions()
    {
        player.GetComponent<PlayerMovement>().enabled = true;
        SeedType.SetActive(false);

    }

}
