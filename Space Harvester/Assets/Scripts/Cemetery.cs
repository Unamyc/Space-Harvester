using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cemetery : PlanetRotation
{
    [SerializeField] private byte soulsNumber = 0;
    [SerializeField] private byte maxSoulsNumber = 5;
    [SerializeField] private GameObject playerPrefab;
    private GameManager _gameManager;

    private GameObject _player;
    // Start is called before the first frame update
    void Start(){
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        Transform limit1 = transform.Find("Limit1");
        Transform limit2 = transform.Find("Limit2");
        limit1.SetParent(null, true);
        limit2.SetParent(null, true);

        SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate((RotationIsReversed ? Vector3.forward : Vector3.back) *  Time.deltaTime * RotationSpeed);
    }

    public void ToggleRotationisReversed()
    {
        RotationIsReversed = !RotationIsReversed;
    }

    public void Respawn()
    {
        transform.rotation = Quaternion.identity;

        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        Transform playerSpawn = transform.Find("PlayerSpawn");
        _player = Instantiate(playerPrefab, transform, true);
        _player.transform.position = playerSpawn.position;
        _player.transform.rotation = playerSpawn.rotation;
        _player.GetComponent<PlayerMovement>().Cemetry = gameObject;
    }
    
    public void IncrementSouls()
    {
        ++soulsNumber;
        if (soulsNumber == maxSoulsNumber)
        {
            Win();
        }
    }

    private void Win()
    {
     _gameManager.DeclareAWinner("Player " + name[name.Length - 1]);   
    }
    

}

