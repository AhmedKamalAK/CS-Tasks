using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scanner
{
    public class Scanner
    {
        string inputText;

        public List<Token> TokensList { get; private set; }
        public HashSet<SymbolData> SymbolTable { get; private set; }
        public List<TokenError> ErrorsList { get; private set; }
        public List<string> CommentsList { get; private set; }

        public Scanner(string inputText)
        {
            this.inputText = inputText;
            TokensList = new List<Token>();
            SymbolTable = new HashSet<SymbolData>();
            ErrorsList = new List<TokenError>();
            CommentsList = new List<string>();
        }

        public List<Token> Scan()
        {
            DFATokenizer tokenizer = new DFATokenizer(inputText);
            tokenizer.Build();

            var tokensSequence = new List<TokenType>();

            var curToken = tokenizer.GetNextToken();

            while (curToken.TokenType != TokenType.EndOfFile)
            {
                if (curToken.TokenType == TokenType.Error)
                {
                    ErrorsList.Add((TokenError)curToken);
                    break;
                }

                if (curToken.TokenType != TokenType.WhiteSpace)
                {
                    TokensList.Add(curToken);
                    tokensSequence.Add(curToken.TokenType);
                }
                curToken = tokenizer.GetNextToken();
            }

            FillSymbolTable();
            FillComentsList();

            return TokensList;
        }

        private void FillSymbolTable()
        {
            foreach (var token in TokensList)
            {
                if (token.TokenType == TokenType.Identifier)
                { 
                    SymbolTable.Add(new SymbolData()
                    {
                        Symbol = token.Lexeme
                    });
                }
            }
        }

        private void FillComentsList()
        {
            foreach (var token in TokensList)
            {
                if (token.TokenType == TokenType.Comment)
                {
                    CommentsList.Add(token.Lexeme);
                }
            }
        }
    }
}
