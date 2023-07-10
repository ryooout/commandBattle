using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameSystemStatus _player;
    [SerializeField] GameSystemStatus _enemy;
    float _turnSpan;
    float _skillSpan;
    bool _isPlayerTurn;
    bool _isSkill;
    int _reflection;
    int _escapeRand;
    void Start()
    {
        _isPlayerTurn = true;
        _isSkill = false;
    }  
    void Update()
    {
        if(!_isPlayerTurn)
        {
            _turnSpan += Time.deltaTime;
            if(_turnSpan>=5.0f)
            {
                if(_isSkill)
                {
                    _turnSpan = 0;
                    _isPlayerTurn = true;
                    if (_reflection<=3)
                    {
                        _skillSpan += Time.deltaTime;
                        if (_skillSpan >= 0.5f)
                        {
                            //敵自身,攻撃を受ける
                            _enemy.RandDamageEnemy = Random.Range(1, 5);
                            _enemy.Damage(_enemy.RandDamageEnemy);
                            _reflection++;
                        }
                    }
                    else
                    {
                        _reflection = 0;
                    }
                }
                else if (!_isSkill)
                {
                    _turnSpan = 0;
                    _isPlayerTurn = true;
                    //プレイヤーがダメージを受ける
                    _enemy.RandDamageEnemy = Random.Range(1, 5);
                    _player.Damage(_enemy.RandDamageEnemy);
                    Debug.Log(_enemy.RandDamageEnemy);
                }
            }           
        }
    }
    public void PlayerAttackButton()
    {
        if (_isPlayerTurn)
        {
            _isPlayerTurn = false;
            //敵がダメージを受ける
            _player.RandDamagePlayer = Random.Range(2, 10);
            _enemy.Damage(_player.RandDamagePlayer);
            Debug.Log(_player.RandDamagePlayer);
        }
    }
    public void PlayerSkillButton()
    {
        if(_isPlayerTurn)
        {
            _escapeRand = Random.Range(1, 10);
            if (_escapeRand <= 8)
            {
                _isSkill = true;
            }
            else
            {
                _isSkill = false;
            }
            Debug.Log(_isSkill);
            _isPlayerTurn = false;
        }
    }
}
