using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class InstatiatePoolObject : MonoBehaviour
{
    [SerializeField]

    private GameObject _prefab;
    [SerializeField]
    private Transform _parent;

    private List<GameObject> _pool = new();
    private GameObject _currentObject;

    public void InstatiateObject(Transform target)
    {
        _currentObject = GetPooledObject();
        if (_currentObject != null)
        {
            PositionObject(obj, target.position, target.rotation);
        }
    }

    public void InstatiateObject(Vector3 position)
    {
        _currentObject = GetPooledObject();
        if (_currentObject != null)
        {
            PositionObject(_currentObject, position, Quaternion.identity);
        }
    }

    private void PositionObject(GameObject obj, Vector3 position, Quaternion rotation)
    {
        if (_parent != null)
        {
            obj.transform.SetParent(_parent, false);
            obj.transform.SetLocalPositionAndRotation(position, rotation);
        }
        else
        {
            obj.transform.SetLocalPositionAndRotation(position, rotation);
        }
        obj.SetActive(true);
    }
    private GameObject GetPooledObject()
    {
        GameObject obj = null;
        obj = _pool.Find(x => !x.activeInHierarchy);
        if (obj == null)
        {
            obj = Instantiate(_prefab);
            _pool.Add(obj);
            obj.SetActive(false);
        }
        return obj;
    }

    public void DesactivateAllObjects()
    {
        foreach (GameObject obj in _pool)
        {
            if (obj != null && obj.activeInHierarchy)
            {
                obj.SetActive(false);
            }
        }
    }
}
