using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float CurrentHealth = 100;
    public float MaxHealth = 100;

    [Header("Interface")]
    public Image HealthBar;
    public Text HealthText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateBar();
    }

    void UpdateBar()
    {
        if (CurrentHealth <= 0)
        {
            Cursor.lockState = CursorLockMode.None; // Esto desbloquea el cursor
            Cursor.visible = true; // Esto hace que el cursor sea visible
            SceneManager.LoadScene("Death");
        }
        else
        {
            HealthBar.fillAmount = CurrentHealth / MaxHealth;
            HealthText.text = CurrentHealth.ToString("f0");
        }
    }

    public void Damage(float damage)
    {
        CurrentHealth -= damage;
    }
}
