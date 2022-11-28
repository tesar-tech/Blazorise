﻿using System.Text;

namespace Blazorise.Docs.Compiler;

public class CodeBuilder
{
    private readonly StringBuilder code;
    private int indentLevel;

    public CodeBuilder()
    {
        code = new StringBuilder();
        indentLevel = 0;
    }

    public string Code { get => code.ToString(); }

    public int IndentLevel { get => indentLevel; set => indentLevel = value; }

    public void Add( string codeString )
    {
        Add( codeString, indentLevel );
    }

    public void Add( string codeString, int indentLevel )
    {
        code.Append( codeString.PadLeft( codeString.Length + ( indentLevel * 4 ), ' ' ) );
    }

    public void AddLine()
    {
        code.Append( '\n' );
    }

    public void AddLine( string codeLine )
    {
        Add( codeLine );
        AddLine();
    }

    public void AddHeader()
    {
        AddLine( "//-----------------------------------------------------------------------" );
        AddLine( "// This file is autogenerated by Blazorise.Docs.Compiler" );
        AddLine( "// Any changes to this file will be overwritten on build" );
        AddLine( "// <auto-generated />" );
        AddLine( "//-----------------------------------------------------------------------" );
        AddLine();
    }

    public override string ToString()
    {
        return code.ToString();
    }
}