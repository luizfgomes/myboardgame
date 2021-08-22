using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public bool isPvp = false;
    private int _tabelwidth = 16;
    private int _tabelDepht = 16;
    private int _playerValue = 0;


    public int randomPlayer2;

    [SerializeField] private string _player1 = "Mage";

    [SerializeField] private string _player2 = "Mage";

    public int TabelWidth {

        get => _tabelwidth;

        set {

            if ((value > 8) && (value <30)) {

                _tabelwidth = value;
            }
        }
    }

    public int TabelDepht {

        get => _tabelDepht;

        set {

            if ((value>8)&&(value<30)) {

                _tabelDepht = value;
            }
        }
    }

    public int PlayerValue {
        get => _playerValue;
        set {
            if ((value>0)&&(value<4)) {

                _playerValue=value;
            }
        }
    }

    public string Player1 {
        get { return _player1; }
        set { _player1=value; }
    }

    public string Player2 {
        get { return _player2; }
        set { _player2=value; }
    }

    private void Start() {

        DontDestroyOnLoad(gameObject);
        randomPlayer2=Random.Range(0, 3);

        switch (randomPlayer2) {
            case 0:
                _player2="Mage";
                break;
            case 1:
                _player2="Rogue";
                break;
            case 2:
                _player2="Orc";
                break;
            case 3:
                _player2="Warrior";
                break;
            default:
                _player2="Mage";
                break;
        }
    }

    public void NewValue(bool value) {
        isPvp=value;
    }
}
