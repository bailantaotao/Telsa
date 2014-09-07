﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// NotifyFromProvinceAnnocement 的摘要描述
/// </summary>
public class NotifyFromProvinceAnnocement : Notify
{
	public NotifyFromProvinceAnnocement(string UserID)
        : base(UserID)
	{
		//
		// TODO: 在這裡新增建構函式邏輯
		//
	}

    public override string NotifyMessage()
    {
        return "select Subjects, Msg, UserName, SendTime from MsgUserData " +
                "left join MsgSubject on MsgUserData.EmailID = MsgSubject.EmailID " +
                "left join Account on Account.UserID = MsgUserData.SenderID " +
                "left join ExpertAuthority on Account.UserID = ExpertAuthority.UserID " +
                "where " +
                "MsgUserData.ReceiverID='" + UserID + "' and " +
                "GETDATE() <= MsgSubject.NotifyDeadLine and " +
                "Account.ClassCode='" + "1" + "' and " + 
                "MsgUserData.Annocement = 'True'";
    }
}