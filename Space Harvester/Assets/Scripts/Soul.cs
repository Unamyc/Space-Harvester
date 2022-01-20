using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{
    private GameObject player;
    private Vector3 startPosition;
    private Quaternion startRotation;

    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    public void Reset()
    {
        transform.SetParent(null, true);
        transform.position = startPosition;
        transform.rotation = startRotation;
        transform.localScale = new Vector3(1, 1, 1);

        GetComponent<Collider>().enabled = true;
    }

    public void SetPlayer(GameObject newPlayer)
    {
        player = newPlayer;
    }
}
