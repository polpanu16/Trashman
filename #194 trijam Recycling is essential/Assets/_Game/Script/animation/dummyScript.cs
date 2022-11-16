using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dummyScript : MonoBehaviour
{
    [SerializeField] GameObject skill1Drop, skill2Drop, skill3Drop;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Skill1")
        {

            if (!skill1Drop.activeSelf)
            {
                skill1Drop.SetActive(true);
                skill1Drop.transform.position = new Vector3(transform.position.x, skill1Drop.transform.position.y, skill1Drop.transform.position.z);
            }



        }

        if (other.tag == "Skill2")
        {

            if (!skill2Drop.activeSelf)
            {
                skill2Drop.SetActive(true);
                skill2Drop.transform.position = new Vector3(transform.position.x, skill2Drop.transform.position.y, skill2Drop.transform.position.z);
            }


        }

        if (other.tag == "Skill3")
        {
            if (!skill3Drop.activeSelf)
            {
                skill3Drop.SetActive(true);
                skill3Drop.transform.position = new Vector3(transform.position.x, skill3Drop.transform.position.y, skill3Drop.transform.position.z);
            }


        }
    }
}
