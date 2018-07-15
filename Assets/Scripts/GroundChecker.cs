using UnityEngine;
using System;
using UnityEngine.UI;

public class GroundChecker : MonoBehaviour
{
    /// <summary>
    /// set casting mask to everything
    /// </summary>
    [Header("Results")]
    public float groundSlopeAngle = 0f;            // Angle of the slope in degrees
     

    [Header("Settings")]
    public bool showDebug = false;                  // Show debug gizmos and lines
    public LayerMask castingMask;                  // Layer mask for casts. You'll want to ignore the player.
    public float startDistanceFromBottom = 0.2f;   // Should probably be higher than skin width
    public float sphereCastRadius = 0.25f;
    public float sphereCastDistance = 0.75f;       // How far spherecast moves down from origin point

    public float raycastLength = 0.75f;
    public Vector3 rayOriginOffset1 = new Vector3(-0.2f, 0f, 0.16f);
    public Vector3 rayOriginOffset2 = new Vector3(0.2f, 0f, -0.16f);

    // Component reference
    private CharacterController controller;

    void Awake()
    {
        // Get component on the same GameObject
        controller = GetComponent<CharacterController>();
        if (controller == null) { Debug.LogError("GroundChecker did not find a CharacterController component."); }
    }

    void Update()
    {
        if (controller && controller.isGrounded)
        {
            CheckGround(new Vector3(transform.position.x, transform.position.y - (controller.height / 2) + startDistanceFromBottom, transform.position.z));
        }
    }

    public void CheckGround(Vector3 origin)
    {
   
        RaycastHit hit;
        if (Physics.SphereCast(origin, sphereCastRadius, Vector3.down, out hit, sphereCastDistance, castingMask))
        {
            groundSlopeAngle = Vector3.Angle(hit.normal, Vector3.up); 
        }

        
    }

    

}