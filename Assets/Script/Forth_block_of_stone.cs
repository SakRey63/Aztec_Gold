using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forth_block_of_stone : MonoBehaviour
{

    public float speed = 1.0f;
    public float gravity = -4.0f;
    

    // В каком направлении объект движется в данный момент
    private int direction = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, gravity * Time.deltaTime, direction * speed * Time.deltaTime);
    }
}
