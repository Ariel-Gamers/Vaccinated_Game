using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    // Start is called before the first frame update

    int energy;
    float time;
    TMP_Text energy_tmp;
    Button b;
    [SerializeField] GameObject myPrefab;
    [SerializeField] GameObject VirusPrefab;

    void Start()
    {
        energy = 0;
        energy_tmp = GameObject.Find("Canvas").GetComponentInChildren<TMP_Text>();
        b = GameObject.Find("ImmuneButton").GetComponent<Button>();
        b.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if(energy >3)
        {
            Instantiate(myPrefab, new Vector3(0, 2, 0), Quaternion.identity);
            energy -= myPrefab.GetComponent<GoodCell>().getCost();
        }
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > 3)
        {
            energy += 2;
            time = 0;
        }

        energy_tmp.text = "ENERGY: " + energy;
    }
}
