using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Change_language : MonoBehaviour {

    public int Idioma;
    public Text texto;

    public void Presionado()
    {
        PlayerPrefs.SetInt("Idioma", Idioma);
        XlsReader reader = FindObjectOfType(typeof(XlsReader)) as XlsReader;
        texto.text = reader.Search(Application.dataPath + "/Textos.xlsx");
        print("Click");
        print(PlayerPrefs.GetInt("Idioma"));
    }
}
