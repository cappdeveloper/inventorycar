using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class LookupHelpers
{
    public string Value { get; set; }
    public string Text { get; set; }

    public static List<LookupHelpers> CanadaProvinces()
    {
        return new List<LookupHelpers>()
        {
             new LookupHelpers(){Value="AB",Text="Alberta"},
	         new LookupHelpers(){Value="BC",Text="British Columbia"},
	         new LookupHelpers(){Value="MB",Text="Manitoba"},
	         new LookupHelpers(){Value="NB",Text="New Brunswick"},
	         new LookupHelpers(){Value="NL",Text="Newfoundland and Labrador"},
	         new LookupHelpers(){Value="NS",Text="Nova Scotia"},
	         new LookupHelpers(){Value="ON",Text="Ontario"},
	         new LookupHelpers(){Value="PE",Text="Prince Edward Island"},
	         new LookupHelpers(){Value="QC",Text="Quebec"},
	         new LookupHelpers(){Value="SK",Text="Saskatchewan"},
	         new LookupHelpers(){Value="NT",Text="Northwest Territories"},
	         new LookupHelpers(){Value="NU",Text="Nunavut"},
             new LookupHelpers(){Value="YT",Text="Yukon"}
        };
    }

    public static List<LookupHelpers> GenereateYearsSelection(int numberOfYearsFromCurrent = 5)
    {
        List<LookupHelpers> list = new List<LookupHelpers>{
            new LookupHelpers(){Value = "2000",Text="2000"},
            new LookupHelpers(){Value = "2001",Text="2001"},
            new LookupHelpers(){Value = "2002",Text="2002"},
            new LookupHelpers(){Value = "2003",Text="2003"},
            new LookupHelpers(){Value = "2004",Text="2004"},
            new LookupHelpers(){Value = "2005",Text="2005"},
            new LookupHelpers(){Value = "2006",Text="2006"},
            new LookupHelpers(){Value = "2007",Text="2007"},
            new LookupHelpers(){Value = "2008",Text="2008"},
            new LookupHelpers(){Value = "2009",Text="2009"},
            new LookupHelpers(){Value = "2010",Text="2010"},
            new LookupHelpers(){Value = "2011",Text="2011"},
            new LookupHelpers(){Value = "2012",Text="2012"},
            new LookupHelpers(){Value = "2013",Text="2013"},
            new LookupHelpers(){Value = "2014",Text="2014"},
        };
        for (int i = 1; i < 5; i++)
        {
            int theYear = 2014 + i;
            LookupHelpers year = new LookupHelpers
            {
                Value = theYear.ToString(),
                Text = theYear.ToString()

            };
            list.Add(year);
        }
        return list;
    }
}
