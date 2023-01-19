using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(player.position.x, player.position.y+1, player.position.z);
    }
}
