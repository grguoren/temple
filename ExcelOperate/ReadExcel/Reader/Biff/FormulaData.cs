
using System;
using ExcelOperate.ReadExcel;
using ExcelOperate.Biff.Formula;
namespace ExcelOperate.Biff
{
	
	/// <summary> Interface which is used for copying formulas from a read only
	/// to a writable spreadsheet
	/// </summary>
	public interface FormulaData : Cell
		{
			/// <summary> Gets the raw bytes for the formula.  This will include the
			/// parsed tokens array EXCLUDING the standard cell information
			/// (row, column, xfindex)
			/// 
			/// </summary>
			/// <returns> the raw record data
			/// </returns>
			/// <exception cref=""> FormulaException
			/// </exception>
			sbyte[] getFormulaData();
		}
}
