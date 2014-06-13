/*
 * 由SharpDevelop创建。
 * 用户： Kingsun
 * 日期: 14-5-25
 * 时间: 22:07
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace QrBikeWS
{
	/// <summary>
	/// Description of DBHelper.
	/// </summary>
	public class DBHelper:IDisposable
	{
		public static SqlConnection sqlCon;
		public DBHelper()
		{
			if(sqlCon==null)
			{
				sqlCon=new SqlConnection();
				sqlCon.ConnectionString=@"Data Source=GODSHIP\SQLEXPRESS;User ID=qrbike;Password=qrbike";
				sqlCon.Open();
			}
		}
		
		//销毁函数
		public void Dispose()
		{
			if(sqlCon!=null)
			{
				sqlCon.Close();
				sqlCon=null;
			}
		}
		
		//获取Bike记录
		public Bike getBike(string id)
		{
			Bike bike = new Bike();
			try 
			{
				string sql="select id,name,phone,dorm,color,areas,state" +
				" from bike where id=" + id;
				SqlCommand cmd=new SqlCommand(sql,sqlCon);
				SqlParameter para=new SqlParameter(id,SqlDbType.VarChar);
				para.Value="%"+id+"%";
				cmd.Parameters.Add(para);
				SqlDataReader reader=cmd.ExecuteReader();
				
				if(reader.HasRows)
				{
					while(reader.Read())
					{
						bike.id=(string)reader.GetValue(0);
						bike.name=(string)reader.GetValue(1);
						bike.phone=(string)reader.GetValue(2);
						bike.dorm=(string)reader.GetValue(3);
						bike.color=(string)reader.GetValue(4);
						bike.areas=(string)reader.GetValue(5);
						bike.state=(string)reader.GetValue(6);
					}
				}
				reader.Close();
				cmd.Dispose();
			}catch(Exception){}
			return bike;
		}
		
		//insert bike.Violation
		public string insertVio(string sfbh, string jlsj, string jlr, string jldz, string wgxw)
		{
			try
			{
			
				string sql="insert into Violation(sfbh,jlsj,jlr,jldz,wgxw) values('" + sfbh + "','" + DateTime.Parse(jlsj) + "','" + jlr + "','" + jldz + "','" + wgxw + "')";

				SqlCommand cmd=new SqlCommand(sql,sqlCon);
				if(cmd.ExecuteNonQuery()!=0)
				{
					return "成功录入.";
				}
				cmd.Dispose();
			}catch(Exception e){ return e.ToString();}
			return "录入失败.";
		}
	}
}
