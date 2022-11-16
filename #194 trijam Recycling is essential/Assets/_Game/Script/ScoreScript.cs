using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isHardMode) 
        {
            text.text = "HARDCORE MODE SCORE\n" + GameManager.instance.saveEarthTime.ToString("F0");
        }

        else
        {
            text.text = "NORMAL MODE SCORE\n" + GameManager.instance.saveEarthTime.ToString("F0");
        }
       
    }
}
