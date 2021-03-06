//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 3.5.0.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// $ANTLR 3.5.0.2 ADL.g 2015-07-22 18:20:25

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 219
// Unreachable code detected.
#pragma warning disable 162
// Missing XML comment for publicly visible type or member 'Type_or_Member'
#pragma warning disable 1591
// CLS compliance checking will not be performed on 'type' because it is not visible from outside this assembly.
#pragma warning disable 3019


using System.Collections.Generic;
using Antlr.Runtime;
using Antlr.Runtime.Misc;

namespace  adt 
{
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "3.5.0.2")]
[System.CLSCompliant(false)]
public partial class ADLLexer : Antlr.Runtime.Lexer
{
	public const int EOF=-1;
	public const int ASTERISK=4;
	public const int ATTRIBUTES=5;
	public const int BASE_CLASS=6;
	public const int CLOSE=7;
	public const int COMMA=8;
	public const int COMMENT=9;
	public const int COMMON_ATTRIBUTES=10;
	public const int COMMON_FIELDS=11;
	public const int DOT=12;
	public const int EQ=13;
	public const int ID=14;
	public const int ID_LETTER=15;
	public const int ID_START_LETTER=16;
	public const int NAMESPACE=17;
	public const int OPEN=18;
	public const int PIPE=19;
	public const int PRINTED=20;
	public const int PRINTER=21;
	public const int QUESTION=22;
	public const int QUOTED_TEXT=23;
	public const int SEMI=24;
	public const int WALKER=25;
	public const int WS=26;

	// delegates
	// delegators

	public ADLLexer()
	{
		OnCreated();
	}

	public ADLLexer(ICharStream input )
		: this(input, new RecognizerSharedState())
	{
	}

	public ADLLexer(ICharStream input, RecognizerSharedState state)
		: base(input, state)
	{

		OnCreated();
	}
	public override string GrammarFileName { get { return "ADL.g"; } }


	partial void OnCreated();
	partial void EnterRule(string ruleName, int ruleIndex);
	partial void LeaveRule(string ruleName, int ruleIndex);

	partial void EnterRule_QUOTED_TEXT();
	partial void LeaveRule_QUOTED_TEXT();

	// $ANTLR start "QUOTED_TEXT"
	[GrammarRule("QUOTED_TEXT")]
	private void mQUOTED_TEXT()
	{
		EnterRule_QUOTED_TEXT();
		EnterRule("QUOTED_TEXT", 1);
		TraceIn("QUOTED_TEXT", 1);
		try
		{
			int _type = QUOTED_TEXT;
			int _channel = DefaultTokenChannel;
			// ADL.g:120:5: ( '\"' ( options {greedy=false; } :~ '\"' )* '\"' )
			DebugEnterAlt(1);
			// ADL.g:120:7: '\"' ( options {greedy=false; } :~ '\"' )* '\"'
			{
			DebugLocation(120, 7);
			Match('\"'); 
			DebugLocation(120, 11);
			// ADL.g:120:11: ( options {greedy=false; } :~ '\"' )*
			try { DebugEnterSubRule(1);
			while (true)
			{
				int alt1=2;
				try { DebugEnterDecision(1, false);
				int LA1_1 = input.LA(1);

				if (((LA1_1>='\u0000' && LA1_1<='!')||(LA1_1>='#' && LA1_1<='\uFFFF')))
				{
					alt1 = 1;
				}
				else if ((LA1_1=='\"'))
				{
					alt1 = 2;
				}


				} finally { DebugExitDecision(1); }
				switch ( alt1 )
				{
				case 1:
					DebugEnterAlt(1);
					// ADL.g:120:41: ~ '\"'
					{
					DebugLocation(120, 41);
					input.Consume();


					}
					break;

				default:
					goto loop1;
				}
			}

			loop1:
				;

			} finally { DebugExitSubRule(1); }

			DebugLocation(120, 48);
			Match('\"'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("QUOTED_TEXT", 1);
			LeaveRule("QUOTED_TEXT", 1);
			LeaveRule_QUOTED_TEXT();
		}
	}
	// $ANTLR end "QUOTED_TEXT"

	partial void EnterRule_NAMESPACE();
	partial void LeaveRule_NAMESPACE();

	// $ANTLR start "NAMESPACE"
	[GrammarRule("NAMESPACE")]
	private void mNAMESPACE()
	{
		EnterRule_NAMESPACE();
		EnterRule("NAMESPACE", 2);
		TraceIn("NAMESPACE", 2);
		try
		{
			int _type = NAMESPACE;
			int _channel = DefaultTokenChannel;
			// ADL.g:122:10: ( '@namespace' )
			DebugEnterAlt(1);
			// ADL.g:122:12: '@namespace'
			{
			DebugLocation(122, 12);
			Match("@namespace"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("NAMESPACE", 2);
			LeaveRule("NAMESPACE", 2);
			LeaveRule_NAMESPACE();
		}
	}
	// $ANTLR end "NAMESPACE"

	partial void EnterRule_WALKER();
	partial void LeaveRule_WALKER();

	// $ANTLR start "WALKER"
	[GrammarRule("WALKER")]
	private void mWALKER()
	{
		EnterRule_WALKER();
		EnterRule("WALKER", 3);
		TraceIn("WALKER", 3);
		try
		{
			int _type = WALKER;
			int _channel = DefaultTokenChannel;
			// ADL.g:123:7: ( '@walker' )
			DebugEnterAlt(1);
			// ADL.g:123:9: '@walker'
			{
			DebugLocation(123, 9);
			Match("@walker"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("WALKER", 3);
			LeaveRule("WALKER", 3);
			LeaveRule_WALKER();
		}
	}
	// $ANTLR end "WALKER"

	partial void EnterRule_PRINTER();
	partial void LeaveRule_PRINTER();

	// $ANTLR start "PRINTER"
	[GrammarRule("PRINTER")]
	private void mPRINTER()
	{
		EnterRule_PRINTER();
		EnterRule("PRINTER", 4);
		TraceIn("PRINTER", 4);
		try
		{
			int _type = PRINTER;
			int _channel = DefaultTokenChannel;
			// ADL.g:124:8: ( '@printer' )
			DebugEnterAlt(1);
			// ADL.g:124:10: '@printer'
			{
			DebugLocation(124, 10);
			Match("@printer"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("PRINTER", 4);
			LeaveRule("PRINTER", 4);
			LeaveRule_PRINTER();
		}
	}
	// $ANTLR end "PRINTER"

	partial void EnterRule_BASE_CLASS();
	partial void LeaveRule_BASE_CLASS();

	// $ANTLR start "BASE_CLASS"
	[GrammarRule("BASE_CLASS")]
	private void mBASE_CLASS()
	{
		EnterRule_BASE_CLASS();
		EnterRule("BASE_CLASS", 5);
		TraceIn("BASE_CLASS", 5);
		try
		{
			int _type = BASE_CLASS;
			int _channel = DefaultTokenChannel;
			// ADL.g:125:11: ( '@baseclass' )
			DebugEnterAlt(1);
			// ADL.g:125:13: '@baseclass'
			{
			DebugLocation(125, 13);
			Match("@baseclass"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("BASE_CLASS", 5);
			LeaveRule("BASE_CLASS", 5);
			LeaveRule_BASE_CLASS();
		}
	}
	// $ANTLR end "BASE_CLASS"

	partial void EnterRule_COMMON_FIELDS();
	partial void LeaveRule_COMMON_FIELDS();

	// $ANTLR start "COMMON_FIELDS"
	[GrammarRule("COMMON_FIELDS")]
	private void mCOMMON_FIELDS()
	{
		EnterRule_COMMON_FIELDS();
		EnterRule("COMMON_FIELDS", 6);
		TraceIn("COMMON_FIELDS", 6);
		try
		{
			int _type = COMMON_FIELDS;
			int _channel = DefaultTokenChannel;
			// ADL.g:127:14: ( '@common_fields' )
			DebugEnterAlt(1);
			// ADL.g:127:16: '@common_fields'
			{
			DebugLocation(127, 16);
			Match("@common_fields"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("COMMON_FIELDS", 6);
			LeaveRule("COMMON_FIELDS", 6);
			LeaveRule_COMMON_FIELDS();
		}
	}
	// $ANTLR end "COMMON_FIELDS"

	partial void EnterRule_ATTRIBUTES();
	partial void LeaveRule_ATTRIBUTES();

	// $ANTLR start "ATTRIBUTES"
	[GrammarRule("ATTRIBUTES")]
	private void mATTRIBUTES()
	{
		EnterRule_ATTRIBUTES();
		EnterRule("ATTRIBUTES", 7);
		TraceIn("ATTRIBUTES", 7);
		try
		{
			int _type = ATTRIBUTES;
			int _channel = DefaultTokenChannel;
			// ADL.g:128:11: ( '@attributes' )
			DebugEnterAlt(1);
			// ADL.g:128:13: '@attributes'
			{
			DebugLocation(128, 13);
			Match("@attributes"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("ATTRIBUTES", 7);
			LeaveRule("ATTRIBUTES", 7);
			LeaveRule_ATTRIBUTES();
		}
	}
	// $ANTLR end "ATTRIBUTES"

	partial void EnterRule_COMMON_ATTRIBUTES();
	partial void LeaveRule_COMMON_ATTRIBUTES();

	// $ANTLR start "COMMON_ATTRIBUTES"
	[GrammarRule("COMMON_ATTRIBUTES")]
	private void mCOMMON_ATTRIBUTES()
	{
		EnterRule_COMMON_ATTRIBUTES();
		EnterRule("COMMON_ATTRIBUTES", 8);
		TraceIn("COMMON_ATTRIBUTES", 8);
		try
		{
			int _type = COMMON_ATTRIBUTES;
			int _channel = DefaultTokenChannel;
			// ADL.g:129:18: ( '@common_attributes' )
			DebugEnterAlt(1);
			// ADL.g:129:20: '@common_attributes'
			{
			DebugLocation(129, 20);
			Match("@common_attributes"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("COMMON_ATTRIBUTES", 8);
			LeaveRule("COMMON_ATTRIBUTES", 8);
			LeaveRule_COMMON_ATTRIBUTES();
		}
	}
	// $ANTLR end "COMMON_ATTRIBUTES"

	partial void EnterRule_PRINTED();
	partial void LeaveRule_PRINTED();

	// $ANTLR start "PRINTED"
	[GrammarRule("PRINTED")]
	private void mPRINTED()
	{
		EnterRule_PRINTED();
		EnterRule("PRINTED", 9);
		TraceIn("PRINTED", 9);
		try
		{
			int _type = PRINTED;
			int _channel = DefaultTokenChannel;
			// ADL.g:130:8: ( '@printed' )
			DebugEnterAlt(1);
			// ADL.g:130:10: '@printed'
			{
			DebugLocation(130, 10);
			Match("@printed"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("PRINTED", 9);
			LeaveRule("PRINTED", 9);
			LeaveRule_PRINTED();
		}
	}
	// $ANTLR end "PRINTED"

	partial void EnterRule_QUESTION();
	partial void LeaveRule_QUESTION();

	// $ANTLR start "QUESTION"
	[GrammarRule("QUESTION")]
	private void mQUESTION()
	{
		EnterRule_QUESTION();
		EnterRule("QUESTION", 10);
		TraceIn("QUESTION", 10);
		try
		{
			int _type = QUESTION;
			int _channel = DefaultTokenChannel;
			// ADL.g:132:9: ( '?' )
			DebugEnterAlt(1);
			// ADL.g:132:11: '?'
			{
			DebugLocation(132, 11);
			Match('?'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("QUESTION", 10);
			LeaveRule("QUESTION", 10);
			LeaveRule_QUESTION();
		}
	}
	// $ANTLR end "QUESTION"

	partial void EnterRule_ASTERISK();
	partial void LeaveRule_ASTERISK();

	// $ANTLR start "ASTERISK"
	[GrammarRule("ASTERISK")]
	private void mASTERISK()
	{
		EnterRule_ASTERISK();
		EnterRule("ASTERISK", 11);
		TraceIn("ASTERISK", 11);
		try
		{
			int _type = ASTERISK;
			int _channel = DefaultTokenChannel;
			// ADL.g:133:9: ( '*' )
			DebugEnterAlt(1);
			// ADL.g:133:11: '*'
			{
			DebugLocation(133, 11);
			Match('*'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("ASTERISK", 11);
			LeaveRule("ASTERISK", 11);
			LeaveRule_ASTERISK();
		}
	}
	// $ANTLR end "ASTERISK"

	partial void EnterRule_DOT();
	partial void LeaveRule_DOT();

	// $ANTLR start "DOT"
	[GrammarRule("DOT")]
	private void mDOT()
	{
		EnterRule_DOT();
		EnterRule("DOT", 12);
		TraceIn("DOT", 12);
		try
		{
			int _type = DOT;
			int _channel = DefaultTokenChannel;
			// ADL.g:135:5: ( '.' )
			DebugEnterAlt(1);
			// ADL.g:135:7: '.'
			{
			DebugLocation(135, 7);
			Match('.'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("DOT", 12);
			LeaveRule("DOT", 12);
			LeaveRule_DOT();
		}
	}
	// $ANTLR end "DOT"

	partial void EnterRule_PIPE();
	partial void LeaveRule_PIPE();

	// $ANTLR start "PIPE"
	[GrammarRule("PIPE")]
	private void mPIPE()
	{
		EnterRule_PIPE();
		EnterRule("PIPE", 13);
		TraceIn("PIPE", 13);
		try
		{
			int _type = PIPE;
			int _channel = DefaultTokenChannel;
			// ADL.g:137:5: ( '|' )
			DebugEnterAlt(1);
			// ADL.g:137:7: '|'
			{
			DebugLocation(137, 7);
			Match('|'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("PIPE", 13);
			LeaveRule("PIPE", 13);
			LeaveRule_PIPE();
		}
	}
	// $ANTLR end "PIPE"

	partial void EnterRule_SEMI();
	partial void LeaveRule_SEMI();

	// $ANTLR start "SEMI"
	[GrammarRule("SEMI")]
	private void mSEMI()
	{
		EnterRule_SEMI();
		EnterRule("SEMI", 14);
		TraceIn("SEMI", 14);
		try
		{
			int _type = SEMI;
			int _channel = DefaultTokenChannel;
			// ADL.g:139:5: ( ';' )
			DebugEnterAlt(1);
			// ADL.g:139:7: ';'
			{
			DebugLocation(139, 7);
			Match(';'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("SEMI", 14);
			LeaveRule("SEMI", 14);
			LeaveRule_SEMI();
		}
	}
	// $ANTLR end "SEMI"

	partial void EnterRule_WS();
	partial void LeaveRule_WS();

	// $ANTLR start "WS"
	[GrammarRule("WS")]
	private void mWS()
	{
		EnterRule_WS();
		EnterRule("WS", 15);
		TraceIn("WS", 15);
		try
		{
			int _type = WS;
			int _channel = DefaultTokenChannel;
			// ADL.g:141:5: ( ( ' ' | '\\t' | '\\r' '\\n' | '\\n' | '\\r' ) )
			DebugEnterAlt(1);
			// ADL.g:141:9: ( ' ' | '\\t' | '\\r' '\\n' | '\\n' | '\\r' )
			{
			DebugLocation(141, 9);
			// ADL.g:141:9: ( ' ' | '\\t' | '\\r' '\\n' | '\\n' | '\\r' )
			int alt2=5;
			try { DebugEnterSubRule(2);
			try { DebugEnterDecision(2, false);
			switch (input.LA(1))
			{
			case ' ':
				{
				alt2 = 1;
				}
				break;
			case '\t':
				{
				alt2 = 2;
				}
				break;
			case '\r':
				{
				int LA2_2 = input.LA(2);

				if ((LA2_2=='\n'))
				{
					alt2 = 3;
				}
				else
				{
					alt2 = 5;
				}
				}
				break;
			case '\n':
				{
				alt2 = 4;
				}
				break;
			default:
				{
					NoViableAltException nvae = new NoViableAltException("", 2, 0, input, 1);
					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(2); }
			switch (alt2)
			{
			case 1:
				DebugEnterAlt(1);
				// ADL.g:141:13: ' '
				{
				DebugLocation(141, 13);
				Match(' '); 

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// ADL.g:142:13: '\\t'
				{
				DebugLocation(142, 13);
				Match('\t'); 

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// ADL.g:143:13: '\\r' '\\n'
				{
				DebugLocation(143, 13);
				Match('\r'); 
				DebugLocation(143, 18);
				Match('\n'); 

				}
				break;
			case 4:
				DebugEnterAlt(4);
				// ADL.g:144:13: '\\n'
				{
				DebugLocation(144, 13);
				Match('\n'); 

				}
				break;
			case 5:
				DebugEnterAlt(5);
				// ADL.g:145:13: '\\r'
				{
				DebugLocation(145, 13);
				Match('\r'); 

				}
				break;

			}
			} finally { DebugExitSubRule(2); }

			DebugLocation(147, 9);
			Skip();

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("WS", 15);
			LeaveRule("WS", 15);
			LeaveRule_WS();
		}
	}
	// $ANTLR end "WS"

	partial void EnterRule_COMMENT();
	partial void LeaveRule_COMMENT();

	// $ANTLR start "COMMENT"
	[GrammarRule("COMMENT")]
	private void mCOMMENT()
	{
		EnterRule_COMMENT();
		EnterRule("COMMENT", 16);
		TraceIn("COMMENT", 16);
		try
		{
			int _type = COMMENT;
			int _channel = DefaultTokenChannel;
			// ADL.g:151:5: ( '/*' ( options {greedy=false; } : . )* '*/' | '//' (~ ( '\\r' | '\\n' ) )* ( '\\n' | ( '\\r' ( options {greedy=true; } : '\\n' )? ) ) )
			int alt7=2;
			try { DebugEnterDecision(7, false);
			int LA7_1 = input.LA(1);

			if ((LA7_1=='/'))
			{
				int LA7_2 = input.LA(2);

				if ((LA7_2=='*'))
				{
					alt7 = 1;
				}
				else if ((LA7_2=='/'))
				{
					alt7 = 2;
				}
				else
				{
					NoViableAltException nvae = new NoViableAltException("", 7, 1, input, 2);
					DebugRecognitionException(nvae);
					throw nvae;
				}
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 7, 0, input, 1);
				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(7); }
			switch (alt7)
			{
			case 1:
				DebugEnterAlt(1);
				// ADL.g:151:7: '/*' ( options {greedy=false; } : . )* '*/'
				{
				DebugLocation(151, 7);
				Match("/*"); 

				DebugLocation(151, 12);
				// ADL.g:151:12: ( options {greedy=false; } : . )*
				try { DebugEnterSubRule(3);
				while (true)
				{
					int alt3=2;
					try { DebugEnterDecision(3, false);
					int LA3_1 = input.LA(1);

					if ((LA3_1=='*'))
					{
						int LA3_2 = input.LA(2);

						if ((LA3_2=='/'))
						{
							alt3 = 2;
						}
						else if (((LA3_2>='\u0000' && LA3_2<='.')||(LA3_2>='0' && LA3_2<='\uFFFF')))
						{
							alt3 = 1;
						}


					}
					else if (((LA3_1>='\u0000' && LA3_1<=')')||(LA3_1>='+' && LA3_1<='\uFFFF')))
					{
						alt3 = 1;
					}


					} finally { DebugExitDecision(3); }
					switch ( alt3 )
					{
					case 1:
						DebugEnterAlt(1);
						// ADL.g:151:39: .
						{
						DebugLocation(151, 39);
						MatchAny(); 

						}
						break;

					default:
						goto loop3;
					}
				}

				loop3:
					;

				} finally { DebugExitSubRule(3); }

				DebugLocation(151, 43);
				Match("*/"); 

				DebugLocation(151, 48);
				 Skip(); 

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// ADL.g:152:7: '//' (~ ( '\\r' | '\\n' ) )* ( '\\n' | ( '\\r' ( options {greedy=true; } : '\\n' )? ) )
				{
				DebugLocation(152, 7);
				Match("//"); 

				DebugLocation(152, 12);
				// ADL.g:152:12: (~ ( '\\r' | '\\n' ) )*
				try { DebugEnterSubRule(4);
				while (true)
				{
					int alt4=2;
					try { DebugEnterDecision(4, false);
					int LA4_1 = input.LA(1);

					if (((LA4_1>='\u0000' && LA4_1<='\t')||(LA4_1>='\u000B' && LA4_1<='\f')||(LA4_1>='\u000E' && LA4_1<='\uFFFF')))
					{
						alt4 = 1;
					}


					} finally { DebugExitDecision(4); }
					switch ( alt4 )
					{
					case 1:
						DebugEnterAlt(1);
						// ADL.g:
						{
						DebugLocation(152, 12);
						input.Consume();


						}
						break;

					default:
						goto loop4;
					}
				}

				loop4:
					;

				} finally { DebugExitSubRule(4); }

				DebugLocation(152, 28);
				// ADL.g:152:28: ( '\\n' | ( '\\r' ( options {greedy=true; } : '\\n' )? ) )
				int alt6=2;
				try { DebugEnterSubRule(6);
				try { DebugEnterDecision(6, false);
				int LA6_1 = input.LA(1);

				if ((LA6_1=='\n'))
				{
					alt6 = 1;
				}
				else if ((LA6_1=='\r'))
				{
					alt6 = 2;
				}
				else
				{
					NoViableAltException nvae = new NoViableAltException("", 6, 0, input, 1);
					DebugRecognitionException(nvae);
					throw nvae;
				}
				} finally { DebugExitDecision(6); }
				switch (alt6)
				{
				case 1:
					DebugEnterAlt(1);
					// ADL.g:152:29: '\\n'
					{
					DebugLocation(152, 29);
					Match('\n'); 

					}
					break;
				case 2:
					DebugEnterAlt(2);
					// ADL.g:152:36: ( '\\r' ( options {greedy=true; } : '\\n' )? )
					{
					DebugLocation(152, 36);
					// ADL.g:152:36: ( '\\r' ( options {greedy=true; } : '\\n' )? )
					DebugEnterAlt(1);
					// ADL.g:152:37: '\\r' ( options {greedy=true; } : '\\n' )?
					{
					DebugLocation(152, 37);
					Match('\r'); 
					DebugLocation(152, 42);
					// ADL.g:152:42: ( options {greedy=true; } : '\\n' )?
					int alt5=2;
					try { DebugEnterSubRule(5);
					try { DebugEnterDecision(5, false);
					int LA5_1 = input.LA(1);

					if ((LA5_1=='\n'))
					{
						alt5 = 1;
					}
					} finally { DebugExitDecision(5); }
					switch (alt5)
					{
					case 1:
						DebugEnterAlt(1);
						// ADL.g:152:65: '\\n'
						{
						DebugLocation(152, 65);
						Match('\n'); 

						}
						break;

					}
					} finally { DebugExitSubRule(5); }


					}


					}
					break;

				}
				} finally { DebugExitSubRule(6); }

				DebugLocation(152, 74);
				 Skip(); 

				}
				break;

			}
			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("COMMENT", 16);
			LeaveRule("COMMENT", 16);
			LeaveRule_COMMENT();
		}
	}
	// $ANTLR end "COMMENT"

	partial void EnterRule_ID();
	partial void LeaveRule_ID();

	// $ANTLR start "ID"
	[GrammarRule("ID")]
	private void mID()
	{
		EnterRule_ID();
		EnterRule("ID", 17);
		TraceIn("ID", 17);
		try
		{
			int _type = ID;
			int _channel = DefaultTokenChannel;
			// ADL.g:155:5: ( ID_START_LETTER ( ID_LETTER )* )
			DebugEnterAlt(1);
			// ADL.g:155:7: ID_START_LETTER ( ID_LETTER )*
			{
			DebugLocation(155, 7);
			mID_START_LETTER(); 
			DebugLocation(155, 23);
			// ADL.g:155:23: ( ID_LETTER )*
			try { DebugEnterSubRule(8);
			while (true)
			{
				int alt8=2;
				try { DebugEnterDecision(8, false);
				int LA8_1 = input.LA(1);

				if ((LA8_1=='$'||(LA8_1>='0' && LA8_1<='9')||(LA8_1>='A' && LA8_1<='Z')||LA8_1=='_'||(LA8_1>='a' && LA8_1<='z')||(LA8_1>='\u0080' && LA8_1<='\uFFFE')))
				{
					alt8 = 1;
				}


				} finally { DebugExitDecision(8); }
				switch ( alt8 )
				{
				case 1:
					DebugEnterAlt(1);
					// ADL.g:
					{
					DebugLocation(155, 23);
					input.Consume();


					}
					break;

				default:
					goto loop8;
				}
			}

			loop8:
				;

			} finally { DebugExitSubRule(8); }


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("ID", 17);
			LeaveRule("ID", 17);
			LeaveRule_ID();
		}
	}
	// $ANTLR end "ID"

	partial void EnterRule_EQ();
	partial void LeaveRule_EQ();

	// $ANTLR start "EQ"
	[GrammarRule("EQ")]
	private void mEQ()
	{
		EnterRule_EQ();
		EnterRule("EQ", 18);
		TraceIn("EQ", 18);
		try
		{
			int _type = EQ;
			int _channel = DefaultTokenChannel;
			// ADL.g:158:4: ( '=' )
			DebugEnterAlt(1);
			// ADL.g:158:6: '='
			{
			DebugLocation(158, 6);
			Match('='); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("EQ", 18);
			LeaveRule("EQ", 18);
			LeaveRule_EQ();
		}
	}
	// $ANTLR end "EQ"

	partial void EnterRule_OPEN();
	partial void LeaveRule_OPEN();

	// $ANTLR start "OPEN"
	[GrammarRule("OPEN")]
	private void mOPEN()
	{
		EnterRule_OPEN();
		EnterRule("OPEN", 19);
		TraceIn("OPEN", 19);
		try
		{
			int _type = OPEN;
			int _channel = DefaultTokenChannel;
			// ADL.g:160:5: ( '(' )
			DebugEnterAlt(1);
			// ADL.g:160:7: '('
			{
			DebugLocation(160, 7);
			Match('('); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("OPEN", 19);
			LeaveRule("OPEN", 19);
			LeaveRule_OPEN();
		}
	}
	// $ANTLR end "OPEN"

	partial void EnterRule_CLOSE();
	partial void LeaveRule_CLOSE();

	// $ANTLR start "CLOSE"
	[GrammarRule("CLOSE")]
	private void mCLOSE()
	{
		EnterRule_CLOSE();
		EnterRule("CLOSE", 20);
		TraceIn("CLOSE", 20);
		try
		{
			int _type = CLOSE;
			int _channel = DefaultTokenChannel;
			// ADL.g:161:6: ( ')' )
			DebugEnterAlt(1);
			// ADL.g:161:8: ')'
			{
			DebugLocation(161, 8);
			Match(')'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("CLOSE", 20);
			LeaveRule("CLOSE", 20);
			LeaveRule_CLOSE();
		}
	}
	// $ANTLR end "CLOSE"

	partial void EnterRule_COMMA();
	partial void LeaveRule_COMMA();

	// $ANTLR start "COMMA"
	[GrammarRule("COMMA")]
	private void mCOMMA()
	{
		EnterRule_COMMA();
		EnterRule("COMMA", 21);
		TraceIn("COMMA", 21);
		try
		{
			int _type = COMMA;
			int _channel = DefaultTokenChannel;
			// ADL.g:163:6: ( ',' )
			DebugEnterAlt(1);
			// ADL.g:163:8: ','
			{
			DebugLocation(163, 8);
			Match(','); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("COMMA", 21);
			LeaveRule("COMMA", 21);
			LeaveRule_COMMA();
		}
	}
	// $ANTLR end "COMMA"

	partial void EnterRule_ID_START_LETTER();
	partial void LeaveRule_ID_START_LETTER();

	// $ANTLR start "ID_START_LETTER"
	[GrammarRule("ID_START_LETTER")]
	private void mID_START_LETTER()
	{
		EnterRule_ID_START_LETTER();
		EnterRule("ID_START_LETTER", 22);
		TraceIn("ID_START_LETTER", 22);
		try
		{
			// ADL.g:168:5: ( '_' | '$' | 'a' .. 'z' | 'A' .. 'Z' | '\\u0080' .. '\\ufffe' )
			DebugEnterAlt(1);
			// ADL.g:
			{
			DebugLocation(168, 5);
			if (input.LA(1)=='$'||(input.LA(1)>='A' && input.LA(1)<='Z')||input.LA(1)=='_'||(input.LA(1)>='a' && input.LA(1)<='z')||(input.LA(1)>='\u0080' && input.LA(1)<='\uFFFE'))
			{
				input.Consume();
			}
			else
			{
				MismatchedSetException mse = new MismatchedSetException(null,input);
				DebugRecognitionException(mse);
				Recover(mse);
				throw mse;
			}


			}

		}
		finally
		{
			TraceOut("ID_START_LETTER", 22);
			LeaveRule("ID_START_LETTER", 22);
			LeaveRule_ID_START_LETTER();
		}
	}
	// $ANTLR end "ID_START_LETTER"

	partial void EnterRule_ID_LETTER();
	partial void LeaveRule_ID_LETTER();

	// $ANTLR start "ID_LETTER"
	[GrammarRule("ID_LETTER")]
	private void mID_LETTER()
	{
		EnterRule_ID_LETTER();
		EnterRule("ID_LETTER", 23);
		TraceIn("ID_LETTER", 23);
		try
		{
			// ADL.g:177:5: ( ID_START_LETTER | '0' .. '9' )
			DebugEnterAlt(1);
			// ADL.g:
			{
			DebugLocation(177, 5);
			if (input.LA(1)=='$'||(input.LA(1)>='0' && input.LA(1)<='9')||(input.LA(1)>='A' && input.LA(1)<='Z')||input.LA(1)=='_'||(input.LA(1)>='a' && input.LA(1)<='z')||(input.LA(1)>='\u0080' && input.LA(1)<='\uFFFE'))
			{
				input.Consume();
			}
			else
			{
				MismatchedSetException mse = new MismatchedSetException(null,input);
				DebugRecognitionException(mse);
				Recover(mse);
				throw mse;
			}


			}

		}
		finally
		{
			TraceOut("ID_LETTER", 23);
			LeaveRule("ID_LETTER", 23);
			LeaveRule_ID_LETTER();
		}
	}
	// $ANTLR end "ID_LETTER"

	public override void mTokens()
	{
		// ADL.g:1:8: ( QUOTED_TEXT | NAMESPACE | WALKER | PRINTER | BASE_CLASS | COMMON_FIELDS | ATTRIBUTES | COMMON_ATTRIBUTES | PRINTED | QUESTION | ASTERISK | DOT | PIPE | SEMI | WS | COMMENT | ID | EQ | OPEN | CLOSE | COMMA )
		int alt9=21;
		try { DebugEnterDecision(9, false);
		int LA9_1 = input.LA(1);

		if ((LA9_1=='\"'))
		{
			alt9 = 1;
		}
		else if ((LA9_1=='@'))
		{
			switch (input.LA(2))
			{
			case 'n':
				{
				alt9 = 2;
				}
				break;
			case 'w':
				{
				alt9 = 3;
				}
				break;
			case 'p':
				{
				int LA9_3 = input.LA(3);

				if ((LA9_3=='r'))
				{
					int LA9_4 = input.LA(4);

					if ((LA9_4=='i'))
					{
						int LA9_5 = input.LA(5);

						if ((LA9_5=='n'))
						{
							int LA9_6 = input.LA(6);

							if ((LA9_6=='t'))
							{
								int LA9_7 = input.LA(7);

								if ((LA9_7=='e'))
								{
									int LA9_8 = input.LA(8);

									if ((LA9_8=='r'))
									{
										alt9 = 4;
									}
									else if ((LA9_8=='d'))
									{
										alt9 = 9;
									}
									else
									{
										NoViableAltException nvae = new NoViableAltException("", 9, 29, input, 8);
										DebugRecognitionException(nvae);
										throw nvae;
									}
								}
								else
								{
									NoViableAltException nvae = new NoViableAltException("", 9, 27, input, 7);
									DebugRecognitionException(nvae);
									throw nvae;
								}
							}
							else
							{
								NoViableAltException nvae = new NoViableAltException("", 9, 25, input, 6);
								DebugRecognitionException(nvae);
								throw nvae;
							}
						}
						else
						{
							NoViableAltException nvae = new NoViableAltException("", 9, 23, input, 5);
							DebugRecognitionException(nvae);
							throw nvae;
						}
					}
					else
					{
						NoViableAltException nvae = new NoViableAltException("", 9, 21, input, 4);
						DebugRecognitionException(nvae);
						throw nvae;
					}
				}
				else
				{
					NoViableAltException nvae = new NoViableAltException("", 9, 17, input, 3);
					DebugRecognitionException(nvae);
					throw nvae;
				}
				}
				break;
			case 'b':
				{
				alt9 = 5;
				}
				break;
			case 'c':
				{
				int LA9_3 = input.LA(3);

				if ((LA9_3=='o'))
				{
					int LA9_4 = input.LA(4);

					if ((LA9_4=='m'))
					{
						int LA9_5 = input.LA(5);

						if ((LA9_5=='m'))
						{
							int LA9_6 = input.LA(6);

							if ((LA9_6=='o'))
							{
								int LA9_7 = input.LA(7);

								if ((LA9_7=='n'))
								{
									int LA9_8 = input.LA(8);

									if ((LA9_8=='_'))
									{
										int LA9_9 = input.LA(9);

										if ((LA9_9=='f'))
										{
											alt9 = 6;
										}
										else if ((LA9_9=='a'))
										{
											alt9 = 8;
										}
										else
										{
											NoViableAltException nvae = new NoViableAltException("", 9, 33, input, 9);
											DebugRecognitionException(nvae);
											throw nvae;
										}
									}
									else
									{
										NoViableAltException nvae = new NoViableAltException("", 9, 30, input, 8);
										DebugRecognitionException(nvae);
										throw nvae;
									}
								}
								else
								{
									NoViableAltException nvae = new NoViableAltException("", 9, 28, input, 7);
									DebugRecognitionException(nvae);
									throw nvae;
								}
							}
							else
							{
								NoViableAltException nvae = new NoViableAltException("", 9, 26, input, 6);
								DebugRecognitionException(nvae);
								throw nvae;
							}
						}
						else
						{
							NoViableAltException nvae = new NoViableAltException("", 9, 24, input, 5);
							DebugRecognitionException(nvae);
							throw nvae;
						}
					}
					else
					{
						NoViableAltException nvae = new NoViableAltException("", 9, 22, input, 4);
						DebugRecognitionException(nvae);
						throw nvae;
					}
				}
				else
				{
					NoViableAltException nvae = new NoViableAltException("", 9, 19, input, 3);
					DebugRecognitionException(nvae);
					throw nvae;
				}
				}
				break;
			case 'a':
				{
				alt9 = 7;
				}
				break;
			default:
				{
					NoViableAltException nvae = new NoViableAltException("", 9, 2, input, 2);
					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

		}
		else if ((LA9_1=='?'))
		{
			alt9 = 10;
		}
		else if ((LA9_1=='*'))
		{
			alt9 = 11;
		}
		else if ((LA9_1=='.'))
		{
			alt9 = 12;
		}
		else if ((LA9_1=='|'))
		{
			alt9 = 13;
		}
		else if ((LA9_1==';'))
		{
			alt9 = 14;
		}
		else if (((LA9_1>='\t' && LA9_1<='\n')||LA9_1=='\r'||LA9_1==' '))
		{
			alt9 = 15;
		}
		else if ((LA9_1=='/'))
		{
			alt9 = 16;
		}
		else if ((LA9_1=='$'||(LA9_1>='A' && LA9_1<='Z')||LA9_1=='_'||(LA9_1>='a' && LA9_1<='z')||(LA9_1>='\u0080' && LA9_1<='\uFFFE')))
		{
			alt9 = 17;
		}
		else if ((LA9_1=='='))
		{
			alt9 = 18;
		}
		else if ((LA9_1=='('))
		{
			alt9 = 19;
		}
		else if ((LA9_1==')'))
		{
			alt9 = 20;
		}
		else if ((LA9_1==','))
		{
			alt9 = 21;
		}
		else
		{
			NoViableAltException nvae = new NoViableAltException("", 9, 0, input, 1);
			DebugRecognitionException(nvae);
			throw nvae;
		}
		} finally { DebugExitDecision(9); }
		switch (alt9)
		{
		case 1:
			DebugEnterAlt(1);
			// ADL.g:1:10: QUOTED_TEXT
			{
			DebugLocation(1, 10);
			mQUOTED_TEXT(); 

			}
			break;
		case 2:
			DebugEnterAlt(2);
			// ADL.g:1:22: NAMESPACE
			{
			DebugLocation(1, 22);
			mNAMESPACE(); 

			}
			break;
		case 3:
			DebugEnterAlt(3);
			// ADL.g:1:32: WALKER
			{
			DebugLocation(1, 32);
			mWALKER(); 

			}
			break;
		case 4:
			DebugEnterAlt(4);
			// ADL.g:1:39: PRINTER
			{
			DebugLocation(1, 39);
			mPRINTER(); 

			}
			break;
		case 5:
			DebugEnterAlt(5);
			// ADL.g:1:47: BASE_CLASS
			{
			DebugLocation(1, 47);
			mBASE_CLASS(); 

			}
			break;
		case 6:
			DebugEnterAlt(6);
			// ADL.g:1:58: COMMON_FIELDS
			{
			DebugLocation(1, 58);
			mCOMMON_FIELDS(); 

			}
			break;
		case 7:
			DebugEnterAlt(7);
			// ADL.g:1:72: ATTRIBUTES
			{
			DebugLocation(1, 72);
			mATTRIBUTES(); 

			}
			break;
		case 8:
			DebugEnterAlt(8);
			// ADL.g:1:83: COMMON_ATTRIBUTES
			{
			DebugLocation(1, 83);
			mCOMMON_ATTRIBUTES(); 

			}
			break;
		case 9:
			DebugEnterAlt(9);
			// ADL.g:1:101: PRINTED
			{
			DebugLocation(1, 101);
			mPRINTED(); 

			}
			break;
		case 10:
			DebugEnterAlt(10);
			// ADL.g:1:109: QUESTION
			{
			DebugLocation(1, 109);
			mQUESTION(); 

			}
			break;
		case 11:
			DebugEnterAlt(11);
			// ADL.g:1:118: ASTERISK
			{
			DebugLocation(1, 118);
			mASTERISK(); 

			}
			break;
		case 12:
			DebugEnterAlt(12);
			// ADL.g:1:127: DOT
			{
			DebugLocation(1, 127);
			mDOT(); 

			}
			break;
		case 13:
			DebugEnterAlt(13);
			// ADL.g:1:131: PIPE
			{
			DebugLocation(1, 131);
			mPIPE(); 

			}
			break;
		case 14:
			DebugEnterAlt(14);
			// ADL.g:1:136: SEMI
			{
			DebugLocation(1, 136);
			mSEMI(); 

			}
			break;
		case 15:
			DebugEnterAlt(15);
			// ADL.g:1:141: WS
			{
			DebugLocation(1, 141);
			mWS(); 

			}
			break;
		case 16:
			DebugEnterAlt(16);
			// ADL.g:1:144: COMMENT
			{
			DebugLocation(1, 144);
			mCOMMENT(); 

			}
			break;
		case 17:
			DebugEnterAlt(17);
			// ADL.g:1:152: ID
			{
			DebugLocation(1, 152);
			mID(); 

			}
			break;
		case 18:
			DebugEnterAlt(18);
			// ADL.g:1:155: EQ
			{
			DebugLocation(1, 155);
			mEQ(); 

			}
			break;
		case 19:
			DebugEnterAlt(19);
			// ADL.g:1:158: OPEN
			{
			DebugLocation(1, 158);
			mOPEN(); 

			}
			break;
		case 20:
			DebugEnterAlt(20);
			// ADL.g:1:163: CLOSE
			{
			DebugLocation(1, 163);
			mCLOSE(); 

			}
			break;
		case 21:
			DebugEnterAlt(21);
			// ADL.g:1:169: COMMA
			{
			DebugLocation(1, 169);
			mCOMMA(); 

			}
			break;

		}

	}


	#region DFA

	protected override void InitDFAs()
	{
		base.InitDFAs();
	}

	#endregion

}

} // namespace  adt 
