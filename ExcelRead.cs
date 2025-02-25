using System;
using System.IO;
using ExcelDataReader;
using System.Data;
using System.Text;
using System.Linq;

namespace ExcelDataReader
{

public class ExcelFileReader
{
    //when looking up how to oranize better the data for years. I had to come to terms with two things:

    //Years could go from 1900 to 2021 so I would need an easy way to navigate through the years.
    //I would also not really need to organize them to much because they will always be in order.
    //I decided on a map, then realized that maps are called dictionaries in c#.
    private Dictionary<int, AnnualReport> toDate = new Dictionary<int, AnnualReport>(); //int is the year, while
    //Annual report is the list of county classes


    //this array I used to be able to compare the names in the UCR so that I could combat the accidential 
    //many times a county is mentioned but not actually containing the numbers I needed
    public string[] floridaCounties = new string[]
    {
        "Alachua County", "Baker County", "Bay County", "Bradford County", "Brevard County", "Broward County",
        "Calhoun County", "Charlotte County", "Citrus County", "Clay County", "Collier County", "Columbia County",
        "DeSoto County", "Dixie County", "Duval County", "Escambia County", "Flagler County", "Franklin County",
        "Gadsden County", "Gilchrist County", "Glades County", "Gulf County", "Hamilton County", "Hardee County",
        "Hendry County", "Hernando County", "Highlands County", "Hillsborough County", "Holmes County", "Indian River County",
        "Jackson County", "Jefferson County", "Lafayette County", "Lake County", "Lee County", "Leon County",
        "Levy County", "Liberty County", "Madison County", "Manatee County", "Marion County", "Martin County",
        "Miami-Dade County", "Monroe County", "Nassau County", "Okaloosa County", "Okeechobee County", "Orange County",
        "Osceola County", "Palm Beach County", "Pasco County", "Pinellas County", "Polk County", "Putnam County",
        "St. Johns County", "St. Lucie County", "Santa Rosa County", "Sarasota County", "Seminole County", "Sumter County",
        "Suwannee County", "Taylor County", "Union County", "Volusia County", "Wakulla County", "Walton County",
        "Washington County"
    };
    
    public Dictionary<int, AnnualReport> ReadExcelFile(string filePath)
    {
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance); //Mecessary for reading excel files

        using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
        {
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                reader.Read(); // Skip header row until we get to Aluchua County
                while (reader.Read())
                {
                    string countyName = reader.GetString(0);
                    if (floridaCounties.Contains(countyName))
                    {
                        int year = Convert.ToInt32(reader.GetValue(1));
                        int population = Convert.ToInt32(reader.GetValue(2));
                        int crimeIndex = Convert.ToInt32(reader.GetValue(3));
                        County county = new County(countyName, population, year, crimeIndex);
                        toDate[year].AddCounty(county);
                    }
                }
            }
        }
        return toDate;
    }
}
}