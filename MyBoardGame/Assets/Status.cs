﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {
    public string name;

    public int moves;
    public bool extraAttack;
    public bool extraDice;
    public int tempMoves;
    public int attack;
    public int health;

    private void Start() {
        ResetMovesValue();
        extraAttack=false;
        extraDice=false;
    }

    public void ResetMovesValue() {
        tempMoves=moves;
    }
}
