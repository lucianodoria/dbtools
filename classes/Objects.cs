using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Microsoft.SqlServer.Management.Smo;

namespace DBTools.classes.ObjectsClass
{
    public enum SqlDataType
    {
        None = 0,
        BigInt = 1,
        Binary = 2,
        Bit = 3,
        Char = 4,
        DateTime = 6,
        Decimal = 7,
        Float = 8,
        Image = 9,
        Int = 10,
        Money = 11,
        NChar = 12,
        NText = 13,
        NVarChar = 14,
        NVarCharMax = 15,
        Real = 16,
        SmallDateTime = 17,
        SmallInt = 18,
        SmallMoney = 19,
        Text = 20,
        Timestamp = 21,
        TinyInt = 22,
        UniqueIdentifier = 23,
        UserDefinedDataType = 24,
        UserDefinedType = 25,
        VarBinary = 28,
        VarBinaryMax = 29,
        VarChar = 30,
        VarCharMax = 31,
        Variant = 32,
        Xml = 33,
        SysName = 34,
        Numeric = 35,
        Date = 36,
        Time = 37,
        DateTimeOffset = 38,
        DateTime2 = 39,
        UserDefinedTableType = 40,
        HierarchyId = 41,
        Geometry = 42,
        Geography = 43
    }
    public struct Table
    {
        public int Id;
        public string Name;
        public DateTime CreateDate;
        public string Owner;
        public int RowCount;
        public string DataBase;
        public string Description;
    }
    public class Tables : CollectionBase
    {
        public Table this[int index]
        {
            get
            {
                return (Table)this.List[index];
            }
            set
            {
                this.List[index] = value;
            }
        }
        public int Add(Table table)
        {
            return base.List.Add(table);
        }
        public bool Contains(Table table)
        {
            return base.List.Contains(table);
        }
        public void Insert(int index, Table table)
        {
            base.List.Insert(index, table);
        }
        public void Remove(Table table)
        {
            base.List.Remove(table);
        }
    }
    public struct View
    {
        public int Id;
        public string Name;
        public string DataBase;
        public string Owner;
    }
    public class Views : CollectionBase
    {
        public View this[int index]
        {
            get
            {
                return (View)this.List[index];
            }
            set
            {
                this.List[index] = value;
            }
        }
        public int Add(View view)
        {
            return base.List.Add(view);
        }
        public bool Contains(View view)
        {
            return base.List.Contains(view);
        }
        public void Insert(int index, View view)
        {
            base.List.Insert(index, view);
        }
        public void Remove(View view)
        {
            base.List.Remove(view);
        }
    }

    public struct StoredProcedure
    {
        public int Id;
        public string Name;
        public string DataBase;
        public string Owner;
    }
    public class StoredProcedures : CollectionBase
    {
        public StoredProcedure this[int index]
        {
            get
            {
                return (StoredProcedure)this.List[index];
            }
            set
            {
                this.List[index] = value;
            }
        }
        public int Add(StoredProcedure sp)
        {
            return base.List.Add(sp);
        }
        public bool Contains(StoredProcedure sp)
        {
            return base.List.Contains(sp);
        }
        public void Insert(int index, StoredProcedure sp)
        {
            base.List.Insert(index, sp);
        }
        public void Remove(StoredProcedure sp)
        {
            base.List.Remove(sp);
        }
    }

    public struct Column
    {
        public int Id;
        public string Name;
        public bool IsPrimaryKey;
        public bool Identity;
        public bool Nullable;
        public bool IsForeignKey;
        public Table TableForeignKey;
        public ColumnDataType DataType;
        public string DataBase;
        public string Description;
    }
    public struct ColumnDataType
    {
        public string Name;
        public int MaximumLength;
        public int NumericPrecision;
        public int NumericScale;
        public SqlDataType SqlDataType;
    }
    public class Columns : CollectionBase
    {
        public Column this[int index]
        {
            get
            {
                return (Column)this.List[index];
            }
            set
            {
                this.List[index] = value;
            }
        }
        public int Add(Column column)
        {
            return base.List.Add(column);
        }
        public bool Contains(Column column)
        {
            return base.List.Contains(column);
        }
        public void Insert(int index, Column column)
        {
            base.List.Insert(index, column);
        }
        public void Remove(Column column)
        {
            base.List.Remove(column);
        }
    }

    public struct StoredProcedureParameter
    {
        public int Id;
        public string Name;
        public bool IsOutputParameter;
        public string TypeWithLength;
        public StoredProcedure StoredProcedure;
        public ColumnDataType DataType;
        public string DataBase;
    }
    public class StoredProcedureParameters : CollectionBase
    {
        public StoredProcedureParameter this[int index]
        {
            get
            {
                return (StoredProcedureParameter)this.List[index];
            }
            set
            {
                this.List[index] = value;
            }
        }
        public int Add(StoredProcedureParameter spp)
        {
            return base.List.Add(spp);
        }
        public bool Contains(StoredProcedureParameter spp)
        {
            return base.List.Contains(spp);
        }
        public void Insert(int index, StoredProcedureParameter spp)
        {
            base.List.Insert(index, spp);
        }
        public void Remove(StoredProcedureParameter spp)
        {
            base.List.Remove(spp);
        }
    }
}
