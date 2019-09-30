using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class DemoMultiThreading : MonoBehaviour
{
    bool _startNewThread = true;
    // Start is called before the first frame update
    void Update()
    {
        if (_startNewThread)
        {
            _startNewThread = false;
            try
            {
                Thread _th_1 = new Thread(NewThread_1);
                _th_1.Start();
            }
            catch
            {
                Debug.Log("FailedToInitializeNewThread");
            }
        }
        
        
    }
    
    void NewThread_1()
    {
        Debug.Log("Thread_1");
        _startNewThread = true;
        try
        {
            Thread _th_2 = new Thread(NewThread_2);
            _th_2.Start();
        }
        catch
        {
            Debug.Log("FailedToInitializeNewThread");
        }
    }

    void NewThread_2()
    {
        Debug.Log("Thread_2");
        try
        {
            Thread _th_1 = new Thread(NewThread_1);
            _th_1.Start();
        }
        catch
        {
            Debug.Log("FailedToInitializeNewThread");
        }
    }
}
