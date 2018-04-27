using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour 
{

    public const int gridRows = 1;
    public const int gridCols = 4;
    public const float offsetX = 2f;
    public const float offsetY = 3f;

    private CardScript firstSeenCard;
    private CardScript secondSeenCard;
    private int score = 0;

    [SerializeField]
    private TextMesh scoreLabel;
    [SerializeField] private CardScript mainCard;
    [SerializeField] private Sprite[] images;

    private void Start()
    {
        Vector3 startPos = mainCard.transform.position; 

        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4 };//, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9};
        numbers = ShuffleCards(numbers);
        //numbersComputer = ShuffleCardsComputer(numbersComputer);

        for (int i = 0; i < gridCols; i++)
        {
            for(int j = 0; j < gridRows; j++)
            {
                CardScript card;
                if(i == 0 && j == 0)
                {
                    card = mainCard;
                }
                else
                {
                    card = Instantiate(mainCard) as CardScript;
                }

                int index = j * gridCols + i;
                int id = numbers[index];
                // changes display image of cards
                card.ChangeSprite(id, images[id]); // todo implement this for computer

                // sets the position
                float posX = (offsetX * i) + startPos.x;
                float posY = (offsetY * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }
    }

    private int[] ShuffleCards(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for (int i = 0; i < newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }
    
    public bool canVisible
    {
        get { return secondSeenCard == null; }
    }

    public void CardRevealed(CardScript card)
    {
        if(firstSeenCard == null)
        {
            firstSeenCard = card;
        }
        else
        {
            secondSeenCard = card;
            StartCoroutine(CheckMatch()); 
        }
    }

    private IEnumerator CheckMatch()
    {
        if(firstSeenCard.id_scene == secondSeenCard.id_scene)
        {
            score++;
            scoreLabel.text = "Score: " + score;        
        }
        else
        {
            yield return new WaitForSeconds(0.5f);

            firstSeenCard.Invisible();
            secondSeenCard.Invisible();
        }
        firstSeenCard = null;
        secondSeenCard = null;
    }

}
