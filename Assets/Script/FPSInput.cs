using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    public float speed_1 = -6.0f;
    public float speed_2 = 6.0f;
    public float gravity = -9.8f;
    
    private CharacterController charController;
    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Vertical") * speed_1;
        float deltaZ = Input.GetAxis("Horizontal") * speed_2;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        
        movement = Vector3.ClampMagnitude(movement, speed_2);

        movement.y = gravity;

        movement *= Time.deltaTime;
        
        movement = transform.TransformDirection(movement);
        
        charController.Move(movement);
    }
}
