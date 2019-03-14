using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    private GameManager _gm;
    private AudioManager _am;
    public GameObject hole;

    private void Start()
    {

        _gm = FindObjectOfType<GameManager>();
        _am = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        if ( Input.GetMouseButtonDown( 0 ) )
        {
            _am.PlaySound("Fire");
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint( Input.mousePosition );
            RaycastHit2D hit = Physics2D.Raycast( worldPoint, Vector2.zero );
            
            if (hit.collider != null)
            {
                if ( hit.collider.CompareTag("Target") )
                {
                    _gm.currentCombo++;
                    _am.PlaySound(("Wound"));
                    Destroy(hit.transform.gameObject);
                    _gm.Delete();
                    _gm.AddScore();
                }
                if (hit.collider.name.Contains("CTbodyTarget"))
                {
                    _am.PlaySound("HeadShot");
                    _gm.AddScore();
                    Destroy(hit.transform.gameObject);
                    _gm.currentCombo++;
                }

            }
            else
            {
                _gm.currentCombo = 0;
                _gm.SubtractScore();
                _am.PlaySound("Miss");
                Instantiate(hole, new Vector2(worldPoint.x, worldPoint.y), Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 361))));
            }
        }
    }
}
