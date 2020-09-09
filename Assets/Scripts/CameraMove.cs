using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player;
    void Update()
    {
        transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
    }
}
