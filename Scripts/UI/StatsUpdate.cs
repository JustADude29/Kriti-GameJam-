using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StatsUpdate : MonoBehaviour
{
    public Slider energy;

    [SerializeField] TMP_Text wheat;
    [SerializeField] TMP_Text rice;
    [SerializeField] TMP_Text corn;
    [SerializeField] TMP_Text money;
    [SerializeField] TMP_Text sc;
    GameObject player;
    PlayerStats stats;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        stats=player.GetComponent<PlayerStats>();
    }
   


    public void Update(){
        energy.value=stats.GetEnergy();
        wheat.text=stats.SeedCount[0].ToString();
        rice.text=stats.SeedCount[1].ToString();
        corn.text=stats.SeedCount[2].ToString();
        money.text=stats.money.ToString();
        sc.text=stats.SCcount.ToString();
    }
}
