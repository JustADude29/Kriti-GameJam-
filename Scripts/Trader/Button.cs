using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    [SerializeField] private ItemVariables itemVariables;
    public int index;
    public TextMeshProUGUI MoneyAmountTxt;
    public Slider buySlider;
    public TextMeshProUGUI buyAmountTxt;
    public Slider sellSlider;
    public TextMeshProUGUI sellAmountTxt;
    public Trader trader;
    public GameObject Player;


    private int buyAmount;
    private int sellAmount;

    private void Update()
    {
        buySlider.minValue = 0;
        if(index<=3)
            buySlider.maxValue = (int) Player.GetComponent<PlayerStats>().money/ itemVariables.Items[index].price;
        else
            buySlider.maxValue = 1;

        sellSlider.minValue = 0;
        if (index < 3)
            sellSlider.maxValue = Player.GetComponent<PlayerStats>().SeedCount[index];
        else if (index >= 3)
            sellSlider.maxValue = 0;
        //set max value = amount player has
    }
    public void BuyButtonClick()
    {
        buyAmount = (int) buySlider.value;
        trader.Buy(buyAmount, index);
        //remaningAmountTxt.SetText(itemVariables.Items[index].buyLimit.ToString());
    }

    public void SellButtonClick()
    {
        sellAmount = (int) sellSlider.value;
        trader.Sell(sellAmount, index);
        //buySlider.maxValue = itemVariables.Items[index].buyLimit;
        //remaningAmountTxt.SetText(itemVariables.Items[index].buyLimit.ToString());
    }

    public void setBuyTextValue()
    {
        buyAmountTxt.SetText(buySlider.value.ToString());
        MoneyAmountTxt.SetText("Gold: " + (buySlider.value * itemVariables.Items[index].price).ToShortString());
    }

    public void setSellTextValue()
    {
        sellAmountTxt.SetText(sellSlider.value.ToString());
        MoneyAmountTxt.SetText("Gold: " + (sellSlider.value * itemVariables.Items[index].price/2).ToShortString());
    }
}
