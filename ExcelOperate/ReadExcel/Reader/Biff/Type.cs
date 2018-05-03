
using System;
namespace ExcelOperate.Biff
{
	
	/// <summary> An enumeration class which contains the  biff types</summary>
	public sealed class Type
	{
		/// <summary> The biff value for this type</summary>
		public int Value;
		/// <summary> An array of all types</summary>
        private static ExcelOperate.Biff.Type[] types;
		
		/// <summary> Constructor
		/// Sets the biff value and adds this type to the array of all types
		/// 
		/// </summary>
		/// <param name="v">the biff code for the type
		/// </param>
		private Type(int v)
		{
			Value = v;
			
			// Add to the list of available types
            ExcelOperate.Biff.Type[] newTypes = new ExcelOperate.Biff.Type[types.Length + 1];
			Array.Copy(types, 0, newTypes, 0, types.Length);
			newTypes[types.Length] = this;
			types = newTypes;
		}
		
		/// <summary> Standard hash code method</summary>
		/// <returns> the hash code
		/// </returns>
		public override int GetHashCode()
		{
			return Value;
		}
		
		/// <summary> Standard equals method</summary>
		/// <param name="o">the object to compare
		/// </param>
		/// <returns> TRUE if the objects are equal, FALSE otherwise
		/// </returns>
		public  override bool Equals(System.Object o)
		{
			if (o == this)
			{
				return true;
			}

            if (!(o is ExcelOperate.Biff.Type))
			{
				return false;
			}

            ExcelOperate.Biff.Type t = (ExcelOperate.Biff.Type)o;
			
			return Value == t.Value;
		}
		
		/// <summary> Gets the type object from its integer value</summary>
		/// <param name="v">the internal code
		/// </param>
		/// <returns> the type
		/// </returns>
        public static ExcelOperate.Biff.Type getType(int v)
		{
			for (int i = 0; i < types.Length; i++)
			{
				if (types[i].Value == v)
				{
					return types[i];
				}
			}
			
			return UNKNOWN;
		}


        public static readonly ExcelOperate.Biff.Type BOF;
        public static readonly ExcelOperate.Biff.Type EOF;
        public static readonly ExcelOperate.Biff.Type BOUNDSHEET;
        public static readonly ExcelOperate.Biff.Type SUPBOOK;
        public static readonly ExcelOperate.Biff.Type EXTERNSHEET;
        public static readonly ExcelOperate.Biff.Type DIMENSION;
		public static readonly ExcelOperate.Biff.Type BLANK;
		public static readonly ExcelOperate.Biff.Type MULBLANK;
		public static readonly ExcelOperate.Biff.Type ROW;
		public static readonly ExcelOperate.Biff.Type NOTE;
		public static readonly ExcelOperate.Biff.Type TXO;
		public static readonly ExcelOperate.Biff.Type RK;
		public static readonly ExcelOperate.Biff.Type RK2;
		public static readonly ExcelOperate.Biff.Type MULRK;
		public static readonly ExcelOperate.Biff.Type INDEX;
		public static readonly ExcelOperate.Biff.Type DBCELL;
		public static readonly ExcelOperate.Biff.Type SST;
		public static readonly ExcelOperate.Biff.Type COLINFO;
		public static readonly ExcelOperate.Biff.Type EXTSST;
		public static readonly ExcelOperate.Biff.Type CONTINUE;
		public static readonly ExcelOperate.Biff.Type LABEL;
		public static readonly ExcelOperate.Biff.Type RSTRING;
		public static readonly ExcelOperate.Biff.Type LABELSST;
		public static readonly ExcelOperate.Biff.Type NUMBER;
		public static readonly ExcelOperate.Biff.Type NAME;
		public static readonly ExcelOperate.Biff.Type TABID;
		public static readonly ExcelOperate.Biff.Type ARRAY;
		public static readonly ExcelOperate.Biff.Type STRING;
		public static readonly ExcelOperate.Biff.Type FORMULA;
		public static readonly ExcelOperate.Biff.Type FORMULA2;
		public static readonly ExcelOperate.Biff.Type SHAREDFORMULA;
		public static readonly ExcelOperate.Biff.Type FORMAT;
		public static readonly ExcelOperate.Biff.Type XF;
		public static readonly ExcelOperate.Biff.Type BOOLERR;
		public static readonly ExcelOperate.Biff.Type INTERFACEHDR;
		public static readonly ExcelOperate.Biff.Type SAVERECALC;
		public static readonly ExcelOperate.Biff.Type INTERFACEEND;
		public static readonly ExcelOperate.Biff.Type XCT;
		public static readonly ExcelOperate.Biff.Type CRN;
		public static readonly ExcelOperate.Biff.Type DEFCOLWIDTH;
		public static readonly ExcelOperate.Biff.Type DEFAULTROWHEIGHT;
		public static readonly ExcelOperate.Biff.Type WRITEACCESS;
		public static readonly ExcelOperate.Biff.Type WSBOOL;
		public static readonly ExcelOperate.Biff.Type CODEPAGE;
		public static readonly ExcelOperate.Biff.Type DSF;
		public static readonly ExcelOperate.Biff.Type FNGROUPCOUNT;
		public static readonly ExcelOperate.Biff.Type COUNTRY;
		public static readonly ExcelOperate.Biff.Type PROTECT;
		public static readonly ExcelOperate.Biff.Type SCENPROTECT;
		public static readonly ExcelOperate.Biff.Type OBJPROTECT;
		public static readonly ExcelOperate.Biff.Type PRINTHEADERS;
		public static readonly ExcelOperate.Biff.Type HEADER;
		public static readonly ExcelOperate.Biff.Type FOOTER;
		public static readonly ExcelOperate.Biff.Type HCENTER;
		public static readonly ExcelOperate.Biff.Type VCENTER;
		public static readonly ExcelOperate.Biff.Type FILEPASS;
		public static readonly ExcelOperate.Biff.Type SETUP;
		public static readonly ExcelOperate.Biff.Type PRINTGRIDLINES;
		public static readonly ExcelOperate.Biff.Type GRIDSET;
		public static readonly ExcelOperate.Biff.Type GUTS;
		public static readonly ExcelOperate.Biff.Type WINDOWPROTECT;
		public static readonly ExcelOperate.Biff.Type PROT4REV;
		public static readonly ExcelOperate.Biff.Type PROT4REVPASS;
		public static readonly ExcelOperate.Biff.Type PASSWORD;
		public static readonly ExcelOperate.Biff.Type REFRESHALL;
		public static readonly ExcelOperate.Biff.Type WINDOW1;
		public static readonly ExcelOperate.Biff.Type WINDOW2;
		public static readonly ExcelOperate.Biff.Type BACKUP;
		public static readonly ExcelOperate.Biff.Type HIDEOBJ;
		public static readonly ExcelOperate.Biff.Type NINETEENFOUR;
		public static readonly ExcelOperate.Biff.Type PRECISION;
		public static readonly ExcelOperate.Biff.Type BOOKBOOL;
		public static readonly ExcelOperate.Biff.Type FONT;
		public static readonly ExcelOperate.Biff.Type MMS;
		public static readonly ExcelOperate.Biff.Type CALCMODE;
		public static readonly ExcelOperate.Biff.Type CALCCOUNT;
		public static readonly ExcelOperate.Biff.Type REFMODE;
		public static readonly ExcelOperate.Biff.Type TEMPLATE;
		public static readonly ExcelOperate.Biff.Type OBJPROJ;
		public static readonly ExcelOperate.Biff.Type DELTA;
		public static readonly ExcelOperate.Biff.Type MERGEDCELLS;
		public static readonly ExcelOperate.Biff.Type ITERATION;
		public static readonly ExcelOperate.Biff.Type STYLE;
		public static readonly ExcelOperate.Biff.Type USESELFS;
		public static readonly ExcelOperate.Biff.Type HORIZONTALPAGEBREAKS;
		public static readonly ExcelOperate.Biff.Type SELECTION;
		public static readonly ExcelOperate.Biff.Type HLINK;
		public static readonly ExcelOperate.Biff.Type OBJ;
		public static readonly ExcelOperate.Biff.Type MSODRAWING;
		public static readonly ExcelOperate.Biff.Type MSODRAWINGGROUP;
		public static readonly ExcelOperate.Biff.Type LEFTMARGIN;
		public static readonly ExcelOperate.Biff.Type RIGHTMARGIN;
		public static readonly ExcelOperate.Biff.Type TOPMARGIN;
		public static readonly ExcelOperate.Biff.Type BOTTOMMARGIN;
		public static readonly ExcelOperate.Biff.Type EXTERNNAME;
		public static readonly ExcelOperate.Biff.Type PALETTE;
		public static readonly ExcelOperate.Biff.Type PLS;
		public static readonly ExcelOperate.Biff.Type SCL;
		public static readonly ExcelOperate.Biff.Type PANE;
		public static readonly ExcelOperate.Biff.Type WEIRD1;
		public static readonly ExcelOperate.Biff.Type SORT;
		// Chart types
		public static readonly ExcelOperate.Biff.Type FONTX;
		public static readonly ExcelOperate.Biff.Type IFMT;
		public static readonly ExcelOperate.Biff.Type FBI;
		public static readonly ExcelOperate.Biff.Type UNKNOWN;

		static Type()
		{
            types = new ExcelOperate.Biff.Type[0];

			BOF = new ExcelOperate.Biff.Type(0x809);
			EOF = new ExcelOperate.Biff.Type(0x0a);
			BOUNDSHEET = new ExcelOperate.Biff.Type(0x85);
			SUPBOOK = new ExcelOperate.Biff.Type(0x1ae);
			EXTERNSHEET = new ExcelOperate.Biff.Type(0x17);
			DIMENSION = new ExcelOperate.Biff.Type(0x200);
			BLANK = new ExcelOperate.Biff.Type(0x201);
			MULBLANK = new ExcelOperate.Biff.Type(0xbe);
			ROW = new ExcelOperate.Biff.Type(0x208);
			NOTE = new ExcelOperate.Biff.Type(0x1c);
			TXO = new ExcelOperate.Biff.Type(0x1b6);
			RK = new ExcelOperate.Biff.Type(0x7e);
			RK2 = new ExcelOperate.Biff.Type(0x27e);
			MULRK = new ExcelOperate.Biff.Type(0xbd);
			INDEX = new ExcelOperate.Biff.Type(0x20b);
			DBCELL = new ExcelOperate.Biff.Type(0xd7);
			SST = new ExcelOperate.Biff.Type(0xfc);
			COLINFO = new ExcelOperate.Biff.Type(0x7d);
			EXTSST = new ExcelOperate.Biff.Type(0xff);
			CONTINUE = new ExcelOperate.Biff.Type(0x3c);
			LABEL = new ExcelOperate.Biff.Type(0x204);
			RSTRING = new ExcelOperate.Biff.Type(0xd6);
			LABELSST = new ExcelOperate.Biff.Type(0xfd);
			NUMBER = new ExcelOperate.Biff.Type(0x203);
			NAME = new ExcelOperate.Biff.Type(0x18);
			TABID = new ExcelOperate.Biff.Type(0x13d);
			ARRAY = new ExcelOperate.Biff.Type(0x221);
			STRING = new ExcelOperate.Biff.Type(0x207);
			FORMULA = new ExcelOperate.Biff.Type(0x406);
			FORMULA2 = new ExcelOperate.Biff.Type(0x6);
			SHAREDFORMULA = new ExcelOperate.Biff.Type(0x4bc);
			FORMAT = new ExcelOperate.Biff.Type(0x41e);
			XF = new ExcelOperate.Biff.Type(0xe0);
			BOOLERR = new ExcelOperate.Biff.Type(0x205);
			INTERFACEHDR = new ExcelOperate.Biff.Type(0xe1);
			SAVERECALC = new ExcelOperate.Biff.Type(0x5f);
			INTERFACEEND = new ExcelOperate.Biff.Type(0xe2);
			XCT = new ExcelOperate.Biff.Type(0x59);
			CRN = new ExcelOperate.Biff.Type(0x5a);
			DEFCOLWIDTH = new ExcelOperate.Biff.Type(0x55);
			DEFAULTROWHEIGHT = new ExcelOperate.Biff.Type(0x225);
			WRITEACCESS = new ExcelOperate.Biff.Type(0x5c);
			WSBOOL = new ExcelOperate.Biff.Type(0x81);
			CODEPAGE = new ExcelOperate.Biff.Type(0x42);
			DSF = new ExcelOperate.Biff.Type(0x161);
			FNGROUPCOUNT = new ExcelOperate.Biff.Type(0x9c);
			COUNTRY = new ExcelOperate.Biff.Type(0x8c);
			PROTECT = new ExcelOperate.Biff.Type(0x12);
			SCENPROTECT = new ExcelOperate.Biff.Type(0xdd);
			OBJPROTECT = new ExcelOperate.Biff.Type(0x63);
			PRINTHEADERS = new ExcelOperate.Biff.Type(0x2a);
			HEADER = new ExcelOperate.Biff.Type(0x14);
			FOOTER = new ExcelOperate.Biff.Type(0x15);
			HCENTER = new ExcelOperate.Biff.Type(0x83);
			VCENTER = new ExcelOperate.Biff.Type(0x84);
			FILEPASS = new ExcelOperate.Biff.Type(0x2f);
			SETUP = new ExcelOperate.Biff.Type(0xa1);
			PRINTGRIDLINES = new ExcelOperate.Biff.Type(0x2b);
			GRIDSET = new ExcelOperate.Biff.Type(0x82);
			GUTS = new ExcelOperate.Biff.Type(0x80);
			WINDOWPROTECT = new ExcelOperate.Biff.Type(0x19);
			PROT4REV = new ExcelOperate.Biff.Type(0x1af);
			PROT4REVPASS = new ExcelOperate.Biff.Type(0x1bc);
			PASSWORD = new ExcelOperate.Biff.Type(0x13);
			REFRESHALL = new ExcelOperate.Biff.Type(0x1b7);
			WINDOW1 = new ExcelOperate.Biff.Type(0x3d);
			WINDOW2 = new ExcelOperate.Biff.Type(0x23e);
			BACKUP = new ExcelOperate.Biff.Type(0x40);
			HIDEOBJ = new ExcelOperate.Biff.Type(0x8d);
			NINETEENFOUR = new ExcelOperate.Biff.Type(0x22);
			PRECISION = new ExcelOperate.Biff.Type(0xe);
			BOOKBOOL = new ExcelOperate.Biff.Type(0xda);
			FONT = new ExcelOperate.Biff.Type(0x31);
			MMS = new ExcelOperate.Biff.Type(0xc1);
			CALCMODE = new ExcelOperate.Biff.Type(0x0d);
			CALCCOUNT = new ExcelOperate.Biff.Type(0x0c);
			REFMODE = new ExcelOperate.Biff.Type(0x0f);
			TEMPLATE = new ExcelOperate.Biff.Type(0x60);
			OBJPROJ = new ExcelOperate.Biff.Type(0xd3);
			DELTA = new ExcelOperate.Biff.Type(0x10);
			MERGEDCELLS = new ExcelOperate.Biff.Type(0xe5);
			ITERATION = new ExcelOperate.Biff.Type(0x11);
			STYLE = new ExcelOperate.Biff.Type(0x293);
			USESELFS = new ExcelOperate.Biff.Type(0x160);
			HORIZONTALPAGEBREAKS = new ExcelOperate.Biff.Type(0x1b);
			SELECTION = new ExcelOperate.Biff.Type(0x1d);
			HLINK = new ExcelOperate.Biff.Type(0x1b8);
			OBJ = new ExcelOperate.Biff.Type(0x5d);
			MSODRAWING = new ExcelOperate.Biff.Type(0xec);
			MSODRAWINGGROUP = new ExcelOperate.Biff.Type(0xeb);
			LEFTMARGIN = new ExcelOperate.Biff.Type(0x26);
			RIGHTMARGIN = new ExcelOperate.Biff.Type(0x27);
			TOPMARGIN = new ExcelOperate.Biff.Type(0x28);
			BOTTOMMARGIN = new ExcelOperate.Biff.Type(0x29);
			EXTERNNAME = new ExcelOperate.Biff.Type(0x23);
			PALETTE = new ExcelOperate.Biff.Type(0x92);
			PLS = new ExcelOperate.Biff.Type(0x4d);
			SCL = new ExcelOperate.Biff.Type(0xa0);
			PANE = new ExcelOperate.Biff.Type(0x41);
			WEIRD1 = new ExcelOperate.Biff.Type(0xef);
			SORT = new ExcelOperate.Biff.Type(0x90);
			// Chart types
			FONTX = new ExcelOperate.Biff.Type(0x1026);
			IFMT = new ExcelOperate.Biff.Type(0x104e);
			FBI = new ExcelOperate.Biff.Type(0x1060);
			UNKNOWN = new ExcelOperate.Biff.Type(0xffff);

		}
	}
}
