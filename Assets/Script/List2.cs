using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Newtonsoft.Json;

public class List2 : MonoBehaviour
{
    public GameObject elementPrefab;        //префаб для создания элемента
    public static List<string> videogames2;         //список 2
    public List<GameObject> childrens = new List<GameObject>();         //список дочерных объектов
    public TextMeshProUGUI elementsCount;           //количество элементов в списке


    void Start()
    {
        string json = @"['Starcraft','Halo','Zelda','Warcraft']";
        videogames2 = JsonConvert.DeserializeObject<List<string>>(json);
        

        for (var i = 0; i < videogames2.Count; i++)
        {

            GameObject elementGO = Instantiate(elementPrefab, this.transform, false);
            elementGO.GetComponentInChildren<TextMeshProUGUI>().text = videogames2[i];
        }
        
    }

    private void Update()
    {
        elementsCount.text =("Elements: " + CountChildren(transform).ToString());
    }
    public int CountChildren(Transform pTransform)
    {
        int count = 0;
        foreach (Transform child in pTransform)
        {
            count++;
        }
        return count;
    }


}