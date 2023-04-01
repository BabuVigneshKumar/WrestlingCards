using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardData : MonoBehaviour
{
    public static CardData instance;


    private void Awake()
    {
        instance = this;
    }
    [Header("Player Texts")]
    public TMP_Text PlayerName;
    public TMP_Text Rank;
    public TMP_Text FightsWon;
    public TMP_Text Fight;
    public TMP_Text Height;
    public TMP_Text Weight;

 

    public void CardsDataText(string rank, string fightsWon, string fight, string height, string weight , string PlayerNAme )
    {
        Rank.text = rank;
        FightsWon.text = fightsWon;
        Weight.text = weight;   
        Height.text = height;
        Fight.text = fight;
        PlayerName.text = PlayerNAme;

       
    }
}
