using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private EnemyData _enemyData;
    private Health _targetHealth;
    private Vector3 _targetPosition;
    private bool _isRunning;
    [SerializeField]
    private UnityEvent _onInitialized;
    [SerializeField]
    private string _targetTag = "Tower";
    private void OnEnable()
    {
        _onInitialized?.Invoke();
        _isRunning = false;
        Invoke("GetTarget", 0.5f);
    }
    private void GetTarget()
    {
        GameObject targetObject = GameObject.FindGameObjectWithTag(_targetTag);
        if (targetObject != null)
        {
            _targetPosition = new Vector3(targetObject.transform.position.x, transform.position.y, targetObject.transform.position.z);
            _targetHealth = targetObject.GetComponent<Health>();
            _isRunning = true;
            _animator.Play(_enemyData.runAnimationName);
        }
    }
    private void Update()
    {
        if (_isRunning)
        {
            transform.LookAt(_targetPosition);
            Vector3 movePosition = Vector3.MoveTowards(transform.position, _targetPosition, _enemyData.runSpeed * Time.deltaTime);
            transform.position = movePosition;
            if (Vector3.Distance(transform.position, _targetPosition) <= _enemyData.attackRange)
            {
                _isRunning = false;
                StartCoroutine(Attack());
            }
        }
    }
    private IEnumerator Attack()
    {
        while (_targetHealth != null && _targetHealth.CurrentHealth > 0)
        {
            _animator.Play(_enemyData.attackAnimationName, 0, 0f);
            yield return new WaitForSeconds(_enemyData.attackDuration);
            _targetHealth.TakeDamage(_enemyData.attackDamage);
            yield return new WaitForSeconds(_enemyData.attackWaitTime);
        }
        Win();
    }
    private void Win()
    {
        _animator.Play(_enemyData.winAnimationName);
        _isRunning = false;
    }
    private void Die()
    {
        _isRunning = false;
        StopAllCoroutines();
        StartCoroutine(DieCoroutine());
    }
    private IEnumerator DieCoroutine()
    {
        _animator.Play(_enemyData.dieAnimationName);
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        _isRunning = false;
        _targetHealth = null;
        StopAllCoroutines();
    }
}
