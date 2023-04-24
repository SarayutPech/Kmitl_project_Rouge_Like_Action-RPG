using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomFade : MonoBehaviour
{
    public Animator Anim;
    public float TimeCountDown;

    // Update is called once per frame
    void Update()
    {
        if (TimeCountDown > 0)
            TimeCountDown -= Time.deltaTime;
        else
        {
            Anim.SetTrigger("Fade");
        }
        
    }
}
