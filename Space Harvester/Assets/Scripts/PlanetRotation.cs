using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlanetRotation : MonoBehaviour
{
    [SerializeField] private bool rotationIsReversed = false;
    [SerializeField] private float rotationSpeed = 50;

    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {
        transform.Rotate((rotationIsReversed ? Vector3.forward : Vector3.back) *  Time.deltaTime * rotationSpeed);
    }
}
