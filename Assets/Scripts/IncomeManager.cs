using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncomeManager : MonoBehaviour
{
  [HideInInspector]
  public int income = 0;

  public void AddIncome(int amount) {
    income += amount;
  }
}
