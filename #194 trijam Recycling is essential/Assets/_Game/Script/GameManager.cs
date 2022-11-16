using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("GameManager is Null");
            }
            return _instance;
        }
    }

    public bool isSkill1 = true;
    public bool isSkill2 = true;
    public bool isSkill3 = true;
    public bool showSkill1, showSkill2, showSkill3;
    public bool isPlayerLeft, isPlayerRight;
    public Color enviColor1;
    public float R, G, _earthHP;
    public Slider earthHP;
    public Slider _playerHP;
    public bool canGetHit = true;
    public float randomEnemySpawn;
    public float regenSpeed;
    public float saveEarthTime;
    public bool thashGone;
    public bool isPlayerDead;
    public bool isGameReady = false;
    public bool isHardMode;
    public float _earthDying;
    public AudioSource _Sound;
    public AudioClip _soundEnemyDead;

    void Awake()
    {
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        _playerHP.value = 1;
        _earthHP = 0.01f;
        _earthDying = 10;
    }

    // Update is called once per frame
    void Update()
    {
        CoolingEarth();
        RandomSpawnPosition();
        EarthHP();

        

        if (_playerHP.value <= 0 && isGameReady)
        {
            PlayerDead();
        }
    }

    public void CoolingEarth()
    {
        if (_earthHP >= 1)
        {
            _earthHP = 1;
            saveEarthTime += 10 * Time.deltaTime;
        }

        if (_earthHP <= 0)
        {
            _earthHP = 0;
            
            if (_earthHP <= 0.1f && _earthDying <= 0 && isGameReady) 
            {
                _earthDying = 0;
                PlayerDead();
            }
            
        }

        enviColor1 = new Color(1, _earthHP, _earthHP, 1);
    }

    public void EarthHP()
    {
        earthHP.value = _earthHP;

        if (_playerHP.value < 0.5f && _earthHP > 0f)
        {
            _earthHP -= regenSpeed * Time.deltaTime;
            _playerHP.value += regenSpeed * Time.deltaTime;
        }
    }

    public void RandomSpawnPosition()
    {
        var rand = Random.Range(1, 3);
        if (rand == 1)
        {
            randomEnemySpawn = 30;
        }
        else if (rand == 2)
        {
            randomEnemySpawn = -30;
        }
    }

    public void PlayerDead()
    {
        isPlayerDead = true;
        isGameReady = false;
    }

    public void StartGAME()
    {
        isGameReady = true;
        isPlayerDead = false;
        isSkill1 = true;
        isSkill2 = true;
        isSkill3 = true;
        _earthHP = 0.5f;
        _playerHP.value = 1f;
        _earthDying = 10;
        saveEarthTime = 0;
    }

    public void HardMODE()
    {
        isHardMode = true;
    }
    public void NormalMode()
    {
        isHardMode = false;
    }

}
