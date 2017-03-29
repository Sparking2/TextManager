using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Excel;
using System.IO;
using System.Data;
using UnityEngine.UI;

public class XlsReader : MonoBehaviour
{
    public int idioma;
    public int contexto;
    public string idKey;
    private string filetoread;

    // Use this for initialization
    void Start()
    {
        string mensaje = Search(Application.dataPath + "/Textos.xlsx");
        var texto = GetComponent<Text>();
        texto.text = mensaje;
        //filetoread = Application.dataPath + "/Textos.xls";
    }

    void readXLS(string filetoread)
    {
        FileStream stream = File.Open(filetoread, FileMode.Open, FileAccess.Read);
        
        //Choose one of either 1 or 2
        //1. Reading from a binary Excel file ('97-2003 format; *.xls)
        //IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);

        //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
        IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

        //Choose one of either 3, 4, or 5
        //3. DataSet - The result of each spreadsheet will be created in the result.Tables
        DataSet result = excelReader.AsDataSet();

        //4. DataSet - Create column names from first row
        //excelReader.IsFirstRowAsColumnNames = true;
        //DataSet result = excelReader.AsDataSet();

        //5. Data Reader methods
        /*while (excelReader.Read())
        {
            //excelReader.GetInt32(0);
        }*/

        //6. Free resources (IExcelDataReader is IDisposable)
        excelReader.Close();

        for(int i = 1; i < result.Tables[0].Rows.Count; i++)
        {
            print(result.Tables[0].Rows[i][4]);
        }
        
    }
    /*
    public List<string> GetContext(string filetoread)
    {
        List<string> contexto = new List<string>();

        FileStream stream = File.Open(filetoread, FileMode.Open, FileAccess.Read);
        IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
        DataSet result = excelReader.AsDataSet();
        excelReader.Close();

        for (int i = 0; i < result.Tables.Count; i++)
        {
            print(result.Tables[i].TableName);
           contexto.Add(result.Tables[i].TableName);
        }

        return contexto;
    }

    public List<string> GetText(string filetoread, int idioma,int contexto)
    {
        List<string> texto = new List<string>();

        FileStream stream = File.Open(filetoread, FileMode.Open, FileAccess.Read);
        IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
        DataSet result = excelReader.AsDataSet();
        excelReader.Close();

        //int = 1, para omitir el nombre de la columna
        for(int i = 1; i < result.Tables[0].Rows.Count; i++)
        {
            texto.Add(result.Tables[contexto].Rows[i][idioma].ToString());
        }

        return texto;
    }
    */


    public string Search(string filetoread)  
    {
        ///filetoread = dirección de archivo, idioma = en que idioma lo retornaremos [1 - esp, 2 - ingles , 3 - italiano, 4 - japones], contexto = No. de tabla que buscammos, idKey = el id que buscamos
        string texto = "";   ///Texto que retornaremos       
        FileStream stream = File.Open(filetoread, FileMode.Open, FileAccess.Read); ///abrir y leer el archivo xls
        IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);   ///Los datos del archivos, los ponemos en el dataSet "Tablas"
        DataSet result = excelReader.AsDataSet();
        excelReader.Close();    ///Liberammos los recursos
        DataTable myTabla = result.Tables[contexto];

        myTabla.PrimaryKey = new DataColumn[] { myTabla.Columns[0] };
        DataRow filaEncontrada = myTabla.Rows.Find(idKey);
        if(filaEncontrada != null)
        {
            texto = filaEncontrada[idioma].ToString();
        }
        else
        {
            texto = "no se encuentra ese ID!!!";
        }

        return texto;
    }
}
