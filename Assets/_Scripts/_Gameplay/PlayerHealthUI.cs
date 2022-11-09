using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterStats))]
public class PlayerHealthUI : MonoBehaviour
{
    public GameObject uiPrefab;
    public Transform target;

    Transform ui;
    Image healthSlider;

    // Start is called before the first frame update
    void Start () {
        ui = Instantiate(uiPrefab, target.transform).transform;
        ui.transform.SetParent(target.transform);
        healthSlider = ui.GetChild(0).GetComponent<Image>();

        GetComponent<CharacterStats>().OnHealthChanged += OnHealthChanged;
	}

    void OnHealthChanged(int maxHealth, int currentHealth) {
        if (ui != null)
        {
            float healthPercent = (float)currentHealth / maxHealth;
            healthSlider.fillAmount = healthPercent;
            if (currentHealth <= 0)
            {
                Destroy(ui.gameObject);
            }
        }
    }
}
