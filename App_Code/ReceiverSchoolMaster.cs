using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// ReceiverSchoolMaster 的摘要描述
/// </summary>
public class ReceiverSchoolMaster : CreateReceiver
{
	public ReceiverSchoolMaster()
	{
		//
		// TODO: 在這裡新增建構函式邏輯
		//
	}
    public override string Receiver()
    {
        return "select UserID, UserName, School from Account where Classcode = '0'";
    }
}