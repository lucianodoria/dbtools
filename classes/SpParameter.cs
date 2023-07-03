using System;
using System.Data;
using System.Data.SqlClient;
using System.CodeDom;
using System.CodeDom.Compiler;

namespace SqlServerSPGenerator
{

	public class SqlDbTypeToTypeAssociation: System.Collections.DictionaryBase
	{
		/// <summary>
		/// Initializes a new empty instance of the SqlDbTypeToTypeAssociation class
		/// </summary>
		public SqlDbTypeToTypeAssociation()
		{
			// empty
		}

		/// <summary>
		/// Gets or sets the Type associated with the given SqlDbType
		/// </summary>
		/// <param name="key">
		/// The SqlDbType whose value to get or set.
		/// </param>
		public virtual Type this[SqlDbType key]
		{
			get
			{
				return (Type) this.Dictionary[key];
			}
			set
			{
				this.Dictionary[key] = value;
			}
		}

		/// <summary>
		/// Adds an element with the specified key and value to this SqlDbTypeToTypeAssociation.
		/// </summary>
		/// <param name="key">
		/// The SqlDbType key of the element to add.
		/// </param>
		/// <param name="value">
		/// The Type value of the element to add.
		/// </param>
		public virtual void Add(SqlDbType key, Type value)
		{
			this.Dictionary.Add(key, value);
		}

		/// <summary>
		/// Determines whether this SqlDbTypeToTypeAssociation contains a specific key.
		/// </summary>
		/// <param name="key">
		/// The SqlDbType key to locate in this SqlDbTypeToTypeAssociation.
		/// </param>
		/// <returns>
		/// true if this SqlDbTypeToTypeAssociation contains an element with the specified key;
		/// otherwise, false.
		/// </returns>
		public virtual bool Contains(SqlDbType key)
		{
			return this.Dictionary.Contains(key);
		}

		/// <summary>
		/// Determines whether this SqlDbTypeToTypeAssociation contains a specific key.
		/// </summary>
		/// <param name="key">
		/// The SqlDbType key to locate in this SqlDbTypeToTypeAssociation.
		/// </param>
		/// <returns>
		/// true if this SqlDbTypeToTypeAssociation contains an element with the specified key;
		/// otherwise, false.
		/// </returns>
		public virtual bool ContainsKey(SqlDbType key)
		{
			return this.Dictionary.Contains(key);
		}

		/// <summary>
		/// Determines whether this SqlDbTypeToTypeAssociation contains a specific value.
		/// </summary>
		/// <param name="value">
		/// The Type value to locate in this SqlDbTypeToTypeAssociation.
		/// </param>
		/// <returns>
		/// true if this SqlDbTypeToTypeAssociation contains an element with the specified value;
		/// otherwise, false.
		/// </returns>
		public virtual bool ContainsValue(Type value)
		{
			foreach (Type item in this.Dictionary.Values)
			{
				if (item == value)
					return true;
			}
			return false;
		}

		/// <summary>
		/// Removes the element with the specified key from this SqlDbTypeToTypeAssociation.
		/// </summary>
		/// <param name="key">
		/// The SqlDbType key of the element to remove.
		/// </param>
		public virtual void Remove(SqlDbType key)
		{
			this.Dictionary.Remove(key);
		}

		/// <summary>
		/// Gets a collection containing the keys in this SqlDbTypeToTypeAssociation.
		/// </summary>
		public virtual System.Collections.ICollection Keys
		{
			get
			{
				return this.Dictionary.Keys;
			}
		}

		/// <summary>
		/// Gets a collection containing the values in this SqlDbTypeToTypeAssociation.
		/// </summary>
		public virtual System.Collections.ICollection Values
		{
			get
			{
				return this.Dictionary.Values;
			}
		}
	}


	public class TypeMapping 
	{
		static SqlDbTypeToTypeAssociation map;

		public static SqlDbTypeToTypeAssociation Mapping 
		{
			get {return map;}
		}

		static TypeMapping()
		{
			map = new SqlDbTypeToTypeAssociation();
			map.Add(SqlDbType.BigInt, typeof(Int64));
			map.Add(SqlDbType.Binary, typeof(byte[]));
			map.Add(SqlDbType.Bit, typeof(Boolean ));
			map.Add(SqlDbType.Char, typeof( String ));
			map.Add(SqlDbType.DateTime, typeof( DateTime ));
			map.Add(SqlDbType.Decimal, typeof( Decimal ));
			map.Add(SqlDbType.Float, typeof( Double ));
			map.Add(SqlDbType.Image, typeof( byte[]));
			map.Add(SqlDbType.Int, typeof( Int32 ));
			map.Add(SqlDbType.Money, typeof( Decimal)); 
			map.Add(SqlDbType.NChar, typeof( String ));
			map.Add(SqlDbType.NText, typeof( String ));
			map.Add(SqlDbType.NVarChar, typeof( String ));
			map.Add(SqlDbType.Real, typeof( Single ));
			map.Add(SqlDbType.SmallDateTime, typeof( DateTime ));
			map.Add(SqlDbType.SmallInt, typeof( Int16 ));
			map.Add(SqlDbType.SmallMoney, typeof( Decimal)); 
			map.Add(SqlDbType.Text, typeof( String ));
			map.Add(SqlDbType.Timestamp, typeof( DateTime ));
			map.Add(SqlDbType.TinyInt, typeof( Byte ));
			map.Add(SqlDbType.UniqueIdentifier, typeof( Guid ));
			map.Add(SqlDbType.VarBinary, typeof( byte[] ));
			map.Add(SqlDbType.VarChar, typeof( String ));
			map.Add(SqlDbType.Variant, typeof( Object  ));
		}
	}

	internal class SpParameter
	{
		private SqlParameter mParam;
		private string sFriendlyName;
		private SqlDbTypeToTypeAssociation mMap;		
		private SpParameter()//Disallowed
		{}
		public SpParameter(SqlParameter sParam)
		{
			mParam =sParam;
			sFriendlyName = mParam.ParameterName.Remove(0,1);//Removes the @ prefix
			mMap = TypeMapping.Mapping;
		}
		public string Name
		{
			get
			{
				return mParam.ParameterName;
			}
		}
		public string FriendlyName
		{
			get
			{
				return sFriendlyName;
			}
		}

		public CodeParameterDeclarationExpression decl()
		{
			CodeParameterDeclarationExpression cpde = new CodeParameterDeclarationExpression(
				mMap[mParam.SqlDbType],
				this.FriendlyName);
			if(mParam.Direction == ParameterDirection.InputOutput || mParam.Direction == ParameterDirection.Output)
				cpde.Direction = FieldDirection.Ref;
			return cpde;
		}

		/// <summary>
		/// Creates the code statements needed to fetch the value from the command object back into
		/// the by ref variable. If this param is not an output variable a comment is generated instead
		/// </summary>
		/// <param name="oCmdName"></param>
		/// <returns></returns>
		public CodeStatement[] FetchFrom(string oCmdName)
		{
			if(
				mParam.Direction == ParameterDirection.Output || 
				mParam.Direction == ParameterDirection.InputOutput
				)
			{
				CodeExpressionStatement ces = new CodeExpressionStatement();
				
				return new CodeStatement[] 
					{
						new CodeAssignStatement(
						new CodeVariableReferenceExpression(this.FriendlyName),
						new CodeCastExpression(mMap[mParam.SqlDbType],
						new CodePropertyReferenceExpression(
						new CodeIndexerExpression(
						new CodePropertyReferenceExpression(
						new CodeVariableReferenceExpression("cmd"),"Parameters"),
						new CodePrimitiveExpression(this.Name)),"Value")))
					};
			}
			else
				return new CodeStatement[] {new CodeCommentStatement(string.Format("The Parameter {0} is not an output type",this.Name))};
		}
		
		/// <summary>
		/// Creates the code statements needed to add this param to a command object
		/// </summary>
		/// <param name="oCmdName"></param>
		/// <returns></returns>
		public CodeStatement[] CreateFor(string oCmdName)
		{

			return new CodeStatement[] 
			{
				new CodeExpressionStatement(
				new CodeMethodInvokeExpression(
				new CodePropertyReferenceExpression(
				new CodeVariableReferenceExpression(oCmdName),"Parameters"),
				"Add",
				new CodeExpression[] {new CodePrimitiveExpression(this.Name),new CodeFieldReferenceExpression(new CodeTypeReferenceExpression("System.Data.SqlDbType"),mParam.SqlDbType.ToString()),new CodePrimitiveExpression(mParam.Size)})
				),
				new CodeAssignStatement(new CodePropertyReferenceExpression(new CodeIndexerExpression(new CodePropertyReferenceExpression(new CodeVariableReferenceExpression(oCmdName),"Parameters"),new CodePrimitiveExpression(this.Name)),"Direction"),
				new CodeFieldReferenceExpression(new CodeTypeReferenceExpression("System.Data.ParameterDirection"),mParam.Direction.ToString())
				),
				new CodeAssignStatement(new CodePropertyReferenceExpression(new CodeIndexerExpression(new CodePropertyReferenceExpression(new CodeVariableReferenceExpression(oCmdName),"Parameters"),new CodePrimitiveExpression(this.Name)),"Value"),
				new CodeArgumentReferenceExpression(this.FriendlyName)
				)
			};
		}
	}
}
