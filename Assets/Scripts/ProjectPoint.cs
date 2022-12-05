using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectPoint : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    private Vector3 fuck;
    public GameObject player;
    public float zDistance;
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        zDistance += Input.GetAxis("Mouse ScrollWheel") * 10;
        //transform.position = new Vector3( player.transform.position.x + 0, 0f, zDistance);

        if(Input.GetKey(KeyCode.Mouse0))
        {
            gameObject.SetActive(true);
        }

        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnMouseDrag()
    {
        
    }

    private void OnMouseUp()
    {
        
    }

    
}
