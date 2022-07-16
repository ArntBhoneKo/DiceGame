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
    public GameObject winScreen;

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

    [Header("Cards")]
    public Sprite[] heartsCard;
    public int hearts;
    public GameObject heartbtn;
    public Sprite[] spadeCard;
    public int spades;
    public GameObject spadebtn;
    public Sprite[] diamondCard;
    public int diamonds;
    public GameObject diamondbtn;
    public Sprite[] cloverCard;
    public GameObject cloverbtn;
    public int clover;
    
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

    public void OpenWinScreen()
    {
        StartCoroutine(SetAllcard());
    }

    IEnumerator SetAllcard()
    {
        hearts = (Random.Range(0, 12));
        spades = (Random.Range(0, 12));
        diamonds = (Random.Range(0, 12));
        clover = (Random.Range(0, 12));

        yield return new WaitForSeconds(2f);
        winScreen.SetActive(true);
        SetHeartsCard(hearts);
        SetSpadeCard(spades);
        SetDiamondCard(diamonds);
        SetCloverCard(clover);
    }

    void SetHeartsCard(int index)
    {
        heartbtn.GetComponent<Image>().sprite = heartsCard[index];
    }

    void SetSpadeCard(int index)
    {
        spadebtn.GetComponent<Image>().sprite = spadeCard[index];
    }

    void SetDiamondCard(int index)
    {
        diamondbtn.GetComponent<Image>().sprite = diamondCard[index];
    }

    void SetCloverCard(int index)
    {
        cloverbtn.GetComponent<Image>().sprite = cloverCard[index];
    }

    public void CloseWinScreen()
    {
        winScreen.SetActive(false);
    }

}
