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
