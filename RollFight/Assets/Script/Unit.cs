using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int maxhp;
    public int currenthp;
    public int atk;
    public int def;
    int damage;
    public TextMeshProUGUI dmgText;

    public bool TakeDamage(int dice, int dmg)
    {
        damage = (dice * (dmg - (def / 10)));
        currenthp -= damage;
        StartCoroutine(ShowPlayerDmg(damage));

        if(currenthp <= 0)
        {
            currenthp = 0;
            return true;
        }    
        else
            return false;
    }

    IEnumerator ShowPlayerDmg(int dmg)
    {
        dmgText = this.transform.GetChild(1).gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        dmgText.text = "-" + dmg.ToString();
        yield return new WaitForSeconds(1f);
        dmgText.text = "";
    }

    public void HpUpgrade(int amount)
    {
        maxhp = maxhp + (amount * 2);
        currenthp = currenthp + (amount * 2);
    }
    public void AtkUpgrade(int amount)
    {
        atk = atk + amount;
    }
    public void DefUpgrade(int amount)
    {
        def = def + amount;
    }
    public void Heal(int amount)
    {
        currenthp = currenthp + (amount * 5);
    }
}
