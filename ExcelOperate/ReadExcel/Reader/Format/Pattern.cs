
using System;
namespace ExcelOperate.Format
{
	
	
	/// <summary> Enumeration class which contains the various patterns available within
	/// the standard Excel pattern palette
	/// </summary>
	public class Pattern
	{
		/// <summary> Gets the value of this pattern.  This is the value that is written to 
		/// the generated Excel file
		/// 
		/// </summary>
		/// <returns> the binary value
		/// </returns>
		virtual public int Value
		{
			get
			{
				return value_Renamed;
			}
			
		}
		/// <summary> Gets the textual description
		/// 
		/// </summary>
		/// <returns> the string
		/// </returns>
		virtual public string Description
		{
			get
			{
				return string_Renamed;
			}
			
		}
		/// <summary> The internal numerical representation of the colour</summary>
		private int value_Renamed;
		
		/// <summary> The textual description</summary>
		private string string_Renamed;
		
		/// <summary> The list of patterns</summary>
		private static Pattern[] patterns;
		
		
		/// <summary> Private constructor
		/// 
		/// </summary>
		/// <param name="val">
		/// </param>
		/// <param name="">s
		/// </param>
		protected internal Pattern(int val, string s)
		{
			value_Renamed = val;
			string_Renamed = s;
			
			Pattern[] oldcols = patterns;
			patterns = new Pattern[oldcols.Length + 1];
			Array.Copy((System.Array) oldcols, 0, (System.Array) patterns, 0, oldcols.Length);
			patterns[oldcols.Length] = this;
		}
		
		/// <summary> Gets the pattern from the value
		/// 
		/// </summary>
		/// <param name="val">
		/// </param>
		/// <returns> the pattern with that value
		/// </returns>
		public static Pattern getPattern(int val)
		{
			for (int i = 0; i < patterns.Length; i++)
			{
				if (patterns[i].Value == val)
				{
					return patterns[i];
				}
			}
			
			return NONE;
		}
		
		public static readonly Pattern SOLID = new Pattern(0x400, "Solid");
		public static readonly Pattern NONE = new Pattern(0x0, "None");
		
		public static readonly Pattern GRAY_75 = new Pattern(0xc00, "Gray 75%");
		public static readonly Pattern GRAY_50 = new Pattern(0x800, "Gray 50%");
		public static readonly Pattern GRAY_25 = new Pattern(0x1000, "Gray 25%");
		static Pattern()
		{
			patterns = new Pattern[0];
		}
	}
}