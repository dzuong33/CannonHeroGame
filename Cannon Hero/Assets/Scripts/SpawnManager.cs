using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject levelPrefab;
    [SerializeField] private int numberOfLevels = 3;
    [SerializeField] private float levelDistance = 7.3f;
    private static List<GameObject> levels;

    [SerializeField] private float levelTransitionSpeed;
    public static bool isChangingLevel;

    public void Renew()
    {
        SpawnManager.isChangingLevel = false;
        levels[1].GetComponent<Level>().Renew();
        for (int i = 0; i < numberOfLevels; i++)
        {
            levels[i].transform.position = new Vector3(levelDistance * i - levelDistance, 0f, 0f);
        }
    }

    private void Awake()
    {
        levels = new List<GameObject>();
        for (int i = 0; i < numberOfLevels; ++i)
        {
            GameObject level = Instantiate(levelPrefab, new Vector3(levelDistance * i - levelDistance, 0f, 0f), Quaternion.identity, transform);
            levels.Add(level);
        }
    }

    private void Update()
    {
        if (SpawnManager.isChangingLevel)
        {
            Debug.Log("Changing");
            if (levels[1].transform.position.x > -levelDistance)
            {
                foreach (var level in levels)
                    level.transform.Translate(Vector3.left * levelTransitionSpeed * Time.deltaTime);

                if (levels[1].transform.position.x <= -levelDistance)
                {
                    // move the old level to the end of list and renew it
                    GameObject _level = levels[0];
                    _level.GetComponent<Level>().Renew();
                    levels.RemoveAt(0);
                    levels.Add(_level);

                    for (int i = 0; i < numberOfLevels; ++i)
                        levels[i].transform.position = new Vector3(levelDistance * i - levelDistance, 0f, 0f);

                    SpawnManager.isChangingLevel = false;
                    GamePlay.isPlayerTurn = true;
                }
            }
        }
    }

    public static GameObject GetCurrentLevel()
    {
        return levels[1];
    }
}