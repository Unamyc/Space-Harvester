using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float returnSpeed = -10f;
    
    private InputMaster _Controls;
    private bool canMove = true;
    private bool canAttachToPlatform = true;
    private List<GameObject> listOfParticuleSystems;

    public GameObject Cemetry;
    public GameObject particuleSysteme;

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
        bool ownASoul = transform.Find("PS_Soul") != null;
        if (canAttachToPlatform && other.gameObject.CompareTag("Platform") && transform.parent == null)
        {
            AttachToPlatform(other);
            if (other.gameObject.name.Contains("Cemetery") && ownASoul)
            {
                other.gameObject.GetComponent<Cemetery>().IncrementSouls();
                Destroy(transform.Find("PS_Soul").gameObject);
            }
        }

        if (other.gameObject.name == "PS_Soul" && !ownASoul)
        {
            other.collider.enabled = false;
            other.transform.SetParent(transform, true);
            other.transform.position = transform.position;
            other.transform.rotation = transform.rotation;
            other.transform.localScale = new Vector3(1, 1, 1);

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
        canMove = false;

        transform.SetParent(other.transform, true);

        transform.localRotation = Quaternion.identity;
        transform.up = (other.transform.position - transform.position) * -1;
    }

    private void DetachFromPlatform()
    {
        canAttachToPlatform = false;
        transform.SetParent(null, true);
        StartCoroutine(FixDetach());
    }

    private void MovePlayer()
    {
        if (_Controls.Player.Move.inProgress && canMove)
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
            DetachFromPlatform();
        }
        else if(!_Controls.Player.Move.inProgress && !canMove)
        {
            canMove = true;
        }
        if(!_Controls.Player.Move.inProgress)
        {
            canAttachToPlatform = true;
        }

        if (!_Controls.Player.Move.inProgress && transform.parent == null)
        {
            transform.Translate(0, returnSpeed * Time.deltaTime, 0);
        }
    }
    
    private IEnumerator FixDetach()
    {
        yield return new WaitForSeconds(1);
        canAttachToPlatform = true;
    }

    private void DestroyPlayer()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).GetComponent<Soul>())
            {
                transform.GetChild(i).GetComponent<Soul>().Reset();
            }
        }
        
       // DestroyParticuleSysteme();
        Cemetry.GetComponent<Cemetery>().Respawn();

        Destroy(gameObject);
    }

    private void CreateParticule()
    {
        listOfParticuleSystems.Add(Instantiate(particuleSysteme, transform.position, Quaternion.identity));
    }

    private void DestroyParticuleSysteme()
    {
        for (int i = 0; i < listOfParticuleSystems.Count; i++)
        {
            Destroy(listOfParticuleSystems[i]);
        }

        listOfParticuleSystems.Clear();
    }
}

