using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class DragAndDropObject : MonoBehaviour
{
    [SerializeField]
    Transform _targetGameObject;
    Vector3 _defaultPos;
    Vector3 _defaultRotation;
    Ray _ray;
    
    void Start()
    {
        _defaultPos = this.transform.position;
        _defaultRotation = this.transform.eulerAngles;
    }

    public void OnDragObject()
    {
        this.transform.SetParent(Camera.main.transform);
        GetComponent<Collider>().enabled = false;
    }

    public void DropObject()
    {
        _ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if (Physics.Raycast(_ray, out RaycastHit hitInfo, 1000f))
        {
            if (hitInfo.collider.gameObject.name.CompareTo(_targetGameObject.name) == 0)
            {
                this.transform.DOMove(_targetGameObject.position, 1f);
                this.transform.DORotate(_targetGameObject.eulerAngles, 1f);
                Destroy(this.gameObject, 1f);
            }
            else
            {
                StartCoroutine(ResetToDefault());
            }

        }
        else
        {
            StartCoroutine(ResetToDefault());
        }
       
    }

    IEnumerator ResetToDefault()
    {
        this.transform.SetParent(null);
        this.transform.DOMove(_defaultPos, 1f);
        this.transform.DORotate(_defaultRotation, 1f);
        yield return new WaitForSeconds(1f);
        GetComponent<Collider>().enabled = true;  
        
    }
}
