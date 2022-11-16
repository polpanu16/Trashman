using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pallarax : MonoBehaviour
{
    private float startPos;
    private GameObject cam;
    [SerializeField] float parallaxEffectMultiplier;

    private float length;
    public Color color;


    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        

    }
    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffectMultiplier));
        float distance = (cam.transform.position.x * parallaxEffectMultiplier);
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if (temp > startPos + length)
        {
            startPos += length;
        }
        else if (temp < startPos - length)
        {
            startPos -= length;
        }
    }
}
