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
    //�v���C���[���G�ɗ^����_���[�W��
    int _randDamagePlayer;
    //�G���v���C���[�ɗ^����_���[�W��
    int _randDamageEnemy;
    /// <summary>�v���C���[���G�ɗ^����_���[�W��</summary>
    public int RandDamagePlayer { get => _randDamagePlayer; set => _randDamagePlayer = value; }
    /// <summary>�G���v���C���[�ɗ^����_���[�W��</summary>
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
