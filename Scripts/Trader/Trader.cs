using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Trader : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    public float triggerRadius;
    [SerializeField] private GameObject ShoptCanvas;
    [SerializeField] private GameObject interactCanvas;
    [SerializeField] private ItemVariables itemVariables;
    // [SerializeField] private float TraderGold = 100;

    private float playerDist;
    private bool shopEnabled;
    void Start()
    {
        ShoptCanvas.SetActive(false);
        interactCanvas.SetActive(false);
        shopEnabled= false;
    }

    private void Update()
    {
        playerDist = (transform.position - _player.transform.position).magnitude;

        if(playerDist <= triggerRadius)
        {
            if (!shopEnabled)
            {
                interactCanvas.SetActive(true);
            }

            if(Input.GetKeyDown(KeyCode.E))
            {
                interactCanvas.SetActive(false);
                ShoptCanvas.SetActive(true);
                Time.timeScale = 0;
                shopEnabled= true;
                _player.GetComponent<PlayerMovement>().enabled = false;
            }
        }
        else if(playerDist > triggerRadius)
        {
            interactCanvas.SetActive(false);
        }
    }

    public void CloseShop()
    {
        ShoptCanvas.SetActive(false);
        Time.timeScale = 1;
        interactCanvas.SetActive(true);
        shopEnabled = false;
        _player.GetComponent<PlayerMovement>().enabled = true;
    }

    public void Buy(int amount, int index)
    {
        if (_player.GetComponent<PlayerStats>().money > amount * (int)itemVariables.Items[index].price)
        {
            Debug.Log("Buy " + amount);
            //Decrease Player Mone and increase player stuff count
            _player.GetComponent<PlayerStats>().money -= amount * (int)itemVariables.Items[index].price;
            if (index < 3)
                _player.GetComponent<PlayerStats>().SeedCount[index] += amount;
            else if (index == 3)
                _player.GetComponent<PlayerStats>().SCcount += amount;
            //TraderGold += itemVariables.Items[index].price;
            //itemVariables.Items[index].buyLimit-=amount;       
        }
    }

    public void Sell(int amount, int index)
    {
        Debug.Log("Sell " + amount);
        //Increase Player MOne
        _player.GetComponent<PlayerStats>().money += amount * (int)itemVariables.Items[index].price / 2;
        _player.GetComponent<PlayerStats>().SeedCount[index] -= amount;
        //TraderGold -= itemVariables.Items[index].price;
        //itemVariables.Items[index].buyLimit += amount;
        //decrease count from player stuff
    }
}
