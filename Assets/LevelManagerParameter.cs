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
        try {
            // agentMoveStep ให้ Agent สร้างกี่ห้อง
            agentMoveStep = agentMoveStep + (GameObject.Find("GameManager").GetComponent<ResultScreen>().boss_defeated) * 2;
            // enemyPerWave;
            enemyPerWave = enemyPerWave + GameObject.Find("GameManager").GetComponent<ResultScreen>().boss_defeated;
            // DmgBuffer;
            DmgBuffer = DmgBuffer + ((GameObject.Find("GameManager").GetComponent<ResultScreen>().boss_defeated) * 5 + (GameObject.Find("GameManager").GetComponent<ResultScreen>().floor_clear));
            // HpBuffer;
            HpBuffer = HpBuffer + ((GameObject.Find("GameManager").GetComponent<ResultScreen>().boss_defeated) * 5 + (GameObject.Find("GameManager").GetComponent<ResultScreen>().floor_clear));
        }
        catch
        {
            Debug.Log("Game System not in Scene.");
        }
        
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
