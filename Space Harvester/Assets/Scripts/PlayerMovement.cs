using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float returnSpeed = -10f;
    
    private InputMaster _Controls;

    private void Awake()
    {
        _Controls = new InputMaster();

    }

    private void OnEnable()
    {
        _Controls.Enable();
    }

    private void OnDisable()
    {
        _Controls.Disable();
    }


    void Update()
    {
        MovePlayer();
    }
    
    void OnCollisionEnter(Collision other)
    {
        AttachToPlanet(other);
    }

    private void AttachToPlanet(Collision other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            transform.parent = other.transform;
        }
    }

    private void MovePlayer()
    {
        if (_Controls.Player.Move.inProgress)
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
    }
}

