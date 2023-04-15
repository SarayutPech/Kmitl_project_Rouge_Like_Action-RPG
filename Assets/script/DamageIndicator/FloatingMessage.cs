using TMPro;
using UnityEngine;

public class FloatingMessage : MonoBehaviour
{
    private Rigidbody2D rb2;
    [SerializeField]
    private TextMeshProUGUI damageValue;

    public float yVelocity = 0.3f;
    public float xVelocityRange = 1f;
    public float lifeTime = 0.5f;

    private void Awake()
    {
        rb2 = GetComponent<Rigidbody2D>();
        //damageValue = GetComponent<TMP_Text>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2.velocity = new Vector2(Random.Range(-xVelocityRange, xVelocityRange), yVelocity);
        Destroy(gameObject, lifeTime);
    }

    public void SetMessage (string msg)
    {
        try
        {
        damageValue.SetText(msg);
        }
        catch
        {

        }
    }

    public void EnemyMessage(string msg , bool isCrit)
    {
        try
        {
            if (isCrit)
            {
                damageValue.color = Color.yellow;
                damageValue.SetText(msg);
                damageValue.text = msg;
            }
            else
            {
                damageValue.color = Color.red;
                damageValue.SetText(msg);
                damageValue.text = msg;
            }

        }
        catch
        {

        }
    }

    public void SkillMessage(string msg)
    {
        damageValue.color = Color.green;
        damageValue.SetText(msg);
        damageValue.text = msg;
    }

    
}
