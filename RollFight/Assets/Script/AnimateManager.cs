using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateManager : MonoBehaviour
{
    public float rollTime = 2f;
    public Animator diceP1;
    public Animator diceP2;
    public Animator diceP3;
    public Animator diceP4;
    public Animator diceE1;
    public Animator diceE2;
    public Animator diceE3;
    public Animator diceE4;
    public Animator playerAnimator;
    public Animator enemyAnimator;

    public void Roll(int p1, int p2, int p3, int p4)
    {
        diceP1.SetBool("PRoll", true);
        diceP2.SetBool("PRoll", true);
        diceP3.SetBool("PRoll", true);
        diceP4.SetBool("PRoll", true);
        StartCoroutine(RollingDice(p1, p2, p3, p4));
    }

    IEnumerator RollingDice(int pd1, int pd2, int pd3, int pd4)
    {
        diceP1.SetInteger("PDiceNum", pd1);
        diceP2.SetInteger("PDiceNum", pd2);
        diceP3.SetInteger("PDiceNum", pd3);
        diceP4.SetInteger("PDiceNum", pd4);
        yield return new WaitForSecondsRealtime(rollTime);
        
        diceP1.SetBool("PRoll", false);
        diceP2.SetBool("PRoll", false);
        diceP3.SetBool("PRoll", false);
        diceP4.SetBool("PRoll", false);

        yield return new WaitForSecondsRealtime(FindObjectOfType<GameManager>().atkTime);
        EnemyAnimHit();
        PlayerAnimAtk();
    }

    public void EnemyRoll(int e1, int e2, int e3, int e4)
    {
        diceE1.SetBool("ERoll", true);
        diceE2.SetBool("ERoll", true);
        diceE3.SetBool("ERoll", true);
        diceE4.SetBool("ERoll", true);
        StartCoroutine(EnemyRollingDice(e1, e2, e3, e4));
    }

    IEnumerator EnemyRollingDice(int ed1, int ed2, int ed3, int ed4)
    {
        diceE1.SetInteger("EDiceNum", ed1);
        diceE2.SetInteger("EDiceNum", ed2);
        diceE3.SetInteger("EDiceNum", ed3);
        diceE4.SetInteger("EDiceNum", ed4);
        yield return new WaitForSecondsRealtime(rollTime);
        
        diceE1.SetBool("ERoll", false);
        diceE2.SetBool("ERoll", false);
        diceE3.SetBool("ERoll", false);
        diceE4.SetBool("ERoll", false);

        yield return new WaitForSecondsRealtime(FindObjectOfType<GameManager>().atkTime);
        EnemyAnimAtk();
        PlayerAnimHit();
    }

    public void PlayerAnimHit()
    {
        playerAnimator.SetTrigger("Hit");
    }

    public void PlayerAnimAtk()
    {
        playerAnimator.SetTrigger("Atk");
    }

    public void PlayerAnimDeath(bool alive)
    {
        playerAnimator.SetBool("Dead", alive);
    }

    public void EnemyAnimHit()
    {
        enemyAnimator.SetTrigger("Hit");
    }

    public void EnemyAnimAtk()
    {
        enemyAnimator.SetTrigger("Atk");
    }

    public void EnemyAnimDeath(bool alive)
    {
        enemyAnimator.SetBool("Dead", alive);
    }
}
