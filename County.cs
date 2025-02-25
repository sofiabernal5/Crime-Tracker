//This Class holds the indiviual county data. year is not really used right now but
//in the future when we add multiple years and allow for researcher/law enforcement input
//it will come in handy for better organization
namespace ExcelDataReader
{
    
public class County
{
    private string countyName;
    private int population;
    private int year;
    private int crimeIndex;

    public County(string countyName, int population, int year, int crimeIndex)
    {
        this.countyName = countyName;
        this.population = population;
        this.year = year;
        this.crimeIndex = crimeIndex;
    }

    public string CountyName
    { 
        get { return countyName; }
        set { countyName = value; }
    }
    public int Population 
    { 
        get { return population; } 
        set { population = value; } 
    }
    public int Year
    {
        get { return year; }
        set { year = value; }
    }
    public int CrimeIndex
    { 
        get { return crimeIndex; } 
        set { crimeIndex = value; }
    }
}

}
