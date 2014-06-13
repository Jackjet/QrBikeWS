/*
 * 由SharpDevelop创建。
 * 用户： Kingsun
 * 日期: 14-5-25
 * 时间: 21:45
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Collections;

namespace QrBikeWS
{
	[WebService]
	public class Soap : System.Web.Services.WebService
	{
		DBHelper dbhelper = new DBHelper();
		/// <summary>
		/// Logs into the web service
		/// </summary>
		/// <param name="userName">The User Name to login in as</param>
		/// <param name="password">User's password</param>
		/// <returns>True on successful login.</returns>
		[WebMethod(EnableSession=true)]
		public bool Login(string userName, string password)
		{
			//NOTE: There are better ways of doing authentication. This is just illustrates Session usage.
			UserName = userName;
			return true;
		}
		
		/// <summary>
		/// Logs out of the Session.
		/// </summary>
		[WebMethod(EnableSession=true)]
		public void Logout()
		{    
			Context.Session.Abandon();
		}
		
		/// <summary>
		/// UserName of the logged in user.
		/// </summary>
		private string UserName {
			get {return (string)Context.Session["User"];}
			set {Context.Session["User"] = value;}
		}
		
		[WebMethod(EnableSession=true)]
		public Bike getBike(string id)
		{
			return dbhelper.getBike(id);
		}
		
		[WebMethod(EnableSession=true)]
		public string insertVio(string sfbh, string jlsj, string jlr, string jldz, string wgxw)
		{
			return dbhelper.insertVio(sfbh,jlsj,jlr,jldz,wgxw);
		}
	}
}
