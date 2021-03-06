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
namespace ExcelOperate.Biff.Formula
{
	
	/// <summary> An interface for an excel ptg</summary>
	internal interface ParsedThing
		{
			/// <summary> Reads the ptg data from the array starting at the specified position
			/// 
			/// </summary>
			/// <param name="data">the RPN array
			/// </param>
			/// <param name="pos">the current position in the array, excluding the ptg identifier
			/// </param>
			/// <returns> the number of bytes read
			/// </returns>
			int read(sbyte[] data, int pos);
		}
}
