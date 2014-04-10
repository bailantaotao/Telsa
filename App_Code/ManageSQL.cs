using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// ManageSQL 的摘要描述
/// </summary>
public class ManageSQL
{
    private SqlConnection cn;
    private SqlCommand cmd;
    private SqlDataReader dr;

    public enum SQLStatus
    {
        Connect,
        DisConnect
    }

	public ManageSQL()
	{
		//
		// TODO: 在這裡新增建構函式邏輯
		//
        cn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConStr"].ToString());
	}

    public bool SQLControl(SQLStatus status)
    {
        try
        {
            if (status == SQLStatus.Connect)
            {
                if (cn.State.ToString() == "Closed")
                    cn.Open();
            }
            else if (status == SQLStatus.DisConnect)
            {
                if (cn.State.ToString() == "Open")
                    cn.Close();
            }
            return true;
        }
        catch (InvalidOperationException)
        {
            return false;
        }
        catch (SqlException)
        {
            return false;
        }
        catch (ArgumentException)
        {
            return false;
        }
    }

    public bool GetOneData(string _query, StringBuilder SB)
    {
        SB.Clear();
        if (SQLControl(SQLStatus.Connect))
        {
            cmd = new SqlCommand(_query, cn);
            try
            {
                dr = cmd.ExecuteReader();
                if (dr.Read())
                    SB.Append(dr[0].ToString());
            }
            catch (SqlException)
            {
                return false;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
            if (SQLControl(SQLStatus.DisConnect))
                return true;
        }
        return false;
    }
    //count_data
    public bool GetRowNumbers(string _query, StringBuilder SB)
    {
        SB.Clear();
        if (SQLControl(SQLStatus.Connect))
        {
            try
            {
                cmd = new SqlCommand(_query, cn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                    SB.Append(Int32.Parse(dr.GetValue(0).ToString()));
            }
            catch (SqlException)
            {
                return false;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
            if (SQLControl(SQLStatus.DisConnect))
                return true;
        }
        return false;
    }
    //--將資料寫入DB--
    public bool WriteData(string query, StringBuilder SB)
    {
        SB.Clear();
        if(SQLControl(SQLStatus.Connect))
        {
            try
            {
                cmd = new SqlCommand(query, cn);
                SB.Append(cmd.ExecuteNonQuery());
            }
            catch (SqlException)
            {
                return false;
            }
            if (SQLControl(SQLStatus.DisConnect))
                return true;
        }
        return false;
    }
    //--取得資料庫內所有資料--
    public bool GetOneColumnData(string query, ArrayList _data)
    {
        _data.Clear();
        if (SQLControl(SQLStatus.Connect))
        {
            try
            {
                cmd = new SqlCommand(query, cn);
                dr = cmd.ExecuteReader();            
                while (dr.Read())
                {
                    _data.Add(dr[0].ToString());
                }
            }
            catch (SqlException)
            {
                return false;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
            if (SQLControl(SQLStatus.DisConnect))
                return true;
        }
        return false;
    }
    public bool GetAllColumnData(string query, ArrayList _data)
    {
        _data.Clear();
        if(SQLControl(SQLStatus.Connect))
        {
            try
            {
                cmd = new SqlCommand(query, cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string[] strResult = new string[dr.FieldCount];
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        strResult[i] = dr[i].ToString();
                    }
                    _data.Add(strResult);
                }
            }
            catch (SqlException)
            {
                return false;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
            if (SQLControl(SQLStatus.DisConnect))
                return true;
        }
        return false;
    }

}