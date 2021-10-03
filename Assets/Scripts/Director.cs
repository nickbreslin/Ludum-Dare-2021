using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{
    public static Director instance;
    public GUIManager guiManager;
    public BuildingManager buildingManager;
    public IncomeManager incomeManager;
    public AlertManager alertManager;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
}
