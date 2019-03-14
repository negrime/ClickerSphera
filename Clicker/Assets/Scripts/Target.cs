using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private GameManager _gm;

    private AudioManager _am;
    // Start is called before the first frame update
    void Start()
    {
        _gm = FindObjectOfType<GameManager>();
        _am = FindObjectOfType<AudioManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x >= 0.5f)
        transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f) * Time.deltaTime;
        else
        {
            _am.PlaySound("NoTime");
            _gm.Delete();
            _gm.SubtractScore();
            Destroy(transform.gameObject);
            _gm.currentCombo = 0;
        }
    }
}
