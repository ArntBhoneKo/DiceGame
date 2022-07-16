using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject turnLight;
    public Sprite enemyTurn;
    public Sprite playerTurn;
    public GameObject again;

    [Header("Enemy")]
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI atkText;
    public TextMeshProUGUI defText;
    public Slider hpSlider;

    [Header("Player")]
    public TextMeshProUGUI pnameText;
    public TextMeshProUGUI phpText;
    public TextMeshProUGUI patkText;
    public TextMeshProUGUI pdefText;
    public Slider phpSlider;

    
    public void ChangeStatsEnemy(Unit unit)
    {
        nameText.text = unit.unitName;
        hpText.text = unit.currenthp.ToString() + "/" + unit.maxhp.ToString();
        atkText.text = unit.atk.ToString();
        defText.text = unit.def.ToString();
        hpSlider.maxValue = unit.maxhp;
        hpSlider.value = unit.currenthp;
    }

    public void ChangeStatsPlayer(Unit unit)
    {
        pnameText.text = unit.unitName;
        phpText.text = unit.currenthp.ToString() + "/" + unit.maxhp.ToString();
        patkText.text = unit.atk.ToString();
        pdefText.text = unit.def.ToString();
        phpSlider.maxValue = unit.maxhp;
        phpSlider.value = unit.currenthp;
    }

    public void ChangePlayerTurn()
    {
        turnLight.GetComponent<Image>().sprite = playerTurn; 
    }

    public void ChangeEnemyTurn()
    {
        turnLight.GetComponent<Image>().sprite = enemyTurn; 
    }

    public void Again()
    {
        StartCoroutine(AgainShow()); 
    }

    IEnumerator AgainShow()
    {
        again.SetActive(true);
        yield return new WaitForSeconds(1f);
        again.SetActive(false);
    }

}
