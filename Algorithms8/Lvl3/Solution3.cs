using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lvl3
{
    class Solution3
    {
        enum State { S0, S1, S2, S3, S4, S5, S6, ERROR }
        enum InputType { PLUS, PERCENT, DIGIT, OTHER }

        static InputType GetInputType(char c)
        {
            if (c == '+') return InputType.PLUS;
            if (c == '%') return InputType.PERCENT;
            if (char.IsDigit(c)) return InputType.DIGIT;
            return InputType.OTHER;
        }

        static void Main()
        {
            var transitionTable = new Dictionary<State, Dictionary<InputType, State>>();

            foreach (State state in Enum.GetValues(typeof(State)))
            {
                transitionTable[state] = new Dictionary<InputType, State>();
            }

            transitionTable[State.S0][InputType.PLUS] = State.S1;
            transitionTable[State.S1][InputType.DIGIT] = State.S2;
            transitionTable[State.S2][InputType.DIGIT] = State.S2;
            transitionTable[State.S2][InputType.PLUS] = State.S3;
            transitionTable[State.S3][InputType.PERCENT] = State.S4;
            transitionTable[State.S4][InputType.PLUS] = State.S5;
            transitionTable[State.S5][InputType.DIGIT] = State.S6;
            transitionTable[State.S6][InputType.DIGIT] = State.S6;

            StringBuilder text = new StringBuilder();

            try
            {
                using (StreamReader sr = new StreamReader("D:\\Temp\\lvl3.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        text.AppendLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in reading file: " + e.Message);
                return;
            }

            char[] separators = { ' ', '$', '#', '\n', '\r' };
            string[] words = text.ToString().Split(separators, StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine("Result in lvl3.txt:");

            foreach (string word in words)
            {
                State currentState = State.S0;

                for (int i = 0; i < word.Length; i++)
                {
                    InputType inputType = GetInputType(word[i]);

                    if (transitionTable[currentState].TryGetValue(inputType, out State nextState))
                    {
                        currentState = nextState;
                    }
                    else
                    {
                        currentState = State.ERROR;
                    }

                    if (currentState == State.ERROR)
                    {
                        break;
                    }
                }

                bool isValid = (currentState == State.S6);

                Console.WriteLine($"Word: '{word,-15}' | Status: {(isValid ? "VALID" : "INVALID")}");
            }
        }
    }
}
