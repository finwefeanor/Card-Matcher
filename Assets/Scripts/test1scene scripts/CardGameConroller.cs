using UnityEngine;
using System.Collections;

public class CardGameConroller : MonoBehaviour
{
    public GameObject[] deck; //= new GameObject[52];
    public GameObject[] player = new GameObject[4];
    public GameObject[] computer = new GameObject[4];

    public GameObject cardPrefab;	//	card game object
	public int totalCardNumbers;			//	instantiating total card numbers
	public int columnNumber;			//	column number to place cards
	public float cardGapX;		//	distance between cards in X axis
	public float cardGapY;      //	distance between cards in Y axis

    //public AudioClip matchCheck;	
    //public AudioClip gameOverSound;		

    GameObject[] cardList;	//	Array of card objects
	GameObject firstCard;			//	first card at matching
	int matchingNumber;			//	correct matchin number

    void Start() {
        CreateCards();
        ShuffleCards();
        PlaceCards();

        matchingNumber = 0;
    }

    // Create cards at given amount
    void CreateCards() 
    {
        cardList = new GameObject[totalCardNumbers];
        //cardList = new GameObject[Random.Range(0, totalCardNumbers)];

        for (int cardNumber = 0; cardNumber < totalCardNumbers; cardNumber++)
        {
            cardList[cardNumber] = Instantiate(cardPrefab, transform);
            int randomCardNumber = Random.Range(0, totalCardNumbers);

            _Card card = cardList[cardNumber].GetComponent<_Card>();

            // give gameobject to card
            card.cardGameObject = gameObject;

            //	give value to card
            //card.ChangeCardValue(cardNumber / 2);
            card.ChangeCardValue(cardNumber);
        }
    }

    void ShuffleCards() 
    {
        // create temporary card list
        GameObject[] tempList = new GameObject[totalCardNumbers];

        for (int cardNumber = 0; cardNumber < totalCardNumbers; cardNumber++)
        {
            // choose random column
            int randomCardNumber = Random.Range(0, totalCardNumbers - cardNumber);

            // place last card number on the list
            int lastCardNumber = totalCardNumbers - cardNumber - 1;

            // take next random card from the list place in to templist
            tempList[cardNumber] = cardList[randomCardNumber];

            // place the last card in the list to random card
            cardList[randomCardNumber] = cardList[lastCardNumber]; 

            // clear the last card on the list
            cardList[lastCardNumber] = null;
        }
        // take templist back to cardlist
        cardList = tempList;
    }

    void PlaceCards() 
    {
        // create cards at given value
        for (int cardNumber = 0; cardNumber < totalCardNumbers; cardNumber++)
        {
            // Create Card
            GameObject newCard = cardList[cardNumber];

            // place card
            int lineNumber = totalCardNumbers / columnNumber;

            float cardXStart = ((columnNumber - 1.0f) / 2.0f) * cardGapX;
            float cardYStart = ((lineNumber - 1.0f) / 2.0f) * cardGapY;

            float cardX = (cardGapX * (cardNumber % columnNumber)) - cardXStart;
            float cardY = (cardGapX * (cardNumber / columnNumber)) - cardYStart;

            newCard.transform.Translate(cardX, cardY, -0.5f);
        }
    }

    public void CardOpened(GameObject newCard) 
    {
        // if first card opened
        if (firstCard == null)
        {
            // lock first card to prevent clicking again
            firstCard = newCard;
            firstCard.GetComponent<_Card>().isCardLocked = true;
        }
        // when pressed second card
        else
        {
            // if value of two cards are same
            if(firstCard.GetComponent<_Card>().value ==
                newCard.GetComponent<_Card>().value)
            {
                Debug.Log("Cards are Same! Pisti!");

                // lock the second card
                newCard.GetComponent<_Card>().isCardLocked = true;

                // do not hold the first card
                firstCard = null;

                // increase matching number
                matchingNumber++;

                // if all cards are matched
                if (matchingNumber == totalCardNumbers /2)
                {
                    Debug.Log("Game OVER!");
                }
            }
            // if two cards are different
            else
            {
                Debug.Log("Cards are different");

                // unlocked first card
                firstCard.GetComponent<_Card>().isCardLocked = false;

                // close two cards
                firstCard.GetComponent<_Card>().CloseCard();
                newCard.GetComponent<_Card>().CloseCard();

                // do not hold the first card
                firstCard = null;
            }
        }
    }

}
