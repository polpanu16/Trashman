using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class IconSkill1 : MonoBehaviour
{
    [SerializeField] GameObject frame, BG, Xmark;
    [SerializeField] TextMeshProUGUI text;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (GameManager.instance.isSkill1)
        {
            frame.GetComponent<Image>().color = new Color32(12, 101, 37, 255);
            BG.GetComponent<Image>().color = new Color32(200, 255, 193, 255);
            text.GetComponent<TextMeshProUGUI>().color = new Color32(12, 101, 37, 255);
            Xmark.SetActive(false);
        }

        else
        {
            frame.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
            BG.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
            text.GetComponent<TextMeshProUGUI>().color = new Color32(255, 0, 0, 255);
            Xmark.SetActive(true);
        }
    }
}
