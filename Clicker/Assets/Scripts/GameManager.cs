using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] targets = new GameObject[1];
    [SerializeField]
    public int maxCount;
    [SerializeField]
    public int currentCount;

    public int scores;
    
    [SerializeField]
    private float minSize;
    [SerializeField]
    private float maxSize;

    public Text scoreTxt;
    void Start()
    {
        scores = 0;
    }

    void Update()
    {
        if (scores < 0)
            scores = 0;
        scoreTxt.text = scores.ToString();

        if (currentCount < maxCount)
        {
            var go = Instantiate(targets[Random.Range(0, targets.Length)], new Vector2(Random.Range(-8, 8), Random.Range(-4, 4)), Quaternion.identity);
            float rndSize = Random.Range(minSize, maxSize);
            go.transform.localScale = new Vector2(rndSize, rndSize);
            currentCount++;
        }
    }

    public void Delete()
    {
        currentCount--;
        Debug.Log((currentCount));
    }

    public void AddScore()
    {
        scores++;
    }

    public void SubtractScore()
    {
        scores--;
    }
}
