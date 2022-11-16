using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBurnScript : MonoBehaviour
{
    public SpriteRenderer Sprite;
    // Start is called before the first frame update
    void Start()
    {
        Sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Sprite.color = GameManager.instance.enviColor1;
    }
}
