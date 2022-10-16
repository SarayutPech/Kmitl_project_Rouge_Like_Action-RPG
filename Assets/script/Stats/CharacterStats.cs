
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; }

    public Stats attack;
    public Stats critRate;
    public Stats critDamage;
    public Stats moveSpeed;
    public Stats dropRate;
    public Stats hp;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        damage = Mathf.Clamp(damage, 0, int.MaxValue);//damage not below 0
        currentHealth -= damage;

        Debug.Log(transform.name + "Take " + damage + " Damage.");

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
        //Die need to be Overwritten
        Debug.Log(transform.name + " die.");
    }

}
