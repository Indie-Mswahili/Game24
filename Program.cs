using System;
using System.Collections.Generic;
using System.Text;

namespace Game24
{
    class Program
    {
        public static string again = "";
        static void Main(string[] args)
        {
            // Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            
            string start = "";
            do 
            {
                System.Console.WriteLine("Enter your name");
                string myName = Console.ReadLine();
                System.Console.WriteLine("Hello, 🐧	\t😀\t🦁\t🥑\t😰\t" + myName + "\t🚴\t🚀\t🙌\t😏\t🐲");
                
                Console.Title = "ASCII Art";
                string title = @"
    ██████╗ ██╗  ██╗     ██████╗ █████╗ ██████╗ ██████╗      ██████╗  █████╗ ███╗   ███╗███████╗
    ╚════██╗██║  ██║    ██╔════╝██╔══██╗██╔══██╗██╔══██╗    ██╔════╝ ██╔══██╗████╗ ████║██╔════╝
     █████╔╝███████║   ██║      ███████║██████╔╝██║  ██║    ██║  ███╗███████║██╔████╔██║█████╗  
    ██╔═══╝ ╚════██║    ██║     ██╔══██║██╔══██╗██║  ██║    ██║   ██║██╔══██║██║╚██╔╝██║██╔══╝  
    ███████╗     ██║    ╚██████╗██║  ██║██║  ██║██████╔╝    ╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗
    ╚══════╝     ╚═╝     ╚═════╝╚═╝  ╚═╝╚═╝  ╚═╝╚═════╝      ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝
                                                                                                ";           
                Console.WriteLine(title);
                System.Console.WriteLine("Description?(y/n)");
                string desc = Console.ReadLine().ToLower();
                if(desc.Equals("y"))
                {
                    Description();
                }
                System.Console.WriteLine("Let's play a 24 Card Game!");
                System.Console.WriteLine("Enter y to Start.");
                start = Console.ReadLine().ToLower();
                
            } while (start != "y");
            
            if(start.ToLower().Equals("y"))
            {
                GetCard();
                do
                {
                    GetCard();
                    Play();
                } while(again.Equals("y"));              
                            
            }        
        }

        public static List<string> GetTokens(string expression)
        {
            string operators = "*/+-()";
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


        public static void GetCard()
        {
            Deck d = new Deck();
            Player me = new Player("Me");            
            // availability for user to type 'draw' to get card
            // maybe another do while
            // availability to save results into txt file
            Card firstCard = me.Draw(d);
            Card secondCard = me.Draw(d);
            Card thirdCard = me.Draw(d);
            Card fourthCard = me.Draw(d);
            System.Console.WriteLine("Your cards:");
            me.DisplayHand();
        }
        public static void Play()
        {
            System.Console.WriteLine("\nEnter your expressions:");
            string input = "";
            double exp = 0.0;
            do
            {
                input = Console.ReadLine();
                exp = Evaluate(input);
                if(exp == 24)
                {
                    string title = @"

 ██████╗  ██████╗  ██████╗ ██████╗          ██╗ ██████╗ ██████╗ 
██╔════╝ ██╔═══██╗██╔═══██╗██╔══██╗         ██║██╔═══██╗██╔══██╗
██║  ███╗██║   ██║██║   ██║██║  ██║         ██║██║   ██║██████╔╝
██║   ██║██║   ██║██║   ██║██║  ██║    ██   ██║██║   ██║██╔══██╗
╚██████╔╝╚██████╔╝╚██████╔╝██████╔╝    ╚█████╔╝╚██████╔╝██████╔╝
 ╚═════╝  ╚═════╝  ╚═════╝ ╚═════╝      ╚════╝  ╚═════╝ ╚═════╝ 
                                                                
";           
                Console.WriteLine(title);
                    System.Console.WriteLine("Play Again? (y/n)");
                    again = Console.ReadLine().ToLower();                      
                }               
                else
                {
                    string wrong = @"
██╗    ██╗██████╗  ██████╗ ███╗   ██╗ ██████╗ 
██║    ██║██╔══██╗██╔═══██╗████╗  ██║██╔════╝ 
██║ █╗ ██║██████╔╝██║   ██║██╔██╗ ██║██║  ███╗
██║███╗██║██╔══██╗██║   ██║██║╚██╗██║██║   ██║
╚███╔███╔╝██║  ██║╚██████╔╝██║ ╚████║╚██████╔╝
 ╚══╝╚══╝ ╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═══╝ ╚═════╝ ";           
                Console.WriteLine(wrong);
                    System.Console.WriteLine("Try again!"); 
                } 
            } while (exp != 24);
            string thanks = @"
  _____ _                 _                           __                    _             _             _ 
 |_   _| |__   __ _ _ __ | | __  _   _  ___  _   _   / _| ___  _ __   _ __ | | __ _ _   _(_)_ __   __ _| |
   | | | '_ \ / _` | '_ \| |/ / | | | |/ _ \| | | | | |_ / _ \| '__| | '_ \| |/ _` | | | | | '_ \ / _` | |
   | | | | | | (_| | | | |   <  | |_| | (_) | |_| | |  _| (_) | |    | |_) | | (_| | |_| | | | | | (_| |_|
   |_| |_| |_|\__,_|_| |_|_|\_\  \__, |\___/ \__,_| |_|  \___/|_|    | .__/|_|\__,_|\__, |_|_| |_|\__, (_)
                                 |___/                               |_|            |___/         |___/   ";           
                Console.WriteLine(thanks);  
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
                if (token.Equals("("))
                {
                    operatorStack.Push(token); // Push '(' to stack
                }
                else if (token.Equals(")"))
                {
                    //Process all the operators in the stack until seeing '('
                    while (operatorStack.Peek() != "(")
                    {
                        processAnOperator(operandStack, operatorStack);
                    }                    
                    operatorStack.Pop(); // Pop the '(' symbol from the stack
                }
                else if (token.Equals("+") || token.Equals("-"))
                {
                    while(operatorStack.Count != 0 && (operatorStack.Peek().Equals("+") ||
                                    operatorStack.Peek().Equals("-")))
                    {
                        processAnOperator(operandStack, operatorStack);
                    }
                    // push the + or - operator into the operator stack
                    operatorStack.Push(token.ToString());
                }
                else if(token.Equals("*") || token.Equals("/"))
                {
                    // Process all *, / in the top of the operator stack
                    while (operatorStack.Count != 0 &&
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

        public static void Description()
        {
            System.Console.WriteLine("🃏🂠🂡🂢🂣🂤🂫🂬🂭🂴🂿🂾🂽🃉🃖🃣🃢🃡🃨🃧🃮🃓🂫🂪🂮🂢🂣🂵🂶🂷🂸🂺🂻🂼🂽🂾🂿🃁🃃🃊🃍🃎🃌🃘🃙🃖🃛🃜🂢🂣🃝🃟🃝🃑🃉🃖🃣🃏\nMake 24 with all 4 numbers on the card.\nYou can add, subtract, multiply or divide. You have to use\nall four numbers. Each number may be used only once.\nFor example: if the numbers are 2, 2, 6, 8:\nYou could make 24 by explaining (8-2) x (6-2) = 24.\n(There might be more than one solution!!!)");
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
