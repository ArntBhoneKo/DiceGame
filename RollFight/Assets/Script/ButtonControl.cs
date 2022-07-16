using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    int dice1;
    int dice2;
    int dice3;
    int dice4;
    int diceTotal;
    int edice1;
    int edice2;
    int edice3;
    int edice4;
    int ediceTotal;
    public bool buttonpressed = false;
    public void RollDice()
    {
        if (FindObjectOfType<GameManager>().state != BattleState.PLAYERTURN)
        return;

        StartCoroutine(RollingDice());
    }

    IEnumerator RollingDice()
    {
        if (buttonpressed)
            yield break;

        dice1 = (Random.Range(0, 5));
        dice2 = (Random.Range(0, 5));
        dice3 = (Random.Range(0, 5));
        dice4 = (Random.Range(0, 5));
        diceTotal = ((dice1 + dice2) + (dice3 + dice4));
        FindObjectOfType<AnimateManager>().Roll(dice1, dice2, dice3, dice4);

        buttonpressed = true;
        yield return new WaitForSecondsRealtime(FindObjectOfType<AnimateManager>().rollTime + FindObjectOfType<GameManager>().atkTime);
        
        FindObjectOfType<GameManager>().PlayerAttack(diceTotal);


        if(((dice1 == dice2) & (dice2 == dice3)) | ((dice1 == dice2) & (dice2 == dice4)) | ((dice1 == dice3) & (dice3 == dice4)) | ((dice2 == dice3) & (dice3 == dice4)))
        {
            FindObjectOfType<GameManager>().luckyRoll = true;
            buttonpressed = false;
        }
        
    }

    public void EnemyRollDice()
    {
        if (FindObjectOfType<GameManager>().state != BattleState.ENERMYTURN)
        return;

        StartCoroutine(EnemyRollingDice());
    }

    IEnumerator EnemyRollingDice()
    {
        edice1 = (Random.Range(0, 5));
        edice2 = (Random.Range(0, 5));
        edice3 = (Random.Range(0, 5));
        edice4 = (Random.Range(0, 5));
        ediceTotal = ((edice1 + edice2) + (edice3 + edice4));
        FindObjectOfType<AnimateManager>().EnemyRoll(edice1, edice2, edice3, edice4);

        yield return new WaitForSecondsRealtime(FindObjectOfType<AnimateManager>().rollTime + FindObjectOfType<GameManager>().atkTime);
        
        FindObjectOfType<GameManager>().EnemyAttack(ediceTotal);


        if(((edice1 == edice2) & (edice2 == edice3)) | ((edice1 == edice2) & (edice2 == edice4)) | ((edice1 == edice3) & (edice3 == edice4)) | ((edice2 == edice3) & (edice3 == edice4)))
        {
            FindObjectOfType<GameManager>().eluckyRoll = true;
        }
        
    }

    
}
