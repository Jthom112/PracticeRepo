using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance; // Singleton instance

    private int ringCount = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddRing(int value)
    {
        ringCount += value;
        Debug.Log("Rings: " + ringCount);
    }

    public int GetRingCount()
    {
        return ringCount;
    }
}
