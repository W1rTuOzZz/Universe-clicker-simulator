using UnityEngine;
using TMPro;
public class InterfaceView : MonoBehaviour
{
    public GameData data;
    public TMP_Text scoreDisplay;
    public TMP_Text grLevel;
    public TMP_Text priceGrStage;
    public TMP_Text scoreClick;
    public TMP_Text passiveIncome;
    public TMP_Text evolutionTxt;

    public void RefreshUI()
    {
        scoreDisplay.text = "Гравитация: " + data.gravityCount.ToString("F1");
        
        // Логика цвета
        passiveIncome.color = (data.gravityCount >= data.passiveIncomeUpgradeCost) ? Color.green : Color.red;
        
        // Твоя логика эволюции
        if (data.gravityLevel == 5 && data.gravityCount >= 10000f) {
            evolutionTxt.text = "Вы готовы к эволюции!";
            evolutionTxt.color = Color.green;
        }
        // ... и так далее по твоему коду
    }
}
