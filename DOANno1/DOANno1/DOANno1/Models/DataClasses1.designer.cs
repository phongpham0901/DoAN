﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DOANno1.Models
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
    using Newtonsoft.Json;
    using System.Runtime.Serialization;

    [global::System.Data.Linq.Mapping.DatabaseAttribute(Name="QLNhanVien")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
        public DataClasses1DataContext() :
        base(global::System.Configuration.ConfigurationManager.ConnectionStrings["QLNhanVienConnectionString"].ConnectionString, mappingSource)
        {
            OnCreated();
        }
        private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertNhanVien(NhanVien instance);
    partial void UpdateNhanVien(NhanVien instance);
    partial void DeleteNhanVien(NhanVien instance);
    partial void InsertQLChamCong(QLChamCong instance);
    partial void UpdateQLChamCong(QLChamCong instance);
    partial void DeleteQLChamCong(QLChamCong instance);
    partial void InsertChucVu(ChucVu instance);
    partial void UpdateChucVu(ChucVu instance);
    partial void DeleteChucVu(ChucVu instance);
    partial void InsertQLLuong(QLLuong instance);
    partial void UpdateQLLuong(QLLuong instance);
    partial void DeleteQLLuong(QLLuong instance);
    partial void InsertTaikhoan(Taikhoan instance);
    partial void UpdateTaikhoan(Taikhoan instance);
    partial void DeleteTaikhoan(Taikhoan instance);
    #endregion
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<NhanVien> NhanViens
		{
			get
			{
				return this.GetTable<NhanVien>();
			}
		}
		
		public System.Data.Linq.Table<QLChamCong> QLChamCongs
		{
			get
			{
				return this.GetTable<QLChamCong>();
			}
		}
		
		public System.Data.Linq.Table<ChucVu> ChucVus
		{
			get
			{
				return this.GetTable<ChucVu>();
			}
		}
		
		public System.Data.Linq.Table<QLLuong> QLLuongs
		{
			get
			{
				return this.GetTable<QLLuong>();
			}
		}
		
		public System.Data.Linq.Table<Taikhoan> Taikhoans
		{
			get
			{
				return this.GetTable<Taikhoan>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.NhanVien")]
	public partial class NhanVien : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _MaNV;
		
		private string _HoTenNV;
		
		private System.Nullable<System.DateTime> _Ngaysinh;
		
		private string _Gioitinh;
		
		private string _Diachi;
		
		private string _SDT;
		
		private string _Email;
		
		private string _MaCV;
		
		private System.Nullable<byte> _isDelete;
		
		private System.Nullable<System.DateTime> _DeleteTime;
		
		private EntitySet<QLChamCong> _QLChamCongs;
		
		private EntitySet<QLLuong> _QLLuongs;
		
		private EntityRef<ChucVu> _ChucVu;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMaNVChanging(string value);
    partial void OnMaNVChanged();
    partial void OnHoTenNVChanging(string value);
    partial void OnHoTenNVChanged();
    partial void OnNgaysinhChanging(System.Nullable<System.DateTime> value);
    partial void OnNgaysinhChanged();
    partial void OnGioitinhChanging(string value);
    partial void OnGioitinhChanged();
    partial void OnDiachiChanging(string value);
    partial void OnDiachiChanged();
    partial void OnSDTChanging(string value);
    partial void OnSDTChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnMaCVChanging(string value);
    partial void OnMaCVChanged();
    partial void OnisDeleteChanging(System.Nullable<byte> value);
    partial void OnisDeleteChanged();
    partial void OnDeleteTimeChanging(System.Nullable<System.DateTime> value);
    partial void OnDeleteTimeChanged();
    #endregion
		
		public NhanVien()
		{
			this._QLChamCongs = new EntitySet<QLChamCong>(new Action<QLChamCong>(this.attach_QLChamCongs), new Action<QLChamCong>(this.detach_QLChamCongs));
			this._QLLuongs = new EntitySet<QLLuong>(new Action<QLLuong>(this.attach_QLLuongs), new Action<QLLuong>(this.detach_QLLuongs));
			this._ChucVu = default(EntityRef<ChucVu>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaNV", DbType="NChar(20) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string MaNV
		{
			get
			{
				return this._MaNV;
			}
			set
			{
				if ((this._MaNV != value))
				{
					this.OnMaNVChanging(value);
					this.SendPropertyChanging();
					this._MaNV = value;
					this.SendPropertyChanged("MaNV");
					this.OnMaNVChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HoTenNV", DbType="NVarChar(100)")]
		public string HoTenNV
		{
			get
			{
				return this._HoTenNV;
			}
			set
			{
				if ((this._HoTenNV != value))
				{
					this.OnHoTenNVChanging(value);
					this.SendPropertyChanging();
					this._HoTenNV = value;
					this.SendPropertyChanged("HoTenNV");
					this.OnHoTenNVChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ngaysinh", DbType="Date")]
		public System.Nullable<System.DateTime> Ngaysinh
		{
			get
			{
				return this._Ngaysinh;
			}
			set
			{
				if ((this._Ngaysinh != value))
				{
					this.OnNgaysinhChanging(value);
					this.SendPropertyChanging();
					this._Ngaysinh = value;
					this.SendPropertyChanged("Ngaysinh");
					this.OnNgaysinhChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Gioitinh", DbType="NChar(10)")]
		public string Gioitinh
		{
			get
			{
				return this._Gioitinh;
			}
			set
			{
				if ((this._Gioitinh != value))
				{
					this.OnGioitinhChanging(value);
					this.SendPropertyChanging();
					this._Gioitinh = value;
					this.SendPropertyChanged("Gioitinh");
					this.OnGioitinhChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Diachi", DbType="NVarChar(100)")]
		public string Diachi
		{
			get
			{
				return this._Diachi;
			}
			set
			{
				if ((this._Diachi != value))
				{
					this.OnDiachiChanging(value);
					this.SendPropertyChanging();
					this._Diachi = value;
					this.SendPropertyChanged("Diachi");
					this.OnDiachiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SDT", DbType="NChar(15)")]
		public string SDT
		{
			get
			{
				return this._SDT;
			}
			set
			{
				if ((this._SDT != value))
				{
					this.OnSDTChanging(value);
					this.SendPropertyChanging();
					this._SDT = value;
					this.SendPropertyChanged("SDT");
					this.OnSDTChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="NVarChar(100)")]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaCV", DbType="NChar(10) NOT NULL", CanBeNull=false)]
		public string MaCV
		{
			get
			{
				return this._MaCV;
			}
			set
			{
				if ((this._MaCV != value))
				{
					if (this._ChucVu.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMaCVChanging(value);
					this.SendPropertyChanging();
					this._MaCV = value;
					this.SendPropertyChanged("MaCV");
					this.OnMaCVChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_isDelete", DbType="TinyInt")]
		public System.Nullable<byte> isDelete
		{
			get
			{
				return this._isDelete;
			}
			set
			{
				if ((this._isDelete != value))
				{
					this.OnisDeleteChanging(value);
					this.SendPropertyChanging();
					this._isDelete = value;
					this.SendPropertyChanged("isDelete");
					this.OnisDeleteChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DeleteTime", DbType="DateTime")]
		public System.Nullable<System.DateTime> DeleteTime
		{
			get
			{
				return this._DeleteTime;
			}
			set
			{
				if ((this._DeleteTime != value))
				{
					this.OnDeleteTimeChanging(value);
					this.SendPropertyChanging();
					this._DeleteTime = value;
					this.SendPropertyChanged("DeleteTime");
					this.OnDeleteTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="NhanVien_QLChamCong", Storage="_QLChamCongs", ThisKey="MaNV", OtherKey="MaNV")]
		public EntitySet<QLChamCong> QLChamCongs
		{
			get
			{
				return this._QLChamCongs;
			}
			set
			{
				this._QLChamCongs.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="NhanVien_QLLuong", Storage="_QLLuongs", ThisKey="MaNV", OtherKey="MaNV")]
		public EntitySet<QLLuong> QLLuongs
		{
			get
			{
				return this._QLLuongs;
			}
			set
			{
				this._QLLuongs.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ChucVu_NhanVien", Storage="_ChucVu", ThisKey="MaCV", OtherKey="MaCV", IsForeignKey=true)]
		public ChucVu ChucVu
		{
			get
			{
				return this._ChucVu.Entity;
			}
			set
			{
				ChucVu previousValue = this._ChucVu.Entity;
				if (((previousValue != value) 
							|| (this._ChucVu.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._ChucVu.Entity = null;
						previousValue.NhanViens.Remove(this);
					}
					this._ChucVu.Entity = value;
					if ((value != null))
					{
						value.NhanViens.Add(this);
						this._MaCV = value.MaCV;
					}
					else
					{
						this._MaCV = default(string);
					}
					this.SendPropertyChanged("ChucVu");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_QLChamCongs(QLChamCong entity)
		{
			this.SendPropertyChanging();
			entity.NhanVien = this;
		}
		
		private void detach_QLChamCongs(QLChamCong entity)
		{
			this.SendPropertyChanging();
			entity.NhanVien = null;
		}
		
		private void attach_QLLuongs(QLLuong entity)
		{
			this.SendPropertyChanging();
			entity.NhanVien = this;
		}
		
		private void detach_QLLuongs(QLLuong entity)
		{
			this.SendPropertyChanging();
			entity.NhanVien = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.QLChamCong")]
	public partial class QLChamCong : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _MaCC;
		
		private System.Nullable<System.DateTime> _SBChamCong;
		
		private string _MaNV;
		
		private System.Nullable<int> _ThangCC;
		
		private System.Nullable<int> _NamCC;
		
		private EntityRef<NhanVien> _NhanVien;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMaCCChanging(string value);
    partial void OnMaCCChanged();
    partial void OnSBChamCongChanging(System.Nullable<System.DateTime> value);
    partial void OnSBChamCongChanged();
    partial void OnMaNVChanging(string value);
    partial void OnMaNVChanged();
    partial void OnThangCCChanging(System.Nullable<int> value);
    partial void OnThangCCChanged();
    partial void OnNamCCChanging(System.Nullable<int> value);
    partial void OnNamCCChanged();
    #endregion
		
		public QLChamCong()
		{
			this._NhanVien = default(EntityRef<NhanVien>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaCC", DbType="NChar(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string MaCC
		{
			get
			{
				return this._MaCC;
			}
			set
			{
				if ((this._MaCC != value))
				{
					this.OnMaCCChanging(value);
					this.SendPropertyChanging();
					this._MaCC = value;
					this.SendPropertyChanged("MaCC");
					this.OnMaCCChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SBChamCong", DbType="Date")]
		public System.Nullable<System.DateTime> SBChamCong
		{
			get
			{
				return this._SBChamCong;
			}
			set
			{
				if ((this._SBChamCong != value))
				{
					this.OnSBChamCongChanging(value);
					this.SendPropertyChanging();
					this._SBChamCong = value;
					this.SendPropertyChanged("SBChamCong");
					this.OnSBChamCongChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaNV", DbType="NChar(20) NOT NULL", CanBeNull=false)]
		public string MaNV
		{
			get
			{
				return this._MaNV;
			}
			set
			{
				if ((this._MaNV != value))
				{
					if (this._NhanVien.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMaNVChanging(value);
					this.SendPropertyChanging();
					this._MaNV = value;
					this.SendPropertyChanged("MaNV");
					this.OnMaNVChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ThangCC", DbType="Int")]
		public System.Nullable<int> ThangCC
		{
			get
			{
				return this._ThangCC;
			}
			set
			{
				if ((this._ThangCC != value))
				{
					this.OnThangCCChanging(value);
					this.SendPropertyChanging();
					this._ThangCC = value;
					this.SendPropertyChanged("ThangCC");
					this.OnThangCCChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NamCC", DbType="Int")]
		public System.Nullable<int> NamCC
		{
			get
			{
				return this._NamCC;
			}
			set
			{
				if ((this._NamCC != value))
				{
					this.OnNamCCChanging(value);
					this.SendPropertyChanging();
					this._NamCC = value;
					this.SendPropertyChanged("NamCC");
					this.OnNamCCChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="NhanVien_QLChamCong", Storage="_NhanVien", ThisKey="MaNV", OtherKey="MaNV", IsForeignKey=true)]
		public NhanVien NhanVien
		{
			get
			{
				return this._NhanVien.Entity;
			}
			set
			{
				NhanVien previousValue = this._NhanVien.Entity;
				if (((previousValue != value) 
							|| (this._NhanVien.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._NhanVien.Entity = null;
						previousValue.QLChamCongs.Remove(this);
					}
					this._NhanVien.Entity = value;
					if ((value != null))
					{
						value.QLChamCongs.Add(this);
						this._MaNV = value.MaNV;
					}
					else
					{
						this._MaNV = default(string);
					}
					this.SendPropertyChanged("NhanVien");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ChucVu")]

    [DataContract(IsReference = true)]

    public partial class ChucVu : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _MaCV;
		
		private string _TenCV;
		
		private System.Nullable<int> _isDelete;
		
		private System.Nullable<System.DateTime> _DeleteTime;

        [JsonIgnore]

        private EntitySet<NhanVien> _NhanViens;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMaCVChanging(string value);
    partial void OnMaCVChanged();
    partial void OnTenCVChanging(string value);
    partial void OnTenCVChanged();
    partial void OnisDeleteChanging(System.Nullable<int> value);
    partial void OnisDeleteChanged();
    partial void OnDeleteTimeChanging(System.Nullable<System.DateTime> value);
    partial void OnDeleteTimeChanged();
    #endregion
		
		public ChucVu()
		{
			this._NhanViens = new EntitySet<NhanVien>(new Action<NhanVien>(this.attach_NhanViens), new Action<NhanVien>(this.detach_NhanViens));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaCV", DbType="NChar(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string MaCV
		{
			get
			{
				return this._MaCV;
			}
			set
			{
				if ((this._MaCV != value))
				{
					this.OnMaCVChanging(value);
					this.SendPropertyChanging();
					this._MaCV = value;
					this.SendPropertyChanged("MaCV");
					this.OnMaCVChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenCV", DbType="NVarChar(50)")]
		public string TenCV
		{
			get
			{
				return this._TenCV;
			}
			set
			{
				if ((this._TenCV != value))
				{
					this.OnTenCVChanging(value);
					this.SendPropertyChanging();
					this._TenCV = value;
					this.SendPropertyChanged("TenCV");
					this.OnTenCVChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_isDelete", DbType="Int")]
		public System.Nullable<int> isDelete
		{
			get
			{
				return this._isDelete;
			}
			set
			{
				if ((this._isDelete != value))
				{
					this.OnisDeleteChanging(value);
					this.SendPropertyChanging();
					this._isDelete = value;
					this.SendPropertyChanged("isDelete");
					this.OnisDeleteChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DeleteTime", DbType="DateTime")]
		public System.Nullable<System.DateTime> DeleteTime
		{
			get
			{
				return this._DeleteTime;
			}
			set
			{
				if ((this._DeleteTime != value))
				{
					this.OnDeleteTimeChanging(value);
					this.SendPropertyChanging();
					this._DeleteTime = value;
					this.SendPropertyChanged("DeleteTime");
					this.OnDeleteTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="ChucVu_NhanVien", Storage="_NhanViens", ThisKey="MaCV", OtherKey="MaCV")]
		public EntitySet<NhanVien> NhanViens
		{
			get
			{
				return this._NhanViens;
			}
			set
			{
				this._NhanViens.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_NhanViens(NhanVien entity)
		{
			this.SendPropertyChanging();
			entity.ChucVu = this;
		}
		
		private void detach_NhanViens(NhanVien entity)
		{
			this.SendPropertyChanging();
			entity.ChucVu = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.QLLuong")]
	public partial class QLLuong : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _MaL;
		
		private System.Nullable<int> _LuongMB;
		
		private string _MaNV;
		
		private System.Nullable<int> _Luongquy;
		
		private EntityRef<NhanVien> _NhanVien;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMaLChanging(string value);
    partial void OnMaLChanged();
    partial void OnLuongMBChanging(System.Nullable<int> value);
    partial void OnLuongMBChanged();
    partial void OnMaNVChanging(string value);
    partial void OnMaNVChanged();
    partial void OnLuongquyChanging(System.Nullable<int> value);
    partial void OnLuongquyChanged();
    #endregion
		
		public QLLuong()
		{
			this._NhanVien = default(EntityRef<NhanVien>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaL", DbType="NChar(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string MaL
		{
			get
			{
				return this._MaL;
			}
			set
			{
				if ((this._MaL != value))
				{
					this.OnMaLChanging(value);
					this.SendPropertyChanging();
					this._MaL = value;
					this.SendPropertyChanged("MaL");
					this.OnMaLChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LuongMB", DbType="Int")]
		public System.Nullable<int> LuongMB
		{
			get
			{
				return this._LuongMB;
			}
			set
			{
				if ((this._LuongMB != value))
				{
					this.OnLuongMBChanging(value);
					this.SendPropertyChanging();
					this._LuongMB = value;
					this.SendPropertyChanged("LuongMB");
					this.OnLuongMBChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaNV", DbType="NChar(20) NOT NULL", CanBeNull=false)]
		public string MaNV
		{
			get
			{
				return this._MaNV;
			}
			set
			{
				if ((this._MaNV != value))
				{
					if (this._NhanVien.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMaNVChanging(value);
					this.SendPropertyChanging();
					this._MaNV = value;
					this.SendPropertyChanged("MaNV");
					this.OnMaNVChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Luongquy", DbType="Int")]
		public System.Nullable<int> Luongquy
		{
			get
			{
				return this._Luongquy;
			}
			set
			{
				if ((this._Luongquy != value))
				{
					this.OnLuongquyChanging(value);
					this.SendPropertyChanging();
					this._Luongquy = value;
					this.SendPropertyChanged("Luongquy");
					this.OnLuongquyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="NhanVien_QLLuong", Storage="_NhanVien", ThisKey="MaNV", OtherKey="MaNV", IsForeignKey=true)]
		public NhanVien NhanVien
		{
			get
			{
				return this._NhanVien.Entity;
			}
			set
			{
				NhanVien previousValue = this._NhanVien.Entity;
				if (((previousValue != value) 
							|| (this._NhanVien.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._NhanVien.Entity = null;
						previousValue.QLLuongs.Remove(this);
					}
					this._NhanVien.Entity = value;
					if ((value != null))
					{
						value.QLLuongs.Add(this);
						this._MaNV = value.MaNV;
					}
					else
					{
						this._MaNV = default(string);
					}
					this.SendPropertyChanged("NhanVien");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Taikhoan")]
	public partial class Taikhoan : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _TenTK;
		
		private string _User;
		
		private string _Password;
		
		private string _QuyenTC;
		
		private System.Nullable<int> _isDetele;
		
		private string _DeleteTime;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnTenTKChanging(string value);
    partial void OnTenTKChanged();
    partial void OnUserChanging(string value);
    partial void OnUserChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnQuyenTCChanging(string value);
    partial void OnQuyenTCChanged();
    partial void OnisDeteleChanging(System.Nullable<int> value);
    partial void OnisDeteleChanged();
    partial void OnDeleteTimeChanging(string value);
    partial void OnDeleteTimeChanged();
    #endregion
		
		public Taikhoan()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenTK", DbType="NChar(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string TenTK
		{
			get
			{
				return this._TenTK;
			}
			set
			{
				if ((this._TenTK != value))
				{
					this.OnTenTKChanging(value);
					this.SendPropertyChanging();
					this._TenTK = value;
					this.SendPropertyChanged("TenTK");
					this.OnTenTKChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[User]", Storage="_User", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string User
		{
			get
			{
				return this._User;
			}
			set
			{
				if ((this._User != value))
				{
					this.OnUserChanging(value);
					this.SendPropertyChanging();
					this._User = value;
					this.SendPropertyChanged("User");
					this.OnUserChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_QuyenTC", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string QuyenTC
		{
			get
			{
				return this._QuyenTC;
			}
			set
			{
				if ((this._QuyenTC != value))
				{
					this.OnQuyenTCChanging(value);
					this.SendPropertyChanging();
					this._QuyenTC = value;
					this.SendPropertyChanged("QuyenTC");
					this.OnQuyenTCChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_isDetele", DbType="Int")]
		public System.Nullable<int> isDetele
		{
			get
			{
				return this._isDetele;
			}
			set
			{
				if ((this._isDetele != value))
				{
					this.OnisDeteleChanging(value);
					this.SendPropertyChanging();
					this._isDetele = value;
					this.SendPropertyChanged("isDetele");
					this.OnisDeteleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DeleteTime", DbType="NVarChar(30)")]
		public string DeleteTime
		{
			get
			{
				return this._DeleteTime;
			}
			set
			{
				if ((this._DeleteTime != value))
				{
					this.OnDeleteTimeChanging(value);
					this.SendPropertyChanging();
					this._DeleteTime = value;
					this.SendPropertyChanged("DeleteTime");
					this.OnDeleteTimeChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
