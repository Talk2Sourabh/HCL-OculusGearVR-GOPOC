using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabInstatiate : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefabToInstantiate, _parent;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GeneratePrefab());
    }

    IEnumerator GeneratePrefab()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            Instantiate(_prefabToInstantiate,_parent.transform);
        }
    }
}
