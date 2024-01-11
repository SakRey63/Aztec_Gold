using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject _ObjectToInstantiate;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Forth_block_of_stone block = FindObjectOfType<Forth_block_of_stone>();
            if (block != null)
            {
                Destroy(block.gameObject);
            }   
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Instantiate(_ObjectToInstantiate);
        }
        
    }
}
