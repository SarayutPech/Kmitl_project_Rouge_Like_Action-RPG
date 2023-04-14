using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipSystem : MonoBehaviour
{
    private static TooltipSystem current;
    public Tooltip tooltip;
    public void Awake()
    {
        current = this;
    }

    public static void Show(string content, string header = "")
    {
        try
        {
            current.tooltip.SetText(content, header);
            current.tooltip.gameObject.SetActive(true);
        }
        catch
        {
            Debug.Log("Cannot show tooltip");
        }
       
    }

    public static void Hide()
    {
        try
        {
            current.tooltip.gameObject.SetActive(false);
        }
        catch
        {
            Debug.Log("Tooltip Error");
        }
        
    }
}
