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
    [SerializeField] Text _arrowText;
    [SerializeField] Text _playerHpText;
    [SerializeField] Text _playerSpText;
    [SerializeField] Text _enemyHpText;
    [SerializeField] RectTransform _parent;
    [SerializeField] Slider _playerSpSlider;
    [SerializeField] Button _attackButton;
    [SerializeField] Button _textBoxPush;
    [SerializeField] Button _skillButton;
    [SerializeField] Text _whichAttack;
    [SerializeField] Text _whichSkillSuccess;

    void Start()
    {
        _whichAttack.gameObject.SetActive(false);
        _whichSkillSuccess.gameObject.SetActive(false);
        _isPlayerTurn = true;
        _isSkill = false;
        _playerSpSlider.value = _player.Sp;
        _playerSpSlider.maxValue = _player.Sp;
        //_arrowText.gameObject.SetActive(false);
        //�A�^�b�N�{�^�����������Ƃ�
        _attackButton.onClick.AddListener(() =>
        {
            if (_isPlayerTurn&&!_isSkill)
            {
                _isPlayerTurn = false;
                _whichAttack.text = "�v���[���[�̍U���I�I";
                _whichAttack.gameObject.SetActive(true);
                //�G���_���[�W���󂯂�
                _player.RandDamagePlayer = Random.Range(2, 10);
                _enemy.Damage(_player.RandDamagePlayer);
                _logText.text = $"�G��{_player.RandDamagePlayer}�̃_���[�W��^����!!\n";
                Text tx = Instantiate(_logText, new Vector3(0, 0, 0), Quaternion.identity);
                tx.transform.SetParent(_parent, false);
                _enemyHpText.text = _enemy.HpSlider.value.ToString();
                Debug.Log(_player.RandDamagePlayer);
                //_arrowText.gameObject.SetActive(true);
                Destroy(tx, 2.0f);
                Invoke(nameof(FalseWhichAttackText), 2.0f);
            }
        });
        ////�e�L�X�g�{�b�N�X���������Ƃ�
        //_textBoxPush.onClick.AddListener(() =>
        //{
        //    if (_isPlayerTurn)
        //    {
        //        _isPlayerTurn = false;
        //        _whichAttack.gameObject.SetActive(false);
        //    }
        //    else
        //    {
        //        if (_isSkill)
        //        {
        //            for (int i = 0; i < _enemyCounterText.Length; i++)
        //            {
        //                Destroy(_enemyCounterText[i]);
        //            }
        //        }
        //        else
        //        {
        //            Destroy(_enemyAttackText);
        //        }
        //        _isPlayerTurn = true;
        //    }
        //    _arrowText.gameObject.SetActive(false);
        //});
        //�X�L���{�^�����������Ƃ�
        _skillButton.onClick.AddListener(() =>
        {
            if (_isPlayerTurn)
            {
                _player.Sp -= 5;
                _playerSpSlider.value = _player.Sp;
                _playerSpText.text = _playerSpSlider.value.ToString();
                _escapeRand = Random.Range(1, 10);
                if (_escapeRand <= 8)
                {
                    _isSkill = true;
                    _whichSkillSuccess.text = "�X�L�����������I�I";
                    _whichSkillSuccess.gameObject.SetActive(true);
                }
                else
                {
                    _isSkill = false;
                    _whichSkillSuccess.text = "�X�L���������s�I�I";
                    _whichSkillSuccess.gameObject.SetActive(true);
                }
                Debug.Log(_isSkill);
                Invoke(nameof(FalseWhichSkillText), 2.0f);
                _isPlayerTurn = false;
            }
        });
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
                    _isSkill = false;
                    _whichAttack.text = "�G�ւ̃J�E���^�[�I�I";
                    _whichAttack.gameObject.SetActive(true);
                    _turnSpan = 0;
                    //�G���g,�U�����󂯂�
                    _enemy.RandDamageEnemy = Random.Range(1, 5);
                    _enemy.Damage(_enemy.RandDamageEnemy);
                    _logText.text = $"�G��{_enemy.RandDamageEnemy}�̃_���[�W��^����!!\n";
                    Text tx = Instantiate(_logText,new Vector3(0,20,0),Quaternion.identity);
                    tx.rectTransform.SetParent(_parent, false);
                    Destroy(tx, 2.0f);
                    Debug.Log(_enemy.RandDamageEnemy);
                    //�G���g,�U�����󂯂�
                    _enemy.RandDamageEnemy = Random.Range(1, 5);
                    _enemy.Damage(_enemy.RandDamageEnemy);
                    _logText.text = $"�G��{_enemy.RandDamageEnemy}�̃_���[�W��^����!!\n";
                    Text tx1 = Instantiate(_logText, new Vector3(0, -10, 0), Quaternion.identity);
                    tx1.rectTransform.SetParent(_parent, false);
                    Destroy(tx1, 2.0f);
                    Debug.Log(_enemy.RandDamageEnemy);
                    //�G���g,�U�����󂯂�
                    _enemy.RandDamageEnemy = Random.Range(1, 5);
                    _enemy.Damage(_enemy.RandDamageEnemy);
                    _logText.text = $"�G��{_enemy.RandDamageEnemy}�̃_���[�W��^����!!\n";
                    Text tx2 = Instantiate(_logText, new Vector3(0, -40, 0), Quaternion.identity);
                    tx2.rectTransform.SetParent(_parent, false);
                    Destroy(tx2, 2.0f);
                    Debug.Log(_enemy.RandDamageEnemy);
                    _enemyHpText.text = _enemy.HpSlider.value.ToString();               
                    Invoke(nameof(FalseWhichAttackText), 2.0f);
                }
                else if (!_isSkill)
                {
                    _whichAttack.text = "�G�̍U���I�I";
                    _whichAttack.gameObject.SetActive(true);
                    _turnSpan = 0;
                    //�v���C���[���_���[�W���󂯂�
                    _enemy.RandDamageEnemy = Random.Range(1, 5);
                    _player.Damage(_enemy.RandDamageEnemy);
                    _logText.text = $"�G����{_enemy.RandDamageEnemy}�̃_���[�W���󂯂�!!\n";
                    Text tx = Instantiate(_logText, new Vector3(0, 0, 0), Quaternion.identity);
                    tx.rectTransform.SetParent(_parent, false);
                    Destroy(tx, 2.0f);
                    _playerHpText.text = _player.HpSlider.value.ToString();
                    Debug.Log(_enemy.RandDamageEnemy);
                    
                    Invoke(nameof(FalseWhichAttackText), 2.0f);
                }
                _isPlayerTurn = true;
                //_arrowText.gameObject.SetActive(true);
            }
        }
    }
    void FalseWhichAttackText()
    {
        _whichAttack.gameObject.SetActive(false);
    }
    void FalseWhichSkillText()
    {
        _whichSkillSuccess.gameObject.SetActive(false);
    }
}
