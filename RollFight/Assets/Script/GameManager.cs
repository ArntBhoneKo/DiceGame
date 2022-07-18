using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START, PLAYERTURN, ENERMYTURN, WON, LOST }

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject[] enemyPrefab;
    public Transform playerBattleStation;
    public Transform enemyBattleStation;
    GameObject enemyGO;
    public Unit playerUnit;
    Unit enemyUnit;
    public float atkTime = 1f;
    public bool luckyRoll = false;
    public bool eluckyRoll = false;
    public int currentRound = 0;
    public int action = 0;
    public BattleState state;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        FindObjectOfType<AnimateManager>().playerAnimator = playerGO.transform.GetChild(0).gameObject.GetComponent<Animator>();
        playerUnit = playerGO.GetComponent<Unit>();

        enemyGO = Instantiate(enemyPrefab[currentRound], enemyBattleStation);
        FindObjectOfType<AnimateManager>().enemyAnimator = enemyGO.transform.GetChild(0).gameObject.GetComponent<Animator>();
        enemyUnit = enemyGO.GetComponent<Unit>();

        FindObjectOfType<AudioManager>().SetEAudios(enemyUnit.myAtk, enemyUnit.myDead);
        FindObjectOfType<UIManager>().ChangeStatsEnemy(enemyUnit);
        FindObjectOfType<UIManager>().ChangeStatsPlayer(playerUnit);
        currentRound++;
        FindObjectOfType<UIManager>().ChangeRound(currentRound);

        yield return new WaitForSeconds(1f);

        PlayerTurn();
    }

    void PlayerTurn()
    {
        state = BattleState.PLAYERTURN;
        luckyRoll = false;

        FindObjectOfType<UIManager>().ChangePlayerTurn();
        FindObjectOfType<ButtonControl>().buttonpressed = false;
    }

    public void EnemyTurn()
    {
        FindObjectOfType<ButtonControl>().EnemyRollDice();
    }

    public void EnemyAttack(int ediceTtl)
    {
        bool isDead = playerUnit.TakeDamage(ediceTtl, enemyUnit.atk);

        UIUpdate();
        StartCoroutine(EnemyEndTurn(isDead));
    }

    public void PlayerAttack(int diceTtl)
    {
        if (action == 0)
        {
            bool isDead = enemyUnit.TakeDamage(diceTtl, playerUnit.atk);

            UIUpdate();
            StartCoroutine(PlayerEndTurn(isDead));
        }
        else if (action == 1)
        {
            playerUnit.BuffAction(diceTtl);
            UIUpdate();
            StartCoroutine(PlayerEndTurn(false));
        }
        else if (action == 2)
        {
            playerUnit.HealAction(diceTtl);
            UIUpdate();
            StartCoroutine(PlayerEndTurn(false));
        }
    }

    void EndBattle()
    {
        if(state == BattleState.WON)
        {
            if (currentRound < enemyPrefab.Length)
            {
                playerUnit.ResetBuff();
                FindObjectOfType<AudioManager>().EDeadAudio();
                FindObjectOfType<UIManager>().OpenWinScreen();
            }
            else
            {
                FindObjectOfType<UIManager>().EndGameScreen();
            }

        }
        else if(state == BattleState.LOST)
        {
            FindObjectOfType<AudioManager>().PDeadAudio();
            FindObjectOfType<UIManager>().OpenLoseScreen();
        }
    }

    void ChangeEnemyTurn()
    {
        state = BattleState.ENERMYTURN;
        eluckyRoll = false;
        
        FindObjectOfType<UIManager>().ChangeEnemyTurn();
    }

    IEnumerator PlayerEndTurn(bool isDead)
    {
        yield return new WaitForSeconds(1f);
        if (!luckyRoll)
        {
            if(isDead)
            {
                FindObjectOfType<AnimateManager>().EnemyAnimDeath(true);
                state = BattleState.WON;
                EndBattle();
            }
            else
            {
                ChangeEnemyTurn();
                EnemyTurn();
            }
        }
        else
        {
            if(isDead)
            {
                FindObjectOfType<AnimateManager>().EnemyAnimDeath(true);
                state = BattleState.WON;
                EndBattle();
            }
            else
            {
                PlayerTurn();
                FindObjectOfType<UIManager>().Again();
            }
        }
    }

    IEnumerator EnemyEndTurn(bool isDead)
    {
        yield return new WaitForSeconds(1f);
        if (!eluckyRoll)
        {
            if(isDead)
            {
                FindObjectOfType<AnimateManager>().PlayerAnimDeath(true);
                state = BattleState.LOST;
                EndBattle();
            }
            else
            {
                PlayerTurn();
            }
        }
        else
        {
            if(isDead)
            {
                FindObjectOfType<AnimateManager>().PlayerAnimDeath(true);
                state = BattleState.LOST;
                EndBattle();
            }
            else
            {
                state = BattleState.ENERMYTURN;
                ChangeEnemyTurn();
                EnemyTurn();
                FindObjectOfType<UIManager>().Again();
            } 
        }
    }

    void UIUpdate()
    {
        FindObjectOfType<UIManager>().ChangeStatsEnemy(enemyUnit);
        FindObjectOfType<UIManager>().ChangeStatsPlayer(playerUnit);
    }

    public void NextRound()
    {
        playerUnit.UpgradeAll();
        Destroy(enemyGO);
        enemyGO = Instantiate(enemyPrefab[currentRound], enemyBattleStation);
        FindObjectOfType<AnimateManager>().enemyAnimator = enemyGO.transform.GetChild(0).gameObject.GetComponent<Animator>();
        enemyUnit = enemyGO.GetComponent<Unit>();
        FindObjectOfType<AudioManager>().SetEAudios(enemyUnit.myAtk, enemyUnit.myDead);

        FindObjectOfType<UIManager>().ChangeStatsEnemy(enemyUnit);
        FindObjectOfType<UIManager>().ChangeStatsPlayer(playerUnit);
        currentRound++;
        FindObjectOfType<UIManager>().ChangeRound(currentRound);

        PlayerTurn();
    }
}
