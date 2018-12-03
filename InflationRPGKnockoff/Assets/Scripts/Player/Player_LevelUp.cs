using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_LevelUp : MonoBehaviour {

    private ulong _curXP;
    [SerializeField]
    private ulong _xpToNextLevel;
    private float _multiplier;

    private Player_Stats _playerStats;

    private void Start()
    {
        _playerStats = this.GetComponent<Player_Stats>();
        _multiplier = 1.0005f;
    }

    // Update is called once per frame
    void Update () {
		if (_curXP >= _xpToNextLevel)
        {
            LevelUp();
        }
	}

    void AddXP(ulong enemyXP)
    {
        _curXP += enemyXP;
    }

    private void LevelUp()
    {
        _playerStats.lvl++;
        _curXP -= _xpToNextLevel;
        _xpToNextLevel = _xpToNextLevel + (10 * ((ulong)_multiplier ^ _playerStats.lvl));
    }
}
