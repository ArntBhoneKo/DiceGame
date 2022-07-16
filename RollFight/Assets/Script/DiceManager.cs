using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    public int[] diceRoll;

    public int GetDiceValue(int index)
    {
        return diceRoll[index];
    }
}
