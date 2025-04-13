using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    // Core stats
    [Header("Core Stats")]
    public int empathy = 2;
    public int curiosity = 0;
    public int defiance = 0;
    public int resolve = 5;
    public int corruption = 0;

    // Chapter keys
    [Header("Chaptere Keys")]
    public int key_p = 0;
    public int key_1 = 0;
    public int key_2 = 0;
    public int key_3 = 0;
    public int key_4 = 0;
    public int key_5 = 0;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
}
