using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alert : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance._earthHP >= 1)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, 100, transform.localPosition.z);
        }

        else
        {
            transform.localPosition = new Vector3(transform.localPosition.x, 400, transform.localPosition.z);
        }
    }
}
