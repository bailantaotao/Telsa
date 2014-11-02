using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// ConcreateSchoolMaster 的摘要描述
/// </summary>
public class ConcreateFactory: IndexFactory
{
    public ConcreateFactory(string UserID, string Zipcode)
    {
        //
        // TODO: 在這裡新增建構函式邏輯
        //
        this.UserID = UserID;
        this.Zipcode = Zipcode;
    }
    public override Notify createNotification(DATA_TYPE item)
    {
        if (item == DATA_TYPE.System)
            return new NotifyFromSystem(UserID);
        else if (item == DATA_TYPE.SystemManager)
            return new NotifyFromSystemManager(UserID);
        else if (item == DATA_TYPE.MingdeExpert)
            return new NotifyFromMingde(UserID);
        else if (item == DATA_TYPE.FromExpertToMingde)
            return new NotifyFromProvinceToMingde(UserID);
        else if (item == DATA_TYPE.FromExpertToSchoolMaster)
            return new NotifyFromProvinceToSchoolMaster(UserID, Zipcode);            
        else if (item == DATA_TYPE.SchoolMaster)
            return new NotifyFromSchoolMaster(UserID);
        else if (item == DATA_TYPE.ProvinceAnnocement)
            return new NotifyFromProvinceAnnocement(UserID);
        else return null;
    }

    public override CreateReceiver createReceiver(DATA_TYPE item)
    {
        if (item == DATA_TYPE.SystemManager)
            return new ReceiverSystemManager();
        else if (item == DATA_TYPE.MingdeExpert)
            return new ReceiverMingde();
        else if (item == DATA_TYPE.FromExpertToMingde)
            return new ReceiverProvince();
        else if (item == DATA_TYPE.SchoolMaster)
            return new ReceiverSchoolMaster();
        else if (item == DATA_TYPE.FromSchoolMasterToExpert)
            return new ReceiverFromSchoolMasterToExpert(Zipcode);
        else if (item == DATA_TYPE.FromExpertToSchoolMaster)
            return new ReceiverFromExpertToSchoolMaster(Zipcode);
        else return null;
    }

}