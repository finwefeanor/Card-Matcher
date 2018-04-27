using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour {

    [SerializeField] private SceneController sceneController;
    [SerializeField] private GameObject cardBack;

    private int id1;
    private int id1_comp;

    public void OnMouseDown()
    {
        if(cardBack.activeSelf && sceneController.canVisible)
        {
            cardBack.SetActive(false);
            sceneController.CardRevealed(this);
        }
    }

    public int id_scene
    {
        get
        {
            return id1;
        }
    }

    public int id_computer 
    {
        get
        {
            return id1_comp;
        }
    }

    public void ChangeSprite(int id, Sprite image)
    {
        id1 = id;

        GetComponent<SpriteRenderer>().sprite = image; 
    }

    public void ChangeSprite_comp(int id_comp, Sprite image) 
    {
        id1_comp = id_comp;

        GetComponent<SpriteRenderer>().sprite = image;
        //This gets the sprite renderer component and changes the sprites
    }

    public void Invisible()
    {
        cardBack.SetActive(true);
    }

}
