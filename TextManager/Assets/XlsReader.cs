using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using System.Data.Odbc;

public class XlsReader : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        readXLS(Application.dataPath + "/Textos.xlsx");
    }

    void readXLS(string filetoread)
    {
       
        string con = "Driver={Microsoft Excel Driver (*.xls)}; DriverId=790; Dbq=" + filetoread + ";";
        string yourQuery = "SELECT * FROM [Dialogos$]";
        OdbcConnection oCon = new OdbcConnection(con);
        OdbcCommand oCmd = new OdbcCommand(yourQuery, oCon);
        DataTable dtYourData = new DataTable("YourData");
        oCon.Open();
        OdbcDataReader rData = oCmd.ExecuteReader();
        dtYourData.Load(rData);
        rData.Close();
        oCon.Close();
        if (dtYourData.Rows.Count > 0)
        {
            for (int i = 0; i < dtYourData.Rows.Count; i++)
            {
                //print(dtYourData.Rows[i][0]);
                /*
                Debug.Log(dtYourData.Columns[0].ColumnName + " : " + dtYourData.Rows[i][dtYourData.Columns[0].ColumnName].ToString() +
                    "  |  " + dtYourData.Columns[1].ColumnName + " : " + dtYourData.Rows[i][dtYourData.Columns[1].ColumnName].ToString() +
                    "  |  " + dtYourData.Columns[2].ColumnName + " : " + dtYourData.Rows[i][dtYourData.Columns[2].ColumnName].ToString());
                */
            }
        }
    }
}
