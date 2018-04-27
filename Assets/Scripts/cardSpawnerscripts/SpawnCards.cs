using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCards : MonoBehaviour {

    public GameObject cardPrefab;
    public Sprite[] cardSprites;

    public void MakeRandomCard() {
        int arrayIdx = Random.Range(0, cardSprites.Length);
        Sprite cardSprite = cardSprites[arrayIdx];
        string cardName = cardSprite.name;

        GameObject newAnimal = Instantiate(cardPrefab);

        newAnimal.name = cardName;
        newAnimal.GetComponent<Card_Test>().cardName = cardName;
        newAnimal.GetComponent<SpriteRenderer>().sprite = cardSprite;
    }
}
