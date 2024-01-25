using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class TurningGrid : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _direction;
    [SerializeField] private int _maxY;
    
    private bool _grid = false;
    
    void Update()
    {
        if (_grid)
        {
            transform.Rotate(Vector3.up * _direction * _speed * Time.deltaTime);
            if (transform.rotation.y <= _maxY)
            {
                _grid = false;
            }
        }
    }

    public void RotateGrid()
    {
        _grid = true;
    }
}
