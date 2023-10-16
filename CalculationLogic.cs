using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

// main driven for it 
/*
 * 
 * static void Main(string[] args)
        {
            try
            {
                string equation1 = "122 + 323";
                string equation2 = "1+234";

                string result1 = stringSolver(equation1);
                string result2 = stringSolver(equation2);

                Console.WriteLine($"Input: equation = \"{equation1}\"\nOutput: \"{result1}\"");
                Console.WriteLine($"Input: equation = \"{equation2}\"\nOutput: \"{result2}\"");

                Console.WriteLine("---------------------------------------------------------");
                string eq2 = "1-234";
                string eq3 = "323 - 121";

                string res2 = stringSolver(eq2);
                string res3 = stringSolver(eq3);


                Console.WriteLine($"Input: \"{eq2}\"");
                Console.WriteLine($"Output: \"{res2}\"");

                Console.WriteLine($"Input: \"{eq3}\"");
                Console.WriteLine($"Output: \"{res3}\"");
                Console.WriteLine("---------------------------------------------------------");
                string equation4 = "22 x 45";
                string equation5 = "3/9";
                string result4 = stringSolver(equation4);
                string result5 = stringSolver(equation5);
                Console.WriteLine($"Input: \"{equation4}\"");
                Console.WriteLine($"Output: \"{result4}\"");

                Console.WriteLine($"Input: \"{equation5}\"");
                Console.WriteLine($"Output: \"{result5}\"");

                Console.WriteLine("---------------------------------------------------------");
                string equ6 = "22 / 2 x 34 - 4";
                string equ7 = "3x4/9+4";

                string res6 = DMASRule(equ6);
                string res7 = DMASRule(equ7);

                Console.WriteLine($"Input: \"{equ6}\"");
                Console.WriteLine($"Output: \"{res6}\"");

                Console.WriteLine($"Input: \"{equ7}\"");
                Console.WriteLine($"Output: \"{res7}\"");
                
                Console.WriteLine("---------------------------------------------------------");
                string equ8 = "(1 + 1) - 3 x (44 x 5) / 20";
                string res8 = solveEquationWithBraces(equ8);
                Console.WriteLine($"Input: \"{equ8}\"");
                Console.WriteLine($"Output: \"{res8}\"");

                Console.WriteLine("---------------------------------------------------------");
                string a = "1 + 2 + 4 + 6 + 8";
               
                string c = "(((1 + 1) x 3) + 4 x 5";
                string d = "1 + 2 + 3 - - 4";
                string e = "1 + 2 + 3 -6";

                string r1 = solveEquationWithBraces(a);
                string r3 = solveEquationWithBraces(c);
                string r4 = solveEquationWithBraces(d);
                string r5 = solveEquationWithBraces(e);

                Console.WriteLine($"Input: equation = \"{a}\"\nOutput: \"{r1}\"");
                Console.WriteLine($"Input: equation = \"{c}\"\nOutput: \"{r3}\"");
                Console.WriteLine($"Input: equation = \"{d}\"\nOutput: \"{r4}\"");
                Console.WriteLine($"Input: equation = \"{e}\"\nOutput: \"{r5}\"");

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }
 * 
 */



namespace the_Calculator
{
    internal class CalculationLogic
    {

        // string solving fpt multiple operators
        public static string stringSolver(string equation)
        {
            // this code is for checking the validity of equation 

            // Remove spaces for consistent formatting
            equation = equation.Replace(" ", "");

            // Check if the equation is not empty
            if (string.IsNullOrWhiteSpace(equation))
            {
                throw new ArgumentException("Invalid equation. Equation is empty.");
            }

            // Check for invalid characters
            if (!Regex.IsMatch(equation, @"^(\d+(\.\d+)?[+\-*/x]\d+(\.\d+)?)+$"))
            {
                throw new ArgumentException("Invalid equation.");
            }

            // Check if there are no consecutive operators
            if (Regex.IsMatch(equation, @"[+\-*/x]{2,}"))
            {
                throw new ArgumentException("Invalid equation. Consecutive operators are not allowed.");
            }
            //-------------------------------------------------------------------------

            // Check if the equation contains a '+' or '-' operator
            if (equation.Contains('+'))
            {
                // Split the equation into operands for addition
                string[] operands = equation.Split('+');
                if (operands.Length != 2)
                {
                    throw new ArgumentException("Invalid equation format. The equation must contain exactly one '+' operator.");
                }

                if (!int.TryParse(operands[0].Trim(), out int operand1) || !int.TryParse(operands[1].Trim(), out int operand2))
                {
                    throw new ArgumentException("Invalid operands. Please provide valid integers.");
                }

                int result = operand1 + operand2;
                return result.ToString();
            }
            else if (equation.Contains('-'))
            {
                // Split the equation into operands for subtraction
                string[] operands = equation.Split('-');
                if (operands.Length != 2)
                {
                    throw new ArgumentException("Invalid equation format. The equation must contain exactly one '-' operator.");
                }

                if (!int.TryParse(operands[0].Trim(), out int operand1) || !int.TryParse(operands[1].Trim(), out int operand2))
                {
                    throw new ArgumentException("Invalid operands. Please provide valid integers.");
                }

                int result = operand1 - operand2;
                return result.ToString();
            }
            else if (equation.Contains("x") || equation.Contains("*"))
            {
                // Split the equation into operands for multiplication
                string[] operands = equation.Split(new[] { "x", "*" }, StringSplitOptions.None);
                if (operands.Length != 2)
                {
                    throw new ArgumentException("Invalid equation format. The equation must contain exactly one 'x' or '*' operator for multiplication.");
                }

                if (!int.TryParse(operands[0], out int operand1) || !int.TryParse(operands[1], out int operand2))
                {
                    throw new ArgumentException("Invalid operands. Please provide valid integers.");
                }

                int result = operand1 * operand2;
                return result.ToString();
            }
            else if (equation.Contains('/'))
            {
                // Split the equation into operands for division
                string[] operands = equation.Split('/');
                if (operands.Length != 2)
                {
                    throw new ArgumentException("Invalid equation format. The equation must contain exactly one '/' operator for division.");
                }

                if (!int.TryParse(operands[0], out int dividend) || !int.TryParse(operands[1], out int divisor))
                {
                    throw new ArgumentException("Invalid operands. Please provide valid integers.");
                }

                if (divisor == 0)
                {
                    throw new ArgumentException("MATH ERROR");
                }

                double result = (double)dividend / divisor;
                return result.ToString("0.######");
            }
            else
            {
                throw new ArgumentException("Invalid operator. The equation must contain '+', '-', 'x', or '/' for addition, subtraction, multiplication, or division.");
            }
        }

        // equation with brackets
        public static string solveEquationWithBraces(string equation)
        {
            try
            {
                // Remove spaces for consistent formatting
                equation = equation.Replace(" ", "");

                // Check if the equation is not empty
                if (string.IsNullOrWhiteSpace(equation))
                {

                    throw new ArgumentException("Invalid equation. Equation is empty.");
                }


                // Check for invalid characters
                if (Regex.IsMatch(equation, @"^(\d+(\.\d+)?[+\-*/x]\d+(\.\d+)?)+$"))
                {
                    throw new ArgumentException("Invalid equation.");
                }

                // Check if there are no consecutive operators except for 'x' and '/'
                if (Regex.IsMatch(equation, @"[+\-*/]{2,}(?![x/])"))
                {
                    //Console.WriteLine("3");
                    throw new ArgumentException("Invalid equation. Consecutive operators are not allowed.");
                }

                while (equation.Contains("("))
                {
                    int openingBracketIndex = equation.LastIndexOf('(');
                    int closingBracketIndex = equation.IndexOf(')', openingBracketIndex);

                    if (openingBracketIndex == -1 || closingBracketIndex == -1)
                    {
                        //Console.WriteLine("4");
                        throw new ArgumentException("Invalid equation format. Mismatched parentheses.");
                    }

                    string subEquation = equation.Substring(openingBracketIndex + 1, closingBracketIndex - openingBracketIndex - 1);
                    string subResult = DMASRule(subEquation);
                    equation = equation.Substring(0, openingBracketIndex) + subResult + equation.Substring(closingBracketIndex + 1);
                }


                // Check for invalid characters after resolving brackets
                if (Regex.IsMatch(equation, @"^(\d+(\.\d+)?[+\-*/x()]\d+(\.\d+)?)+$"))
                {
                    //Console.WriteLine("5");
                    throw new ArgumentException("Invalid equation.");
                }

                return DMASRule(equation);
            }
            catch (ArgumentException ex)
            {
                return $"{ex.Message}";
            }
        }

        // method for DMAS rule implementation
        public static string DMASRule(string equation)
        {
            equation = equation.Replace(" ", ""); // Remove spaces for consistent formatting

            // Lists to store operators and operands
            var operatorList = new List<string>();
            var operandList = new List<string>();

            // Variables to build operands
            string currentOperand = "";

            foreach (char c in equation)
            {
                if (c == '+' || c == '-' || c == 'x' || c == '*' || c == '/')
                {
                    // If a character is an operator, add the currentOperand to the operandList and then add the operator to the operatorList
                    operandList.Add(currentOperand);
                    currentOperand = "";
                    operatorList.Add(c.ToString());
                }
                else
                {
                    // If a character is a digit, add it to the currentOperand
                    currentOperand += c;
                }
            }

            // Add the last operand (after the last operator) to the operandList
            operandList.Add(currentOperand);

            // Check for valid equation format
            if (operatorList.Count + 1 != operandList.Count)
            {
                throw new ArgumentException("Invalid equation format.");
            }

            // Apply DMAS rule
            while (operatorList.Contains("/") || operatorList.Contains("x") || operatorList.Contains("*"))
            {
                int index = -1;
                if (operatorList.Contains("/"))
                    index = operatorList.IndexOf("/");
                else if (operatorList.Contains("x") || operatorList.Contains("*"))
                    index = operatorList.IndexOf("x") >= 0 ? operatorList.IndexOf("x") : operatorList.IndexOf("*");

                if (index != -1)
                {
                    double operand1 = double.Parse(operandList[index]);
                    double operand2 = double.Parse(operandList[index + 1]);

                    double result = 0;

                    if (operatorList[index] == "/")
                        result = operand1 / operand2;
                    else if (operatorList[index] == "x" || operatorList[index] == "*")
                        result = operand1 * operand2;

                    operandList[index] = result.ToString("0.######"); // Maximum precision of 6 decimal places
                    operandList.RemoveAt(index + 1);
                    operatorList.RemoveAt(index);
                }
            }

            while (operatorList.Count > 0)
            {
                double operand1 = double.Parse(operandList[0]);
                double operand2 = double.Parse(operandList[1]);
                double result = 0;

                if (operatorList[0] == "+")
                    result = operand1 + operand2;
                else if (operatorList[0] == "-")
                    result = operand1 - operand2;

                operandList[0] = result.ToString();
                operandList.RemoveAt(1);
                operatorList.RemoveAt(0);
            }

            return operandList[0];
        }
    }
}
