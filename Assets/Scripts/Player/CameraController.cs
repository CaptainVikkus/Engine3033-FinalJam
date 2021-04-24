using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    private void Start()
    {
        AppEvents.Invoke_OnMouseCursorEnable(false);
    }

    public void OnLook(InputValue value)
    {
        Vector2 aim = value.Get<Vector2>();

        //Smooth Rotation
        Quaternion addRot = Quaternion.AngleAxis(
            aim.x * GameManager.Sensitivity * Time.deltaTime,
            transform.up);
        //Rotate cam horizontal
        transform.rotation *= addRot;
    }
}
