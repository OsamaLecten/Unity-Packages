using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager scr;
    public int levelCount;
    public int[] tutorialLevels;
    public GameObject openThisLevel;
    public static GameObject currentLevel;
    [Space(16)]
    public bool spawn;

    [HideInInspector]
    public List<int> lvl;
    bool allLevelsDone;
    private void Awake()
    {
        scr = this;
        SetValues();
        

    }
    private void Start()
    {
        SpawnLevel();
    }
    private void SetValues()
    {
        for (int i = 0; i < levelCount; i++)
        {
            lvl.Add(i + 1);
        }
        if ((StandardAssets.SA.GetLevel() + 1) > lvl.Count)
        {
            for (int i = 0; i < tutorialLevels.Length; i++)
            {
                lvl.Remove(tutorialLevels[i]);
            }
            allLevelsDone = true;
        }
    }
    GameObject obj;
    private void SpawnLevel()
    {
        if (spawn)
        {
            if (openThisLevel != null)
            {
                obj = openThisLevel;
            }
            else
            {
                if (!allLevelsDone)
                {
                    obj = UnityEngine.Resources.Load<GameObject>("Levels/Level " + lvl[StandardAssets.SA.GetLevel() % lvl.Count]);
                }
                else
                {
                    obj = UnityEngine.Resources.Load<GameObject>("Levels/Level " + lvl[(StandardAssets.SA.GetLevel()-tutorialLevels.Length) % lvl.Count]);
                }
                
            }

            currentLevel = Instantiate(obj);
        }
    }

}
