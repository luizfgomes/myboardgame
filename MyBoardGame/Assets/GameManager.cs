using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public bool isPvp = false;
    private int _tabelwidth = 16;
    private int _tabelDepht = 16;
    private int _playerValue = 0;
    public int TabelWidth {

        get => _tabelwidth;

        set {

            if ((value > 8)&& (value <30)) {

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

    private void Start() {

        DontDestroyOnLoad(gameObject);
    }

    public void NewValue(bool value) {
        isPvp=value;
    }
}
