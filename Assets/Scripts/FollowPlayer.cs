using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Variables
    public GameObject player;
    private Vector3 offset = new Vector3(0f, 6.0f, -5.0F);

    // Update is called once per frame
    void Update()
    {
        // Offset the camera to follow the player
        transform.position = player.transform.position + offset;
    }
}

