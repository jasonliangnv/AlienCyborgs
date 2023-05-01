using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{

    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;

    public Image[] hearts;
    
    private int totalHearts;
    private int counter = 1;

    private void Start()
    {
        
        totalHearts = hearts.Length - 1;
    }
    // Start is called before the first frame update
    public void updateHealth()
    {
      
        if (counter == 0)
        {
            Debug.Log("Total hearts are: " + totalHearts);
            hearts[totalHearts].GetComponent<Image>().sprite = emptyHeart;
            totalHearts--;
            if (totalHearts < 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                Debug.Log("Player has Died!");
                return;
            }
            counter = 1;
        }
        else if(counter == 1)
        {
            hearts[totalHearts].GetComponent<Image>().sprite = halfHeart;
            counter--;
        }
       

    }
}
