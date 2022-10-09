using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public bool attacking = false;

    private float timeToAttack = 0.25f;
    private float timer = 0f;
    private int indexWeapon = 0;

    public Animator animator;
    public Animator weaponAnimator;
    public AnimatorOverrideController animatorOverride;

    // private Equipment[] equipWeapon = new Equipment[5];
    Equipment equipWeapon;
    public EquipmentManager equipmentManager;
    void Start()
    {
       equipmentManager = EquipmentManager.instance;
       weaponAnimator.runtimeAnimatorController = animatorOverride;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            
            Attack();
        }

        if (attacking)
        {
            timer += Time.deltaTime;

            if(timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
            }
        }
    }

    private void Attack()
    {       
        if (equipmentManager.AttackCmd(indexWeapon) < 5)
        {
            attacking = true;
            //string usingweapon = equipmentManager.currentEquipCard[indexWeapon].animationWeapon.ToString();
            animatorOverride["Sword_Sprite"] = equipmentManager.currentEquipCard[indexWeapon].animationWeapon;
            indexWeapon += 1;
            //animator.SetBool("attacking", attacking);
            animator.SetTrigger("attack");

            // Debug.Log("Using "+ usingweapon);
            //animator.runtimeAnimatorController.n
            //weaponAnimator.SetBool("WeaponAttack", attacking);
            //animatorOverride.ApplyOverrides(equipmentManager.currentEquipCard[indexWeapon].animationWeapon);
            //animatorOverride = equipmentManager.currentEquipCard[indexWeapon].animationWeapon;
            
            weaponAnimator.SetTrigger("WeaponAttack");
            // Play weapon Animation
            //weaponAnimator.GetComponent<Animator>();           
            //string currentWeaponAnimation = equipmentManager.currentEquipCard[indexWeapon - 1].animationWeapon.name;
            // Debug.Log("animate : "+ currentWeaponAnimation);
            //weaponAnimator.SetTrigger(currentWeaponAnimation);          
            if (indexWeapon >= 5)
            {
                indexWeapon = 0;
            }
            
        }
        else
        {
            Debug.Log("Can't Attack");
            attacking = false;
            indexWeapon = 0;
        }      
    }

  
}
