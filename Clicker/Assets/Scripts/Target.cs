using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x >= 0.5f)
        transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f) * Time.deltaTime;
        else
        {
            gm.Delete();
            gm.SubtractScore();
            Destroy(transform.gameObject);
        }
        
    }
}
