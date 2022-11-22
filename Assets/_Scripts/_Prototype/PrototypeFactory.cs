using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PrototypeFactory : MonoBehaviour
{
    public List<CollectableData> allData;

    public GameObject buttonPanel;
    public GameObject buttonPrefab;

    private EditorManager editor;

    Coin coinPrototype;
    BlueGem bluePrototype;
    GreenGem greenPrototype;
    PinkGem pinkPrototype;
    FullHeart heartPrototype;
    LevelKey keyPrototype;

    CustomizablePlatform platformPrototype;
    public GameObject platformPrefab;
    public TMP_InputField widthInput;
    public TMP_InputField heightInput;
    public Toggle staticPlatform;
    int platWidth;
    int platHeight;

    // Start is called before the first frame update
    void Start()
    {
        editor = EditorManager.instance;

        coinPrototype = new Coin(allData[0]._prefab, 1);
        bluePrototype = new BlueGem(allData[1]._prefab, 10);
        greenPrototype = new GreenGem(allData[2]._prefab, 50);
        pinkPrototype = new PinkGem(allData[3]._prefab, 100);
        heartPrototype = new FullHeart(allData[4]._prefab, 10);
        keyPrototype = new LevelKey(allData[5]._prefab);

        for(int i = 0; i < allData.Count; i++)
        {
            var button = Instantiate(buttonPrefab);
            button.transform.SetParent(buttonPanel.transform, false);
            button.gameObject.name = allData[i].name + " Button";
            button.GetComponentInChildren<TextMeshProUGUI>().text = allData[i].name;
            button.GetComponent<Button>().onClick.AddListener(delegate {Spawner(button);});
        }
    }

    public void Spawner(GameObject button)
    {
        var btn = button.GetComponentInChildren<TextMeshProUGUI>();

        switch (btn.text)
        {
            case "Coin":
                editor.item = coinPrototype.Clone().Spawn();
                break;
            case "BlueGem":
                editor.item = bluePrototype.Clone().Spawn();
                break;
            case "GreenGem":
                editor.item = greenPrototype.Clone().Spawn();
                break;
            case "PinkGem":
                editor.item = pinkPrototype.Clone().Spawn();
                break;
            case "FullHeart":
                editor.item = heartPrototype.Clone().Spawn();
                break;
            case "Key":
                editor.item = keyPrototype.Clone().Spawn();
                break;
            default:
                break;
        } 

        editor.instantiated = true;
    }

    public void PlatformClone()
    {
        platWidth = int.Parse(widthInput.text);
        platHeight = int.Parse(heightInput.text);
        
        platformPrototype = new CustomizablePlatform(platformPrefab, platWidth, platHeight);

        if(platWidth != 0 && platHeight != 0)
        {
            editor.item = platformPrototype.Clone().Spawn();
            if(!staticPlatform.isOn)
            {
                editor.item.AddComponent<MovingPlatform>();
            }
            editor.instantiated = true;
        }
    }
}
