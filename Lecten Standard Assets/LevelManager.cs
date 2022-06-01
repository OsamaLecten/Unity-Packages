using System.Collections.Generic;
using UnityEngine;
using StandardAssets;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{
    public int levelCount;
    public int[] tutorialLevels;
    [Space(16)]
    public bool Testing;
    public List<int> lvl;
    public GameObject TestLevel;
    public Text levelText;
    private void Start()
    {
        SetValues();
        SpawnLevel();
    }
    private void SetValues()
    {
        for (int i = 0; i < levelCount; i++)
        {
            lvl.Add(i + 1);
        }
        if ((SA.SaveData.level + 1) >= lvl.Count)
        {
            for (int i = 0; i < tutorialLevels.Length; i++)
            {
                lvl.Remove(tutorialLevels[i]);
            }
        }
        levelText.text = "Level " + (SA.SaveData.level + 1);
    }
    private void SpawnLevel()
    {
        if (!Testing)
        {
            int index = lvl[SA.SaveData.level % lvl.Count];
            GameObject obj = Resources.Load<GameObject>("Level/Level " + index);
            Instantiate(obj);
        }
        else
        {
            Debug.LogWarning("Test level loaded.");
            GameObject obj = TestLevel;
            Instantiate(obj);
        }
    }
}