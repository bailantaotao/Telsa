using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// ConcreateSchoolMaster 的摘要描述
/// </summary>
public class ConcreateFactory: IndexFactory
{
    public ConcreateFactory(string UserID)
        : base(UserID)
	{
		//
		// TODO: 在這裡新增建構函式邏輯
		//
	}

    public override Notify createNotification(DATA_TYPE item)
    {
        if (item == DATA_TYPE.System)
            return new NotifyFromSystem(UserID);
        else if (item == DATA_TYPE.SystemManager)
            return new NotifyFromSystemManager(UserID);
        else if (item == DATA_TYPE.MingdeExpert)
            return new NotifyFromMingde(UserID);
        else if (item == DATA_TYPE.Expert)
            return new NotifyFromProvince(UserID);
        else if (item == DATA_TYPE.SchoolMaster)
            return new NotifyFromSchoolMaster(UserID);
        else return null;
    }

}