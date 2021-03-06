using UnityEngine;
using System.Collections;

public class World : MonoBehaviour
{
    // drag in the prefab for basic kernel
    public Object kernel;
    public int count = 30;
	GameObject[] KernelList;
    
    public const int READY = 0;
    public const int STARTING = 1;
    public const int RUNNING = 2;
    public const int DONE = 3;
    public static bool grav = true;

    void Start()
    {
        KernelList = new GameObject[count];
        Set();
    }

    void Update()
    { 
        if (TimerScript.state == DONE && TimerScript.time < -5f)
        {
            if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
            {
                Set();
            }
        }
    }

    void Set()
    {
        for (int i = 0; i < count; i++)
        {
            Destroy(KernelList[i]);
        }
        for (int i = 0; i < count; i++)
        {
            KernelList[i] = (GameObject)Instantiate(kernel,new Vector3(0,0,0),new Quaternion(0,0,0,0));
        }
    }
}