using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;


public enum UserRoles : int
{
    [Description("Admin")]
    Admin = 1,
    [Description("Admin")]
    Users = 2
}

public enum GenericStatuses : int
{
    [Description("Active")]
    Active = 1,
    [Description("Active")]
    InActive = 2,
    [Description("Active")]
    Pending = 3,
    [Description("Active")]
    Approved = 4
}



public enum RequestResultInfoType : int
{
    Information = 0,
    Success = 1,
    Warning = 2,
    ErrorOrDanger = 3
}

public enum NotifyType: int
{
    PageInline = 0,
    DialogInline = 1,
    Dialog = 2,
    PageFixedPoupUp = 3
}
