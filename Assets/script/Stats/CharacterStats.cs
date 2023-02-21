
using UnityEngine;

public class CharacterStats : MonoBehaviour
{


    #region Singleton
    public static CharacterStats instance;
    
    #endregion

    public int maxHealth = 100;
    public int maxStatPoint = 30;
    public int currentHealth { get; private set; }

    public HealthBar healthBar;

    //Status
    public Stats str,vit,agi,dex,luk;

    //Parameter
    public Stats attack;
    public Stats critRate;
    public Stats critDamage;
    public Stats moveSpeed;
    public Stats dropRate;
    public Stats hp;


    //Skill
    public bool heavyArmorisActive;

    public bool deflectisActive;
    public float deflectChance = 0.2f;


    void Awake()
    {


        if (instance != null)
        {
            instance = this;
            Debug.LogWarning("Character Stat more than one instance !");
        }
        instance = this;

        healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);

       

    }


    public void TakeDamage(int damage)
    {
       
        damage = HeavyArmor_Skill(heavyArmorisActive,damage);
        damage = Deflect_Skill(deflectisActive, damage);

        damage = Mathf.Clamp(damage, 0, int.MaxValue);//damage not below 0
        currentHealth -= damage;

        Debug.Log(transform.name + "Take " + damage + " Damage.");

        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0)
        {
            //Game Over
            Die();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public virtual void Die()
    {
       Result_UI gameResultUI = GameObject.Find("GameManager").GetComponent<Result_UI>();
       gameResultUI.GameOver();
    }

    public int Deflect_Skill(bool isActive , int damage)
    {
        
        if (isActive)
        {
            float randValue = Random.value;
            if (randValue < deflectChance)
            {
                Debug.Log("Deflect Activate!!");
                damage = 0;               
            }
        }

        return damage;
    }

    public int HeavyArmor_Skill(bool isActive,int damage)
    {
        if (isActive)
        {
            int incomeDamage = damage;
            float reduceDamage = 0.2f;
            damage -=  (int)(incomeDamage * reduceDamage);
            Debug.Log("Heavy Armor Activate!!");
        }
        return damage;
    }

}
