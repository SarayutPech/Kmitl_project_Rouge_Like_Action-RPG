using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public bool attacking = false;
    public Vector2 playerHitbox;
    public Vector2 playerForceAttack;
    public Transform playerAttackHitbox;
    public LayerMask enemyLayer;
    private float timeToAttack = 0.20f;
    private float timer = 0f;
    private int indexWeapon = 0;



    public Animator animator;
    public Animator weaponAnimator;
    public AnimatorOverrideController animatorOverride;

    // private Equipment[] equipWeapon = new Equipment[5];
   // Equipment equipWeapon;
    public EquipmentManager equipmentManager;
    void Start()
    {
       equipmentManager = EquipmentManager.instance;
       weaponAnimator.runtimeAnimatorController = animatorOverride;
    }

    private void Awake()
    {
        equipmentManager = GameObject.Find("GameManager").GetComponent<EquipmentManager>();
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
            Collider2D[] enemyHit = Physics2D.OverlapBoxAll(playerAttackHitbox.position, playerHitbox, 0, enemyLayer);
            

            attacking = true;
            //Override Animation clip 
            animatorOverride["Sword_Sprite"] = equipmentManager.currentEquipCard[indexWeapon].animationWeapon;

            //Draw Weapon Hitbox
            //ChangeGizmos(equipmentManager.currentEquipCard[indexWeapon].hitboxWeapon);
            

            //knockback Enemy When hit
            foreach (Collider2D i in enemyHit)
            {
                i.GetComponent<Rigidbody2D>().AddForce(equipmentManager.currentEquipCard[indexWeapon].forceWeapon * ScaleX(), ForceMode2D.Impulse);
                //i.GetComponent<Animator>().SetTrigger("getHit");
                Debug.Log("Attack Enemy " + i);
                i.GetComponent<EnemyStat>().setHp(20);
            }


            
            // Play weapon Animation
            animator.SetTrigger("attack");
            weaponAnimator.SetTrigger("WeaponAttack");

            indexWeapon += 1;
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(playerAttackHitbox.position, playerHitbox);

        try
        {
            if (equipmentManager.currentEquipCard[indexWeapon - 1].hitboxWeapon != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireCube(playerAttackHitbox.position, equipmentManager.currentEquipCard[indexWeapon - 1].hitboxWeapon);
            }
        }
        catch { }
       
        

      
    }

    private void ChangeGizmos(Vector2 weaponHitbox)
     {
           Gizmos.color = Color.red;
         Gizmos.DrawWireCube(playerAttackHitbox.position, weaponHitbox);

     }
    public float ScaleX()
    {
        return transform.root.gameObject.transform.localScale.x;
    }

}
