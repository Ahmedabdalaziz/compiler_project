using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace compiler_proj
{
    public partial class IDE : Form
    {
        private static readonly HashSet<string> Keywords = new HashSet<string>
        {
            "اذا", "طالما", "متغير", "اطبع", "ادخل", "اخرج", "حرف", "رقم", "نص"
        };

        private static readonly Regex IdentifierRegex = new Regex(@"^[a-zA-Z_]\w*$");
        private static readonly Regex NumberRegex = new Regex(@"^\d+(\.\d+)?$");
        private static readonly Regex WhiteSpaceRegex = new Regex(@"^\s+$");
        private static readonly Regex OperatorRegex = new Regex(@"^[\+\-\*/%=<>!&|]+$");
        private static readonly Regex PunctuationRegex = new Regex(@"^[\(\)\{\}\[\],;.]$");
        private static readonly Regex SemiColumnRegex = new Regex(@"^[;\.]$");
        private static readonly Regex StringRegex = new Regex("^\".*\"$");
        private static readonly Regex CommentRegex = new Regex(@"^//.*?$|/\*[\s\S]*?\*/$");

        public IDE()
        {
            InitializeComponent();
        }

        private void input_code(object sender, EventArgs e)
        {
        }

        private void output_analyze(object sender, EventArgs e)
        {
        }

        private void analyze(object sender, EventArgs e)
        {
            string sourceCode = inputCode.Text;
            outputAnalyze.Clear();

            var tokenPattern =
                @"(\b(اذا|طالما|متغير|اطبع|ادخل|اخرج|حرف|رقم|نص)\b|\d+(\.\d+)?|""[^""]*""|//.*?$|/\*[\s\S]*?\*/|[\+\-\*/%=<>!&|]+|[\(\)\{\}\[\],;.]|[a-zA-Z_]\w*)";

            var matches = Regex.Matches(sourceCode, tokenPattern, RegexOptions.Multiline);

            foreach (Match match in matches)
            {
                string token = match.Value;

                if (Keywords.Contains(token))
                {
                    if (token == "اطبع")
                    {
                        outputAnalyze.AppendText($"Token: '{token}', Type: Print Function{Environment.NewLine}");
                    }
                    else if (token == "ادخل")
                    {
                        outputAnalyze.AppendText($"Token: '{token}', Type: Input Function{Environment.NewLine}");
                    }
                    else if (token == "اخرج")
                    {
                        outputAnalyze.AppendText($"Token: '{token}', Type: Output Function{Environment.NewLine}");
                    }
                    else if (token == "حرف")
                    {
                        outputAnalyze.AppendText($"Token: '{token}', Type: Character Type{Environment.NewLine}");
                    }
                    else if (token == "رقم")
                    {
                        outputAnalyze.AppendText($"Token: '{token}', Type: Number Type{Environment.NewLine}");
                    }
                    else if (token == "نص")
                    {
                        outputAnalyze.AppendText($"Token: '{token}', Type: String Type{Environment.NewLine}");
                    }
                    else
                    {
                        outputAnalyze.AppendText($"Token: '{token}', Type: Keyword{Environment.NewLine}");
                    }
                }
                else if (IdentifierRegex.IsMatch(token))
                {
                    outputAnalyze.AppendText($"Token: '{token}', Type: Identifier{Environment.NewLine}");
                }
                else if (NumberRegex.IsMatch(token))
                {
                    outputAnalyze.AppendText($"Token: '{token}', Type: Number{Environment.NewLine}");
                }
                else if (OperatorRegex.IsMatch(token))
                {
                    outputAnalyze.AppendText($"Token: '{token}', Type: Operator{Environment.NewLine}");
                }
                else if (PunctuationRegex.IsMatch(token))
                {
                    outputAnalyze.AppendText($"Token: '{token}', Type: Punctuation Mark{Environment.NewLine}");
                }
                else if (StringRegex.IsMatch(token))
                {
                    outputAnalyze.AppendText($"Token: '{token}', Type: String{Environment.NewLine}");
                }
                else if (SemiColumnRegex.IsMatch(token))
                {
                    outputAnalyze.AppendText($"Token: '{token}', Type: Semicolon{Environment.NewLine}");
                }
                else
                {
                    outputAnalyze.AppendText($"Token: '{token}', Type: Unknown{Environment.NewLine}");
                }
            }
        }

        private void clearButton_Click_1(object sender, EventArgs e)
        {
            inputCode.Clear();
            outputAnalyze.Clear();
        }

        private void parserButton_Click(object sender, EventArgs e)
        {
            outputAnalyze.Clear();

            string sourceCode = inputCode.Text;
            var tokens = Tokenize(sourceCode); 
            string error = Parse(tokens);

            if (string.IsNullOrEmpty(error))
            {
                outputAnalyze.AppendText("Parsing tree was successful! No errors." + Environment.NewLine);
            }
            else
            {
                outputAnalyze.AppendText("Parse error: " + error + Environment.NewLine);
            }
        }

        private List<string> Tokenize(string sourceCode)
        {
            var tokenPattern =
                @"(\b(اذا|طالما|متغير|اطبع|ادخل|اخرج|حرف|رقم|نص)\b|\d+(\.\d+)?|""[^""]*""|//.*?$|/\*[\s\S]*?\*/|[\+\-\*/%=<>!&|]+|[\(\)\{\}\[\],;.]|[a-zA-Z_]\w*)";
            var matches = Regex.Matches(sourceCode, tokenPattern, RegexOptions.Multiline);
            var tokens = new List<string>();

            foreach (Match match in matches)
            {
                tokens.Add(match.Value);
            }

            return tokens;
        }

        private string Parse(List<string> tokens)
        {
            int index = 0;

            string Expect(string expectedToken)
            {
                if (index < tokens.Count && tokens[index] == expectedToken)
                {
                    index++;
                    return null;
                }
                else
                {
                    return $"Expected '{expectedToken}' but found '{(index < tokens.Count ? tokens[index] : "end of file")}'";
                }
            }

            string ParseExpression()
            {
                var error = ParseTerm();
                if (!string.IsNullOrEmpty(error)) return error;

                while (index < tokens.Count && OperatorRegex.IsMatch(tokens[index]))
                {
                    index++; 
                    error = ParseTerm();
                    if (!string.IsNullOrEmpty(error)) return error;
                }

                return null;
            }

            string ParseTerm()
            {
                if (index < tokens.Count && (NumberRegex.IsMatch(tokens[index]) || StringRegex.IsMatch(tokens[index]) || IdentifierRegex.IsMatch(tokens[index])))
                {
                    index++;
                    return null;
                }
                else if (index < tokens.Count && tokens[index] == "(")
                {
                    index++;
                    var error = ParseExpression();
                    if (!string.IsNullOrEmpty(error)) return error;

                    error = Expect(")");
                    if (!string.IsNullOrEmpty(error)) return error;

                    return null;
                }
                return $"Expected a valid expression but found '{(index < tokens.Count ? tokens[index] : "end of file")}'";
            }

            string ParseStatement()
            {
                if (index < tokens.Count)
                {
                    if (tokens[index] == "اذا")
                        return ParseIf();
                    else if (tokens[index] == "طالما")
                        return ParseLoop();
                    else if (tokens[index] == "متغير")
                        return ParseVariableDeclaration();
                    else if (tokens[index] == "اطبع")
                        return ParsePrintStatement();
                    else
                        return $"Unsupported statement: '{tokens[index]}'";
                }

                return $"Unexpected end of file.";
            }

            string ParseIf()
            {
                var error = Expect("اذا");
                if (!string.IsNullOrEmpty(error)) return error;

                error = Expect("(");
                if (!string.IsNullOrEmpty(error)) return error;

                error = ParseExpression();
                if (!string.IsNullOrEmpty(error)) return error;

                error = Expect(")");
                if (!string.IsNullOrEmpty(error)) return error;

                return ParseBody();
            }

            string ParseLoop()
            {
                var error = Expect("طالما");
                if (!string.IsNullOrEmpty(error)) return error;

                error = Expect("(");
                if (!string.IsNullOrEmpty(error)) return error;

                error = ParseExpression(); 
                if (!string.IsNullOrEmpty(error)) return error;

                error = Expect(")");
                if (!string.IsNullOrEmpty(error)) return error;

                return ParseBody(); 
            }

            string ParseVariableDeclaration()
            {
                var error = Expect("متغير");
                if (!string.IsNullOrEmpty(error)) return error;

                error = ExpectIdentifier();
                if (!string.IsNullOrEmpty(error)) return error;

                error = Expect("=");
                if (!string.IsNullOrEmpty(error)) return error;

                error = ParseExpression();
                if (!string.IsNullOrEmpty(error)) return error;

                return Expect(";");
            }

            string ParsePrintStatement()
            {
                var error = Expect("اطبع");
                if (!string.IsNullOrEmpty(error)) return error;

                error = Expect("(");
                if (!string.IsNullOrEmpty(error)) return error;

                error = ParseExpression(); 
                if (!string.IsNullOrEmpty(error)) return error;

                error = Expect(")");
                if (!string.IsNullOrEmpty(error)) return error;

                error = Expect(";");
                if (!string.IsNullOrEmpty(error)) return error;

                return null;
            }

            string ExpectIdentifier()
            {
                if (index < tokens.Count && IdentifierRegex.IsMatch(tokens[index]))
                {
                    index++;
                    return null;
                }
                return $"Expected a valid identifier but found '{(index < tokens.Count ? tokens[index] : "end of file")}'";
            }

            string ParseBody()
            {
                if (index < tokens.Count && tokens[index] == "{")
                {
                    index++;
                    while (index < tokens.Count && tokens[index] != "}")
                    {
                        var error = ParseStatement();
                        if (!string.IsNullOrEmpty(error)) return error;
                    }

                    if (index < tokens.Count && tokens[index] == "}")
                    {
                        index++; 
                        return null;
                    }
                    else
                    {
                        return "Expected '}' but found end of file or invalid token.";
                    }
                }
                else
                {
                    return "Expected '{' but found '" + (index < tokens.Count ? tokens[index] : "end of file") + "'.";
                }
            }

            if (tokens.Count == 0)
            {
                return "No statements found.";
            }

            while (index < tokens.Count)
            {
                var error = ParseStatement();
                if (!string.IsNullOrEmpty(error)) return error;
            }

            return null;
        }

    }
}
