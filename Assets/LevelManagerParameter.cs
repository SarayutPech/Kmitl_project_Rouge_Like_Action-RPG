using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManagerParameter : MonoBehaviour
{
    [Header("Map size.")]
    public int agentMoveStep;
    [Header("Enemy amount.")]
    public int enemyPerWave;
    [Header("Enemy Buffer.")]
    public int DmgBuffer;
    public int HpBuffer;



    [Header("Keys.")]
    public bool keys = false;
    public Color haveKey;
    public Color dontHaveKey;

    private void Start()
    {
        // agentMoveStep ให้ Agent สร้างกี่ห้อง
        agentMoveStep = 3 + (GameObject.Find("GameManager").GetComponent<ResultScreen>().boss_defeated) * 5;
        // enemyPerWave;
        enemyPerWave = 2 + (GameObject.Find("GameManager").GetComponent<ResultScreen>().floor_clear);
        // DmgBuffer;
        DmgBuffer = -5 + ((GameObject.Find("GameManager").GetComponent<ResultScreen>().boss_defeated) * 5 + (GameObject.Find("GameManager").GetComponent<ResultScreen>().floor_clear) );
        // HpBuffer;
        HpBuffer = -10 + ((GameObject.Find("GameManager").GetComponent<ResultScreen>().boss_defeated) * 5 + (GameObject.Find("GameManager").GetComponent<ResultScreen>().floor_clear));
    }

    public void givekeys()
    {
        keys = true;
        GameObject.Find("Keys UI img").GetComponent<RawImage>().color = haveKey;
    }

    public void usekeys()
    {
        keys = false;
        GameObject.Find("Keys UI img").GetComponent<RawImage>().color = dontHaveKey;
    }
}
