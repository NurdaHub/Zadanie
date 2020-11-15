using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Newtonsoft.Json;

public class List1 : MonoBehaviour
{
    public GameObject elementPrefab;        //префаб для создания элемента
    public static List<string> videogames1;         //список 1
    public List<GameObject> childrens = new List<GameObject>();     //список дочерных объектов
    public TextMeshProUGUI elementsCount;       //количество элементов в списке


    void Start()
    {
        string json = @"['SMario','Sonic','Contra','Dune']";
        videogames1 = JsonConvert.DeserializeObject<List<string>>(json);


        for (var i = 0; i < videogames1.Count; i++)
        {

            GameObject elementGO = Instantiate(elementPrefab, this.transform, false);
            elementGO.GetComponentInChildren<TextMeshProUGUI>().text = videogames1[i];
        }
    }


    private void Update()
    {
        elementsCount.text = ("Elements: " + CountChildren(transform).ToString());
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