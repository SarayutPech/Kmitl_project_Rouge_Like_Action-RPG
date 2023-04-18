using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject extraAttackskillObj;
    [SerializeField] Transform skillSpawnPosition;
    public bool attacking = false;
    public Vector2 playerHitbox;
    public Vector2 playerForceAttack;
    public Transform playerAttackHitbox;
    public LayerMask enemyLayer;
    private float timeToAttack = 0.20f;
    private float timer = 0f;
    public int indexWeapon = 0;


    public PlayerStats charaStat;
    public Animator animator;
    public Animator weaponAnimator;
    public AnimatorOverrideController animatorOverride;
  

    // private Equipment[] equipWeapon = new Equipment[5];
   // Equipment equipWeapon;
    public EquipmentManager equipmentManager;


    //Skill Extra Attack
    public Animator skillAnimator;
    public int attackTimes = 0;
    public bool extraAttackisActive;


    //Skill Combo Strike
    public bool comboStrikeisActive;
    public float comboChance = 0.1f;

    void Start()
    {
       equipmentManager = EquipmentManager.instance;
       weaponAnimator.runtimeAnimatorController = animatorOverride;
       skillAnimator = GameObject.FindGameObjectWithTag("Animator_Skill").GetComponent<Animator>();
    }

    private void Awake()
    {
        equipmentManager = GameObject.Find("GameManager").GetComponent<EquipmentManager>();
        charaStat = GetComponent<PlayerStats>();
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
            //Override Animation clip 
            animatorOverride["Sword_Sprite"] = equipmentManager.currentEquipCard[indexWeapon].animationWeapon;

            //Draw Weapon Hitbox
            //ChangeGizmos(equipmentManager.currentEquipCard[indexWeapon].hitboxWeapon);


            //knockback Enemy When hit



            // Play weapon Animation
            animator.SetTrigger("attack");
            //weaponAnimator.SetTrigger("WeaponAttack");

            //CheckEnemyHit();



            indexWeapon += 1;
           
            if (indexWeapon >= 5)
            {
                indexWeapon = 0;
            }

            // skill Combo Strike 
            ComboStrike_Skill(comboStrikeisActive);

            // skill extra attack
            attackTimes += 1; 
            if (attackTimes >= 5 && extraAttackisActive)
            {
                attackTimes = 0;
                //Vector3 playerTrans = GameObject.FindGameObjectWithTag("Player").transform.position;
                //Vector3 pos = new Vector3(((transform.position.x+0.3f)/1.4f)*ScaleX(), transform.position.y+0.32f, transform.position.z+0f);
                //Vector3 skillpos = (playerTrans + pos);
                Instantiate(extraAttackskillObj, skillSpawnPosition.position, Quaternion.identity);
                //Debug.Log(pos);
                //skillAnimator.SetTrigger("ExtraAttack");
                Debug.Log("Skill Extra Attack Activate !");
            }else if(!extraAttackisActive)
            {
                attackTimes = 0;
            }

        }
        else
        {
            Debug.Log("Can't Attack");
            attacking = false;
            indexWeapon = 0;
        }      
    }

    public void CheckEnemyHit()
    {
        Collider2D[] enemyHit = Physics2D.OverlapBoxAll(playerAttackHitbox.position, playerHitbox, 0, enemyLayer);

        foreach (Collider2D i in enemyHit)
        {
            i.GetComponent<Rigidbody2D>().AddForce(equipmentManager.currentEquipCard[indexWeapon].forceWeapon * ScaleX(), ForceMode2D.Impulse);
            //i.GetComponent<Animator>().SetTrigger("getHit");

            if (i.GetComponent<BossStat>())
                i.GetComponent<BossStat>().setHp(charaStat.attack.GetValue());
            else if (i.GetComponent<EnemyStat>())
                i.GetComponent<EnemyStat>().setHp(charaStat.attack.GetValue());
            Debug.Log("Attack Enemy " + i + " Enemy Take" + charaStat.attack.GetValue() + "Damage.");
        }
    }

    public void CallWeaponAnimator()
    {
        weaponAnimator.SetTrigger("WeaponAttack");
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

    public void ComboStrike_Skill(bool isActive)
    {
        if (isActive)
        {
            float randValue = Random.value;
            if (randValue < comboChance)
            {
                skillAnimator.SetTrigger("ComboStrike");
                Debug.Log("Combo Strike!!");
            }
        }
    }
}
