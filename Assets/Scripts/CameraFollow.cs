using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform player;
    public Transform target;
    public Vector3 offset;

    public float turnSpeed = 5.0f;
    public GameObject gplayer;

    private float yOffset = 2.0f;
    private float zOffset = 4.0f;
    void Start()
    {
        offset = new Vector3(player.position.x, player.position.y + yOffset, player.position.z - zOffset);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        //transform.position = player.transform.position - offset;
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
        transform.position = player.position + offset;
        transform.LookAt(target.position);
    }
}
