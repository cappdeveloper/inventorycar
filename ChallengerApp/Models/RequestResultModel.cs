using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class RequestResultModel
{
    public String Title { get; set; }
    public String Message { get; set; }
    public int HideInSeconds { get; set; }
    public RequestResultInfoType InfoType { get; set; }
}
