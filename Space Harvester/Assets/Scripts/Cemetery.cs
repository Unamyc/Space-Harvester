using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cemetery : PlanetRotation
{
    [SerializeField] private byte SoulsNumber = 0;
    [SerializeField]private GameObject PlayerPrefab;


    private GameObject Player;
    // Start is called before the first frame update
    void Start(){
        Transform limit1 = transform.Find("Limit1");
        Transform limit2 = transform.Find("Limit2");
        limit1.SetParent(null, true);
        limit2.SetParent(null, true);
        
        Transform playerSpawn = transform.Find("PlayerSpawn");
        Player = Instantiate(PlayerPrefab, transform, true);
        Player.transform.position = playerSpawn.position;
        Player.transform.rotation = playerSpawn.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate((RotationIsReversed ? Vector3.forward : Vector3.back) *  Time.deltaTime * RotationSpeed);
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        ToggleRotationisInversed();
    }

    void ToggleRotationisInversed()
    {
        RotationIsReversed = !RotationIsReversed;
    }
}
