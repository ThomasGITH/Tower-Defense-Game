using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_system {

    private Wave[] waveList;
    internal uint currentWave = 0;
    internal bool ready = true;

    public Wave_system(int number_of_waves, GameObject defaultMinionType)
    {
        waveList = new Wave[number_of_waves];

        //Default wave/minion configuration
        for(uint i = 0; i < number_of_waves; i++)
        {
            waveList[i] = new Wave(defaultMinionType, 5);
        }
    }

    public Wave_system(int number_of_waves, GameObject defaultMinionType, int default_number_of_minions)
    {
        waveList = new Wave[number_of_waves];

        //Default wave/minion configuration
        for (uint i = 0; i < number_of_waves; i++)
        {
            waveList[i] = new Wave(defaultMinionType, default_number_of_minions);
        }
    }

    public void nextWave()
    {
        if (currentWave < waveList.Length && ready)
        {
            waveList[currentWave].intialize();
            currentWave++;
            ready = false;
        }
    }

    public Wave configureWave(int index)
    {
        return waveList[index];
    }

}

public class Wave
{

    private GameObject[] enemyList, parentList;
    private GameObject parent;

    public Wave(GameObject default_type, int number_of_minions)
    {
        enemyList = new GameObject[number_of_minions];

        GameObject Waves = GameObject.FindGameObjectWithTag("Wave_category");
        parent = new GameObject();
        parent.transform.parent = Waves.transform;
        parent.name = "Wave " + Waves.transform.childCount;

        for(uint i = 0; i < enemyList.Length; i++)
        {
            var go = MonoBehaviour.Instantiate(default_type, parent.transform);
            enemyList[i] = go;
            enemyList[i].SetActive(false);
        }
    }

    public void setMinions(GameObject type, params Vector2[] range)
    {
        for(uint i = 0; i < range.Length; i++)
        {
            float left = range[i].x;
            float right = range[i].y;

            for(uint j = 0; j < enemyList.Length; j++)
            {
                if(j >= left && j <= right)
                {
                    enemyList[j] = type;
                }
            }
        }
    }


    public void intialize()
    {
        for (uint i = 0; i < enemyList.Length; i++)
        {
            enemyList[i].transform.position = new Vector2(enemyList[i].transform.position.x + (i * 2.5f), enemyList[i].transform.position.y);
            enemyList[i].SetActive(true);
        }
    }

    public bool isDone()
    {
        int n = 0;
        for(uint i = 0; i < enemyList.Length; i++)
        {
            if(enemyList[i].activeSelf)
            {
                n++;
            }
        }

        if(n <= 0 )
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}