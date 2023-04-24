using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHPBar : MonoBehaviour
{
    public GameObject HPBar;

    public void showHPBar()
    {
        HPBar.SetActive(true);
    }
}
