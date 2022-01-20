using System;
using System.Net.Sockets;
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
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform") && transform.parent == null)
        {
            AttachToPlatform(other);
        }
    }

    private void AttachToPlatform(Collision2D other)
    {
        Debug.Log("Nique");
        transform.SetParent(other.transform, true);
        transform.eulerAngles.Set(0,0,90);
    }
    private void DetachFromPlatform()
    {
        transform.SetParent(null, true);
    }

    private void MovePlayer()
    {
        if (_Controls.Player.Move.inProgress)
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
            DetachFromPlatform();
            // transform.Translate(0, returnSpeed * Time.deltaTime, 0);
        }
    }
}

