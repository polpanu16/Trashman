using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class theThash : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    // Start is called before the first frame update
    void OnEnable()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.thashGone)
        {
            StartCoroutine(WaitforSecond());
        }
    }

    IEnumerator WaitforSecond()
    {
        transform.localPosition = new Vector3(16, -140, 0);
        yield return new WaitForSeconds(3);
        GameManager.instance.thashGone = false;
        transform.localPosition = new Vector3(16, -427, 0);
    }
}
