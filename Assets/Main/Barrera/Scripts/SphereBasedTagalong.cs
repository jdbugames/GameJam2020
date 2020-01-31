// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;

/// <summary>
/// A Tagalong that stays at a fixed distance from the camera and always
/// seeks to stay on the edge or inside a sphere that is straight in front of the camera.
/// </summary>
public class SphereBasedTagalong : MonoBehaviour
{
    #region Properties

    [Header("Tagalong Settings"), Tooltip("Sphere radius."), Range(0, 5)]
    public float sphereRadius = 0.25f;

    [Space, Tooltip("How fast the object will move to the target position.")]
    public float moveSpeed = 2.0f;
    [Tooltip("How fast the object will move to the target position.")]
    public float rotationSpeed = 6.0f;
    [Tooltip("Smooths object movement."), Range(0, 1)]
    public float moveSmoothTime = 0.9f;

    [Space, Tooltip("Distance in meters between object and target."), Range(0, 5)]
    public float distanceToCamera = 1.5f;

    [Space, Tooltip("Target transform reference")]
    public Transform target;

    /// <summary>
    /// When moving, use unscaled time. This is useful for games that have a pause mechanism or otherwise adjust the game timescale.
    /// </summary>
    [Header("Time Settings"), SerializeField, Tooltip("When moving, use unscaled time. This is useful for games that have a pause mechanism or otherwise adjust the game timescale.")]
    private bool useUnscaledTime = true;

    [Header("Gizmos Settings"), SerializeField, Tooltip("Display the sphere in red wireframe for debugging purposes.")]
    private bool debugDisplaySphere = false;
    [SerializeField, Tooltip("Display a small green cube where the target position is.")]
    private bool debugDisplayTargetPosition = false;

    // Hidden
    private float deltaTime = 0;

    // Cached Components
    private Vector3 velocity = Vector3.zero;

    private Vector3 optimalPosition;
    private Vector3 targetPosition;

    private Vector3 offsetDirection = Vector3.zero;

    private Quaternion currentRotation;
    private Quaternion targetRotation;

    // Cached Components (Gizmos)
    private Color oldColor;

    #endregion

    #region Unity functions

    private void Update()
    {
        if (target != null)
        {
            optimalPosition = target.position + target.forward *  distanceToCamera;

            offsetDirection = transform.position - optimalPosition;

            if (offsetDirection.magnitude > sphereRadius)
            {
                // Setting position...
                targetPosition = optimalPosition + offsetDirection.normalized * sphereRadius;

                deltaTime = useUnscaledTime
                    ? Time.unscaledDeltaTime
                    : Time.deltaTime;

                // Position...
                transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, moveSmoothTime, Mathf.Infinity, moveSpeed * deltaTime);

                // Setting rotation...
                currentRotation = transform.rotation;

                transform.LookAt(target);

                targetRotation = Quaternion.Euler(Vector3.up * transform.rotation.eulerAngles.y);

                transform.rotation = Quaternion.Lerp(
                    currentRotation,
                    targetRotation,
                    rotationSpeed * deltaTime);

                // Rotation...
                transform.rotation = Quaternion.Euler((Vector3.up * transform.rotation.eulerAngles.y));
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying == false)
            return;

        oldColor = Gizmos.color;

        if (debugDisplaySphere)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(optimalPosition, sphereRadius);
        }

        if (debugDisplayTargetPosition)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawCube(targetPosition, new Vector3(0.1f, 0.1f, 0.1f));
        }

        Gizmos.color = oldColor;
    }

    #endregion
}
