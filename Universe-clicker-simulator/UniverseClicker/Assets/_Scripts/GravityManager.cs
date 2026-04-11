using UnityEngine;
using TMPro;
using System.Threading;
using System.Collections;
using Unity.VisualScripting;
public class GravityManager : MonoBehaviour
{
public float gravityCount;
public TMP_Text scoreDisplay;
public float autoClickSpeed;
public float clickPower;
public bool isGameStarted;
public float upgradeCost = 10f;
public TMP_Text priceDisplay;
public float autoClickTime = 0f;
public float autoClickTimeUpgrade = 0f;
public float autoClickCostTimeUpgrade = 5f;
public float autoClickSpeedUpgrade = 0f;
public float autoClickCostSpeedUpgrade = 5f;
void UpdateUI()
    {
        scoreDisplay.text = "Гравитация: " + gravityCount.ToString("F1");
        priceDisplay.text = "Стоимость апгрейда: " + upgradeCost.ToString("F2");
        if (gravityCount >= upgradeCost)
           {
            priceDisplay.color = Color.green; // Если денег хватает — зеленый
           }
            else
              {
                priceDisplay.color = Color.red; // Если нет — красный
              } 
    }
void Start ()
    {
        UpdateUI();
    }

    public void OnPlanetClick() 
    {
        gravityCount += clickPower; 
        isGameStarted = true;       
        UpdateUI();                 
        Debug.Log("Клик по кнопке! Теперь гравитация: " + gravityCount);
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
    public void BuyUpgrade()
    {
        if (gravityCount >= upgradeCost)
        {
            gravityCount -= upgradeCost;
            autoClickTime += (10f + autoClickTimeUpgrade); 
            autoClickSpeed = (0.5f + autoClickSpeedUpgrade);
            Debug.Log("Покупка апгрейд: " + upgradeCost);
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
