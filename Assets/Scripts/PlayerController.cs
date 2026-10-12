using UnityEngine;
using UnityEngine.InputSystem;
using FishNet.Object;
using FishNet.Managing;

public class PlayerController : NetworkBehaviour
{
    public float speed = 5.0f;
    public float turnSpeed = 5.0f;

    public InputAction MoveAction;

    private Vector2 moveInput;

    public override void OnStartClient()
    {
        base.OnStartClient();

        if (IsOwner)
        {
            int clientId = NetworkManager.ClientManager.Clients.Count - 1; 
            transform.Translate(new Vector3(4*clientId -6 , 0, 2 * clientId)); // Perform any client-specific initialization here

            Camera mainCamera = Camera.main;
            if (mainCamera != null && mainCamera.TryGetComponent(out FollowPlayer followPlayer))
                followPlayer.SetPlayer(gameObject);
        }
    }

    void Start()
    {
        MoveAction.Enable();
    }

    void Update()
    {
        if (!base.IsOwner)
            return;
        moveInput = MoveAction.ReadValue<Vector2>();

        transform.Translate(Vector3.forward * Time.deltaTime * speed * moveInput.y);

        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * moveInput.x * moveInput.y);
    }
}
