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
    public enum DATA_TYPE
    {
        SystemManager = 0,
        MingdeExpert = 1,
        Expert = 2,
        SchoolMaster = 3,
        System = 4
    }
    public enum RETURN_TYPE
    {
        SUCCESS = 0,
        ERROR = 1
    }
    public ArrayList notificationSet = new ArrayList();

    public string UserID = string.Empty;

    public IndexFactory(string UserID)
	{
		//
		// TODO: 在這裡新增建構函式邏輯
		//
        this.UserID = UserID;
	}

    public abstract Notify createNotification(DATA_TYPE item);
    public abstract CreateReceiver createReceiver(DATA_TYPE item);

    public void prepareNotification(DATA_TYPE type)
    {
        notify = createNotification(type);
        RETURN_TYPE rtst = queryData(notify.NotifyMessage(), notificationSet);
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