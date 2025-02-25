
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
//The namespace fore the data managment aspect of this project is ExcelDataReader
namespace ExcelDataReader
{
    
    class Program
{
    static void Main(string[] args)
    {
        ExcelFileReader reader = new ExcelFileReader(); //Class in ExcelRead.cs
        var reports = reader.ReadExcelFile("2021A_Statewide_County.xlsx");

        foreach (var report in reports.Values)
        {
            foreach (County county in report.GetCounties())
            {
                Console.WriteLine($"{county.CountyName}: Population {county.Population}, Crime Index {county.CrimeIndex}");
            }
        }
    }
}
}