using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player_Move : MonoBehaviour {
    private float _speed;

    private Player_Stats _pStats;
    private Player_EnemyEncounter _pEnemyEnc;

    private Vector2 _moveDir = Vector2.zero;

    private void Start()
    {
        _pStats = GetComponent<Player_Stats>();
        _pEnemyEnc = GetComponent<Player_EnemyEncounter>();

        _speed = (float)(_pStats.speed);
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            _moveDir = new Vector2(Input.GetAxis("Horizontal") * (_speed / 100), Input.GetAxis("Vertical") * (_speed / 100));
            Debug.Log(_moveDir);
            if (!_pEnemyEnc.encounterFound)
            {
                _pEnemyEnc.encounterGauge++;
                _pEnemyEnc.encounterGaugeBar.fillAmount = (float)_pEnemyEnc.encounterGauge / 1000;
            }
        }
        else
        {
            _moveDir = Vector2.zero;
        }
        this.transform.Translate(_moveDir);
    }
}