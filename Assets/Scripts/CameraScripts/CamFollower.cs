using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollower : MonoBehaviour
{
    /* This Code is used to smooth the camera motion when following player*/
    // based on code from https://answers.unity.com/questions/1861989/pixel-perfect-camera-jittering.html

    // Players transfrom varible
    private Transform player;

    // Velocity for camera
    private Vector3 velocity = Vector3.zero;

    // Make sure to keep camera position above everything else
    private Vector3 renderOntop = new Vector3 (0, 0, -20);

    // Camera smoothing amount
    public float smoothRatio = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        // Find player gameobject
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Set camera posititon to player position
        transform.position = player.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // New camera position
        Vector3 newPosition = player.position + renderOntop;

        // Camera position with smoothing
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothRatio);

        // Set camera position to new smooth position
        transform.position = smoothPosition;
    }
}
