// Business class TestProduct generated from TestProducts
// Creator: WGM
// Created Date: [2015-03-31]

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Castle.ActiveRecord;
using Razor.Data;
	
namespace DataModel
{
	[ActiveRecord("TestProducts")]
	public partial class TestProduct : ModelBase<TestProduct>
	{
		#region Property_Names

		public static string Prop_ID = "ID";
		public static string Prop_ProductID = "ProductID";
		public static string Prop_ProductName = "ProductName";
		public static string Prop_SupplierID = "SupplierID";
		public static string Prop_CategoryID = "CategoryID";
		public static string Prop_QuantityPerUnit = "QuantityPerUnit";
		public static string Prop_UnitPrice = "UnitPrice";
		public static string Prop_UnitsInStock = "UnitsInStock";
		public static string Prop_UnitsOnOrder = "UnitsOnOrder";
		public static string Prop_ReorderLevel = "ReorderLevel";
		public static string Prop_Discontinued = "Discontinued";

		#endregion

		#region Private_Variables

		private string _id;
		private int _productID;
		private string _productName;
		private int? _supplierID;
		private int? _categoryID;
		private string _quantityPerUnit;
		private System.Decimal? _unitPrice;
		private short? _unitsInStock;
		private short? _unitsOnOrder;
		private short? _reorderLevel;
		private bool _discontinued;


		#endregion

		#region Constructors

		public TestProduct()
		{
		}

		public TestProduct(
			string p_id,
			int p_productID,
			string p_productName,
			int? p_supplierID,
			int? p_categoryID,
			string p_quantityPerUnit,
			System.Decimal? p_unitPrice,
			short? p_unitsInStock,
			short? p_unitsOnOrder,
			short? p_reorderLevel,
			bool p_discontinued)
		{
			_id = p_id;
			_productID = p_productID;
			_productName = p_productName;
			_supplierID = p_supplierID;
			_categoryID = p_categoryID;
			_quantityPerUnit = p_quantityPerUnit;
			_unitPrice = p_unitPrice;
			_unitsInStock = p_unitsInStock;
			_unitsOnOrder = p_unitsOnOrder;
			_reorderLevel = p_reorderLevel;
			_discontinued = p_discontinued;
		}

		#endregion

		#region Properties

		[PrimaryKey("ID", Generator = PrimaryKeyType.Custom, CustomGenerator = typeof(IDGenerator), Access = PropertyAccess.NosetterLowercaseUnderscore)]
		public string ID
		{
			get { return _id; }
			set { _id = value; } // 处理列表编辑时去掉注释

		}

		[Property("ProductID", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true)]
		public int ProductID
		{
			get { return _productID; }
			set
			{
				if (value != _productID)
				{
                    object oldValue = _productID;
					_productID = value;
					RaisePropertyChanged(TestProduct.Prop_ProductID, oldValue, value);
				}
			}

		}

		[Property("ProductName", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true, Length = 40)]
		public string ProductName
		{
			get { return _productName; }
			set
			{
				if ((_productName == null) || (value == null) || (!value.Equals(_productName)))
				{
                    object oldValue = _productName;
					_productName = value;
					RaisePropertyChanged(TestProduct.Prop_ProductName, oldValue, value);
				}
			}

		}

		[Property("SupplierID", Access = PropertyAccess.NosetterCamelcaseUnderscore)]
		public int? SupplierID
		{
			get { return _supplierID; }
			set
			{
				if (value != _supplierID)
				{
                    object oldValue = _supplierID;
					_supplierID = value;
					RaisePropertyChanged(TestProduct.Prop_SupplierID, oldValue, value);
				}
			}

		}

		[Property("CategoryID", Access = PropertyAccess.NosetterCamelcaseUnderscore)]
		public int? CategoryID
		{
			get { return _categoryID; }
			set
			{
				if (value != _categoryID)
				{
                    object oldValue = _categoryID;
					_categoryID = value;
					RaisePropertyChanged(TestProduct.Prop_CategoryID, oldValue, value);
				}
			}

		}

		[Property("QuantityPerUnit", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 20)]
		public string QuantityPerUnit
		{
			get { return _quantityPerUnit; }
			set
			{
				if ((_quantityPerUnit == null) || (value == null) || (!value.Equals(_quantityPerUnit)))
				{
                    object oldValue = _quantityPerUnit;
					_quantityPerUnit = value;
					RaisePropertyChanged(TestProduct.Prop_QuantityPerUnit, oldValue, value);
				}
			}

		}

		[Property("UnitPrice", Access = PropertyAccess.NosetterCamelcaseUnderscore)]
		public System.Decimal? UnitPrice
		{
			get { return _unitPrice; }
			set
			{
				if (value != _unitPrice)
				{
                    object oldValue = _unitPrice;
					_unitPrice = value;
					RaisePropertyChanged(TestProduct.Prop_UnitPrice, oldValue, value);
				}
			}

		}

		[Property("UnitsInStock", Access = PropertyAccess.NosetterCamelcaseUnderscore)]
		public short? UnitsInStock
		{
			get { return _unitsInStock; }
			set
			{
				if (value != _unitsInStock)
				{
                    object oldValue = _unitsInStock;
					_unitsInStock = value;
					RaisePropertyChanged(TestProduct.Prop_UnitsInStock, oldValue, value);
				}
			}

		}

		[Property("UnitsOnOrder", Access = PropertyAccess.NosetterCamelcaseUnderscore)]
		public short? UnitsOnOrder
		{
			get { return _unitsOnOrder; }
			set
			{
				if (value != _unitsOnOrder)
				{
                    object oldValue = _unitsOnOrder;
					_unitsOnOrder = value;
					RaisePropertyChanged(TestProduct.Prop_UnitsOnOrder, oldValue, value);
				}
			}

		}

		[Property("ReorderLevel", Access = PropertyAccess.NosetterCamelcaseUnderscore)]
		public short? ReorderLevel
		{
			get { return _reorderLevel; }
			set
			{
				if (value != _reorderLevel)
				{
                    object oldValue = _reorderLevel;
					_reorderLevel = value;
					RaisePropertyChanged(TestProduct.Prop_ReorderLevel, oldValue, value);
				}
			}

		}

		[Property("Discontinued", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true)]
		public bool Discontinued
		{
			get { return _discontinued; }
			set
			{
				if (value != _discontinued)
				{
                    object oldValue = _discontinued;
					_discontinued = value;
					RaisePropertyChanged(TestProduct.Prop_Discontinued, oldValue, value);
				}
			}

		}

		#endregion
	} // TestProduct
}

