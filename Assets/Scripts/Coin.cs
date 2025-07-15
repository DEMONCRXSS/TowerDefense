using UnityEngine;
using System.Collections;
using UnityEngine.Events;
public class Coin : MonoBehaviour
{
    [SerializeField]

    private Animator _animator;

    [SerializeField]
    private string _appearAnimationName = "CoinAppear";
    [SerializeField]
    private string _disappearAnimationName = "CoinDisappear";
    [SerializeField]

    private float _secondsToDisappear = 2f;
    private Coroutine _appearCoroutine;
    private void OnEnable()
    {
        _appearCoroutine = StartCoroutine(Appear());
    }

    private IEnumerator Appear()
    {
        _animator.Play(_appearAnimationName);
        yield return new WaitForSeconds(_secondsToDisappear);
        StartCoroutine(Disappear());
    }

    public void Collect()
    {
        Stop();
        StartCoroutine(Disappear());
    }

    private IEnumerator Disappear()
    {
        _animator.Play(_disappearAnimationName);
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
        gameObject.SetActive(false);
    }

    private void Stop()
    {
        if (_appearCoroutine != null)
        {
            StopCoroutine(_appearCoroutine);
            _appearCoroutine = null;
        }
    }
}
