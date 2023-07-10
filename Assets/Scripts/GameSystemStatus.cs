using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameSystemStatus : MonoBehaviour
{
    [SerializeField] Slider _hpSlider;
    int _hp;
    int _maxHp = 100;
    int _sp = 50;
    //プレイヤーが敵に与えるダメージ量
    int _randDamagePlayer;
    //敵がプレイヤーに与えるダメージ量
    int _randDamageEnemy;
    /// <summary>プレイヤーが敵に与えるダメージ量</summary>
    public int RandDamagePlayer { get => _randDamagePlayer; set => _randDamagePlayer = value; }
    /// <summary>敵がプレイヤーに与えるダメージ量</summary>
    public int RandDamageEnemy { get => _randDamageEnemy; set => _randDamageEnemy = value; }
    public int Hp { get => _hp; set => _hp = value; }
    private void Start()
    {
        _hp = _maxHp;
        _hpSlider.maxValue = _maxHp;
        _hpSlider.value = _maxHp;        
    }
    public void Damage(int damage)
    {
        
        _hp -= damage;
        _hpSlider.value = _hp;
        if (_hp<=0)
        {
            _hp = 0;
        }       
    }
}
