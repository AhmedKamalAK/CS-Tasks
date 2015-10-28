using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scanner
{
    class DFATokenizer
    {
        string inputText;
        int curCharIndex = 0;
        int curLineNumber = 1;
        State startState;
        Dictionary<State, Dictionary<char, State>> stateTransitionTable = new Dictionary<State, Dictionary<char, State>>();
        Dictionary<string, TokenType> symbolToTokenDictionary = new Dictionary<string, TokenType>();
        Dictionary<string, TokenType> reservedWordsTokens = new Dictionary<string, TokenType>();

        public DFATokenizer(string inputText)
        {
            this.inputText = inputText;
            FillSymbolToTokenDictionary();
            FillReservedWordsTokensDictionary();
        }

        private void FillSymbolToTokenDictionary()
        {
            symbolToTokenDictionary.Add("+", TokenType.Plus);
            symbolToTokenDictionary.Add("-", TokenType.Minus);
            symbolToTokenDictionary.Add("*", TokenType.Multiply);
            symbolToTokenDictionary.Add("/", TokenType.Division);
            symbolToTokenDictionary.Add("identifier", TokenType.Identifier);
            symbolToTokenDictionary.Add("number", TokenType.Number);
            symbolToTokenDictionary.Add("}", TokenType.Comment);
            symbolToTokenDictionary.Add("=", TokenType.Equal);
            symbolToTokenDictionary.Add("<", TokenType.LessThan);
            symbolToTokenDictionary.Add("<=", TokenType.LessThanOrEqual);
            symbolToTokenDictionary.Add(">", TokenType.Greater);
            symbolToTokenDictionary.Add(">=", TokenType.GreaterThanOrEqual);
            symbolToTokenDictionary.Add("(", TokenType.LeftParenthesis);
            symbolToTokenDictionary.Add(")", TokenType.RightParenthesis);
            symbolToTokenDictionary.Add(";", TokenType.Semicolon);
            symbolToTokenDictionary.Add(":=", TokenType.Assignment);
        }

        private void FillReservedWordsTokensDictionary()
        {
            reservedWordsTokens.Add("if", TokenType.If);
            reservedWordsTokens.Add("then", TokenType.Then);
            reservedWordsTokens.Add("else", TokenType.Else);
            reservedWordsTokens.Add("end", TokenType.End);
            reservedWordsTokens.Add("repeat", TokenType.Repeat);
            reservedWordsTokens.Add("until", TokenType.Until);
            reservedWordsTokens.Add("read", TokenType.Read);
            reservedWordsTokens.Add("write", TokenType.Write);
        }
        private void ChangeTokenTypeIfReserved(Token token)
        {
            if (reservedWordsTokens.ContainsKey(token.Lexeme))
                token.TokenType = reservedWordsTokens[token.Lexeme];
        }
        private State CreateState(int id, bool isFinal)
        {
            return new State()
            {
                ID = id,
                IsFinal = isFinal,
            };
        }

        public void Build()
        {
            DFAReader dfaReader = new DFAReader();
            List<State> dfaStates = dfaReader.ReadStates();
            List<StateTransition> dfaTransitions = dfaReader.ReadTransitions();

            startState = dfaStates[0];

            foreach (var transition in dfaTransitions)
            {
                State state1 = dfaStates[transition.State1ID];
                State state2 = dfaStates[transition.State2ID];

                foreach (var ch in transition.TransitionChars)
                {
                    if (!stateTransitionTable.ContainsKey(state1))
                        stateTransitionTable.Add(state1, new Dictionary<char, State>());

                    stateTransitionTable[state1].Add(ch, state2);
                }
            }
        }

        public Token GetNextToken()
        {
            if (curCharIndex >= inputText.Length)
            {
                return new Token()
                {
                    TokenType = TokenType.EndOfFile
                };
            }

            char curChar = inputText[curCharIndex];
            if (char.IsWhiteSpace(curChar))
            {
                if (curChar == '\n') curLineNumber++;

                curCharIndex++;
                return new Token()
                {
                    Lexeme = curChar.ToString(),
                    TokenType = TokenType.WhiteSpace
                };
            }

            State curState = startState;
            State lastFinal = null;
            StringBuilder lexeme = new StringBuilder();

            while (curCharIndex < inputText.Length)
            {
                curChar = inputText[curCharIndex];

                //if (char.IsWhiteSpace(curChar))
                //{
                
                //    if (curState == startState)
                //    {
                //        curCharIndex++;
                //        return new Token()
                //        {
                //            Lexeme = curChar.ToString(),
                //            TokenType = TokenType.WhiteSpace
                //        };
                //    }
                //    else break;
                //}

                if (!stateTransitionTable.ContainsKey(curState) || !stateTransitionTable[curState].ContainsKey(curChar))
                    break;

                if (curChar == '\n') curLineNumber++;

                curState = stateTransitionTable[curState][curChar];

                if (curState.IsFinal)
                    lastFinal = curState;

                lexeme.Append(curChar);
                curCharIndex++;
            }

            if (lastFinal == null || lastFinal.MatchedSymbol == "number" && char.IsLetter(curChar))
            {
                return new TokenError()
                {
                    Lexeme = curChar.ToString(),
                    TokenType = TokenType.Error,
                    ErrorLineNumber = curLineNumber
                };
            }

            Token token = new Token()
            {
                Lexeme = lexeme.ToString(),
                TokenType = symbolToTokenDictionary[lastFinal.MatchedSymbol]
            };

            ChangeTokenTypeIfReserved(token);

            return token;
        }

    }
}
