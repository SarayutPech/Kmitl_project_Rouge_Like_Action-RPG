using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGuideScript : MonoBehaviour
{
    [SerializeField]GameObject buttonGuide_UI;

    public void TriggerGuideButton()
    {
        buttonGuide_UI.SetActive(!buttonGuide_UI.activeSelf);
    }
}
