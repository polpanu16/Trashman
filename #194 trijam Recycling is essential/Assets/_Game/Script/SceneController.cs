using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] GameObject _introScene, _startScene, _gameOverScene, _fadeIn, _fadeOut, _creditScene , _creditSlide, _UI;
    [SerializeField] GameObject _GuideUI, _guide1, _guide2, _guide3 , _button, _button2, _button3, _click;
    [SerializeField] AudioSource _soundBGM;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IntroScene());

    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.instance.isGameReady)
        {
            _startScene.SetActive(false);
            _gameOverScene.SetActive(false);
            _UI.SetActive(true);
        }
        else
        {
            _UI.SetActive(false);
        }

        if (GameManager.instance.isPlayerDead)
        {
            _gameOverScene.SetActive(true);
        }

        if (_gameOverScene.activeSelf)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                StartCoroutine(IntroScene2());
            }
        }

        if (_creditScene.activeSelf)
        {
            if (_creditSlide.transform.localPosition.y >= -60)
            {
                if (Input.GetButtonDown("Cancel"))
                {
                    _startScene.SetActive(true);
                    _creditScene.SetActive(false);
                }
            }
        }
        
    }

    private IEnumerator IntroScene()
    {
        yield return new WaitForSeconds(4);
        _fadeIn.SetActive(false);
        _fadeOut.SetActive(true);
        yield return new WaitForSeconds(2);
        _fadeIn.SetActive(true);
        _startScene.SetActive(true);
        _fadeOut.SetActive(false);
        _introScene.SetActive(false);
        _soundBGM.Play();
        yield return new WaitForSeconds(2);
        _fadeIn.SetActive(false);
        

    }

    private IEnumerator IntroScene2()
    {
        _fadeOut.SetActive(true);
        GameManager.instance.isPlayerDead = false;
        GameManager.instance.isGameReady = false;
        yield return new WaitForSeconds(2);
        _fadeOut.SetActive(false);
        _gameOverScene.SetActive(false);
        _startScene.SetActive(true);
        _fadeIn.SetActive(true);
        yield return new WaitForSeconds(2);
        _fadeIn.SetActive(false);
    }

    public void OpenGuide()
    {
        _startScene.SetActive(false);
        _GuideUI.SetActive(true);
        _guide1.SetActive(true);
        _button.SetActive(true);
    }
    public void GuideScene1()
    {
        _guide1.SetActive(false);
        _button.SetActive(false);

        _guide2.SetActive(true);
        _button2.SetActive(true);
    }

    public void GuideScene2()
    {
        _guide2.SetActive(false);
        _button2.SetActive(false);

        _guide3.SetActive(true);
        _button3.SetActive(true);
    }

    public void GuideScene3()
    {
        _guide3.SetActive(false);
        _button3.SetActive(false);

        _startScene.SetActive(true);
        _GuideUI.SetActive(false);
    }

    public void CreditScene()
    {
        _startScene.SetActive(false);
        _creditScene.SetActive(true);
    }
}
