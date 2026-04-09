using UnityEngine;
using TMPro;
public class GravityManager : MonoBehaviour
{
public float gravityCount;
public TMP_Text scoreDisplay;
public float autoClickSpeed;
public float clickPower;
public bool isGameStarted;
public float upgradeCost = 10;
public TMP_Text priceDisplay;
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

void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
        gravityCount += clickPower;
        isGameStarted = true;
        Debug.Log("Гравитация: " + gravityCount);
        } if (isGameStarted)
        {
            gravityCount += autoClickSpeed * Time.deltaTime;
            UpdateUI();
        } if (Input.GetKeyDown(KeyCode.Space) && gravityCount >= upgradeCost)
        {
            gravityCount -= upgradeCost;
            clickPower += 2;
            upgradeCost *= 1.5f;
        }
    }
}
