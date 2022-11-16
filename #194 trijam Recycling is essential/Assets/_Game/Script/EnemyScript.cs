using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] GameObject _player, skill1Drop, skill2Drop, skill3Drop;
    [SerializeField] float speed = 15;
    public bool isDead;
    [SerializeField] float fadeTime;
    [SerializeField] SpriteRenderer _enemySprite;
    [SerializeField] float dissapearSpeed;
    [SerializeField] Vector3 startPosition;
    // Start is called before the first frame update

    private void OnDisable()
    {

    }
    void Start()
    {
        startPosition = transform.position;
        fadeTime = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameReady) 
        {
            if (isDead)
            {
                
                fadeTime -= Time.deltaTime * dissapearSpeed;
                _enemySprite.color = new Color(1, 1, 1, fadeTime);
            }
            else
            {
                if (transform.position.x <= _player.transform.position.x)
                {
                    transform.rotation = new Quaternion(0, 180, 0, 0);
                }

                transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, speed * Time.deltaTime);
                transform.position = new Vector3(transform.position.x, -4, transform.position.z);
            }

            if (fadeTime <= 0)
            {
                transform.position = new Vector3(GameManager.instance.randomEnemySpawn, -4, 0);
                transform.rotation = new Quaternion(0, 0, 0, transform.rotation.w);
                fadeTime = 1;
                isDead = false;
                _enemySprite.color = new Color(1, 1, 1, fadeTime);
                gameObject.GetComponent<CapsuleCollider>().enabled = true;
            }
        }

        else
        {
            transform.position = startPosition;
            transform.rotation = new Quaternion(0, 0, 0, transform.rotation.w);
            fadeTime = 1;
            isDead = false;
            _enemySprite.color = new Color(1, 1, 1, fadeTime);
            gameObject.GetComponent<CapsuleCollider>().enabled = true;
        }

       




    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.instance.isGameReady)
        {
            if (other.tag == "Skill1")
            {
                DeadEnemy();
                if (!skill1Drop.activeSelf)
                {
                    GameManager.instance.saveEarthTime += 10;
                    skill1Drop.SetActive(true);
                    skill1Drop.transform.position = new Vector3(transform.position.x, skill1Drop.transform.position.y, skill1Drop.transform.position.z);
                }



            }

            if (other.tag == "Skill2")
            {
                DeadEnemy();
                if (!skill2Drop.activeSelf)
                {
                    GameManager.instance.saveEarthTime += 10;
                    skill2Drop.SetActive(true);
                    skill2Drop.transform.position = new Vector3(transform.position.x, skill2Drop.transform.position.y, skill2Drop.transform.position.z);
                }


            }

            if (other.tag == "Skill3")
            {
                DeadEnemy();
                if (!skill3Drop.activeSelf)
                {
                    GameManager.instance.saveEarthTime += 10;
                    skill3Drop.SetActive(true);
                    skill3Drop.transform.position = new Vector3(transform.position.x, skill3Drop.transform.position.y, skill3Drop.transform.position.z);
                }


            }

            if (other.tag == "Player")
            {
                if (GameManager.instance.canGetHit)
                {
                    DeadEnemy();
                }
            }
        }
        

    }

    void DeadEnemy()
    {
        isDead = true;
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        transform.rotation = new Quaternion(0, 0, 90, transform.rotation.w);
       
    }
}
