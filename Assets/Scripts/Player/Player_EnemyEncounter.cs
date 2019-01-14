using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player_EnemyEncounter : MonoBehaviour {
    //A gauge that fills the more you move, from 0 to 100.
    //The closer to 100 it is, the higher the chance of encounter
    public double encounterGauge;
    public bool encounterFound;

    private double _randomNum;

    public Image encounterGaugeBar;

    void FixedUpdate()
    {
        _randomNum = Random.Range(200, 1000);
        if (_randomNum < encounterGauge)
        {
            encounterFound = true;
            StartEncounter();
        }
    }

    private void StartEncounter()
    {
        encounterGauge = 0;
        Debug.Log("HELP! YOU ARE BEING ATTACKED!");
    }
}
