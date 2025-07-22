using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
    public float runSpeed = 5f;
    public float attackDamage = 10f;
    public float attackRange = 2f;
    public float attackDuration = 1f;
    public float attackWaitTime = 0.5f;
    public string runAnimationName = "Run";
    public string attackAnimationName = "Attack";
    public string deathAnimationName = "Death";
    public string hitAnimationName = "Hit";
    public string winAnimationName = "Win";
}
