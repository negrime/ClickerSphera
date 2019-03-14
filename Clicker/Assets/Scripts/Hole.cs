using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    SpriteRenderer sr;
    private Color _newColor;

    void Start()
    {
        Destroy(gameObject, 4);
        sr = gameObject.GetComponent<SpriteRenderer>();
        CallFade();
    }
    
    void CallFade()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        while (sr.color.a > 0)
        {
            sr.color = Color.Lerp(sr.color, _newColor, 0.5f * Time.deltaTime);
            yield return null;
        }
    }
}
