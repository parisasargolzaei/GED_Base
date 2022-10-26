using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropDownHandler : MonoBehaviour
{
    TMP_Dropdown dropdown;
    public List<GameObject> allpanels;

    // Start is called before the first frame update
    void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();

        DeactivateAllPanels();
        DropdownItemSelected(dropdown);

        // dropdown.onValueChanged.AddListener(delegate {DropdownItemSelected(dropdown);});
    }

    public void DropdownItemSelected(TMP_Dropdown dropdown)
    {
        int index = dropdown.value;

        // switch (index)
        // {
        //     case 0:
        //         DeactivateAllPanels();
        //         allpanels[0].SetActive(true);
        //         break;
        //     case 1:
        //         DeactivateAllPanels();
        //         allpanels[1].SetActive(true);
        //         break;
        //     case 2:
        //         DeactivateAllPanels();
        //         allpanels[2].SetActive(true);
        //         break;
        //     default:
        //         break;
        // }

        for(int i = 0; i < allpanels.Count; i++)
        {
            if(i == index)
            {
                DeactivateAllPanels();
                allpanels[i].SetActive(true);
            }
        }
    }

    void DeactivateAllPanels()
    {
        foreach (GameObject panel in allpanels)
        {
            panel.SetActive(false);
        }
    }
}
