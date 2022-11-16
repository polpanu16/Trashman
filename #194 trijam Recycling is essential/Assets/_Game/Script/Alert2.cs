using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Alert2 : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] AudioSource _sound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance._earthHP <= 0.1f)
        {
            if (!_sound.isPlaying) 
            {
                _sound.Play();
            }
            
            GameManager.instance._earthDying -= 1 * Time.deltaTime;
            text.text = "The Earth's Keep Healing You \r\n\r\nit's Dying In " + GameManager.instance._earthDying.ToString("F0") + " Second\r\n\r\nRecycle Faster !!";
        }

        else
        {
            _sound.Stop();
            GameManager.instance._earthDying = 10;
        }
    }

    private void LateUpdate()
    {
        if (GameManager.instance._earthHP <= 0.1f)
        {

            transform.localPosition = new Vector3(-56, 100, 0);
            
        }

        else
        {
            transform.localPosition = new Vector3(-56, 499, 0);
        }
    }
}
