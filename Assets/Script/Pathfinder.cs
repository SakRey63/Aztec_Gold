using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private Transform _cameraMount;
    [SerializeField] private float _jumpPower;
    
    private MovingToTheRight _movingToTheRight;
    private MovingToTheLeft _movingToTheLeft;
    private EnemySpawner _spawnFishes;

    private bool _dobleJump;
    void Update()
    {
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * _movementSpeed);
        transform.Rotate(Vector3.up * _rotateSpeed * Input.GetAxis("Horizontal"));
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate((Vector3.up * _jumpPower * Time.deltaTime));
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GateActivator component = other.gameObject.GetComponent<GateActivator>();
        if (component != null)
        {
            _movingToTheRight.GoOpen();
            _movingToTheLeft.GoOpen();
        }

    }
    private void OnTriggerExit(Collider other)
    {
        Fishes spawnFishes = other.gameObject.GetComponent<Fishes>();
        if (spawnFishes != null)
        {
            _spawnFishes.SpawnFishes();
        }

        GateActivator component = other.gameObject.GetComponent<GateActivator>();
        if (component != null)
        {
            _movingToTheRight.GoClose();
            _movingToTheLeft.GoClose();
        }
    }

    public void SetCamera(GameObject cam)
    {
        cam.transform.SetParent(_cameraMount, false);
    }
    
    public void OpenRight(MovingToTheRight open)
    {
        _movingToTheRight = open;
    }
    public void OpenLeft(MovingToTheLeft open)
    {
        _movingToTheLeft = open;
    }
    public void SpawnFish(EnemySpawner fish)
    {
        _spawnFishes = fish;
    }
}
