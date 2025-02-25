namespace ExcelDataReader
{


public class AnnualReport
{
    //the reason for using list is just because its the most comforatble one for me. I'm not really too well versed
    //in c# so I decided to stick with something I am familiar with.
    //Private variables
    private List<County> counties;// The list that holds all the classes for the different counties
    
    private int year; //used to oranize multiple years of reports so that way we dont need to reach all the way down
    //to the county level.

    public AnnualReport(int year)
    {
        this.year = year;
        counties = new List<County>();
    }

    public void AddCounty(County county)
    {
        counties.Add(county);
    }

    public List<County> GetCounties()
    {
        return counties;
    }
    public int Year
    {
        get { return year; }
        set { year = value; }
    }
}
    //end of namespace
}