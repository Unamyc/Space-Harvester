using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlanetRotation : MonoBehaviour
{
    [SerializeField] protected bool RotationIsReversed = false;
    [SerializeField] protected float RotationSpeed = 50f;

    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {
        transform.Rotate((RotationIsReversed ? Vector3.forward : Vector3.back) *  Time.deltaTime * RotationSpeed);
    }
}
