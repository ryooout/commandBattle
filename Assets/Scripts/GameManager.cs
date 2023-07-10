using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField] GameSystemStatus _player;
    [SerializeField] GameSystemStatus _enemy;
    float _turnSpan;
    bool _isPlayerTurn;
    bool _isSkill;
    int _escapeRand;
    [SerializeField] Text _logText;
    [SerializeField] Transform _parent;
    [SerializeField] Slider _playerSpSlider;
    void Start()
    {
        _isPlayerTurn = true;
        _isSkill = false;
        _playerSpSlider.value = _player.Sp;
        _playerSpSlider.maxValue = _player.Sp;
    }
    void Update()
    {
        if (!_isPlayerTurn)
        {
            _turnSpan += Time.deltaTime;
            if (_turnSpan >= 5.0f)
            {
                if (_isSkill)
                {
                    _turnSpan = 0;
                    //敵自身,攻撃を受ける
                    _enemy.RandDamageEnemy = Random.Range(1, 5);
                    _enemy.Damage(_enemy.RandDamageEnemy);
                    _logText.text = $"敵に{_enemy.RandDamageEnemy}のダメージを与えた!!\n";
                    Text tx = Instantiate(_logText);
                    tx.transform.SetParent(_parent, false);
                    Debug.Log(_enemy.RandDamageEnemy);
                    //敵自身,攻撃を受ける
                    _enemy.RandDamageEnemy = Random.Range(1, 5);
                    _enemy.Damage(_enemy.RandDamageEnemy);
                    _logText.text = $"敵に{_enemy.RandDamageEnemy}のダメージを与えた!!\n";
                    Text tx1 = Instantiate(_logText);
                    tx1.transform.SetParent(_parent, false);
                    Debug.Log(_enemy.RandDamageEnemy);
                    //敵自身,攻撃を受ける
                    _enemy.RandDamageEnemy = Random.Range(1, 5);
                    _enemy.Damage(_enemy.RandDamageEnemy);
                    _logText.text = $"敵に{_enemy.RandDamageEnemy}のダメージを与えた!!\n";
                    Text tx2 = Instantiate(_logText);
                    tx2.transform.SetParent(_parent, false);
                    Debug.Log(_enemy.RandDamageEnemy);
                    Destroy(tx, 2.0f);
                    Destroy(tx1, 2.0f);
                    Destroy(tx2, 2.0f);
                }
                else if (!_isSkill)
                {
                    _turnSpan = 0;
                    //プレイヤーがダメージを受ける
                    _enemy.RandDamageEnemy = Random.Range(1, 5);
                    _player.Damage(_enemy.RandDamageEnemy);
                    _logText.text = $"敵から{_enemy.RandDamageEnemy}のダメージを受けた!!\n";
                    Text tx3 = Instantiate(_logText);
                    tx3.transform.SetParent(_parent, false);
                    Debug.Log(_enemy.RandDamageEnemy);
                    Destroy(tx3, 2.0f);
                }
                _isPlayerTurn = true;
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
            _logText.text = $"敵に{_player.RandDamagePlayer}のダメージを与えた!!\n";
            Text attackText = Instantiate(_logText);
            attackText.transform.SetParent(_parent, false);
            Destroy(attackText, 2.0f);
            Debug.Log(_player.RandDamagePlayer);
        }
    }
    public void PlayerSkillButton()
    {
        if (_isPlayerTurn)
        {
            _player.Sp -= 5;
            _playerSpSlider.value = _player.Sp;
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
