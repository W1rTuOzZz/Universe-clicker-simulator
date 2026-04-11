using UnityEngine;
using TMPro;
using System.Threading;
using System.Collections;
using Unity.VisualScripting;
public class GravityManager : MonoBehaviour
{
public float gravityCount;
public TMP_Text scoreDisplay;
public TMP_Text grLevel;
public TMP_Text priceGrStage;
public TMP_Text scoreClick;
public TMP_Text passiveIncome;
public TMP_Text evolutionTxt;
public float autoClickSpeed;
public float clickPower;
public bool isGameStarted;
public float passiveIncomeUpgradeCost = 10f;
public float autoClickTime = 0f;
public float autoClickTimeUpgrade = 0f;
public float autoClickCostTimeUpgrade = 5f;
public float autoClickSpeedUpgrade = 0f;
public float autoClickCostSpeedUpgrade = 5f;
public int gravityLevel = 0;
public int nextLevelCost = 1000;
void UpdateUI()
    {
        scoreDisplay.text = "Уровень гравитация: " + gravityCount.ToString("F1");
        passiveIncome.text = "Стоимость апгрейда: " + passiveIncomeUpgradeCost.ToString("F2");
        grLevel.text = "Уровень: " + gravityLevel.ToString("F0");
        priceGrStage.text = "Цена Апа: " + nextLevelCost.ToString("F0");
        scoreClick.text = "Очки за клик: " + clickPower.ToString("F1");
        if (gravityCount >= passiveIncomeUpgradeCost)
        {
            passiveIncome.color = Color.green;
        } else
        {
            passiveIncome.color = Color.red;
        } 
        
        if (gravityCount >= nextLevelCost)
        {
            priceGrStage.color = Color.green;
        } else
        {
            priceGrStage.color = Color.red;
        }
        if (gravityLevel == 5 && gravityCount >= 10000f)
        {
            evolutionTxt.text = "Вы готовы к эволюции!";
            evolutionTxt.color = Color.green;
        } else if (gravityLevel != 5 && gravityCount >= 10000f)
        {
            evolutionTxt.text = "Чтобы эволюционировать, вам нужно апнуть все уровни гравитации!";
            evolutionTxt.color = Color.yellow;
        } else if (gravityLevel == 5 && gravityCount != 10000f)
        {
            evolutionTxt.text = "Чтобы эволюционировать, вам нужно накопить 10к очков гравитации!";
            evolutionTxt.color = Color.yellow;
        } else
        {
            evolutionTxt.text = "У вас нехватает, как уровней гравитации, так и очков гравитации!";
            evolutionTxt.color = Color.red;
        }
    }
void Start ()
    {
        UpdateUI();
    }

    public void OnClick() 
    {
        gravityCount += clickPower; 
        isGameStarted = true;       
        UpdateUI();                 
        Debug.Log("Клик по кнопке! Теперь гравитация: " + gravityCount);
    }
    public void GravityLevel()
    {
        if (gravityCount >= nextLevelCost && gravityLevel <5)
        {
            gravityCount -= nextLevelCost;
            gravityLevel++;
            clickPower += 5;
            nextLevelCost += 1000;
            Debug.Log("Уровень повышен до: " + gravityLevel);
        } if (gravityLevel == 5)
        {
            
        }
        UpdateUI();
    }
    public void ClickSpeedUpgrade()
    {
        if (gravityCount >= autoClickCostSpeedUpgrade)
        {
            gravityCount -= autoClickCostSpeedUpgrade;
            autoClickSpeedUpgrade += 1f;
            autoClickCostSpeedUpgrade *= 1.5f;
        }
        UpdateUI();
    }
    public void ClickTimeUpgrade()
    {
        if (gravityCount >= autoClickCostTimeUpgrade) 
        {
         gravityCount -= autoClickCostTimeUpgrade;
         autoClickTimeUpgrade += 2f;
         autoClickCostTimeUpgrade *= 1.5f;
        }
        UpdateUI();
    }
    public void BuyPassiveIncome()
    {
        if (gravityCount >= passiveIncomeUpgradeCost)
        {
            gravityCount -= passiveIncomeUpgradeCost;
            autoClickTime += (10f + autoClickTimeUpgrade); 
            autoClickSpeed = (0.5f + autoClickSpeedUpgrade);
            Debug.Log("Покупка апгрейд: " + passiveIncomeUpgradeCost);
        }
        UpdateUI();
    }
void Update()
    {
        if (autoClickTime > 0)
        {
            autoClickTime -= Time.deltaTime;
            gravityCount += autoClickSpeed * Time.deltaTime;
            UpdateUI();
        }
    }
}
