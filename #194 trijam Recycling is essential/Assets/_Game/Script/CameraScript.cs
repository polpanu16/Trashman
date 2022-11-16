using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] float endLeft, endRight;
    [SerializeField] GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(_player.transform.position.x, 0, -10);
        if (transform.position.x <= endLeft)
        {
            transform.position = new Vector3(endLeft, 0, -10);
        }

        if (transform.position.x >= endRight)
        {
            transform.position = new Vector3(endRight, 0, -10);
        }

    }
}
