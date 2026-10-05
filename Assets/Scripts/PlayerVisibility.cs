using UnityEngine;

public class PlayerVisibility : MonoBehaviour
{
    public FollowPlayer followPlayerScript;

    private Renderer[] vehicleRenderers;

    void Start()
    {
        vehicleRenderers = GetComponentsInChildren<Renderer>();
    }

    void Update()
    {
        UpdateVehicleVisibility();
    }

    void UpdateVehicleVisibility()
    {
        bool isBackseat = followPlayerScript != null && followPlayerScript.currentCameraMode == "Backseat";

        foreach (Renderer r in vehicleRenderers)
        {
            r.enabled = !isBackseat;
        }
    }
}
