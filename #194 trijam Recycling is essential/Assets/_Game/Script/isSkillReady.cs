using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isSkillReady : MonoBehaviour
{
    [SerializeField] Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isSkill1)
        {
            anim.SetBool("isSkill", true);
        }

        else
        {
            anim.SetBool("isSkill", false);
        }
    }
}
