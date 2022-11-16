using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup3 : MonoBehaviour
{
    [SerializeField] GameObject youTrashGone;
    // Start is called before the first frame update
    void OnEnable()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (transform.position.x > 24 || transform.position.x < -24)
        {
            StartCoroutine(wait());
        }

        if (!GameManager.instance.isGameReady)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.isSkill3 = true;
            gameObject.SetActive(false);
            GameManager.instance.G += 0.02f;
            GameManager.instance._earthHP += 0.02f;
        }
    }

    IEnumerator wait()
    {
        GameManager.instance.thashGone = true;
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
