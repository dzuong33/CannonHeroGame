using System.Collections;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    private Player player;
    public static bool isPlayerTurn, isEnemyTurn;
    public static bool isPlaying, isGameOver, isVictory;
    public void Renew()
    {
        GamePlay.isPlaying = false;
        GamePlay.isPlayerTurn = false;
        GamePlay.isEnemyTurn = false;
        GamePlay.isGameOver = false;
        GamePlay.isVictory = false;
        player.gameObject.SetActive(true);
        player.Renew();
    }

    private void Awake()
    {
        GamePlay.isPlaying = false;
        GamePlay.isPlayerTurn = false;
        GamePlay.isEnemyTurn = false;
        GamePlay.isGameOver = false;
        GamePlay.isVictory = false;
  
    }

    private void Update()
    {
        if (!GamePlay.isPlaying)
            return;

        if (!player.gameObject.activeInHierarchy)
        {
            GamePlay.isPlaying = false;
            GamePlay.isGameOver = true;
            return;
        }

        if (GamePlay.isPlayerTurn && Player.isShot)
        {
            Player.isShot = false;
            GamePlay.isPlayerTurn = false;
            StartCoroutine(CheckWinLose());
        }
    }

    private IEnumerator CheckWinLose()
    {
        yield return new WaitForEndOfFrame();

        if (GamePlay.isVictory)
        {
            GamePlay.isVictory = false;
            StartCoroutine(ChangeLevel());
        }
        else
        {
            StartCoroutine(ChangeTurn());
        }
    }

    private IEnumerator ChangeLevel()
    {
        yield return new WaitForSeconds(0.1f);
    }

    private IEnumerator ChangeTurn()
    {
        GamePlay.isPlayerTurn = false;
        yield return new WaitForSeconds(0.1f);
        GamePlay.isEnemyTurn = true;
    }
}