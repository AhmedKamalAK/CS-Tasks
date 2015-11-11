using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scanner;

namespace Parser
{
    public class Parser
    {
        Scanner.Scanner scanner;
        Token curToken;
        List<Token> tokensList;
        public Parser(List<Token> tokensList)
        {
            this.tokensList = tokensList;
        }
        public Parser(string inputText)
        {
            scanner = new Scanner.Scanner(inputText);
        }

        private SyntaxTreeNode StatementSequence()
        {
            SyntaxTreeSequenceNode node = new SyntaxTreeSequenceNode();

            node.Sequence.Add(Statement());

            while (curToken.TokenType == TokenType.Semicolon)
            {
                Match(TokenType.Semicolon);
                node.Sequence.Add(Statement());
            }

            return node;
        }

        private SyntaxTreeNode Statement()
        {
            SyntaxTreeNode node = null;

            if (curToken.TokenType == TokenType.If)
            {
                node = IfStatement();
            }
            else if (curToken.TokenType == TokenType.Repeat)
            {
                node = RepeatStatement();
            }
            else if (curToken.TokenType == TokenType.Assignment)
            {
                node = AssignStatement();
            }
            else if (curToken.TokenType == TokenType.Read)
            {
                node = ReadStatement();
            }
            else if (curToken.TokenType == TokenType.Write)
            {
                node = WriteStatement();
            }

            return node;
        }

        private SyntaxTreeNode IfStatement()
        {
            SyntaxTreeBinaryNode ifNode = new SyntaxTreeBinaryNode() { Token = curToken };
            Match(TokenType.If);

            ifNode.Left = Expression();
            Match(TokenType.Then);

            SyntaxTreeNode thenPart = StatementSequence();
            SyntaxTreeBinaryNode ifParts = new SyntaxTreeBinaryNode() { Left = thenPart };
            
            if (curToken.TokenType == TokenType.Else)
            {
                Match(TokenType.Else);
                ifParts.Right = StatementSequence();
            }

            ifNode.Right = ifParts;
            Match(TokenType.End);

            return ifNode;
        }

        private SyntaxTreeNode RepeatStatement()
        {
            SyntaxTreeBinaryNode node = new SyntaxTreeBinaryNode() { Token = curToken };
            Match(TokenType.Repeat);

            SyntaxTreeNode statements = StatementSequence();
            Match(TokenType.Until);

            SyntaxTreeNode condition = Expression();

            node.Left = condition;
            node.Right = statements;

            return node;
        }

        private SyntaxTreeNode ReadStatement()
        {
            SyntaxTreeBinaryNode node = new SyntaxTreeBinaryNode() { Token = curToken };
            Match(TokenType.Read);

            if (curToken.TokenType == TokenType.Identifier)
            {
                node.Left = new SyntaxTreeBinaryNode() { Token = curToken };
                Match(TokenType.Identifier);
            }

            return node;
        }
        private SyntaxTreeNode WriteStatement()
        {
            SyntaxTreeBinaryNode node = new SyntaxTreeBinaryNode() { Token = curToken };
            Match(TokenType.Write);

            node.Left = Expression();

            return node;
        }

        private SyntaxTreeNode AssignStatement()
        {
            SyntaxTreeBinaryNode node = new SyntaxTreeBinaryNode();
            if (curToken.TokenType == TokenType.Identifier)
            {
                node.Left = new SyntaxTreeBinaryNode() { Token = curToken };
                Match(TokenType.Identifier);
            }

            if (curToken.TokenType == TokenType.Assignment)
            {
                node.Token = curToken;
                Match(TokenType.Assignment);
            }

            node.Right = Expression();

            return node;
        }

        private SyntaxTreeNode Expression()
        {
            SyntaxTreeNode node = SimpleExpression();
            if (IsComparison(curToken.TokenType))
            {
                SyntaxTreeBinaryNode temp = new SyntaxTreeBinaryNode() { Token = curToken };
                temp.Left = node;
                temp.Right = SimpleExpression();
                node = temp;
            }

            return node;
        }
        private SyntaxTreeNode SimpleExpression()
        {
            SyntaxTreeNode node = Term();

            while (curToken.TokenType == TokenType.Plus || curToken.TokenType == TokenType.Minus)
            {
                SyntaxTreeBinaryNode temp = new SyntaxTreeBinaryNode() { Token = curToken };
                temp.Left = node;
                Match(curToken.TokenType);
                temp.Right = Term();
                node = temp;
            }
            return node;
        }

        private SyntaxTreeNode AddOp()
        {
            SyntaxTreeBinaryNode node = new SyntaxTreeBinaryNode() { Token = curToken };
            if (curToken.TokenType == TokenType.Plus)
                Match(TokenType.Plus);
            else if (curToken.TokenType == TokenType.Minus)
                Match(TokenType.Minus);
            return node;
        }

        private SyntaxTreeNode Term()
        {
            SyntaxTreeNode node = Factor();

            while (curToken.TokenType == TokenType.Multiply || curToken.TokenType == TokenType.Division)
            {
                SyntaxTreeBinaryNode temp = new SyntaxTreeBinaryNode() { Token = curToken };
                temp.Left = node;
                Match(curToken.TokenType);
                temp.Right = Factor();
                node = temp;
            }
            return node;
        }
        private SyntaxTreeNode Factor()
        {
            SyntaxTreeBinaryNode node = null;
            if (curToken.TokenType == TokenType.LeftParenthesis)
            {
                Match(TokenType.LeftParenthesis);
                node = Expression();
                Match(TokenType.RightParenthesis);
            }
            else if (curToken.TokenType == TokenType.Number)
            {
                node = new SyntaxTreeBinaryNode() { Token = curToken };
                Match(TokenType.Number);
            }
            else
            {
                node = new SyntaxTreeBinaryNode() { Token = curToken };
                Match(TokenType.Identifier);
            }
            return node;
        }
        private SyntaxTreeNode MulOp()
        {
            SyntaxTreeBinaryNode node = new SyntaxTreeBinaryNode() { Token = curToken };
            if (curToken.TokenType == TokenType.Multiply)
                Match(TokenType.Multiply);
            else if (curToken.TokenType == TokenType.Division)
                Match(TokenType.Division);
            return node;
        }
        private SyntaxTreeNode ComparisonOp()
        {
            SyntaxTreeBinaryNode node = new SyntaxTreeBinaryNode() { Token = curToken };
            if (curToken.TokenType == TokenType.Greater)
                Match(TokenType.Greater);
            else if (curToken.TokenType == TokenType.LessThan)
                Match(TokenType.LessThan);
            else if (curToken.TokenType == TokenType.LessThanOrEqual)
                Match(TokenType.LessThanOrEqual);
            else if (curToken.TokenType == TokenType.GreaterThanOrEqual)
                Match(TokenType.GreaterThanOrEqual);
            else if (curToken.TokenType == TokenType.Equal)
                Match(TokenType.Equal);
            return node;
        }

        private bool Match(TokenType expectedToken)
        {
            if (curToken.TokenType == expectedToken)
            {
                curToken = scanner.GetNextToken();
                return true;
            }

            return false;
        }
        private bool IsComparison(TokenType token)
        {
            return curToken.TokenType == TokenType.Greater || curToken.TokenType == TokenType.LessThan
                || curToken.TokenType == TokenType.LessThanOrEqual || curToken.TokenType == TokenType.GreaterThanOrEqual
                || curToken.TokenType == TokenType.Equal;
        }
    }
}
