/// <summary>******************************************************************
/// 
/// Copyright (C) 2005  Stefano Franco
///
/// Based on JExcelAPI by Andrew Khan.
/// 
/// This library is free software; you can redistribute it and/or
/// modify it under the terms of the GNU Lesser General Public
/// License as published by the Free Software Foundation; either
/// version 2.1 of the License, or (at your option) any later version.
/// 
/// This library is distributed in the hope that it will be useful,
/// but WITHOUT ANY WARRANTY; without even the implied warranty of
/// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
/// Lesser General Public License for more details.
/// 
/// You should have received a copy of the GNU Lesser General Public
/// License along with this library; if not, write to the Free Software
/// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
/// *************************************************************************
/// </summary>
using System;
using ExcelOperate.Utils;
using ExcelOperate.ReadExcel ;
using ExcelOperate.Biff;
namespace ExcelOperate.Read.Biff
{
	
	/// <summary> A number record.  This is stored as 8 bytes, as opposed to the
	/// 4 byte RK record
	/// </summary>
	class NumberRecord:CellValue, NumberCell
	{
		/// <summary> Accessor for the value
		/// 
		/// </summary>
		/// <returns> the value
		/// </returns>
		virtual public double DoubleValue
		{
			get
			{
			return _Value;
			}
		}

		/// <summary>
		/// Returns the string value.
		/// </summary>
		virtual public object Value
		{
			get
			{
				return this._Value;
			}
		}

		/// <summary> Returns the contents of this cell as a string
		/// 
		/// </summary>
		/// <returns> the value formatted into a string
		/// </returns>
		virtual public string Contents
		{
			get
			{
 
//				return _Value.ToString(format);
				return string.Format(format, "{0}", _Value);
			}
			
		}
		/// <summary> Accessor for the cell type
		/// 
		/// </summary>
		/// <returns> the cell type
		/// </returns>
		virtual public CellType Type
		{
			get
			{
				return CellType.NUMBER;
			}
			
		}
		/// <summary> Gets the NumberFormatInfo used to format this cell.  This is the java
		/// equivalent of the Excel format
		/// 
		/// </summary>
		/// <returns> the NumberFormatInfo used to format the cell
		/// </returns>
		virtual public NumberFormatInfo NumberFormat
		{
			get
			{
				return format;
			}
			
		}
		/// <summary> The value</summary>
		private double _Value;
		
		/// <summary> The java equivalent of the excel format</summary>
		new private NumberFormatInfo format;
		
		/// <summary> The formatter to convert the value into a string</summary>
		private static NumberFormatInfo defaultFormat;
		
		/// <summary> Constructs this object from the raw data
		/// 
		/// </summary>
		/// <param name="t">the raw data
		/// </param>
		/// <param name="fr">the available formats
		/// </param>
		/// <param name="si">the sheet
		/// </param>
		public NumberRecord(Record t, FormattingRecords fr, SheetImpl si):base(t, fr, si)
		{
			sbyte[] data = getRecord().Data;
			
			_Value = DoubleHelper.getIEEEDouble(data, 6);
			
			// Now get the number format
			format = fr.getNumberFormat(XFIndex);
			if (format == null)
			{
				format = defaultFormat;
			}
		}
		static NumberRecord()
		{
			defaultFormat = new NumberFormatInfo("#.###");
		}
	}
}
