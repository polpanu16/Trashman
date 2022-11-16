using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadAnim : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] GameObject _Enemy;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (_Enemy.transform.rotation.z >= 90)
        {
            anim.SetBool("isDead", true);
        }
        else
        {
            anim.SetBool("isDead", false);
        }
    }
}
