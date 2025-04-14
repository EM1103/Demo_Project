using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    // Core stats
    [Header("Core Stats")]
    public int empathy = 0;
    public int curiosity = 0;
    public int defiance = 0;
    public int resolve = 0;
    public int corruption = 0;

    // Chapter keys
    [Header("Chapter Keys")]
    public int key_p = 0;
    public int key_1 = 0;
    public int key_2 = 0;
    public int key_3 = 0;
    public int key_4 = 0;
    public int key_5 = 0;

    // Inventory stats
    [Header("Inventory stats")]
    public int search_1 = 0;
    public int journal = 0;
    public int flyer = 0;
    public int amulet = 0;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
}
