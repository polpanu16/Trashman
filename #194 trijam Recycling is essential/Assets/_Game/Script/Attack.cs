using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] GameObject _player, youTrashGone;
    [SerializeField] float speed;
    [SerializeField] bool isPlayerLeft, isPlayerRight;

    private void OnEnable()
    {
        isPlayerLeft = GameManager.instance.isPlayerLeft;
        isPlayerRight = GameManager.instance.isPlayerRight;
        transform.position = new Vector3(_player.transform.position.x, transform.position.y, transform.position.z);
    }

    private void OnDisable()
    {
        GameManager.instance._Sound.PlayOneShot(GameManager.instance._soundEnemyDead, 0.5f);
    }
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerRight)
        {
            transform.position += (transform.right * speed * Time.deltaTime);
        }
        
        if (isPlayerLeft)
        {
            transform.position += (-transform.right * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" || other.tag == "Enemy2" || other.tag == "Enemy3")
        {
            gameObject.SetActive(false);
        }
    }
}
