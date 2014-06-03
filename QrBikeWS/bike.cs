/*
 * 由SharpDevelop创建。
 * 用户： Kingsun
 * 日期: 14-5-25
 * 时间: 23:06
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Runtime.Serialization;
using System.IO;

namespace QrBikeWS
{
	/// <summary>
	/// Description of bike.
	/// </summary>
	public class Bike
	{
		private string _id;
		private string _name;
		private string _phone;
		private string _dorm;
		private string _color;
		private string _areas;
		private char _state;
		public Bike()
		{
		}
		
		public string id
		{
			get{return _id;}
			set{this._id=value;}
		}		
		public string name
		{
			get{return _name;}
			set{this._name=value;}
		}		
		public string phone
		{
			get{return _phone;}
			set{this._phone=value;}
		}		
		public string dorm
		{
			get{return _dorm;}
			set{this._dorm=value;}
		}		
		public string color
		{
			get{return _color;}
			set{this._color=value;}
		}		
		public string areas
		{
			get{return _areas;}
			set{this._areas=value;}
		}		
		public char state
		{
			get{return _state;}
			set{this._state=value;}
		}
	}
}
