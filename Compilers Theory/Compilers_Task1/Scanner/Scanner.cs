using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scanner
{
    public class Scanner
    {
        DFATokenizer tokenizer;

        public List<Token> TokensList { get; private set; }
        public HashSet<SymbolData> SymbolTable { get; private set; }
        public List<TokenError> ErrorsList { get; private set; }
        public List<string> CommentsList { get; private set; }

        public Scanner(string inputText)
        {
            tokenizer = new DFATokenizer(inputText);
            tokenizer.Build();

            TokensList = new List<Token>();
            SymbolTable = new HashSet<SymbolData>();
            ErrorsList = new List<TokenError>();
            CommentsList = new List<string>();
        }

        public List<Token> Scan()
        {         
            var tokensSequence = new List<TokenType>();

            var curToken = tokenizer.GetNextToken();

            while (curToken.TokenType != TokenType.EndOfFile)
            {
                if (curToken.TokenType == TokenType.Error)
                {
                    ErrorsList.Add((TokenError)curToken);
                    break;
                }

                if (curToken.TokenType != TokenType.WhiteSpace && curToken.TokenType != TokenType.Comment)
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

        public Token GetNextToken()
        {
            Token nextToken = tokenizer.GetNextToken();

            while (nextToken.TokenType == TokenType.WhiteSpace || nextToken.TokenType == TokenType.Comment)
            {
                nextToken = tokenizer.GetNextToken();
            }

            return nextToken;
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
