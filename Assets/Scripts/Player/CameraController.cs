using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] float RotationPower = 250f;
    [SerializeField] float HorizontalDamping = 1f;

    private void Start()
    {
        AppEvents.Invoke_OnMouseCursorEnable(false);
    }

    public void OnLook(InputValue value)
    {
        Vector2 aim = value.Get<Vector2>();

        //Smooth Rotation
        Quaternion addRot = Quaternion.AngleAxis(
            aim.x * RotationPower * Time.deltaTime,
            transform.up);
        //Rotate cam horizontal
        transform.rotation *= addRot;
    }
}
