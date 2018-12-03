using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI_PlayerLevel : MonoBehaviour {

    [SerializeField]
    private Text _lvlText;
    private Player_Stats _pStats;

	// Use this for initialization
	void Start () {
        _pStats = GetComponent<Player_Stats>();
	}
	
	// Update is called once per frame
	void Update () {
        _lvlText.text = _pStats.lvl.ToString();
	}
}
