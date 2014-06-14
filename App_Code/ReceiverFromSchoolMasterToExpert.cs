using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// ReceiverFromSchoolMasterToExpert 的摘要描述
/// </summary>
public class ReceiverFromSchoolMasterToExpert : CreateReceiver
{
	public ReceiverFromSchoolMasterToExpert()
	{
		//
		// TODO: 在這裡新增建構函式邏輯
		//
	}
    public ReceiverFromSchoolMasterToExpert(string Zipcode)
    {
        this.Zipcode = Zipcode;
    }
    public override string Receiver()
    {
        return "select UserID, UserName, School from Account where Classcode = '1' and Zipcode = '" +Zipcode+"'";
    }
}