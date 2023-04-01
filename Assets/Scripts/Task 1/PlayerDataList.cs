using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;

public class PlayerDataList : SerializedMonoBehaviour
{

    public List<PlayerData> dataList;
    public List<TrumpCard> trumpCards;

    [Header("Player Lists")]
    public List<TrumpCard> Player1cards = new List<TrumpCard>(5);
    public List<TrumpCard> Player2cards = new List<TrumpCard>(5);
    public List<TrumpCard> Player3cards = new List<TrumpCard>(5);
    public List<TrumpCard> Player4cards = new List<TrumpCard>(5);
    [Header("Player Positions")]
    public Transform Player1cardss;
    public Transform Player2cardss;
    public Transform Player3cardss;
    public Transform Player4cardss;

    [Header("Prefabs")]
    public GameObject cardPrefab;
 

    private void Start()
    {
        Generator();
        TrumpGeneratorCards();
        DistuributionCards();
        DisplayCards();
    }
    public void Generator()
    {
        string[] Playernames = { "JohnCena", "TheRock ", "UnderTaker", "Randy Ortan", "Gibsy", "Ram", "VIcky", " Kannan", "Jacky", "Harry potter", "Rey mysterio", "Triple H", "Kavin Anna", " Vishal", " Ragavan", "Dinesh Anna", "Amal Fedro", "Udhay", " SAi", " Bhuvi"};

        for (int j = 0; j < Playernames.Length; j++)
        {
            PlayerData data = new PlayerData();
            data.playername = Playernames[j];
            data.ProfilePicture = "Profile Pic" + j;
            dataList.Add(data);

          
        }

        //TrumpCard card = new TrumpCard();
        //card.profilePicture = "Profile Pic0";
        //if (profilePictures.ContainsKey(card.profilePicture))
        //{
        //    profilePictureImage.sprite = profilePictures[card.profilePicture];
        //}

    }

    public void TrumpGeneratorCards()
    {
        for (int i = 0; i < 20; i++)
        {
            TrumpCard Tcard = new TrumpCard();
            PlayerData playerdata = dataList[i % 20];
            Tcard.playername = playerdata.playername;
            Tcard.profilePicture = playerdata.ProfilePicture;
            Tcard.rank = Random.Range(1, 20);
            Tcard.Fights = Random.Range(10, 150);
            Tcard.FightsWon = Random.Range(0, Tcard.Fights);
            Tcard.Height = Random.Range(90, 120);
            Tcard.Weight = Random.Range(100, 600);
            trumpCards.Add(Tcard);
            ShuffleCards();

        }
    }
    public void DisplayCards()
    {

        for (int i = 0; i < Player1cards.Count; i++)
        {
            TrumpCard trumpCard = Player1cards[i];
            GameObject Player1Cards = Instantiate(cardPrefab, Player1cardss.transform.position, Quaternion.identity);
            Player1Cards.GetComponent<CardData>().CardsDataText(trumpCard.rank.ToString(), trumpCard.Fights.ToString(), trumpCard.FightsWon.ToString(), trumpCard.Height.ToString(), trumpCard.Weight.ToString() ,trumpCard.playername.ToString());
            Player1Cards.GetComponent<Sprite>();

         
            Player1Cards.transform.SetParent(Player1cardss.transform, false);
        }
 


        for (int i = 0; i < Player2cards.Count; i++)
        {
            TrumpCard trumpCard = Player2cards[i];
            GameObject Player2Cards = Instantiate(cardPrefab, Player2cardss.transform.position, Quaternion.identity);

            Player2Cards.GetComponent<CardData>().CardsDataText(trumpCard.rank.ToString(), trumpCard.Fights.ToString(), trumpCard.FightsWon.ToString(), trumpCard.Height.ToString(), trumpCard.Weight.ToString(), trumpCard.playername.ToString());
            Player2Cards.transform.SetParent(Player2cardss.transform, false);
        }
        for (int i = 0; i < Player3cards.Count; i++)
        {
            TrumpCard trumpCard = Player3cards[i];
            GameObject Player3Cards = Instantiate(cardPrefab, Player3cardss.transform.position, Quaternion.identity);

            Player3Cards.GetComponent<CardData>().CardsDataText(trumpCard.rank.ToString(), trumpCard.Fights.ToString(), trumpCard.FightsWon.ToString(), trumpCard.Height.ToString(), trumpCard.Weight.ToString(), trumpCard.playername.ToString());
            Player3Cards.transform.SetParent(Player3cardss.transform, false);
        }
        for (int i = 0; i < Player4cards.Count; i++)
        {
            TrumpCard trumpCard = Player4cards[i];
            GameObject Player4Cards = Instantiate(cardPrefab, Player4cardss.transform.position, Quaternion.identity);

            Player4Cards.GetComponent<CardData>().CardsDataText(trumpCard.rank.ToString(), trumpCard.Fights.ToString(), trumpCard.FightsWon.ToString(), trumpCard.Height.ToString(), trumpCard.Weight.ToString(), trumpCard.playername.ToString());
            Player4Cards.transform.SetParent(Player4cardss.transform, false);
        }

    }
 
        public void ShuffleCards()
    {
        for (int i = 0; i < trumpCards.Count; i++)
        {
            int shufflecards = Random.Range(i, trumpCards.Count);

            TrumpCard shuffleData = trumpCards[i];
            trumpCards[i] = trumpCards[shufflecards];
            trumpCards[shufflecards] = shuffleData;

        }


    }
    public void DistuributionCards()
    {
        for (int i = 0; i < 5; i++)
        {

            Player1cards.Add(trumpCards[i * 4]);
            Player2cards.Add(trumpCards[i * 4+1]);
            Player3cards.Add(trumpCards[i * 4+2]);
            Player4cards.Add(trumpCards[i * 4+3]);

        }
    }







}
[System.Serializable]
public class TrumpCard
{
    public string playername;
    public string profilePicture;
    public int rank;
    public int Fights;
    public int FightsWon;
    public int Height;
    public int Weight;
}



[System.Serializable]
public class PlayerData
{
    public string playername;
    public string ProfilePicture;
}



