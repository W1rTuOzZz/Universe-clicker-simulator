using UnityEngine;

public class GameData : MonoBehaviour
{
    [Header("Currency")]
    public float gravityCount;
    public float clickPower = 1f;

    [Header("Levels & Evolution")]
    public int gravityLevel = 1;
    public int nextLevelCost = 1000;
    public int maxGravityLevel = 5;

    [Header("Passive Income")]
    public float autoClickTime = 0f;
    public float autoClickSpeed = 0.5f;
    public float passiveIncomeUpgradeCost = 10f;
    
    // Сюда же можно добавить остальные переменные стоимости апов
}