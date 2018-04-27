using UnityEngine;
using System.Collections;
using System;

public class _Card : MonoBehaviour
{
    [SerializeField]
    Texture2D[] textures;                   // card texture arrays
    public GameObject foreGround;           // foreground object of card to change the foregrnd txture when value changed            
    public int value;                       //	current value of card
    public GameObject cardGameObject;      
    public bool isCardLocked;              

    bool isCardOpen;        
    int cardTurn;              // shows how many steps left to turn the card
    float cardTurnAngle;		// shows cards turning degree in every steps

    void Start() 
    {
        isCardOpen = false;
        isCardLocked = false;
    }

    void Update() 
    {
        if (cardTurn > 0)
        {
            cardTurn--;
            transform.Rotate(0, cardTurnAngle, 0);

            //if turning is over and iscardopen inform gamecontroller script
            if (cardTurn == 0 && isCardOpen == true)
            {
                cardGameObject.GetComponent<CardGameConroller>().CardOpened(gameObject);
            }
        }
    }

    void OnMouseDown() 
    {       
        if (cardTurn == 0 && isCardLocked == false)
        {
            if (isCardOpen == true)
            {
                CloseCard();
            }
            else
            {
                OpenCard();
            }
        }
    }

    public void ChangeCardValue(int newValue) 
    {
        // save given value and change foreground txture
        value = newValue;

        foreGround.GetComponent<MeshRenderer>().material.mainTexture 
            = textures[value];
    }   

    public void CloseCard() 
    {
        isCardOpen = false;
        cardTurn = 9;
        cardTurnAngle = 20;
    }

    public void OpenCard() 
    {
        isCardOpen = true;
        cardTurn = 18;
        cardTurnAngle = -10;
    }
}
