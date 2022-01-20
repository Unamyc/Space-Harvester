using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    [SerializeField] protected bool RotationIsReversed = false;
    [SerializeField] protected float RotationSpeed = 50f;

    void Update()
    {
        transform.Rotate((RotationIsReversed ? Vector3.forward : Vector3.back) * Time.deltaTime * RotationSpeed);
    }
}
