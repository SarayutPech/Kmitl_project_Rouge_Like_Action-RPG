using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveSlot : MonoBehaviour
{
    [SerializeField]
    GameObject hasSave, emptySave;
    [SerializeField]
    TextMeshProUGUI leveltext;
    public void ShowData()
    {
        hasSave.SetActive(true);
        emptySave.SetActive(false);

    }

    public void ShowEmpty()
    {
        hasSave.SetActive(false);
        emptySave.SetActive(true);
    }

    public void setShowData(int level)
    {
        leveltext.text = level.ToString();
    }

}
