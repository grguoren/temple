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
using System.IO;
using ExcelOperate.Read.Biff;
namespace ExcelOperate.ReadExcel
{ 
	
	/// <summary> Represents a Workbook.  Contains the various factory methods and provides
	/// a variety of accessors which provide access to the work sheets.
	/// </summary>
	public abstract class Workbook 
	{
		/// <summary> Gets the sheets within this workbook.  Use of this method for
		/// large worksheets can cause performance problems.
		/// 
		/// </summary>
		/// <returns> an array of the individual sheets
		/// </returns>
		public abstract Sheet[] Sheets{get;}
		/// <summary> Gets the sheet names
		/// 
		/// </summary>
		/// <returns> an array of strings containing the sheet names
		/// </returns>
		public abstract string[] SheetNames{get;}

		/// <summary> Returns the number of sheets in this workbook
		/// 
		/// </summary>
		/// <returns> the number of sheets in this workbook
		/// </returns>
		public abstract int NumberOfSheets{get;}
		/// <summary> Gets the named ranges
		/// 
		/// </summary>
		/// <returns> the list of named cells within the workbook
		/// </returns>
		public abstract string[] RangeNames{get;}
		/// <summary> Determines whether the sheet is protected
		/// 
		/// </summary>
		/// <returns> TRUE if the workbook is protected, FALSE otherwise
		/// </returns>
		public abstract bool Protected{get;}

		/// <summary> The constructor</summary>
		protected internal Workbook()
		{
		}
		
		/// <summary> Gets the specified sheet within this workbook
		/// As described in the accompanying technical notes, each call
		/// to getSheet forces a reread of the sheet (for memory reasons).
		/// Therefore, do not make unnecessary calls to this method.  Furthermore,
		/// do not hold unnecessary references to Sheets in client code, as
		/// this will prevent the garbage collector from freeing the memory
		/// 
		/// </summary>
		/// <param name="index">the zero based index of the reQuired sheet
		/// </param>
		/// <returns> The sheet specified by the index
		/// </returns>
		/// <exception cref=""> IndexOutOfBoundException when index refers to a non-existent
		/// sheet
		/// </exception>
		public abstract Sheet getSheet(int index);
		
		/// <summary> Gets the sheet with the specified name from within this workbook.
		/// As described in the accompanying technical notes, each call
		/// to getSheet forces a reread of the sheet (for memory reasons).
		/// Therefore, do not make unnecessary calls to this method.  Furthermore,
		/// do not hold unnecessary references to Sheets in client code, as
		/// this will prevent the garbage collector from freeing the memory
		/// 
		/// </summary>
		/// <param name="name">the sheet name
		/// </param>
		/// <returns> The sheet with the specified name, or null if it is not found
		/// </returns>
		public abstract Sheet getSheet(string name);
		
		/// <summary> Gets the named cell from this workbook.  The name refers to a
		/// range of cells, then the cell on the top left is returned.  If
		/// the name cannot be, null is returned.
		/// This is a convenience function to quickly access the contents
		/// of a single cell.  If you need further information (such as the
		/// sheet or adjacent cells in the range) use the functionally
		/// richer method, findByName which returns a list of ranges
		/// 
		/// </summary>
		/// <param name="name">the name of the cell/range to search for
		/// </param>
		/// <returns> the cell in the top left of the range if found, NULL
		/// otherwise
		/// </returns>
		public abstract Cell findCellByName(string name);
		
		/// <summary> Gets the named range from this workbook.  The Range object returns
		/// contains all the cells from the top left to the bottom right
		/// of the range.
		/// If the named range comprises an adjacent range,
		/// the Range[] will contain one object; for non-adjacent
		/// ranges, it is necessary to return an array of .Length greater than
		/// one.
		/// If the named range contains a single cell, the top left and
		/// bottom right cell will be the same cell
		/// 
		/// </summary>
		/// <param name="name">the name of the cell/range to search for
		/// </param>
		/// <returns> the range of cells, or NULL if the range does not exist
		/// </returns>
		public abstract Range[] findByName(string name);
		
		/// <summary> Parses the excel file.
		/// If the workbook is password protected a PasswordException is thrown
		/// in case consumers of the API wish to handle this in a particular way
		/// 
		/// </summary>
		/// <exception cref=""> BiffException
		/// </exception>
		/// <exception cref=""> PasswordException
		/// </exception>
		protected internal abstract void  parse();
		
		/// <summary> Closes this workbook, and frees makes any memory allocated available
		/// for garbage collection
		/// </summary>
		public abstract void  close();
		
		/// <summary> A factory method which takes in an excel file and reads in the contents.
		/// 
		/// </summary>
		/// <exception cref=""> IOException
		/// </exception>
		/// <exception cref=""> BiffException
		/// </exception>
		/// <param name="file">the excel 97 spreadsheet to parse
		/// </param>
		/// <returns> a workbook instance
		/// </returns>
		public static Workbook getWorkbook(FileInfo file)
		{
			return getWorkbook(file, new WorkbookSettings());
		}

		/// <summary> A factory method which takes in an excel file and reads in the contents.
		/// 
		/// </summary>
		/// <exception cref=""> IOException
		/// </exception>
		/// <exception cref=""> BiffException
		/// </exception>
		/// <param name="file">the excel 97 spreadsheet to parse
		/// </param>
		/// <param name="ws">the settings for the workbook
		/// </param>
		/// <returns> a workbook instance
		/// </returns>
		public static Workbook getWorkbook(FileInfo file, WorkbookSettings ws)
		{
			return getWorkbook(file.FullName, new WorkbookSettings());
		}
	
		/// <summary> A factory method which takes in an excel file and reads in the contents.
		/// 
		/// </summary>
		/// <exception cref=""> IOException
		/// </exception>
		/// <exception cref=""> BiffException
		/// </exception>
		/// <param name="filename">the excel 97 spreadsheet to parse
		/// </param>
		/// <returns> a workbook instance
		/// </returns>
		public static Workbook getWorkbook(string filename)
		{
			return getWorkbook(filename, new WorkbookSettings());
		}
	

		/// <summary> A factory method which takes in an excel file and reads in the contents.
		/// 
		/// </summary>
		/// <exception cref=""> IOException
		/// </exception>
		/// <exception cref=""> BiffException
		/// </exception>
		/// <param name="filename">the excel 97 spreadsheet to parse
		/// </param>
		/// <param name="ws">the settings for the workbook
		/// </param>
		/// <returns> a workbook instance
		/// </returns>
		public static Workbook getWorkbook(string filename, WorkbookSettings ws)
		{
			FileStream fis = new FileStream(filename, FileMode.Open, FileAccess.Read);
			
			// Always close down the input stream, regardless of whether or not the
			// file can be parsed.  Thanks to Steve Hahn for this
            ExcelOperate.Read.Biff.File dataFile = null;
			
			try
			{
                dataFile = new ExcelOperate.Read.Biff.File(fis, ws);
			}
			catch (Exception e)
			{
				fis.Close();
				throw e;
			}
			
			fis.Close();
			
			Workbook workbook = new WorkbookParser(dataFile, ws);
			workbook.parse();
			
			return workbook;
		}
		
		/// <summary> A factory method which takes in an excel file and reads in the contents.
		/// 
		/// </summary>
		/// <exception cref=""> IOException
		/// </exception>
		/// <exception cref=""> BiffException
		/// </exception>
		/// <param name="is">an open stream which is the the excel 97 spreadsheet to parse
		/// </param>
		/// <returns> a workbook instance
		/// </returns>
		public static Workbook getWorkbook(Stream stream)
		{
			return getWorkbook(stream, new WorkbookSettings());
		}
		
		/// <summary> A factory method which takes in an excel file and reads in the contents.
		/// 
		/// </summary>
		/// <exception cref=""> IOException
		/// </exception>
		/// <exception cref=""> BiffException
		/// </exception>
		/// <param name="is">an open stream which is the the excel 97 spreadsheet to parse
		/// </param>
		/// <param name="ws">the settings for the workbook
		/// </param>
		/// <returns> a workbook instance
		/// </returns>
		public static Workbook getWorkbook(Stream stream, WorkbookSettings ws)
		{
            ExcelOperate.Read.Biff.File dataFile = new ExcelOperate.Read.Biff.File(stream, ws);
			
			Workbook workbook = new WorkbookParser(dataFile, ws);
			workbook.parse();
			
			return workbook;
		}
		
		
		
 
 
	}
}
