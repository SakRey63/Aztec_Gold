using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class Forth_block_of_stone : MonoBehaviour
{

    [SerializeField] private float speed;
    

    // В каком направлении объект движется в данный момент
    private int direction = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, direction * speed * Time.deltaTime);
    }
}
