using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5000f;
    
    private InputMaster _Controls;
    // [SerializeField] private InputAction moveAction;

    // [SerializeField] private InputActionMap playerActions;

    private void Awake()
    {
        
        /*
        // Adding MoveAction to ActionMap
        moveAction = new InputAction("move",
            binding: "<Keyboard>/space");*/
        _Controls = new InputMaster();

        // _Controls.Player.Move.performed += ctx => Move();

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
        if (_Controls.Player.Move.triggered)
        {
            Debug.Log("NIQUE !");

        }
    }
}

