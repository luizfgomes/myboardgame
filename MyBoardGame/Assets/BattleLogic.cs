using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleLogic : MonoBehaviour {

    public static int[,,] dice1;
    public static int[,,] dice2;
    public static List<Result> result = new List<Result>();

    public static List<Result> StartBattle(bool extraDice1, bool extraDice2, int playerAttack ) {

        result = new List<Result>();

        if (extraDice1) {

            dice1 = new int[,,] { { { Random.Range(1, 6), Random.Range(1, 6), Random.Range(1, 6), Random.Range(1, 6) } } };
            dice2 = new int[,,] { { { Random.Range(1, 6), Random.Range(1, 6), Random.Range(1, 6), 0 } } };
        } else if (extraDice2) {

            dice1=new int[,,] { { { Random.Range(1, 6), Random.Range(1, 6), Random.Range(1, 6), 0 } } };
            dice2=new int[,,] { { { Random.Range(1, 6), Random.Range(1, 6), Random.Range(1, 6), Random.Range(1, 6) } } };
        } else {

            dice1=new int[,,] { { { Random.Range(1, 6), Random.Range(1, 6), Random.Range(1, 6),0 } } };
            dice2=new int[,,] { { { Random.Range(1, 6), Random.Range(1, 6), Random.Range(1, 6),0 } } };
        }

        
        CalcChampion(dice1, dice2, playerAttack);
        ReturnDicePlayer1(dice1);
        ReturnDicePlayer2(dice2);
        ResultDamage(dice1, dice2);
        result.Add(new Result() {
            champion=CalcChampion(dice1, dice2, playerAttack),
            player1dice=ReturnDicePlayer1(dice1),
            player2dice=ReturnDicePlayer1(dice2),
            damage=ResultDamage(dice1, dice2)
        });

        return result;
    }

    public static int[,,] ReturnDicePlayer1(int[,,] a) {
        return a;
    }

    public static int[,,] ReturnDicePlayer2(int[,,] a) {
        return a;
    }

    public static int CalcChampion(int[,,] dice1, int[,,] dice2, int playerAttack) {

        int player1 = 0;
        int player2 = 0;

        for(int i = 0; i < 3; i++) {

            if(dice1[0, 0, i]>dice2[0, 0, i] && (dice1[0, 0, i]>0&&dice2[0, 0, i]>0)) {

                player1++;
            } else if (dice1[0, 0, i]<dice2[0, 0, i] && (dice1[0, 0, i]>0 && dice2[0, 0, i] > 0)) {

                player2++;
            } else {

                if (playerAttack==0)
                    player1++;
                else
                    player2++;
            }
        }

        if (player1>player2) {
            Debug.Log("Campeão é o primeiro");
            return 0;
        } else {
            Debug.Log("Campeão é o segundo");
            return 1;
        }
    }

    public static int ResultDamage(int[,,] a, int[,,] b) {

        int value = 0;

        for (int i = 0; i<3; i++) {

            value=dice1[0, 0, i]-dice2[0, 0, i];
        }

        return value;
    }
}

public class Result {
    public int champion;
    public int[,,] player1dice;
    public int[,,] player2dice;
    public int damage;
}
