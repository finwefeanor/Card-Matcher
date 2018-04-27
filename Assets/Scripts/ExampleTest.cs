using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleTest : MonoBehaviour 
{
    public const int gridRows = 1;
    public const int gridCols = 4;
    public const float offsetX = 2f;
    public const float offsetY = 3f;

    [SerializeField]
    private CardScript originalCard;
    [SerializeField]
    private Sprite[] images;

    private void Start() 
    {
        Vector3 startPos = originalCard.transform.position;

        int[] cardArray = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4 };
    }

    public static void Shuffle<T>(T[] array) // try to implement fisher shuffle
    {
        int count = array.Length;
        for (int i = count - 1; i > 0; --i)
        {
            int randIndex = Random.Range(0, i);

            T temp = array[i];
            array[i] = array[randIndex];
            array[randIndex] = temp;
        }
    }

}
