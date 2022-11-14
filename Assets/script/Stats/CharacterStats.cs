
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

    void Awake()
    {


        if (instance != null)
        {
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
            TakeDamage(attack.GetValue());
        }
    }

    public virtual void Die()
    {
        //Die need to be Overwritten
        Debug.Log(transform.name + " die.");
    }

}
