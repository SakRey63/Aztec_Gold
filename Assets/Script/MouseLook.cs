using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

namespace UnityInAction
{
    public class MouseLook : MonoBehaviour
    {
        public enum RotentionAxes
        {
            MouseXAndY = 0,
            MouseX = 1,
            MouseY = 2
        }
        public RotentionAxes axes = RotentionAxes.MouseXAndY;

        public float sensitivityHor = 9.0f;
        public float sensitivityVert = 9.0f;

        public float minimumVert = -45.0f;
        public float maxiimumVert = 45.0f;

        private float verticalRot = 0;

        void Start ()
        {
            Rigidbody body = GetComponent<Rigidbody>();
            if (body != null )
            {
                body.freezeRotation = true;
            }
        }

        void Update()
        {
            if (axes == RotentionAxes.MouseX)
            {
                // это поворот в горизонтальной плоскости
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
            }
            else if (axes == RotentionAxes.MouseY)
            {
                // это поворот в вертикальной плоскости
                verticalRot -= Input.GetAxis("Mouse Y") * sensitivityVert;
                verticalRot = Mathf.Clamp(verticalRot, minimumVert, maxiimumVert);

                float horizontalRot = transform.localEulerAngles.y;

                transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
            }
            else
            {
                // это комбинированный поворот
                verticalRot -= Input.GetAxis("Mouse Y") * sensitivityVert;
                verticalRot = Mathf.Clamp(verticalRot, minimumVert, maxiimumVert);

                float delta = Input.GetAxis("Mouse X") * sensitivityHor;
                float horizontalRot = transform.localEulerAngles.y + delta;

                transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
            }
        }
    }
}


