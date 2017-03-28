using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Excel;
using System.IO;
using System.Data;

public class XlsReader : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        readXLS(Application.dataPath + "/Textos.xls");
    }

    void readXLS(string filetoread)
    {
        FileStream stream = File.Open(filetoread, FileMode.Open, FileAccess.Read);
        
        //Choose one of either 1 or 2
        //1. Reading from a binary Excel file ('97-2003 format; *.xls)
        IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);

        //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
        //IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

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
}
