using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageAttack : MonoBehaviour
{
    public BossMagePattern mage;
    public int dmg = 10;
    public GameObject fireBall;


    public void attack1() {
        for (int i = 0; i < 7; i++)
        {
            GameObject fb = (GameObject)Instantiate(fireBall, new Vector3(Random.Range(-8.2f, 8.2f), 6, -6.6f), transform.rotation * Quaternion.Euler(0, 0, -90));
            fb.GetComponent<Fireball>().dir = new Vector3(0, -1, 0);
        }
        
    }
    public void attack2() {

        for(int i = 0; i < 7; i++)
        {
            switch (Random.Range(0, 1))
            {
                case 0:
                    GameObject fb = (GameObject)Instantiate(fireBall, new Vector3(-10, Random.Range(-4.25f, 4f), -6.6f), transform.rotation * Quaternion.Euler(0, 0, 0));
                    fb.GetComponent<Fireball>().dir = new Vector3(1, 0, 0);
                    break;
                case 1:
                    GameObject fb2 = (GameObject)Instantiate(fireBall, new Vector3(10, Random.Range(-4.25f, 4f), -6.6f), transform.rotation * Quaternion.Euler(0, 0, 180));
                    fb2.GetComponent<Fireball>().dir = new Vector3(-1, 0, 0);
                    break;
            }
        }
        

        
    }
    public void attack3() {
        for (int i = 0; i < 7; i++)
        {
            GameObject fb = (GameObject)Instantiate(fireBall, new Vector3(Random.Range(-8.2f, 8.2f), -6, -6.6f), transform.rotation * Quaternion.Euler(0, 0, 90));
            fb.GetComponent<Fireball>().dir = new Vector3(0, 1, 0);
        }
        
    }
    public void warp() {
        List<GameObject> warpPoint = new List<GameObject>();
        foreach (GameObject platform in GameObject.FindGameObjectsWithTag("PCG_OB"))
        {
            warpPoint.Add(platform);
        }

        int rand = Random.Range(0, warpPoint.Count);
        transform.root.position = warpPoint[rand].transform.position + new Vector3(0,1,0);
    }


}
