using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour

{
    
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotateSpeed;
    
    void Update()
    {
        transform.Translate(Vector3.forward * (Input.GetAxis("Vertical") * _movementSpeed));
        transform.Rotate(Vector3.up * _rotateSpeed * Input.GetAxis("Horizontal"));
    }
}
