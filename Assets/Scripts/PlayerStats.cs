using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    // Core stats
    public int empathy = 2;
    public int curiosity = 0;
    public int defiance = 0;
    public int resolve = 5;
    public int corruption = 0;

    // Inventory stats
    public int p_hasbook = 0;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
}
