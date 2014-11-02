using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Notify 的摘要描述
/// </summary>
public abstract class Notify
{
    public string UserID = string.Empty;
    public string Zipcode = string.Empty;

	public Notify(string UserID)
	{
		//
		// TODO: 在這裡新增建構函式邏輯
		//
        this.UserID = UserID;
	}
    public Notify()
    {
 
    }

    public abstract string NotifyMessage();

    //public abstract string ShoolMasterNotify();
    //public abstract string SystemManagerNotify();
    //public abstract string MingDeNotify();
    //public abstract string ProvinceNotify();
    //public string SystemNotify()
    //{
    //    return "select Subjects, Msg, UserName, SendTime from MsgUserData " +
    //    "left join MsgSubject on MsgUserData.EmailID = MsgSubject.EmailID " +
    //    "left join Account on Account.UserID = MsgUserData.SenderID " +
    //    "left join ExpertAuthority on Account.UserID = ExpertAuthority.UserID " +
    //    "where " +
    //    "MsgUserData.ReceiverID='" + UserID + "' and " +
    //    "GETDATE() <= MsgSubject.NotifyDeadLine and " +
    //    "Account.ClassCode='" + "2" + "'";
    //}
}