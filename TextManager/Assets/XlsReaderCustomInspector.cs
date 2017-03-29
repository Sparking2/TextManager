using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(XlsReader))]
public class XlsReaderCustomInspector : Editor
{
    string[] idioma = new string[]
    {
        "ID",
        "Español",
        "Ingles",
        "Italiano",
        "Japones"
    };

    string[] contexto = new string[]
    {
        "Dialogos",
        "Tienda",
        "Otro1",
        "Otro2"
    };

    public override void OnInspectorGUI()
    {
        EditorGUILayout.LabelField("");

        XlsReader script = target as XlsReader;

        #region Idioma
        /////////////w/////////////////////////////////////////////////////////////////////
        EditorGUILayout.LabelField("Idioma");
        script.idioma = EditorGUILayout.Popup(script.idioma, idioma);
        ///////////////////////////////////////////////////////////////////////////////
        #endregion

        #region Contexto
        EditorGUILayout.LabelField("");
        EditorGUILayout.LabelField("Contexto");
        script.contexto = EditorGUILayout.Popup(script.contexto, contexto);
        #endregion

        #region busqueda
        EditorGUILayout.LabelField("");
        EditorGUILayout.LabelField("ID de Texto");
        script.idKey = EditorGUILayout.TextField(script.idKey);
        if (GUILayout.Button("Buscar ID"))
        {
            Debug.Log(script.Search(Application.dataPath + "/Textos.xlsx"));
        }

        #endregion



    }
}
