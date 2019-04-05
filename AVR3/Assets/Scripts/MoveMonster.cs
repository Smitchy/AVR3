using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity;
using HoloToolkit.Unity.SpatialMapping;

public class MoveMonster : MonoBehaviour, IInputClickHandler
{
    private bool beingMoved = false;
    Interpolator interpolator;

    private void Awake()
    {
        interpolator = GetComponent<Interpolator>();
    }

    private void Update()
    {
        if (!beingMoved) return;

        Transform cameraTransform = CameraCache.Main.transform;
        Vector3 placementPosition = GetPlacementPosition(cameraTransform.position, cameraTransform.forward, 2.0f);

        // update the placement to match the user's gaze.
        interpolator.SetTargetPosition(placementPosition);

        // Rotate this object to face the user.
        interpolator.SetTargetRotation(Quaternion.Euler(0, cameraTransform.localEulerAngles.y, 0));

    }

    private static Vector3 GetPlacementPosition(Vector3 headPosition, Vector3 gazeDirection, float defaultGazeDistance)
    {
        RaycastHit hitInfo;
        if (SpatialMappingRaycast(headPosition, gazeDirection, out hitInfo))
        {
            return hitInfo.point;
        }
        return GetGazePlacementPosition(headPosition, gazeDirection, defaultGazeDistance);
    }

    private static bool SpatialMappingRaycast(Vector3 origin, Vector3 direction, out RaycastHit spatialMapHit)
    {
        if (SpatialMappingManager.Instance != null)
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(origin, direction, out hitInfo, 30.0f, SpatialMappingManager.Instance.LayerMask))
            {
                spatialMapHit = hitInfo;
                return true;
            }
        }
        spatialMapHit = new RaycastHit();
        return false;
    }

    private static Vector3 GetGazePlacementPosition(Vector3 headPosition, Vector3 gazeDirection, float defaultGazeDistance)
    {
        if (GazeManager.Instance.HitObject != null)
        {
            return GazeManager.Instance.HitPosition;
        }
        return headPosition + gazeDirection * defaultGazeDistance;
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        beingMoved = !beingMoved;
        HandleMove();
        eventData.Use();
    }

    private void HandleMove()
    {
        if (beingMoved)
        {
            WorldAnchorManager.Instance.RemoveAnchor(gameObject);
        }
        else{
            WorldAnchorManager.Instance.AttachAnchor(gameObject);
        }
        

    }
}
