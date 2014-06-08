﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// NotifySystem 的摘要描述
/// </summary>
public class NotifyFromSystem : Notify
{
    public NotifyFromSystem(string UserID)
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
        "GETDATE() <= MsgSubject.NotifyDeadLine and " +
        "Account.ClassCode='" + "2" + "'";
    }
}