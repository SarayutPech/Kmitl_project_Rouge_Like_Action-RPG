using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveSlot : MonoBehaviour
{
    [SerializeField]
    GameObject hasSave, emptySave , deleteBtn;
    [SerializeField]
    TextMeshProUGUI leveltext;
    public void ShowData()
    {
        hasSave.SetActive(true);
        emptySave.SetActive(false);
        deleteBtn.SetActive(true);
    }

    public void ShowEmpty()
    {
        hasSave.SetActive(false);
        emptySave.SetActive(true);
        deleteBtn.SetActive(false);
    }

    public void setShowData(int level)
    {
        leveltext.text = level.ToString();
    }

}
