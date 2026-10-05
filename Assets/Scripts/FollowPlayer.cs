using UnityEngine;
using UnityEngine.InputSystem;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public InputAction SwitchCameraAction;
    private Vector3 offset = new Vector3(0,5,-7);
    private Vector3 backseat = new Vector3(0, 2, -2);
    private Vector3 currentCameraPosition;
    private Vector3 lookPosition = new Vector3(0, 2, 0);
    public string currentCameraMode = "DefaultCamera";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentCameraPosition = offset;
        transform.position = player.transform.position + offset;

        SwitchCameraAction.Enable();
        SwitchCameraAction.performed += OnInputActionPerformed;
    }

    void OnInputActionPerformed(InputAction.CallbackContext context)
    {
        if (currentCameraMode != "Backseat")
        {
            currentCameraPosition = backseat;
            currentCameraMode = "Backseat";
        }
        else
        {
            currentCameraPosition = offset;
            currentCameraMode = "DefaultCamera";
        }
    }
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.TransformPoint(currentCameraPosition);
        transform.LookAt(player.transform.TransformPoint(lookPosition));
    }
}
