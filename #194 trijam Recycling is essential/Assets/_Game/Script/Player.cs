using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject bottleSkill1;
    [SerializeField] GameObject trashSkill2;
    [SerializeField] GameObject canSkill3;

    [SerializeField] GameObject showSkill1;
    [SerializeField] GameObject showSkill2;
    [SerializeField] GameObject showSkill3;

    [SerializeField] SpriteRenderer _playerSprite;

    [SerializeField] AudioSource _sound;
    [SerializeField] AudioClip _soundGetHit;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameReady)
        {
            controller.enabled = true;
            Movement();
            Attack();
            PickWeapon();
        }

        else
        {
            controller.enabled = false;
            transform.position = new Vector3(0,-3.36f,0);
        }
    }
    
    void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector3 direction = new Vector3(horizontal, 0f, 0f).normalized;
        controller.Move(direction * moveSpeed * Time.deltaTime);

        if (transform.position.x <= -23.0f)
        {
            transform.position = new Vector3(-23, transform.position.y, transform.position.z);
        }

        if (transform.position.x >= 23.0f)
        {
            transform.position = new Vector3(23, transform.position.y, transform.position.z);
        }

        if (horizontal < 0)
        {
            transform.rotation = new Quaternion(transform.rotation.x, 180, transform.rotation.z, transform.rotation.w);
            GameManager.instance.isPlayerLeft = true;
            GameManager.instance.isPlayerRight = false;
        }
        if (horizontal > 0)
        {
            transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);
            GameManager.instance.isPlayerLeft = false;
            GameManager.instance.isPlayerRight = true;
        }
    }

    void Attack()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.J))
        {
            if (showSkill1.activeSelf)
            {
                bottleSkill1.SetActive(true);
                GameManager.instance.isSkill1 = false;
                GameManager.instance.showSkill1 = false;
            }

            if (showSkill2.activeSelf)
            {
                trashSkill2.SetActive(true);
                GameManager.instance.isSkill2 = false;
                GameManager.instance.showSkill2 = false;
            }

            if (showSkill3.activeSelf)
            {
                canSkill3.SetActive(true);
                GameManager.instance.isSkill3 = false;
                GameManager.instance.showSkill3 = false;
            }

        }
    }

    void PickWeapon()
    {
        if (GameManager.instance.isSkill1 && !bottleSkill1.activeSelf)
        {
                GameManager.instance.showSkill1 = true;
                GameManager.instance.showSkill2 = false;
                GameManager.instance.showSkill3 = false;
        }

        if (!GameManager.instance.isSkill1 && GameManager.instance.isSkill2 && !trashSkill2.activeSelf)
        {
                GameManager.instance.showSkill1 = false;
                GameManager.instance.showSkill2 = true;
                GameManager.instance.showSkill3 = false;
        }
           
        if (!GameManager.instance.isSkill1 && !GameManager.instance.isSkill2 && GameManager.instance.isSkill3 && !canSkill3.activeSelf) 
        {
                GameManager.instance.showSkill1 = false;
                GameManager.instance.showSkill2 = false;
                GameManager.instance.showSkill3 = true;
        }

        showSkill1.SetActive(GameManager.instance.showSkill1);
        showSkill2.SetActive(GameManager.instance.showSkill2);
        showSkill3.SetActive(GameManager.instance.showSkill3);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.instance.isGameReady && !GameManager.instance.isHardMode) 
        {
            if (other.tag == "Skill1Drop")
            {
                GameManager.instance.isSkill1 = true;
            }

            if (other.tag == "Skill2Drop")
            {
                GameManager.instance.isSkill2 = true;
            }

            if (other.tag == "Skill3Drop")
            {
                GameManager.instance.isSkill3 = true;
            }

            if (other.tag == "Enemy")
            {
                StartCoroutine(GetHitEffect(0.1f));
            }

            if (other.tag == "Enemy2")
            {
                StartCoroutine(GetHitEffect(0.2f));
            }

            if (other.tag == "Enemy3")
            {
                StartCoroutine(GetHitEffect(0.5f));
            }
        }

        if (GameManager.instance.isGameReady && GameManager.instance.isHardMode)
        {
            if (other.tag == "Skill1Drop")
            {
                GameManager.instance.isSkill1 = true;
            }

            if (other.tag == "Skill2Drop")
            {
                GameManager.instance.isSkill2 = true;
            }

            if (other.tag == "Skill3Drop")
            {
                GameManager.instance.isSkill3 = true;
            }

            if (other.tag == "Enemy")
            {
                StartCoroutine(GetHitEffect(0.4f));
            }

            if (other.tag == "Enemy2")
            {
                StartCoroutine(GetHitEffect(0.5f));
            }

            if (other.tag == "Enemy3")
            {
                StartCoroutine(GetHitEffect(0.7f));
            }
        }

    }


    public IEnumerator GetHitEffect(float HP)
    {
        Color color = new Color(1, 1, 1, 1);
        if (GameManager.instance.canGetHit)
        {
            _sound.PlayOneShot(_soundGetHit);
            GameManager.instance._playerHP.value -= HP;
            GameManager.instance.canGetHit = false;
            _playerSprite.color = new Color(1, 1, 1, 0.6f);
            yield return new WaitForSeconds(0.2f);
            _playerSprite.color = new Color(1, 1, 1, 0.3f);
            yield return new WaitForSeconds(0.2f);
            _playerSprite.color = new Color(1, 1, 1, 0.6f);
            yield return new WaitForSeconds(0.2f);
            _playerSprite.color = new Color(1, 1, 1, 0.3f);
            yield return new WaitForSeconds(0.2f);
            _playerSprite.color = new Color(1, 1, 1, 0.6f);
            yield return new WaitForSeconds(0.2f);
            _playerSprite.color = new Color(1, 1, 1, 0.3f);
            yield return new WaitForSeconds(0.2f);
            _playerSprite.color = new Color(1, 1, 1, 1);
            GameManager.instance.canGetHit = true;
        }
       

    }
}
