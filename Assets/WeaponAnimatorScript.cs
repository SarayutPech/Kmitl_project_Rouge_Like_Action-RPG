using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimatorScript : MonoBehaviour
{

    public Animator weaponAnimator;
    public AnimatorOverrideController animatorOverride;
    // Start is called before the first frame update
    void Start()
    {
        weaponAnimator = gameObject.GetComponent<Animator>();
        weaponAnimator.runtimeAnimatorController = animatorOverride;       
    }

    public void CallWeaponAnimator()
    {
        weaponAnimator.SetTrigger("WeaponAttack");
    }
}
