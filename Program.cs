using System;
using System.Collections.Generic;
using System.Text;

namespace Game24
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            
            string start = "";
            // do 
            // {
                Console.Title = "ASCII Art";
                string title = @"
    ██████╗ ██╗  ██╗     ██████╗ █████╗ ██████╗ ██████╗      ██████╗  █████╗ ███╗   ███╗███████╗
    ╚════██╗██║  ██║    ██╔════╝██╔══██╗██╔══██╗██╔══██╗    ██╔════╝ ██╔══██╗████╗ ████║██╔════╝
    █████╔╝███████║    ██║     ███████║██████╔╝██║  ██║    ██║  ███╗███████║██╔████╔██║█████╗  
    ██╔═══╝ ╚════██║    ██║     ██╔══██║██╔══██╗██║  ██║    ██║   ██║██╔══██║██║╚██╔╝██║██╔══╝  
    ███████╗     ██║    ╚██████╗██║  ██║██║  ██║██████╔╝    ╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗
    ╚══════╝     ╚═╝     ╚═════╝╚═╝  ╚═╝╚═╝  ╚═╝╚═════╝      ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝
                                                                                                ";           
                Console.WriteLine(title);
                System.Console.WriteLine("Let's play a 24 Card Game!");
                System.Console.WriteLine("Enter y to Start.");
                // start = Console.ReadLine().ToLower();
            // } while (start != "y");
            
            // if(start.ToLower().Equals("y"))
            // {
                Deck d = new Deck();
                Player me = new Player("Me");
                System.Console.WriteLine("Hi, " + me.Name);
                // availability for user to type 'draw' to get card
                // maybe another do while
                // availability to save results into txt file
                Card firstCard = me.Draw(d);
                Card secondCard = me.Draw(d);
                Card thirdCard = me.Draw(d);
                Card fourthCard = me.Draw(d);
                System.Console.WriteLine("Your cards:");
                me.DisplayHand();

                System.Console.WriteLine("\nTry making 24 with these numbers and operations:");

                string input = Console.ReadLine();
                System.Console.WriteLine("YAYYYYY " + Evaluate(input));
                if(Evaluate(input) == 24)
                {
                    System.Console.WriteLine("YAYYYYY");
                }                
                else
                {
                    System.Console.WriteLine("nope");
                }
                string AceOfSpades = "\U0001F0A1";
                Console.Write(AceOfSpades);
            // }        
        }

        public static List<string> GetTokens(string expression)
        {
            string operators = "*/+-";
            List<string> tokens = new List<string>();
            StringBuilder sb = new StringBuilder();

            foreach (char c in expression.Replace(" ", string.Empty)) 
            {
                // blank space
                if (operators.IndexOf(c) >= 0) 
                {
                    if ((sb.Length > 0)) 
                    {
                        tokens.Add(sb.ToString());
                        sb.Length = 0;
                    }
                    tokens.Add(c.ToString());
                } 
                else 
                {
                    sb.Append(c);
                }
            }

            if ((sb.Length > 0)) 
            {
                tokens.Add(sb.ToString());
            }
            return tokens;
        }


        public static double Evaluate(string expression)
        {
            List<string> tokens = GetTokens(expression);
            Stack<double> operandStack = new Stack<double>();
            Stack<string> operatorStack = new Stack<string>();
            int tokenIndex = 0;
            while (tokenIndex < tokens.Count)
            {
                string token = tokens[tokenIndex];
                if (token.Equals("+") || token.Equals("-") ||
                    token.Equals("*") || token.Equals("/"))
                {
                    while(operatorStack.Count != 0 && (operatorStack.Peek().Equals("+") ||
                                    operatorStack.Peek().Equals("-") ||
                                    operatorStack.Peek().Equals('*') ||
                            operatorStack.Peek().Equals('/')))
                    {
                        processAnOperator(operandStack, operatorStack);
                    }
                    // push the + or - operator into the operator stack
                    operatorStack.Push(token[0].ToString());
                }
                else if(token.Equals("*") || token.Equals("/"))
                {
                    // Process all *, / in the top of the operator stack
                    while (operatorStack != null &&
                            (operatorStack.Peek().Equals('*') ||
                            operatorStack.Peek().Equals('/')))
                    {
                        processAnOperator(operandStack, operatorStack);
                    }
                    // push the * or / operator into the operator stack
                    operatorStack.Push(token.ToString());
                    
                }
                else 
                {   //An operand scanned
                    //Push an operand to the stack
                    operandStack.Push(Convert.ToDouble(token));
                }   // back to the while loop to extract the next token
                tokenIndex += 1;
            }

            // phase 2: process all the remaining operators in the stack
            while (operatorStack.Count != 0) 
            {
                processAnOperator(operandStack, operatorStack);
            } 

            // return the result
            return operandStack.Pop();
        }

        public static void processAnOperator(Stack<double> operandStack, 
            Stack<string> operatorStack)
        {
            string op = operatorStack.Pop();
            double op1 = operandStack.Pop();
            double op2 = operandStack.Pop();
            if (op == "+")
                operandStack.Push(op2 + op1);
            else if (op == "-")
                operandStack.Push(op2 - op1);
            else if (op == "*")            
                operandStack.Push((op2) * (op1));            
            else if (op == "/")
                operandStack.Push(op2 / op1);    
        }

    }
}
