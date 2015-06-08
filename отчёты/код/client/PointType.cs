using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PointType
{
    public const string ACTION = "ACTIV";
    public const string NOT_ACTION = "NOT_ACTIV";
    public const string NEXT = "NEXT";
    public const string INFO = "INFO";
    public const string SELECTED = "SELECTED";
    public const string GROUP = "GROUP";
    public const string PORTER_POSITION = "PORTER_POSITION";

    public static bool isTypeStandart(string type) 
    {
        if (type.Equals(ACTION) || type.Equals(NEXT) || type.Equals(INFO) || type.Equals(NOT_ACTION)) { return true; }
        else return false;
    }

    public static bool isTypeGUIDES(string type)
    {
        if (type.Equals(PORTER_POSITION)) { return false; }
        else return true;
    }
    
}

