using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// CreateReceiver 的摘要描述
/// </summary>
public abstract class CreateReceiver
{
    public string Zipcode = string.Empty;
    public CreateReceiver()
	{
		//
		// TODO: 在這裡新增建構函式邏輯
		//
	}
    public abstract string Receiver();
}