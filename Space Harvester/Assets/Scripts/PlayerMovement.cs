using System;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float returnSpeed = -10f;
    
    private InputMaster _Controls;
    private bool canMove = true;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent != null)
        {
            if (collision.transform.parent.gameObject.CompareTag("DeathWall"))
            {
                DestroyPlayer();
            }
        }
        else if(collision.gameObject.CompareTag("Limit"))
        {
            transform.parent.GetComponent<Cemetery>().ToggleRotationisReversed();
        }
    }

    private void AttachToPlatform(Collision2D other)
    {
        Debug.Log("Nique");
        canMove = false;

        transform.SetParent(other.transform, true);

        transform.localRotation = Quaternion.identity;
        transform.up = (other.transform.position - transform.position) * -1;

        print(other.transform.position);
    }

    private void DetachFromPlatform()
    {
        transform.SetParent(null, true);
    }

    private void MovePlayer()
    {
        if (_Controls.Player.Move.inProgress && canMove)
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
            DetachFromPlatform();
            // transform.Translate(0, returnSpeed * Time.deltaTime, 0);
        }
        else if(!_Controls.Player.Move.inProgress && !canMove)
        {
            canMove = true;
        }
    }

    private void DestroyPlayer()
    {
        Destroy(gameObject);
    }
}

