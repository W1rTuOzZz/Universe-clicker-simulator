using UnityEngine;
using UnityEngine.UI;
public class AsteroidView : MonoBehaviour
{
    public Image asteroidImage;
    public Sprite[] asteroidSprites;

    public void UpdateAsteroid(int level)
    {
        int index = Mathf.Clamp(level - 1, 0, asteroidSprites.Length - 1);
        if (asteroidImage != null) asteroidImage.sprite = asteroidSprites[index];
    }
}
