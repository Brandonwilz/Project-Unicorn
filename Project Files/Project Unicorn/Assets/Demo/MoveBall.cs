using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    private Vector2 _targetPos;
    private float _direction = 1f;
    private float _lerp = 0;

    private void Start()
    {
        _targetPos = new Vector2(9.5f, 0);
    }

    private void Update()
    {
        if (transform.position.x != _targetPos.x)
        {
            _lerp += Time.deltaTime * _direction;
            transform.position = new Vector2(Mathf.Lerp(-9.5f, 9.5f, _lerp), 0);
        }
        else
        {
            _targetPos = new Vector2(-_targetPos.x, _targetPos.y);
            _direction = -_direction;
        }
    }
}
