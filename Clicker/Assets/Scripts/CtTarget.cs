using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Serialization;
using Vector3 = UnityEngine.Vector3;

public class CtTarget : MonoBehaviour
{
    [FormerlySerializedAs("speed")] [SerializeField]
    private float _speed;
    private bool _isRight;
    private Vector3 _dir;

    private GameManager _gm;
    void Start()
    {
        _gm = FindObjectOfType<GameManager>();
        transform.position = StartPosition(ref _isRight);

        if (_isRight)
        {
            _dir = new Vector3(-1, 0);
        }
        else
        {
            _dir = new Vector3(1, 0);
        }
        
    }


    void Update()
    {
        transform.Translate(_speed * _dir * Time.deltaTime, Space.World);

        if (transform.position.x <= -12 || transform.position.x >= 12)
        {
            _gm.SubtractScore();
            Destroy(gameObject);
        }
    }

    private Vector3 StartPosition(ref bool isRight)
    {
        Vector3 result;
        
        if (Random.Range(0, 2) == 0)
        {
            isRight = false;
            result = new Vector3(-11, -3);
        }
        else
        {
            isRight = true;
            result = result = new Vector3(11, -3);
        }

        return result;
    }
}
