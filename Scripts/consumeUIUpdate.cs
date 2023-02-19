using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class consumeUIUpdate : MonoBehaviour
{
    public GameObject Player;
    public TextMeshProUGUI wheatText;
    public TextMeshProUGUI riceText;
    public TextMeshProUGUI cornText;
    public GameObject Canvas;

    private void Start()
    {
        Canvas.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Canvas.SetActive(true);
            Player.GetComponent<PlayerMovement>().enabled= false;
        }
        wheatText.SetText("Remaning: " + Player.GetComponent<PlayerStats>().SeedCount[0]);
        riceText.SetText("Remaning: " + Player.GetComponent<PlayerStats>().SeedCount[1]);
        cornText.SetText("Remaning: " + Player.GetComponent<PlayerStats>().SeedCount[2]);
    }

    public void CloseCanvas()
    {
        Canvas.SetActive(false);
        Player.GetComponent<PlayerMovement>().enabled = true;
    }
}
