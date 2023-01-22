using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardChest : MonoBehaviour
{
    public float x, y;

    public LayerMask player;
    public GameObject slider;
    private float progressBar = 0;
    public float maxProgressValue;
    public Animator anim;

    public bool notOpen = true;
    public GameObject key_rawImg;

    private LevelManagerParameter levelManagerParameter;

    private void Awake()
    {
        slider.GetComponent<Slider>().maxValue = maxProgressValue;
        anim = GetComponent<Animator>();
        levelManagerParameter = GameObject.Find("level manager").GetComponent<LevelManagerParameter>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D playerCol = Physics2D.OverlapBox(transform.position, new Vector2(x, y), 0f, player);
        if (playerCol && notOpen)
        {
            slider.SetActive(true);
            if (progressBar < maxProgressValue)
            {
                progressBar += Time.deltaTime;
                slider.GetComponent<Slider>().value = progressBar;
            }
            else
            {
                notOpen = false;
                slider.SetActive(false);
                // Do something
                giveReward();
            }
        }
        else
        {
            slider.SetActive(false);
            progressBar = 0;
        }
    }

    private void giveReward()
    {
        // give key
        anim.SetTrigger("Open");
        levelManagerParameter.givekeys();

        // give Item
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, new Vector2(x, y));
    }
}
