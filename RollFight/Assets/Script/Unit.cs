using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Unit : MonoBehaviour
{
    public string unitName;
    public float maxhp;
    public float currenthp;
    public float atk;
    public float def;
    float damage;
    public TextMeshProUGUI dmgText;
    public AudioClip myAtk;
    public AudioClip myDead;
    public float buffAmount = 0;

    public bool TakeDamage(float dice, float atk)
    {
        damage = (dice * (atk / def));
        currenthp -= Mathf.RoundToInt(damage);
        StartCoroutine(ShowPlayerDmg(Mathf.RoundToInt(damage)));

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

    public void UpgradeAll()
    {
        HpUpgrade(5);
        AtkUpgrade(2);
        DefUpgrade(2);
        Heal(10);
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
        if (maxhp < currenthp)
        {
            currenthp = maxhp;
        }
    }
    public void BuffAction(float dice)
    {
        float amount = Mathf.RoundToInt(dice / 4);
        buffAmount += amount;
        atk += amount;
        def += amount;
    }

    public void HealAction(float dice)
    {
        float amount = Mathf.RoundToInt((dice / 24) * 100);
        buffAmount += amount;
        atk += amount;
        def += amount;
    }

    public void ResetBuff()
    {        
        atk -= buffAmount;
        def -= buffAmount;
        
        StartCoroutine(ResetBuffAmount());
    }

    IEnumerator ResetBuffAmount()
    {
        yield return new WaitForSeconds(1f);
        buffAmount = 0;
    }
}
