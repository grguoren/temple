
using System;
using ExcelOperate.common;
using ExcelOperate.ReadExcel;
using System.Text;
namespace ExcelOperate.Biff
{
	
	
	/// <summary> Helper function to convert Java string objects to and from the byte
	/// representations
	/// </summary>
	public sealed class StringHelper
	{
		/// <summary> The logger</summary>
		private static Logger logger;
		
		/// <summary> Private default constructor to prevent instantiation</summary>
		private StringHelper()
		{
		}
		
		/// <summary> Gets the bytes of the specified string.  This will simply return the ASCII
		/// values of the characters in the string
		/// 
		/// </summary>
		/// <param name="s">the string to convert into bytes
		/// </param>
		/// <returns> the ASCII values of the characters in the string
		/// </returns>
		/// <deprecated>
		/// </deprecated>
		public static sbyte[] getBytes(string s)
		{
            return ExcelOperate.Utils.Byte.ToSByteArray(ExcelOperate.Utils.Byte.ToByteArray(s));
		}
		
		/// <summary> Converts the string into a little-endian array of Unicode bytes
		/// 
		/// </summary>
		/// <param name="s">the string to convert
		/// </param>
		/// <returns> the unicode values of the characters in the string
		/// </returns>
		public static sbyte[] getUnicodeBytes(string s)
		{
			try
			{
				
				// [TODO] check it's critical
				UnicodeEncoding encoding = new UnicodeEncoding();
				byte[] b0 = encoding.GetBytes(s);
                sbyte[] b1 = ExcelOperate.Utils.Byte.ToSByteArray(b0);

				// Sometimes this method writes out the unicode
				// identifier
				if (b1.Length == (s.Length * 2 + 2))
				{
					sbyte[] b2 = new sbyte[b1.Length - 2];
					Array.Copy(b1, 2, b2, 0, b2.Length);
					b1 = b2;
				}
				return b1;
			}
			catch (System.IO.IOException e)
			{
				// Fail silently
				return null;
			}
		}
		
		/// <summary> Gets the ASCII bytes from the specified string and places them in the
		/// array at the specified position
		/// 
		/// </summary>
		/// <param name="pos">the position at which to place the converted data
		/// </param>
		/// <param name="s">the string to convert
		/// </param>
		/// <param name="d">the byte array which will contain the converted string data
		/// </param>
		public static void  getBytes(string s, sbyte[] d, int pos)
		{
			sbyte[] b = getBytes(s);
			Array.Copy(b, 0, d, pos, b.Length);
		}
		
		/// <summary> Inserts the unicode byte representation of the specified string into the
		/// array passed in
		/// 
		/// </summary>
		/// <param name="pos">the position at which to insert the converted data
		/// </param>
		/// <param name="s">the string to convert
		/// </param>
		/// <param name="d">the byte array which will hold the string data
		/// </param>
		public static void  getUnicodeBytes(string s, sbyte[] d, int pos)
		{
			sbyte[] b = getUnicodeBytes(s);
			Array.Copy(b, 0, d, pos, b.Length);
		}
		
		/// <summary> Gets a string from the data array using the character encoding for
		/// this workbook
		/// 
		/// </summary>
		/// <param name="pos">The start position of the string
		/// </param>
		/// <param name=".Length">The number of characters in the string
		/// </param>
		/// <param name="d">The byte data
		/// </param>
		/// <param name="ws">the workbook settings
		/// </param>
		/// <returns> the string built up from the raw bytes
		/// </returns>
		public static string getString(sbyte[] d, int length, int pos, WorkbookSettings ws)
		{
			try
			{
				sbyte[] b = new sbyte[length];
				Array.Copy(d, pos, b, 0, length);
				// [TODO] - check if it's right - this is critical
				// return new String(b, ws.getEncoding());
                byte[] bb = ExcelOperate.Utils.Byte.ToByteArray(b);
				Encoding encoding = Encoding.GetEncoding(ws.Encoding);

				return encoding.GetString(bb);

			}
			catch (System.IO.IOException e)
			{
				logger.warn(e.Message);
				return "";
			}
		}
		
		/// <summary> Gets a string from the data array
		/// 
		/// </summary>
		/// <param name="pos">The start position of the string
		/// </param>
		/// <param name=".Length">The number of characters in the string
		/// </param>
		/// <param name="d">The byte data
		/// </param>
		/// <returns> the string built up from the unicode characters
		/// </returns>
		public static string getUnicodeString(sbyte[] data, int length, int pos)
		{
			try
			{
				sbyte[] bytes = new sbyte[length * 2];
				Array.Copy(data, pos, bytes, 0, length * 2);
//				return new String(b, "UnicodeLittle");

                byte[] bb = ExcelOperate.Utils.Byte.ToByteArray(bytes);
				Encoding encoding = Encoding.Unicode;
				return encoding.GetString(bb);

//				// it's a work-around. Test if it's right.
//				char[] c = new char[d.Length];
//				for(int i=0; i<c.Length; i++)
//				{
//					c[i] = (char) d[i];
//				}
//				return new string(c);

			}
			catch (System.IO.IOException e)
			{
				// Fail silently
				return "";
			}
		}
		static StringHelper()
		{
			logger = Logger.getLogger(typeof(StringHelper));
		}
	}
}
