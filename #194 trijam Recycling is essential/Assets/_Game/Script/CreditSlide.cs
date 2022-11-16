using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditSlide : MonoBehaviour
{
    [SerializeField] float speed;
    // Start is called before the first frame update
    private void OnEnable()
    {

    }

    private void OnDisable()
    {
        transform.localPosition = new Vector3(0, -600, 0);
        speed = 25;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += transform.up * Time.deltaTime * speed;
        if (transform.localPosition.y >= -50)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, -50, transform.localPosition.z);
        }

        if (Input.GetButtonDown("Cancel"))
        {
            speed = speed * 5;
        }
    }
}
