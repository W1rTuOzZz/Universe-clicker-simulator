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
public float autoClickTimer = 0f;
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

public void BuyUpgrade()
    {
        if (gravityCount >= upgradeCost)
        {
            gravityCount -= upgradeCost;
            upgradeCost *= 1.5f;
            autoClickTimer += 10f;
            UpdateUI();
            Debug.Log("Покупка апгрейда: " + upgradeCost);
        }
    }
void Update()
    {
        if (autoClickTimer > 0)
        {
            autoClickTimer -= Time.deltaTime;
            gravityCount += autoClickSpeed * Time.deltaTime;
            UpdateUI();
        }
    }
}
