using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// BaseClass 的摘要描述
/// </summary>
public class BaseClass
{
    private int i, k, toint, tochar;
    private string cryption;
    private const int BaseYear = 0;

	public BaseClass()
	{
		//
		// TODO: 在這裡新增建構函式邏輯
		//
    }

    /// <summary>
    /// 回傳民國年
    /// </summary>
    /// <returns>int</returns>
    public static int NowYear
    {
        set { }
        get
        {
            return (Convert.ToInt32(DateTime.Now.ToString("yyyy")) - BaseYear);
        }
    }

    /// <summary>
    /// swap data
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    public void swap(ref int a, ref int b)
    {
        int tmp = a;
        a = b;
        b = tmp;
    }

    /// <summary>
    /// 顯示彈出對話框訊息
    /// </summary>
    /// <param name="pMsg">要顯示的訊息</param>
    /// <returns>JavaScript</returns>
    public string responseMsg(string pMsg)
    {        
        StringBuilder tJsString = new StringBuilder();
        tJsString.AppendFormat("<SCRIPT>alert(\"{0}\")</SCRIPT>", pMsg);

        return tJsString.ToString();
    }

    /// <summary>
    /// Encryption String
    /// </summary>
    /// <param></param>
    /// <returns>String</returns>
    public string encryption(string encrypt)
    {
        cryption = "";
        toint = 0;

        for (i = 0; i < encrypt.Length; i++)
        {
            //get ascii code and encrypt
            toint = Int32.Parse(Convert.ToByte(Convert.ToChar(encrypt.ToString().Substring(i, 1).ToString())).ToString());
            toint = toint - 8;
            cryption += Convert.ToChar(toint).ToString();
        }

        return cryption;
    }

    /// <summary>
    /// Decryption String
    /// </summary>
    /// <param></param>
    /// <returns>String</returns>
    public string decryption(string decrypt)
    {
        cryption = "";
        tochar = 0;

        for (k = 0; k < decrypt.Length; k++)
        {
            tochar = Convert.ToInt32(Convert.ToByte(Convert.ToChar(decrypt.ToString().Substring(k, 1).ToString())).ToString()) + 8;
            cryption += Convert.ToChar(tochar).ToString();
        }

        return cryption;
    }
}
