using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCard_AnimationOverride : MonoBehaviour
{

    public Animator weaponAnimator;
    public AnimatorOverrideController animatorOverride;
    public EquipmentManager equipmentManager;
    private string[] animationName = {"1stAttack","2ndAttack","3rdAttack","4thAttack","5thAttack"};
    // Start is called before the first frame update
    void Start()
    {
        equipmentManager = EquipmentManager.instance;
        weaponAnimator.runtimeAnimatorController = animatorOverride;
        equipmentManager.onEquipmentChanged += OnEquipmentChanged;
    }

    // Update is called once per frame
    /*public void OverrideAnimationWeapon()
    {

        
    }*/
    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        for (int i = 0; i < 5; i++)
        {
            if (equipmentManager.currentEquipCard[i] != null)
            {
                animatorOverride[animationName[i]] = equipmentManager.currentEquipCard[i].animationWeapon;
            }
            else
            {
                break;
            }

        }
    }
    }
