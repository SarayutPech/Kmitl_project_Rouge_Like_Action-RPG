using UnityEngine;

public class MessageSpawner : MonoBehaviour
{
    [SerializeField]
    private Vector2 initPosition;
    [SerializeField]
    private GameObject messagePrefab;


   public void SpawnMessage(string msg)
    {
        var msgObject = Instantiate(messagePrefab, GetSpawnPosition(), Quaternion.identity);
        var inGameMessage = msgObject.GetComponent<FloatingMessage>();

        inGameMessage.SetMessage(msg);
    }

    public void EnemySpawnMessage(Collider2D t , string msg, bool isCrit)
    {
        Vector3 enemyPos = t.GetComponent<Rigidbody2D>().transform.position + (Vector3)initPosition;

        var msgObject = Instantiate(messagePrefab, enemyPos, Quaternion.identity);
        var inGameMessage = msgObject.GetComponent<FloatingMessage>();

        inGameMessage.EnemyMessage(msg,isCrit);
    }

    public void EnemySpawnSkillMessage(Collider2D t, string msg)
    {
        Vector3 enemyPos = t.GetComponent<Rigidbody2D>().transform.position + (Vector3)initPosition;

        var msgObject = Instantiate(messagePrefab, enemyPos, Quaternion.identity);
        var inGameMessage = msgObject.GetComponent<FloatingMessage>();

        inGameMessage.SkillMessage(msg);
    }

    private Vector3 GetSpawnPosition()
    {
        return transform.position + (Vector3)initPosition;
    }
}
