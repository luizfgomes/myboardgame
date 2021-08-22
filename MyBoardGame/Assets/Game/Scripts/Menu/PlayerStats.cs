using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayer", menuName = "Players")]
public class PlayerStats : ScriptableObject {

    public new string name;
    public string description;

    public Sprite sprite;
    public GameObject charGO;

    public int moves;
    public int attack;
    public int health;
}
