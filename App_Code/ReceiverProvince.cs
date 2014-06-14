using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// ReceiverProvince 的摘要描述
/// </summary>
public class ReceiverProvince : CreateReceiver
{
	public ReceiverProvince()
	{
		//
		// TODO: 在這裡新增建構函式邏輯
		//
	}


    public override string Receiver()
    {
        return "select Account.UserID, Account.UserName, Account.School from Account " +
            "left join ExpertAuthority on Account.UserID = ExpertAuthority.UserID " +
            "where ExpertAuthority.IsMingder = 'false' " +
            "and Account.ClassCode='1' ";
    }
}