using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// FromExpertToSchoolMaster 的摘要描述
/// </summary>
public class ReceiverFromExpertToSchoolMaster:CreateReceiver
{
	public ReceiverFromExpertToSchoolMaster()
	{
		//
		// TODO: 在這裡新增建構函式邏輯
		//
	}
    public ReceiverFromExpertToSchoolMaster(string Zipcode)
    {
        this.Zipcode = Zipcode;
    }
    public override string Receiver()
    {
        return "select UserID, UserName, School from Account where Classcode = '0' and Zipcode = '" +Zipcode+"'";
    }
}