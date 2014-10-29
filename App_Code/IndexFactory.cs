using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// IndexFactory 的摘要描述
/// </summary>
public abstract class IndexFactory
{
    public Notify notify;
    public CreateReceiver getReceiver;
    public enum DATA_TYPE
    {
        SystemManager = 0,
        MingdeExpert = 1,
        FromExpertToMingde = 2,
        SchoolMaster = 3,
        System = 4,
        ProvinceAnnocement = 5,
        FromExpertToSchoolMaster = 6,
        FromSchoolMasterToExpert = 7
    }
    public enum RETURN_TYPE
    {
        SUCCESS = 0,
        ERROR = 1
    }
    public ArrayList notificationSet = new ArrayList();
    public ArrayList receiverSet = new ArrayList();
    public ArrayList countSet = new ArrayList();

    public string UserID = string.Empty;
    public string Zipcode = string.Empty;

    //public IndexFactory(string UserID)
    //{
    //    //
    //    // TODO: 在這裡新增建構函式邏輯
    //    //
    //    this.UserID = UserID;
    //}

    public abstract Notify createNotification(DATA_TYPE item);
    public abstract CreateReceiver createReceiver(DATA_TYPE item);

    public void prepareNotification(DATA_TYPE type)
    {
        notify = createNotification(type);
        RETURN_TYPE rtst = queryData(notify.NotifyMessage(), notificationSet);
    }

    public void prepareReceiver(DATA_TYPE type)
    {
        getReceiver = createReceiver(type);
        RETURN_TYPE rtst = queryData(getReceiver.Receiver(), receiverSet);
    }

    public void completeMultiCal()
    {
        receiverSet = (ArrayList)countSet.Clone();
    }

    // 依據傳進來的參數執行不同的內容
    private RETURN_TYPE queryData(string query, ArrayList mArrayList)
    {        
        ManageSQL ms = new ManageSQL();
        if (ms.GetAllColumnData(query, mArrayList))
        {
            return RETURN_TYPE.SUCCESS;
        }
        return RETURN_TYPE.ERROR;
    }

}