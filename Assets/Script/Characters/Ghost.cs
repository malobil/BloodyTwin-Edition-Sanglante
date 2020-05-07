using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Character
{
    public override void Move()
    {
        Vector2 inputs = controls.General.Move.ReadValue<Vector2>();
        Vector3 movement = new Vector3(inputs.x, Rb.velocity.y, inputs.y);
        movement = (movement.z * transform.forward * Cdatas.MoveSpeed) + (movement.x * transform.right * Cdatas.MoveSpeed);
        movement.y = controls.Ghost.GoUp.ReadValue<float>() - controls.Ghost.GoDown.ReadValue<float>();
        movement.y *= Cdatas.MoveSpeed;
        Debug.Log(movement.y);
        Rb.velocity = movement;
    }
}
