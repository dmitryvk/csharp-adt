//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 3.5.0.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// $ANTLR 3.5.0.2 ADL.g 2015-06-03 00:29:35

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 219
// Unreachable code detected.
#pragma warning disable 162
// Missing XML comment for publicly visible type or member 'Type_or_Member'
#pragma warning disable 1591
// CLS compliance checking will not be performed on 'type' because it is not visible from outside this assembly.
#pragma warning disable 3019


using adt.ADL;


using System.Collections.Generic;
using Antlr.Runtime;
using Antlr.Runtime.Misc;

namespace  adt 
{
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "3.5.0.2")]
[System.CLSCompliant(false)]
public partial class ADLParser : Antlr.Runtime.Parser
{
	internal static readonly string[] tokenNames = new string[] {
		"<invalid>", "<EOR>", "<DOWN>", "<UP>", "ASTERISK", "ATTRIBUTES", "CLOSE", "COMMA", "COMMENT", "COMMON_ATTRIBUTES", "DOT", "EQ", "ID", "ID_LETTER", "ID_START_LETTER", "NAMESPACE", "OPEN", "PIPE", "QUESTION", "QUOTED_TYPE", "SEMI", "WS"
	};
	public const int EOF=-1;
	public const int ASTERISK=4;
	public const int ATTRIBUTES=5;
	public const int CLOSE=6;
	public const int COMMA=7;
	public const int COMMENT=8;
	public const int COMMON_ATTRIBUTES=9;
	public const int DOT=10;
	public const int EQ=11;
	public const int ID=12;
	public const int ID_LETTER=13;
	public const int ID_START_LETTER=14;
	public const int NAMESPACE=15;
	public const int OPEN=16;
	public const int PIPE=17;
	public const int QUESTION=18;
	public const int QUOTED_TYPE=19;
	public const int SEMI=20;
	public const int WS=21;

	public ADLParser(ITokenStream input)
		: this(input, new RecognizerSharedState())
	{
	}
	public ADLParser(ITokenStream input, RecognizerSharedState state)
		: base(input, state)
	{
		OnCreated();
	}

	public override string[] TokenNames { get { return ADLParser.tokenNames; } }
	public override string GrammarFileName { get { return "ADL.g"; } }


	partial void OnCreated();
	partial void EnterRule(string ruleName, int ruleIndex);
	partial void LeaveRule(string ruleName, int ruleIndex);

	#region Rules
	partial void EnterRule_program();
	partial void LeaveRule_program();
	// $ANTLR start "program"
	// ADL.g:16:8: public program returns [ProgramDecl r] : namespaceDecl ( node )+ EOF ;
	[GrammarRule("program")]
	public ProgramDecl program()
	{
		EnterRule_program();
		EnterRule("program", 1);
		TraceIn("program", 1);
		ProgramDecl r = default(ProgramDecl);


		NamespaceDecl namespaceDecl1 = default(NamespaceDecl);
		NodeDecl node2 = default(NodeDecl);

		try { DebugEnterRule(GrammarFileName, "program");
		DebugLocation(16, 10);
		try
		{
			// ADL.g:17:5: ( namespaceDecl ( node )+ EOF )
			DebugEnterAlt(1);
			// ADL.g:17:7: namespaceDecl ( node )+ EOF
			{
			DebugLocation(17, 7);
			PushFollow(Follow._namespaceDecl_in_program57);
			namespaceDecl1=namespaceDecl();
			PopFollow();

			DebugLocation(17, 22);
			 r = new ProgramDecl { ns = namespaceDecl1 }; 
			DebugLocation(18, 5);
			// ADL.g:18:5: ( node )+
			int cnt1=0;
			try { DebugEnterSubRule(1);
			while (true)
			{
				int alt1=2;
				try { DebugEnterDecision(1, false);
				int LA1_1 = input.LA(1);

				if ((LA1_1==ID))
				{
					alt1 = 1;
				}


				} finally { DebugExitDecision(1); }
				switch (alt1)
				{
				case 1:
					DebugEnterAlt(1);
					// ADL.g:18:6: node
					{
					DebugLocation(18, 6);
					PushFollow(Follow._node_in_program67);
					node2=node();
					PopFollow();

					DebugLocation(19, 9);

					            r.nodes.Add(node2);
					        

					}
					break;

				default:
					if (cnt1 >= 1)
						goto loop1;

					EarlyExitException eee1 = new EarlyExitException( 1, input );
					DebugRecognitionException(eee1);
					throw eee1;
				}
				cnt1++;
			}
			loop1:
				;

			} finally { DebugExitSubRule(1); }

			DebugLocation(22, 8);
			Match(input,EOF,Follow._EOF_in_program86); 

			}

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("program", 1);
			LeaveRule("program", 1);
			LeaveRule_program();
		}
		DebugLocation(22, 10);
		} finally { DebugExitRule(GrammarFileName, "program"); }
		return r;

	}
	// $ANTLR end "program"

	partial void EnterRule_namespaceDecl();
	partial void LeaveRule_namespaceDecl();
	// $ANTLR start "namespaceDecl"
	// ADL.g:24:1: namespaceDecl returns [NamespaceDecl r] : NAMESPACE id1= ID ( DOT id2= ID )* SEMI ;
	[GrammarRule("namespaceDecl")]
	private NamespaceDecl namespaceDecl()
	{
		EnterRule_namespaceDecl();
		EnterRule("namespaceDecl", 2);
		TraceIn("namespaceDecl", 2);
		NamespaceDecl r = default(NamespaceDecl);


		IToken id1 = default(IToken);
		IToken id2 = default(IToken);

		 r = new NamespaceDecl(); 
		try { DebugEnterRule(GrammarFileName, "namespaceDecl");
		DebugLocation(24, 95);
		try
		{
			// ADL.g:26:5: ( NAMESPACE id1= ID ( DOT id2= ID )* SEMI )
			DebugEnterAlt(1);
			// ADL.g:26:7: NAMESPACE id1= ID ( DOT id2= ID )* SEMI
			{
			DebugLocation(26, 7);
			Match(input,NAMESPACE,Follow._NAMESPACE_in_namespaceDecl107); 
			DebugLocation(26, 20);
			id1=(IToken)Match(input,ID,Follow._ID_in_namespaceDecl111); 
			DebugLocation(26, 24);
			 r.ids.Add((id1!=null?id1.Text:default(string))); 
			DebugLocation(26, 51);
			// ADL.g:26:51: ( DOT id2= ID )*
			try { DebugEnterSubRule(2);
			while (true)
			{
				int alt2=2;
				try { DebugEnterDecision(2, false);
				int LA2_1 = input.LA(1);

				if ((LA2_1==DOT))
				{
					alt2 = 1;
				}


				} finally { DebugExitDecision(2); }
				switch ( alt2 )
				{
				case 1:
					DebugEnterAlt(1);
					// ADL.g:26:52: DOT id2= ID
					{
					DebugLocation(26, 52);
					Match(input,DOT,Follow._DOT_in_namespaceDecl116); 
					DebugLocation(26, 59);
					id2=(IToken)Match(input,ID,Follow._ID_in_namespaceDecl120); 
					DebugLocation(26, 63);
					 r.ids.Add((id2!=null?id2.Text:default(string))); 

					}
					break;

				default:
					goto loop2;
				}
			}

			loop2:
				;

			} finally { DebugExitSubRule(2); }

			DebugLocation(26, 92);
			Match(input,SEMI,Follow._SEMI_in_namespaceDecl126); 

			}

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("namespaceDecl", 2);
			LeaveRule("namespaceDecl", 2);
			LeaveRule_namespaceDecl();
		}
		DebugLocation(26, 95);
		} finally { DebugExitRule(GrammarFileName, "namespaceDecl"); }
		return r;

	}
	// $ANTLR end "namespaceDecl"

	partial void EnterRule_node();
	partial void LeaveRule_node();
	// $ANTLR start "node"
	// ADL.g:28:1: node returns [NodeDecl r] : ( nodeVariants | nodeConcrete );
	[GrammarRule("node")]
	private NodeDecl node()
	{
		EnterRule_node();
		EnterRule("node", 3);
		TraceIn("node", 3);
		NodeDecl r = default(NodeDecl);


		NodeVariantsDecl nodeVariants3 = default(NodeVariantsDecl);
		NodeConcreteDecl nodeConcrete4 = default(NodeConcreteDecl);

		try { DebugEnterRule(GrammarFileName, "node");
		DebugLocation(28, 85);
		try
		{
			// ADL.g:29:5: ( nodeVariants | nodeConcrete )
			int alt3=2;
			try { DebugEnterDecision(3, false);
			int LA3_1 = input.LA(1);

			if ((LA3_1==ID))
			{
				int LA3_2 = input.LA(2);

				if ((LA3_2==EQ))
				{
					int LA3_3 = input.LA(3);

					if ((LA3_3==ID))
					{
						int LA3_4 = input.LA(4);

						if ((LA3_4==OPEN))
						{
							alt3 = 1;
						}
						else if (((LA3_4>=ASTERISK && LA3_4<=ATTRIBUTES)||LA3_4==COMMA||LA3_4==ID||LA3_4==QUESTION||LA3_4==SEMI))
						{
							alt3 = 2;
						}
						else
						{
							NoViableAltException nvae = new NoViableAltException("", 3, 3, input, 4);
							DebugRecognitionException(nvae);
							throw nvae;
						}
					}
					else if ((LA3_3==ATTRIBUTES||LA3_3==SEMI))
					{
						alt3 = 2;
					}
					else
					{
						NoViableAltException nvae = new NoViableAltException("", 3, 2, input, 3);
						DebugRecognitionException(nvae);
						throw nvae;
					}
				}
				else
				{
					NoViableAltException nvae = new NoViableAltException("", 3, 1, input, 2);
					DebugRecognitionException(nvae);
					throw nvae;
				}
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 3, 0, input, 1);
				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(3); }
			switch (alt3)
			{
			case 1:
				DebugEnterAlt(1);
				// ADL.g:29:7: nodeVariants
				{
				DebugLocation(29, 7);
				PushFollow(Follow._nodeVariants_in_node142);
				nodeVariants3=nodeVariants();
				PopFollow();

				DebugLocation(29, 20);
				 r = nodeVariants3; 

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// ADL.g:29:48: nodeConcrete
				{
				DebugLocation(29, 48);
				PushFollow(Follow._nodeConcrete_in_node148);
				nodeConcrete4=nodeConcrete();
				PopFollow();

				DebugLocation(29, 61);
				 r = nodeConcrete4; 

				}
				break;

			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("node", 3);
			LeaveRule("node", 3);
			LeaveRule_node();
		}
		DebugLocation(29, 85);
		} finally { DebugExitRule(GrammarFileName, "node"); }
		return r;

	}
	// $ANTLR end "node"

	partial void EnterRule_nodeVariants();
	partial void LeaveRule_nodeVariants();
	// $ANTLR start "nodeVariants"
	// ADL.g:31:1: nodeVariants returns [NodeVariantsDecl r] : ID EQ v1= nodeVariant ( PIPE v2= nodeVariant )* ( common_attributes )? SEMI ;
	[GrammarRule("nodeVariants")]
	private NodeVariantsDecl nodeVariants()
	{
		EnterRule_nodeVariants();
		EnterRule("nodeVariants", 4);
		TraceIn("nodeVariants", 4);
		NodeVariantsDecl r = default(NodeVariantsDecl);


		IToken ID5 = default(IToken);
		NodeVariantDecl v1 = default(NodeVariantDecl);
		NodeVariantDecl v2 = default(NodeVariantDecl);
		List<AttributeDecl> common_attributes6 = default(List<AttributeDecl>);

		try { DebugEnterRule(GrammarFileName, "nodeVariants");
		DebugLocation(31, 8);
		try
		{
			// ADL.g:32:5: ( ID EQ v1= nodeVariant ( PIPE v2= nodeVariant )* ( common_attributes )? SEMI )
			DebugEnterAlt(1);
			// ADL.g:32:7: ID EQ v1= nodeVariant ( PIPE v2= nodeVariant )* ( common_attributes )? SEMI
			{
			DebugLocation(32, 7);
			ID5=(IToken)Match(input,ID,Follow._ID_in_nodeVariants170); 
			DebugLocation(32, 10);
			Match(input,EQ,Follow._EQ_in_nodeVariants172); 
			DebugLocation(32, 13);
			 r = new NodeVariantsDecl { id = (ID5!=null?ID5.Text:default(string)) }; 
			DebugLocation(33, 7);
			PushFollow(Follow._nodeVariant_in_nodeVariants182);
			v1=nodeVariant();
			PopFollow();

			DebugLocation(33, 20);
			 r.variants.Add(v1); 
			DebugLocation(33, 48);
			// ADL.g:33:48: ( PIPE v2= nodeVariant )*
			try { DebugEnterSubRule(4);
			while (true)
			{
				int alt4=2;
				try { DebugEnterDecision(4, false);
				int LA4_1 = input.LA(1);

				if ((LA4_1==PIPE))
				{
					alt4 = 1;
				}


				} finally { DebugExitDecision(4); }
				switch ( alt4 )
				{
				case 1:
					DebugEnterAlt(1);
					// ADL.g:33:49: PIPE v2= nodeVariant
					{
					DebugLocation(33, 49);
					Match(input,PIPE,Follow._PIPE_in_nodeVariants187); 
					DebugLocation(33, 56);
					PushFollow(Follow._nodeVariant_in_nodeVariants191);
					v2=nodeVariant();
					PopFollow();

					DebugLocation(33, 69);
					 r.variants.Add(v2); 

					}
					break;

				default:
					goto loop4;
				}
			}

			loop4:
				;

			} finally { DebugExitSubRule(4); }

			DebugLocation(34, 5);
			// ADL.g:34:5: ( common_attributes )?
			int alt5=2;
			try { DebugEnterSubRule(5);
			try { DebugEnterDecision(5, false);
			int LA5_1 = input.LA(1);

			if ((LA5_1==COMMON_ATTRIBUTES))
			{
				alt5 = 1;
			}
			} finally { DebugExitDecision(5); }
			switch (alt5)
			{
			case 1:
				DebugEnterAlt(1);
				// ADL.g:34:5: common_attributes
				{
				DebugLocation(34, 5);
				PushFollow(Follow._common_attributes_in_nodeVariants201);
				common_attributes6=common_attributes();
				PopFollow();


				}
				break;

			}
			} finally { DebugExitSubRule(5); }

			DebugLocation(35, 5);

			        r.attributes = common_attributes6 ?? new List<AttributeDecl>();
			    
			DebugLocation(38, 5);
			Match(input,SEMI,Follow._SEMI_in_nodeVariants214); 

			}

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("nodeVariants", 4);
			LeaveRule("nodeVariants", 4);
			LeaveRule_nodeVariants();
		}
		DebugLocation(38, 8);
		} finally { DebugExitRule(GrammarFileName, "nodeVariants"); }
		return r;

	}
	// $ANTLR end "nodeVariants"

	partial void EnterRule_nodeVariant();
	partial void LeaveRule_nodeVariant();
	// $ANTLR start "nodeVariant"
	// ADL.g:40:1: nodeVariant returns [NodeVariantDecl r] : ID OPEN ( fields )? CLOSE ( attributes )? ;
	[GrammarRule("nodeVariant")]
	private NodeVariantDecl nodeVariant()
	{
		EnterRule_nodeVariant();
		EnterRule("nodeVariant", 5);
		TraceIn("nodeVariant", 5);
		NodeVariantDecl r = default(NodeVariantDecl);


		IToken ID7 = default(IToken);
		List<FieldDecl> fields8 = default(List<FieldDecl>);
		List<AttributeDecl> attributes9 = default(List<AttributeDecl>);

		try { DebugEnterRule(GrammarFileName, "nodeVariant");
		DebugLocation(40, 4);
		try
		{
			// ADL.g:41:5: ( ID OPEN ( fields )? CLOSE ( attributes )? )
			DebugEnterAlt(1);
			// ADL.g:41:7: ID OPEN ( fields )? CLOSE ( attributes )?
			{
			DebugLocation(41, 7);
			ID7=(IToken)Match(input,ID,Follow._ID_in_nodeVariant230); 
			DebugLocation(41, 10);
			Match(input,OPEN,Follow._OPEN_in_nodeVariant232); 
			DebugLocation(41, 15);
			// ADL.g:41:15: ( fields )?
			int alt6=2;
			try { DebugEnterSubRule(6);
			try { DebugEnterDecision(6, false);
			int LA6_1 = input.LA(1);

			if ((LA6_1==ID))
			{
				alt6 = 1;
			}
			} finally { DebugExitDecision(6); }
			switch (alt6)
			{
			case 1:
				DebugEnterAlt(1);
				// ADL.g:41:15: fields
				{
				DebugLocation(41, 15);
				PushFollow(Follow._fields_in_nodeVariant234);
				fields8=fields();
				PopFollow();


				}
				break;

			}
			} finally { DebugExitSubRule(6); }

			DebugLocation(41, 23);
			Match(input,CLOSE,Follow._CLOSE_in_nodeVariant237); 
			DebugLocation(41, 29);
			// ADL.g:41:29: ( attributes )?
			int alt7=2;
			try { DebugEnterSubRule(7);
			try { DebugEnterDecision(7, false);
			int LA7_1 = input.LA(1);

			if ((LA7_1==ATTRIBUTES))
			{
				alt7 = 1;
			}
			} finally { DebugExitDecision(7); }
			switch (alt7)
			{
			case 1:
				DebugEnterAlt(1);
				// ADL.g:41:29: attributes
				{
				DebugLocation(41, 29);
				PushFollow(Follow._attributes_in_nodeVariant239);
				attributes9=attributes();
				PopFollow();


				}
				break;

			}
			} finally { DebugExitSubRule(7); }

			DebugLocation(42, 4);
			 r = new NodeVariantDecl 
			       { id = (ID7!=null?ID7.Text:default(string)),
			        fields = fields8 ?? new List<FieldDecl>(),
			        attributes = attributes9 ?? new List<AttributeDecl>()
			       };
			   

			}

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("nodeVariant", 5);
			LeaveRule("nodeVariant", 5);
			LeaveRule_nodeVariant();
		}
		DebugLocation(47, 4);
		} finally { DebugExitRule(GrammarFileName, "nodeVariant"); }
		return r;

	}
	// $ANTLR end "nodeVariant"

	partial void EnterRule_nodeConcrete();
	partial void LeaveRule_nodeConcrete();
	// $ANTLR start "nodeConcrete"
	// ADL.g:49:1: nodeConcrete returns [NodeConcreteDecl r] : ID EQ ( fields )? ( attributes )? SEMI ;
	[GrammarRule("nodeConcrete")]
	private NodeConcreteDecl nodeConcrete()
	{
		EnterRule_nodeConcrete();
		EnterRule("nodeConcrete", 6);
		TraceIn("nodeConcrete", 6);
		NodeConcreteDecl r = default(NodeConcreteDecl);


		IToken ID10 = default(IToken);
		List<FieldDecl> fields11 = default(List<FieldDecl>);
		List<AttributeDecl> attributes12 = default(List<AttributeDecl>);

		try { DebugEnterRule(GrammarFileName, "nodeConcrete");
		DebugLocation(49, 9);
		try
		{
			// ADL.g:50:5: ( ID EQ ( fields )? ( attributes )? SEMI )
			DebugEnterAlt(1);
			// ADL.g:50:7: ID EQ ( fields )? ( attributes )? SEMI
			{
			DebugLocation(50, 7);
			ID10=(IToken)Match(input,ID,Follow._ID_in_nodeConcrete261); 
			DebugLocation(50, 10);
			Match(input,EQ,Follow._EQ_in_nodeConcrete263); 
			DebugLocation(50, 13);
			// ADL.g:50:13: ( fields )?
			int alt8=2;
			try { DebugEnterSubRule(8);
			try { DebugEnterDecision(8, false);
			int LA8_1 = input.LA(1);

			if ((LA8_1==ID))
			{
				alt8 = 1;
			}
			} finally { DebugExitDecision(8); }
			switch (alt8)
			{
			case 1:
				DebugEnterAlt(1);
				// ADL.g:50:13: fields
				{
				DebugLocation(50, 13);
				PushFollow(Follow._fields_in_nodeConcrete265);
				fields11=fields();
				PopFollow();


				}
				break;

			}
			} finally { DebugExitSubRule(8); }

			DebugLocation(50, 21);
			// ADL.g:50:21: ( attributes )?
			int alt9=2;
			try { DebugEnterSubRule(9);
			try { DebugEnterDecision(9, false);
			int LA9_1 = input.LA(1);

			if ((LA9_1==ATTRIBUTES))
			{
				alt9 = 1;
			}
			} finally { DebugExitDecision(9); }
			switch (alt9)
			{
			case 1:
				DebugEnterAlt(1);
				// ADL.g:50:21: attributes
				{
				DebugLocation(50, 21);
				PushFollow(Follow._attributes_in_nodeConcrete268);
				attributes12=attributes();
				PopFollow();


				}
				break;

			}
			} finally { DebugExitSubRule(9); }

			DebugLocation(51, 4);
			 r = new NodeConcreteDecl 
			       { id = (ID10!=null?ID10.Text:default(string)),
			        fields = fields11 ?? new List<FieldDecl>(),
			        attributes = attributes12 ?? new List<AttributeDecl>()
			       };
			   
			DebugLocation(56, 6);
			Match(input,SEMI,Follow._SEMI_in_nodeConcrete276); 

			}

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("nodeConcrete", 6);
			LeaveRule("nodeConcrete", 6);
			LeaveRule_nodeConcrete();
		}
		DebugLocation(56, 9);
		} finally { DebugExitRule(GrammarFileName, "nodeConcrete"); }
		return r;

	}
	// $ANTLR end "nodeConcrete"

	partial void EnterRule_fields();
	partial void LeaveRule_fields();
	// $ANTLR start "fields"
	// ADL.g:58:1: fields returns [List<FieldDecl> r] : f1= field ( COMMA f2= field )* ;
	[GrammarRule("fields")]
	private List<FieldDecl> fields()
	{
		EnterRule_fields();
		EnterRule("fields", 7);
		TraceIn("fields", 7);
		List<FieldDecl> r = default(List<FieldDecl>);


		FieldDecl f1 = default(FieldDecl);
		FieldDecl f2 = default(FieldDecl);

		 r = new List<FieldDecl>(); 
		try { DebugEnterRule(GrammarFileName, "fields");
		DebugLocation(58, 70);
		try
		{
			// ADL.g:60:5: (f1= field ( COMMA f2= field )* )
			DebugEnterAlt(1);
			// ADL.g:60:7: f1= field ( COMMA f2= field )*
			{
			DebugLocation(60, 9);
			PushFollow(Follow._field_in_fields303);
			f1=field();
			PopFollow();

			DebugLocation(60, 16);
			 r.Add(f1); 
			DebugLocation(60, 35);
			// ADL.g:60:35: ( COMMA f2= field )*
			try { DebugEnterSubRule(10);
			while (true)
			{
				int alt10=2;
				try { DebugEnterDecision(10, false);
				int LA10_1 = input.LA(1);

				if ((LA10_1==COMMA))
				{
					alt10 = 1;
				}


				} finally { DebugExitDecision(10); }
				switch ( alt10 )
				{
				case 1:
					DebugEnterAlt(1);
					// ADL.g:60:36: COMMA f2= field
					{
					DebugLocation(60, 36);
					Match(input,COMMA,Follow._COMMA_in_fields308); 
					DebugLocation(60, 44);
					PushFollow(Follow._field_in_fields312);
					f2=field();
					PopFollow();

					DebugLocation(60, 51);
					 r.Add(f2); 

					}
					break;

				default:
					goto loop10;
				}
			}

			loop10:
				;

			} finally { DebugExitSubRule(10); }


			}

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("fields", 7);
			LeaveRule("fields", 7);
			LeaveRule_fields();
		}
		DebugLocation(60, 70);
		} finally { DebugExitRule(GrammarFileName, "fields"); }
		return r;

	}
	// $ANTLR end "fields"

	partial void EnterRule_attributes();
	partial void LeaveRule_attributes();
	// $ANTLR start "attributes"
	// ADL.g:62:1: attributes returns [List<AttributeDecl> r] : ATTRIBUTES a1= attributeDecl ( COMMA a2= attributeDecl )* ;
	[GrammarRule("attributes")]
	private List<AttributeDecl> attributes()
	{
		EnterRule_attributes();
		EnterRule("attributes", 8);
		TraceIn("attributes", 8);
		List<AttributeDecl> r = default(List<AttributeDecl>);


		AttributeDecl a1 = default(AttributeDecl);
		AttributeDecl a2 = default(AttributeDecl);

		 r = new List<AttributeDecl>(); 
		try { DebugEnterRule(GrammarFileName, "attributes");
		DebugLocation(62, 97);
		try
		{
			// ADL.g:64:5: ( ATTRIBUTES a1= attributeDecl ( COMMA a2= attributeDecl )* )
			DebugEnterAlt(1);
			// ADL.g:64:7: ATTRIBUTES a1= attributeDecl ( COMMA a2= attributeDecl )*
			{
			DebugLocation(64, 7);
			Match(input,ATTRIBUTES,Follow._ATTRIBUTES_in_attributes337); 
			DebugLocation(64, 20);
			PushFollow(Follow._attributeDecl_in_attributes341);
			a1=attributeDecl();
			PopFollow();

			DebugLocation(64, 35);
			 r.Add(a1); 
			DebugLocation(64, 54);
			// ADL.g:64:54: ( COMMA a2= attributeDecl )*
			try { DebugEnterSubRule(11);
			while (true)
			{
				int alt11=2;
				try { DebugEnterDecision(11, false);
				int LA11_1 = input.LA(1);

				if ((LA11_1==COMMA))
				{
					alt11 = 1;
				}


				} finally { DebugExitDecision(11); }
				switch ( alt11 )
				{
				case 1:
					DebugEnterAlt(1);
					// ADL.g:64:55: COMMA a2= attributeDecl
					{
					DebugLocation(64, 55);
					Match(input,COMMA,Follow._COMMA_in_attributes346); 
					DebugLocation(64, 63);
					PushFollow(Follow._attributeDecl_in_attributes350);
					a2=attributeDecl();
					PopFollow();

					DebugLocation(64, 78);
					 r.Add(a2); 

					}
					break;

				default:
					goto loop11;
				}
			}

			loop11:
				;

			} finally { DebugExitSubRule(11); }


			}

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("attributes", 8);
			LeaveRule("attributes", 8);
			LeaveRule_attributes();
		}
		DebugLocation(64, 97);
		} finally { DebugExitRule(GrammarFileName, "attributes"); }
		return r;

	}
	// $ANTLR end "attributes"

	partial void EnterRule_common_attributes();
	partial void LeaveRule_common_attributes();
	// $ANTLR start "common_attributes"
	// ADL.g:66:1: common_attributes returns [List<AttributeDecl> r] : COMMON_ATTRIBUTES a1= attributeDecl ( COMMA a2= attributeDecl )* ;
	[GrammarRule("common_attributes")]
	private List<AttributeDecl> common_attributes()
	{
		EnterRule_common_attributes();
		EnterRule("common_attributes", 9);
		TraceIn("common_attributes", 9);
		List<AttributeDecl> r = default(List<AttributeDecl>);


		AttributeDecl a1 = default(AttributeDecl);
		AttributeDecl a2 = default(AttributeDecl);

		 r = new List<AttributeDecl>(); 
		try { DebugEnterRule(GrammarFileName, "common_attributes");
		DebugLocation(66, 104);
		try
		{
			// ADL.g:68:5: ( COMMON_ATTRIBUTES a1= attributeDecl ( COMMA a2= attributeDecl )* )
			DebugEnterAlt(1);
			// ADL.g:68:7: COMMON_ATTRIBUTES a1= attributeDecl ( COMMA a2= attributeDecl )*
			{
			DebugLocation(68, 7);
			Match(input,COMMON_ATTRIBUTES,Follow._COMMON_ATTRIBUTES_in_common_attributes375); 
			DebugLocation(68, 27);
			PushFollow(Follow._attributeDecl_in_common_attributes379);
			a1=attributeDecl();
			PopFollow();

			DebugLocation(68, 42);
			 r.Add(a1); 
			DebugLocation(68, 61);
			// ADL.g:68:61: ( COMMA a2= attributeDecl )*
			try { DebugEnterSubRule(12);
			while (true)
			{
				int alt12=2;
				try { DebugEnterDecision(12, false);
				int LA12_1 = input.LA(1);

				if ((LA12_1==COMMA))
				{
					alt12 = 1;
				}


				} finally { DebugExitDecision(12); }
				switch ( alt12 )
				{
				case 1:
					DebugEnterAlt(1);
					// ADL.g:68:62: COMMA a2= attributeDecl
					{
					DebugLocation(68, 62);
					Match(input,COMMA,Follow._COMMA_in_common_attributes384); 
					DebugLocation(68, 70);
					PushFollow(Follow._attributeDecl_in_common_attributes388);
					a2=attributeDecl();
					PopFollow();

					DebugLocation(68, 85);
					 r.Add(a2); 

					}
					break;

				default:
					goto loop12;
				}
			}

			loop12:
				;

			} finally { DebugExitSubRule(12); }


			}

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("common_attributes", 9);
			LeaveRule("common_attributes", 9);
			LeaveRule_common_attributes();
		}
		DebugLocation(68, 104);
		} finally { DebugExitRule(GrammarFileName, "common_attributes"); }
		return r;

	}
	// $ANTLR end "common_attributes"

	partial void EnterRule_field();
	partial void LeaveRule_field();
	// $ANTLR start "field"
	// ADL.g:70:1: field returns [FieldDecl r] : typeId= ID (q= QUESTION |a= ASTERISK )? (nameId= ID )? ;
	[GrammarRule("field")]
	private FieldDecl field()
	{
		EnterRule_field();
		EnterRule("field", 10);
		TraceIn("field", 10);
		FieldDecl r = default(FieldDecl);


		IToken typeId = default(IToken);
		IToken q = default(IToken);
		IToken a = default(IToken);
		IToken nameId = default(IToken);

		try { DebugEnterRule(GrammarFileName, "field");
		DebugLocation(70, 5);
		try
		{
			// ADL.g:71:5: (typeId= ID (q= QUESTION |a= ASTERISK )? (nameId= ID )? )
			DebugEnterAlt(1);
			// ADL.g:71:7: typeId= ID (q= QUESTION |a= ASTERISK )? (nameId= ID )?
			{
			DebugLocation(71, 13);
			typeId=(IToken)Match(input,ID,Follow._ID_in_field414); 
			DebugLocation(71, 17);
			// ADL.g:71:17: (q= QUESTION |a= ASTERISK )?
			int alt13=3;
			try { DebugEnterSubRule(13);
			try { DebugEnterDecision(13, false);
			int LA13_1 = input.LA(1);

			if ((LA13_1==QUESTION))
			{
				alt13 = 1;
			}
			else if ((LA13_1==ASTERISK))
			{
				alt13 = 2;
			}
			} finally { DebugExitDecision(13); }
			switch (alt13)
			{
			case 1:
				DebugEnterAlt(1);
				// ADL.g:71:18: q= QUESTION
				{
				DebugLocation(71, 19);
				q=(IToken)Match(input,QUESTION,Follow._QUESTION_in_field419); 

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// ADL.g:71:29: a= ASTERISK
				{
				DebugLocation(71, 30);
				a=(IToken)Match(input,ASTERISK,Follow._ASTERISK_in_field423); 

				}
				break;

			}
			} finally { DebugExitSubRule(13); }

			DebugLocation(71, 48);
			// ADL.g:71:48: (nameId= ID )?
			int alt14=2;
			try { DebugEnterSubRule(14);
			try { DebugEnterDecision(14, false);
			int LA14_1 = input.LA(1);

			if ((LA14_1==ID))
			{
				alt14 = 1;
			}
			} finally { DebugExitDecision(14); }
			switch (alt14)
			{
			case 1:
				DebugEnterAlt(1);
				// ADL.g:71:48: nameId= ID
				{
				DebugLocation(71, 48);
				nameId=(IToken)Match(input,ID,Follow._ID_in_field429); 

				}
				break;

			}
			} finally { DebugExitSubRule(14); }

			DebugLocation(71, 53);

			    r = new FieldDecl {
			    type = (typeId!=null?typeId.Text:default(string)), id = (nameId!=null?nameId.Text:default(string)) ?? (typeId!=null?typeId.Text:default(string)), optional = q != null, many = a != null    };
			    

			}

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("field", 10);
			LeaveRule("field", 10);
			LeaveRule_field();
		}
		DebugLocation(74, 5);
		} finally { DebugExitRule(GrammarFileName, "field"); }
		return r;

	}
	// $ANTLR end "field"

	partial void EnterRule_attributeDecl();
	partial void LeaveRule_attributeDecl();
	// $ANTLR start "attributeDecl"
	// ADL.g:76:1: attributeDecl returns [AttributeDecl r] : attrType ID ;
	[GrammarRule("attributeDecl")]
	private AttributeDecl attributeDecl()
	{
		EnterRule_attributeDecl();
		EnterRule("attributeDecl", 11);
		TraceIn("attributeDecl", 11);
		AttributeDecl r = default(AttributeDecl);


		IToken ID13 = default(IToken);
		string attrType14 = default(string);

		try { DebugEnterRule(GrammarFileName, "attributeDecl");
		DebugLocation(76, 83);
		try
		{
			// ADL.g:77:5: ( attrType ID )
			DebugEnterAlt(1);
			// ADL.g:77:7: attrType ID
			{
			DebugLocation(77, 7);
			PushFollow(Follow._attrType_in_attributeDecl448);
			attrType14=attrType();
			PopFollow();

			DebugLocation(77, 16);
			ID13=(IToken)Match(input,ID,Follow._ID_in_attributeDecl450); 
			DebugLocation(77, 19);
			 r = new AttributeDecl { id = (ID13!=null?ID13.Text:default(string)), type = attrType14 }; 

			}

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("attributeDecl", 11);
			LeaveRule("attributeDecl", 11);
			LeaveRule_attributeDecl();
		}
		DebugLocation(77, 83);
		} finally { DebugExitRule(GrammarFileName, "attributeDecl"); }
		return r;

	}
	// $ANTLR end "attributeDecl"

	partial void EnterRule_attrType();
	partial void LeaveRule_attrType();
	// $ANTLR start "attrType"
	// ADL.g:79:1: attrType returns [string r] : (id1= ID ( DOT id2= ID )* | QUOTED_TYPE );
	[GrammarRule("attrType")]
	private string attrType()
	{
		EnterRule_attrType();
		EnterRule("attrType", 12);
		TraceIn("attrType", 12);
		string r = default(string);


		IToken id1 = default(IToken);
		IToken id2 = default(IToken);
		IToken QUOTED_TYPE15 = default(IToken);

		try { DebugEnterRule(GrammarFileName, "attrType");
		DebugLocation(79, 88);
		try
		{
			// ADL.g:80:5: (id1= ID ( DOT id2= ID )* | QUOTED_TYPE )
			int alt16=2;
			try { DebugEnterDecision(16, false);
			int LA16_1 = input.LA(1);

			if ((LA16_1==ID))
			{
				alt16 = 1;
			}
			else if ((LA16_1==QUOTED_TYPE))
			{
				alt16 = 2;
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 16, 0, input, 1);
				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(16); }
			switch (alt16)
			{
			case 1:
				DebugEnterAlt(1);
				// ADL.g:80:7: id1= ID ( DOT id2= ID )*
				{
				DebugLocation(80, 10);
				id1=(IToken)Match(input,ID,Follow._ID_in_attrType470); 
				DebugLocation(80, 14);
				 r = (id1!=null?id1.Text:default(string)); 
				DebugLocation(80, 34);
				// ADL.g:80:34: ( DOT id2= ID )*
				try { DebugEnterSubRule(15);
				while (true)
				{
					int alt15=2;
					try { DebugEnterDecision(15, false);
					int LA15_1 = input.LA(1);

					if ((LA15_1==DOT))
					{
						alt15 = 1;
					}


					} finally { DebugExitDecision(15); }
					switch ( alt15 )
					{
					case 1:
						DebugEnterAlt(1);
						// ADL.g:80:35: DOT id2= ID
						{
						DebugLocation(80, 35);
						Match(input,DOT,Follow._DOT_in_attrType475); 
						DebugLocation(80, 42);
						id2=(IToken)Match(input,ID,Follow._ID_in_attrType479); 
						DebugLocation(80, 46);
						 r = r + "." + (id2!=null?id2.Text:default(string)); 

						}
						break;

					default:
						goto loop15;
					}
				}

				loop15:
					;

				} finally { DebugExitSubRule(15); }


				}
				break;
			case 2:
				DebugEnterAlt(2);
				// ADL.g:81:7: QUOTED_TYPE
				{
				DebugLocation(81, 7);
				QUOTED_TYPE15=(IToken)Match(input,QUOTED_TYPE,Follow._QUOTED_TYPE_in_attrType491); 
				DebugLocation(81, 19);
				 r = (QUOTED_TYPE15!=null?QUOTED_TYPE15.Text:default(string)).Substring(1, (QUOTED_TYPE15!=null?QUOTED_TYPE15.Text:default(string)).Length - 2); 

				}
				break;

			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("attrType", 12);
			LeaveRule("attrType", 12);
			LeaveRule_attrType();
		}
		DebugLocation(81, 88);
		} finally { DebugExitRule(GrammarFileName, "attrType"); }
		return r;

	}
	// $ANTLR end "attrType"
	#endregion Rules


	#region Follow sets
	private static class Follow
	{
		public static readonly BitSet _namespaceDecl_in_program57 = new BitSet(new ulong[]{0x1000UL});
		public static readonly BitSet _node_in_program67 = new BitSet(new ulong[]{0x0UL});
		public static readonly BitSet _EOF_in_program86 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _NAMESPACE_in_namespaceDecl107 = new BitSet(new ulong[]{0x1000UL});
		public static readonly BitSet _ID_in_namespaceDecl111 = new BitSet(new ulong[]{0x100400UL});
		public static readonly BitSet _DOT_in_namespaceDecl116 = new BitSet(new ulong[]{0x1000UL});
		public static readonly BitSet _ID_in_namespaceDecl120 = new BitSet(new ulong[]{0x100400UL});
		public static readonly BitSet _SEMI_in_namespaceDecl126 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _nodeVariants_in_node142 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _nodeConcrete_in_node148 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _ID_in_nodeVariants170 = new BitSet(new ulong[]{0x800UL});
		public static readonly BitSet _EQ_in_nodeVariants172 = new BitSet(new ulong[]{0x1000UL});
		public static readonly BitSet _nodeVariant_in_nodeVariants182 = new BitSet(new ulong[]{0x120200UL});
		public static readonly BitSet _PIPE_in_nodeVariants187 = new BitSet(new ulong[]{0x1000UL});
		public static readonly BitSet _nodeVariant_in_nodeVariants191 = new BitSet(new ulong[]{0x120200UL});
		public static readonly BitSet _common_attributes_in_nodeVariants201 = new BitSet(new ulong[]{0x100000UL});
		public static readonly BitSet _SEMI_in_nodeVariants214 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _ID_in_nodeVariant230 = new BitSet(new ulong[]{0x10000UL});
		public static readonly BitSet _OPEN_in_nodeVariant232 = new BitSet(new ulong[]{0x1040UL});
		public static readonly BitSet _fields_in_nodeVariant234 = new BitSet(new ulong[]{0x40UL});
		public static readonly BitSet _CLOSE_in_nodeVariant237 = new BitSet(new ulong[]{0x22UL});
		public static readonly BitSet _attributes_in_nodeVariant239 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _ID_in_nodeConcrete261 = new BitSet(new ulong[]{0x800UL});
		public static readonly BitSet _EQ_in_nodeConcrete263 = new BitSet(new ulong[]{0x101020UL});
		public static readonly BitSet _fields_in_nodeConcrete265 = new BitSet(new ulong[]{0x100020UL});
		public static readonly BitSet _attributes_in_nodeConcrete268 = new BitSet(new ulong[]{0x100000UL});
		public static readonly BitSet _SEMI_in_nodeConcrete276 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _field_in_fields303 = new BitSet(new ulong[]{0x82UL});
		public static readonly BitSet _COMMA_in_fields308 = new BitSet(new ulong[]{0x1000UL});
		public static readonly BitSet _field_in_fields312 = new BitSet(new ulong[]{0x82UL});
		public static readonly BitSet _ATTRIBUTES_in_attributes337 = new BitSet(new ulong[]{0x81000UL});
		public static readonly BitSet _attributeDecl_in_attributes341 = new BitSet(new ulong[]{0x82UL});
		public static readonly BitSet _COMMA_in_attributes346 = new BitSet(new ulong[]{0x81000UL});
		public static readonly BitSet _attributeDecl_in_attributes350 = new BitSet(new ulong[]{0x82UL});
		public static readonly BitSet _COMMON_ATTRIBUTES_in_common_attributes375 = new BitSet(new ulong[]{0x81000UL});
		public static readonly BitSet _attributeDecl_in_common_attributes379 = new BitSet(new ulong[]{0x82UL});
		public static readonly BitSet _COMMA_in_common_attributes384 = new BitSet(new ulong[]{0x81000UL});
		public static readonly BitSet _attributeDecl_in_common_attributes388 = new BitSet(new ulong[]{0x82UL});
		public static readonly BitSet _ID_in_field414 = new BitSet(new ulong[]{0x41012UL});
		public static readonly BitSet _QUESTION_in_field419 = new BitSet(new ulong[]{0x1002UL});
		public static readonly BitSet _ASTERISK_in_field423 = new BitSet(new ulong[]{0x1002UL});
		public static readonly BitSet _ID_in_field429 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _attrType_in_attributeDecl448 = new BitSet(new ulong[]{0x1000UL});
		public static readonly BitSet _ID_in_attributeDecl450 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _ID_in_attrType470 = new BitSet(new ulong[]{0x402UL});
		public static readonly BitSet _DOT_in_attrType475 = new BitSet(new ulong[]{0x1000UL});
		public static readonly BitSet _ID_in_attrType479 = new BitSet(new ulong[]{0x402UL});
		public static readonly BitSet _QUOTED_TYPE_in_attrType491 = new BitSet(new ulong[]{0x2UL});
	}
	#endregion Follow sets
}

} // namespace  adt 