
using System;
using ExcelOperate.Biff;
using System.IO;
namespace ExcelOperate.Biff.Formula
{
	
	
	class Yylex
	{
		private void  InitBlock()
		{
			yy_acpt = new int[]{YY_NOT_ACCEPT, YY_NO_ANCHOR, YY_NO_ANCHOR, YY_NO_ANCHOR, YY_NO_ANCHOR, YY_NO_ANCHOR, YY_NO_ANCHOR, YY_NO_ANCHOR, YY_NO_ANCHOR, YY_NO_ANCHOR, YY_NO_ANCHOR, YY_NO_ANCHOR, YY_NO_ANCHOR, YY_NO_ANCHOR, YY_NO_ANCHOR, YY_NO_ANCHOR, YY_NO_ANCHOR, YY_NO_ANCHOR, YY_NO_ANCHOR, YY_NO_ANCHOR, YY_NO_ANCHOR, YY_NO_ANCHOR, YY_NO_ANCHOR, YY_NO_ANCHOR, YY_NO_ANCHOR, YY_NO_ANCHOR, YY_NO_ANCHOR, YY_NO_ANCHOR, YY_NO_ANCHOR, YY_NO_ANCHOR, YY_NOT_ACCEPT, YY_NO_ANCHOR, YY_NO_ANCHOR, YY_NO_ANCHOR, YY_NO_ANCHOR, YY_NOT_ACCEPT, YY_NO_ANCHOR, YY_NOT_ACCEPT, YY_NO_ANCHOR, YY_NOT_ACCEPT, YY_NO_ANCHOR, YY_NOT_ACCEPT, YY_NOT_ACCEPT, YY_NOT_ACCEPT, YY_NOT_ACCEPT, YY_NOT_ACCEPT, YY_NOT_ACCEPT, YY_NOT_ACCEPT, YY_NOT_ACCEPT, YY_NOT_ACCEPT, YY_NOT_ACCEPT, YY_NOT_ACCEPT, YY_NOT_ACCEPT, YY_NOT_ACCEPT, YY_NOT_ACCEPT, YY_NOT_ACCEPT, YY_NOT_ACCEPT, YY_NOT_ACCEPT, YY_NOT_ACCEPT, YY_NOT_ACCEPT, YY_NOT_ACCEPT, YY_NOT_ACCEPT, YY_NO_ANCHOR, YY_NOT_ACCEPT, YY_NO_ANCHOR, YY_NOT_ACCEPT, YY_NOT_ACCEPT, YY_NOT_ACCEPT, YY_NOT_ACCEPT, YY_NO_ANCHOR, YY_NOT_ACCEPT};
			yy_cmap = unpackFromString(1, 130, "29:8,14:3,29:21,14,16,28,15,11,15:2,13,26,27,3,1,8,2,10,4,9:10,17,15,7,6,5," + "15:2,23,12:3,21,22,12:5,24,12:5,19,25,18,20,12:5,29:3,15:2,29,12:26,29,15,2" + "9,15,29,0:2")[0];
			yy_rmap = unpackFromString(1, 71, "0,1,2:4,3,2,4,2,5,2,1:4,2:3,6,7,1,8,9,10,11,10,12,13,1,2,14,10,15,16,17,18," + "19,20,21,22,8,23,24,25,26,27,28,29,30,31,32,33,34,35,36,11,37,38,39,12,40,4" + "1,42,43,44,45,46,47,48,49")[0];
			yy_nxt = unpackFromString(50, 30, "1,2,3,4,5,6,7,8,9,10,30,63,35,37,11,30:2,12,65,35:3,70,35:3,13,14,15,-1:32," + "30:12,39,30:2,67,-1,30:8,-1:5,30:5,16,30:6,39,30:2,67,-1,30:8,-1:5,30:4,17," + "18,30:6,39,30:2,67,-1,30:8,-1:5,30:8,10,41,30:2,39,30:2,67,-1,30:8,-1:5,30:" + "8,19,30:3,39,30:2,67,66,30:8,-1:5,30:8,31,30,43,32,39,30:2,67,-1,32:8,21,-1" + ":4,30:8,22,30:3,39,30:2,67,-1,30:8,-1:5,30:8,23,30:3,39,30:2,67,55,30:8,-1:" + "5,30:8,38,30:2,32,39,30:2,67,-1,32:8,21,-1:12,25,-1:29,27,-1:20,1,34:27,29," + "34,-1,30:8,31,30:2,38,39,30:2,67,66,38:8,-1:13,33,-1:7,55,-1:13,34:27,-1,34" + ",-1,30:8,19,30,43,20,39,30:2,67,-1,20:8,21,-1:4,30:8,38,30:2,32,39,30:2,67," + "-1,32:3,24,32:4,21,-1:4,30:12,-1,30:3,-1,30:8,-1:5,30:8,38,30:2,38,39,30:2," + "67,-1,38:8,-1:20,44,-1:14,30:8,38,30:2,32,39,30:2,67,-1,32:3,26,32:4,21,-1:" + "4,30:8,19,30,43,46,39,30:2,67,-1,46:8,-1:5,30:8,19,30:3,39,30:2,67,-1,30:8," + "-1:15,47,48,-1:5,48:8,-1:5,30:8,23,30,49,50,39,30:2,67,-1,50:8,-1:5,30:8,19" + ",30,43,30,39,30:2,67,-1,30:8,-1:16,48,-1:5,48:8,-1:13,33,-1,53,54,-1:5,54:8" + ",-1:5,30:8,23,30:3,39,30:2,67,-1,30:8,-1:5,30:8,23,30,49,30,39,30:2,67,-1,3" + "0:8,-1:16,52,-1:5,52:8,-1:13,25,-1,56,57,-1:5,57:8,-1:13,33,-1:29,33,-1,53," + "-1:29,58,59,-1:5,59:8,-1:13,25,-1,56,-1:30,59,-1:5,59:8,-1:13,27,-1,60,61,-" + "1:5,61:8,-1:13,27,-1,60,-1:19,30:8,31,30,43,32,39,30:2,67,-1,32:2,36,32:5,2" + "1,-1:4,30:11,42,39,30:2,67,-1,42:8,-1:5,30:8,38,30:2,32,39,30:2,67,-1,32:7," + "40,21,-1:4,30:8,19,30,43,20,39,30:2,67,-1,20,62,20:6,21,-1:14,51,52,-1:5,52" + ":8,-1:5,30:10,68,45,39,30:2,67,-1,45:8,-1:5,30:11,45,39,30:2,67,-1,45:8,-1:" + "5,30:8,31,30,43,32,39,30:2,67,-1,32:6,64,32,21,-1:4,30:8,19,30,43,20,39,30:" + "2,67,-1,20:5,69,20:2,21,-1:3");
		}
		virtual internal int Pos
		{
			get
			{
				return yychar;
			}
			
		}
		virtual internal ExternalSheet ExternalSheet
		{
			set
			{
				externalSheet = value;
			}
			
		}
		virtual internal WorkbookMethods NameTable
		{
			set
			{
				nameTable = value;
			}
			
		}
		private int YY_BUFFER_SIZE = 512;
		private int YY_F = - 1;
		private int YY_NO_STATE = - 1;
		private int YY_NOT_ACCEPT = 0;
		private int YY_START = 1;
		private int YY_END = 2;
		private int YY_NO_ANCHOR = 4;
		private int YY_BOL = 128;
		private int YY_EOF = 129;
		
		private bool emptyString;
		
		private ExternalSheet externalSheet;
		private WorkbookMethods nameTable;
		private StringReader yy_reader;
		private int yy_buffer_index;
		private int yy_buffer_read;
		private int yy_buffer_start;
		private int yy_buffer_end;
		private char[] yy_buffer;
		private int yychar;
		private int yyline;
		private bool yy_at_bol;
		private int yy_lexical_state;
		
		internal Yylex(string reader):this()
		{
			if (null == (System.Object) reader)
			{
				throw (new System.ApplicationException("Error: Bad input stream initializer."));
			}
 			yy_reader = new StringReader(reader);
		}
		
		private Yylex()
		{
			InitBlock();
			yy_buffer = new char[YY_BUFFER_SIZE];
			yy_buffer_read = 0;
			yy_buffer_index = 0;
			yy_buffer_start = 0;
			yy_buffer_end = 0;
			yychar = 0;
			yyline = 0;
			yy_at_bol = true;
			yy_lexical_state = YYINITIAL;
		}
		
		private bool yy_eof_done = false;
		private int YYSTRING = 1;
		private int YYINITIAL = 0;
		private int[] yy_state_dtrans = new int[]{0, 28};
		private void  yybegin(int state)
		{
			yy_lexical_state = state;
		}
		private int yy_advance()
		{
			int next_read;
			int i;
			int j;
			
			if (yy_buffer_index < yy_buffer_read)
			{
				return yy_buffer[yy_buffer_index++];
			}
			
			if (0 != yy_buffer_start)
			{
				i = yy_buffer_start;
				j = 0;
				while (i < yy_buffer_read)
				{
					yy_buffer[j] = yy_buffer[i];
					++i;
					++j;
				}
				yy_buffer_end = yy_buffer_end - yy_buffer_start;
				yy_buffer_start = 0;
				yy_buffer_read = j;
				yy_buffer_index = j;
				next_read = yy_reader.Read(yy_buffer, yy_buffer_read, yy_buffer.Length - yy_buffer_read);
				if (- 1 == next_read)
				{
					return YY_EOF;
				}
				yy_buffer_read = yy_buffer_read + next_read;
			}
			
			while (yy_buffer_index >= yy_buffer_read)
			{
				if (yy_buffer_index >= yy_buffer.Length)
				{
					yy_buffer = yy_double(yy_buffer);
				}
				next_read = yy_reader.Read(yy_buffer, yy_buffer_read, yy_buffer.Length - yy_buffer_read);
				if (- 1 == next_read)
				{
					return YY_EOF;
				}
				yy_buffer_read = yy_buffer_read + next_read;
			}
			return yy_buffer[yy_buffer_index++];
		}
		private void  yy_move_end()
		{
			if (yy_buffer_end > yy_buffer_start && '\n' == yy_buffer[yy_buffer_end - 1])
				yy_buffer_end--;
			if (yy_buffer_end > yy_buffer_start && '\r' == yy_buffer[yy_buffer_end - 1])
				yy_buffer_end--;
		}
		private bool yy_last_was_cr = false;
		private void  yy_mark_start()
		{
			int i;
			for (i = yy_buffer_start; i < yy_buffer_index; ++i)
			{
				if ('\n' == yy_buffer[i] && !yy_last_was_cr)
				{
					++yyline;
				}
				if ('\r' == yy_buffer[i])
				{
					++yyline;
					yy_last_was_cr = true;
				}
				else
					yy_last_was_cr = false;
			}
			yychar = yychar + yy_buffer_index - yy_buffer_start;
			yy_buffer_start = yy_buffer_index;
		}
		private void  yy_mark_end()
		{
			yy_buffer_end = yy_buffer_index;
		}
		private void  yy_to_mark()
		{
			yy_buffer_index = yy_buffer_end;
			yy_at_bol = (yy_buffer_end > yy_buffer_start) && ('\r' == yy_buffer[yy_buffer_end - 1] || '\n' == yy_buffer[yy_buffer_end - 1] || 2028 == yy_buffer[yy_buffer_end - 1] || 2029 == yy_buffer[yy_buffer_end - 1]);
		}
		private string yytext()
		{
			return (new string(yy_buffer, yy_buffer_start, yy_buffer_end - yy_buffer_start));
		}
		private int yylength()
		{
			return yy_buffer_end - yy_buffer_start;
		}
		private char[] yy_double(char[] buf)
		{
			int i;
			char[] newbuf;
			newbuf = new char[2 * buf.Length];
			for (i = 0; i < buf.Length; ++i)
			{
				newbuf[i] = buf[i];
			}
			return newbuf;
		}
		private int YY_E_INTERNAL = 0;
		private int YY_E_MATCH = 1;
		private string[] yy_error_string = new string[]{"Error: Internal error.\n", "Error: Unmatched input.\n"};
		private void  yy_error(int code, bool fatal)
		{
			//System.Console.Out.Write(yy_error_string[code]);
			//System.Console.Out.Flush();
			if (fatal)
			{
				throw new System.ApplicationException("Fatal Error.\n");
			}
		}
		private int[][] unpackFromString(int size1, int size2, string st)
		{
			int colonIndex = - 1;
			string lengthString;
			int sequenceLength = 0;
			int sequenceInteger = 0;
			
			int commaIndex;
			string workString;
			
			int[][] res = new int[size1][];
			for (int i = 0; i < size1; i++)
			{
				res[i] = new int[size2];
			}
			for (int i = 0; i < size1; i++)
			{
				for (int j = 0; j < size2; j++)
				{
					if (sequenceLength != 0)
					{
						res[i][j] = sequenceInteger;
						sequenceLength--;
						continue;
					}
					commaIndex = st.IndexOf((System.Char) ',');
					workString = (commaIndex == - 1)?st:st.Substring(0, (commaIndex) - (0));
					st = st.Substring(commaIndex + 1);
					colonIndex = workString.IndexOf((System.Char) ':');
					if (colonIndex == - 1)
					{
						res[i][j] = System.Int32.Parse(workString);
						continue;
					}
					lengthString = workString.Substring(colonIndex + 1);
					sequenceLength = System.Int32.Parse(lengthString);
					workString = workString.Substring(0, (colonIndex) - (0));
					sequenceInteger = System.Int32.Parse(workString);
					res[i][j] = sequenceInteger;
					sequenceLength--;
				}
			}
			return res;
		}
		private int[] yy_acpt;
		private int[] yy_cmap;
		
		private int[] yy_rmap;
		
		private int[][] yy_nxt;
		
		public virtual ParseItem yylex()
		{
			int yy_lookahead;
			int yy_anchor = YY_NO_ANCHOR;
			int yy_state = yy_state_dtrans[yy_lexical_state];
			int yy_next_state = YY_NO_STATE;
			int yy_last_accept_state = YY_NO_STATE;
			bool yy_initial = true;
			int yy_this_accept;
			
			yy_mark_start();
			yy_this_accept = yy_acpt[yy_state];
			if (YY_NOT_ACCEPT != yy_this_accept)
			{
				yy_last_accept_state = yy_state;
				yy_mark_end();
			}
			while (true)
			{
				if (yy_initial && yy_at_bol)
					yy_lookahead = YY_BOL;
				else
					yy_lookahead = yy_advance();
				yy_next_state = YY_F;
				yy_next_state = yy_nxt[yy_rmap[yy_state]][yy_cmap[yy_lookahead]];
				if (YY_EOF == yy_lookahead && true == yy_initial)
				{
					return null;
				}
				if (YY_F != yy_next_state)
				{
					yy_state = yy_next_state;
					yy_initial = false;
					yy_this_accept = yy_acpt[yy_state];
					if (YY_NOT_ACCEPT != yy_this_accept)
					{
						yy_last_accept_state = yy_state;
						yy_mark_end();
					}
				}
				else
				{
					if (YY_NO_STATE == yy_last_accept_state)
					{
						throw (new System.ApplicationException("Lexical Error: Unmatched Input."));
					}
					else
					{
						yy_anchor = yy_acpt[yy_last_accept_state];
						if (0 != (YY_END & yy_anchor))
						{
							yy_move_end();
						}
						yy_to_mark();
						bool goToYyError = false;
						switch (yy_last_accept_state)
						{
							case -1:
								break;
							case 1: 
							case - 2: 
								break;
							
							case 2: 
							{
								return new Plus();
							}
							
							case - 3: 
								break;
							
							case 3: 
							{
								return new Minus();
							}
							
							case - 4: 
								break;
							
							case 4: 
							{
								return new Multiply();
							}
							
							case - 5: 
								break;
							
							case 5: 
							{
								return new Divide();
							}
							
							case - 6: 
								break;
							
							case 6: 
							{
								return new GreaterThan();
							}
							
							case - 7: 
								break;
							
							case 7: 
							{
								return new Equal();
							}
							
							case - 8: 
								break;
							
							case 8: 
							{
								return new LessThan();
							}
							
							case - 9: 
								break;
							
							case 9: 
							{
								return new ArgumentSeparator();
							}
							
							case - 10: 
								break;
							
							case 10: 
							{
								return new IntegerValue(yytext());
							}
							
							case - 11: 
								break;
							
							case 11: 
								{
								}
								goto case - 12;
							
							case - 12: 
								break;
							
							case 12: 
							{
								return new RangeSeparator();
							}
							
							case - 13: 
								break;
							
							case 13: 
							{
								return new OpenParentheses();
							}
							
							case - 14: 
								break;
							
							case 14: 
							{
								return new CloseParentheses();
							}
							
							case - 15: 
								break;
							
							case 15: 
								{
									emptyString = true; yybegin(YYSTRING);
								}
								goto case - 16;
							
							case - 16: 
								break;
							
							case 16: 
							{
								return new GreaterEqual();
							}
							
							case - 17: 
								break;
							
							case 17: 
							{
								return new NotEqual();
							}
							
							case - 18: 
								break;
							
							case 18: 
							{
								return new LessEqual();
							}
							
							case - 19: 
								break;
							
							case 19: 
							{
								return new CellReference(yytext());
							}
							
							case - 20: 
								break;
							
							case 20: 
							{
								return new NameRange(yytext(), nameTable);
							}
							
							case - 21: 
								break;
							
							case 21: 
							{
								return new StringFunction(yytext());
							}
							
							case - 22: 
								break;
							
							case 22: 
							{
								return new DoubleValue(yytext());
							}
							
							case - 23: 
								break;
							
							case 23: 
							{
								return new CellReference3d(yytext(), externalSheet);
							}
							
							case - 24: 
								break;
							
							case 24: 
							{
								return new BooleanValue(yytext());
							}
							
							case - 25: 
								break;
							
							case 25: 
							{
								return new Area(yytext());
							}
							
							case - 26: 
								break;
							
							case 26: 
							{
								return new BooleanValue(yytext());
							}
							
							case - 27: 
								break;
							
							case 27: 
							{
								return new Area3d(yytext(), externalSheet);
							}
							
							case - 28: 
								break;
							
							case 28: 
							{
								emptyString = false; return new StringValue(yytext());
							}
							
							case - 29: 
								break;
							
							case 29: 
								{
									yybegin(YYINITIAL);
									if (emptyString)
										return new StringValue("");
								}
								goto case - 30;
							
							case - 30: 
								break;
							
							case 31: 
							{
								return new CellReference(yytext());
							}
							
							case - 31: 
								break;
							
							case 32: 
							{
								return new NameRange(yytext(), nameTable);
							}
							
							case - 32: 
								break;
							
							case 33: 
							{
								return new CellReference3d(yytext(), externalSheet);
							}
							
							case - 33: 
								break;
							
							case 34: 
							{
								emptyString = false; return new StringValue(yytext());
							}
							
							case - 34: 
								break;
							
							case 36: 
							{
								return new NameRange(yytext(), nameTable);
							}
							
							case - 35: 
								break;
							
							case 38: 
							{
								return new NameRange(yytext(), nameTable);
							}
							
							case - 36: 
								break;
							
							case 40: 
							{
								return new NameRange(yytext(), nameTable);
							}
							
							case - 37: 
								break;
							
							case 62: 
							{
								return new NameRange(yytext(), nameTable);
							}
							
							case - 38: 
								break;
							
							case 64: 
							{
								return new NameRange(yytext(), nameTable);
							}
							
							case - 39: 
								break;
							
							case 69: 
							{
								return new NameRange(yytext(), nameTable);
							}
							
							case - 40: 
								break;
							default: 
								goToYyError = true;
								break;
						}
						if (goToYyError) yy_error(YY_E_INTERNAL, false);

						yy_initial = true;
						yy_state = yy_state_dtrans[yy_lexical_state];
						yy_next_state = YY_NO_STATE;
						yy_last_accept_state = YY_NO_STATE;
						yy_mark_start();
						yy_this_accept = yy_acpt[yy_state];
						if (YY_NOT_ACCEPT != yy_this_accept)
						{
							yy_last_accept_state = yy_state;
							yy_mark_end();
						}
					}
				}
			}
		}
	}
}
