using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Scanner
{
    class DFAReader
    {
        string letters;
        string digits;
        string alphabet;

        string statesFilePath;
        string transitionsFilePath;

        public DFAReader()
        {
            letters = "_";

            for (char ch = 'a'; ch <= 'z'; ch++)
            {
                letters += ch;
            }
            for (char ch = 'A'; ch <= 'Z'; ch++)
            {
                letters += ch;
            }

            for (char dig = '0'; dig <= '9'; dig++)
            {
                digits += dig;
            }

            for (int i = char.MinValue + 1; i <= char.MaxValue; i++)
            {
                if ((char)i == '}') continue;
                alphabet += (char)i;
            }

            string statesFileName = "TinyLanguageDFAStates.txt";
            string transitionsFileName = "TinyLanguageDFATransitions.txt";
            string directory = Directory.GetCurrentDirectory();

            statesFilePath = Path.Combine(directory, statesFileName);
            transitionsFilePath = Path.Combine(directory, transitionsFileName);
        }

        public List<State> ReadStates()
        {
            string[] statesFile = File.ReadAllLines(statesFilePath);

            List<State> states = new List<State>();

            foreach (var line in statesFile)
            {
                string[] data = line.Split(' ');
                State state = new State()
                {
                    ID = int.Parse(data[0]),
                    IsFinal = (data[1] == "t" ? true : false)
                };

                if (state.IsFinal == true) state.MatchedSymbol = data[2];

                states.Add(state);
            }

            return states;
        }

        public List<StateTransition> ReadTransitions()
        {
            string[] transitionsFile = File.ReadAllLines(transitionsFilePath);

            List<StateTransition> transitions = new List<StateTransition>();

            foreach (var line in transitionsFile)
            {
                string[] data = line.Split();
                if (data[2] == "letter")
                {
                    data[2] = letters;
                }
                else if (data[2] == "digit")
                {
                    data[2] = digits;
                }
                else if (data[2] == "alphabet")
                {
                    data[2] = alphabet;
                }

                StateTransition transition = new StateTransition()
                {
                    State1ID = int.Parse(data[0]),
                    State2ID = int.Parse(data[1]),
                    TransitionChars = data[2]
                };

                transitions.Add(transition);
            }

            return transitions;
        }
    }
}
