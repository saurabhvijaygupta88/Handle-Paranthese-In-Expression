using System;
using System.Collections.Generic;

namespace HandleParantheseInExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            string condExp = "1 AND 2 AND 3 OR 4 AND 5 OR 6";
            //"(((((1 AND 2) AND 3) OR 4) AND 5) OR 6)"
            Console.WriteLine("Input String:-      \"" + condExp + "\"");

            string formatedCondExp = FormatConditionExpression(condExp);

            #region Old code with operand grouping
            //string condExp = "1 AND 2 AND 3 OR 4 AND 5 OR 6";
            ////"(((1 AND 2 AND 3) OR (4 AND 5)) OR (6))"
            //Console.WriteLine("Input String:-      \"" + condExp + "\"");

            //Stack<string> groups = new Stack<string>();
            //condExp = condExp.Replace("AND", "A").Replace("OR", "O").Replace(" ", ""); // "1A2O3A4" 
            //string formatedCondExp = string.Empty;
            //for (int i = 0; i < condExp.Length; i++)
            //{
            //    if (i == 0 && condExp[i] != '(')
            //    {
            //        formatedCondExp = string.Concat(formatedCondExp, "(");
            //    }
            //    if (IsNumber(condExp[i]))
            //    {
            //        formatedCondExp = string.Concat(formatedCondExp, condExp[i]);
            //    }
            //    if (IsExpression(condExp[i]) && IsExpression(formatedCondExp[formatedCondExp.Length - 2]) && formatedCondExp[formatedCondExp.Length - 2] != condExp[i])
            //    {
            //        formatedCondExp = string.Concat(formatedCondExp, ")");
            //        groups.Push(formatedCondExp.Substring(formatedCondExp.LastIndexOf('(')));
            //        if (groups.Count == 3)
            //        {
            //            string rhsOperand = groups.Pop();
            //            string operatorValue = groups.Pop();
            //            string lhsOperand = groups.Pop();
            //            groups.Push(string.Format("({0})", string.Concat(lhsOperand, operatorValue, rhsOperand)));
            //        }

            //        formatedCondExp = string.Concat(formatedCondExp, condExp[i]);                    
            //        groups.Push(condExp[i].ToString());                    
            //        formatedCondExp = string.Concat(formatedCondExp, "(");
            //        i++;
            //        formatedCondExp = string.Concat(formatedCondExp, condExp[i]);
            //    }
            //    if (IsExpression(condExp[i]))
            //    {
            //        formatedCondExp = string.Concat(formatedCondExp, condExp[i]);
            //    }
            //    if (i == condExp.Length - 1)
            //    {
            //        formatedCondExp = string.Concat(formatedCondExp, ")");
            //        groups.Push(formatedCondExp.Substring(formatedCondExp.LastIndexOf('(')));
            //        if (groups.Count == 3)
            //        {
            //            string rhsOperand = groups.Pop();
            //            string operatorValue = groups.Pop();
            //            string lhsOperand = groups.Pop();

            //            if(!rhsOperand.Contains('A') || !rhsOperand.Contains('O'))
            //            {
            //                rhsOperand = rhsOperand.Replace("(", "").Replace(")", "");
            //            }

            //            groups.Push(string.Format("({0})", string.Concat(lhsOperand, operatorValue, rhsOperand)));
            //        }
            //        //validExp = (((formatedCondExp.LastIndexOf(')') - 1) - formatedCondExp.LastIndexOf('(')) == 3);
            //    }
            //}

            //formatedCondExp = groups.Pop();

            //formatedCondExp = formatedCondExp.Replace("A", " AND ").Replace("O", " OR "); 
            #endregion

            Console.WriteLine("Formated String:-   \"" + formatedCondExp + "\"");

            Console.ReadLine();
        }

        private static string FormatConditionExpression(string condExp)
        {
            Stack<string> groups = new Stack<string>();
            condExp = condExp.Replace("AND", "A").Replace("OR", "O").Replace(" ", "");
            for (int i = 0; i < condExp.Length; i++)
            {
                groups.Push(condExp[i].ToString());
                if (groups.Count == 3)
                {
                    string rhsOperand = groups.Pop();
                    string operatorValue = groups.Pop();
                    string lhsOperand = groups.Pop();
                    groups.Push(string.Format("({0})", string.Concat(lhsOperand, operatorValue, rhsOperand)));
                }
            }
            return groups.Pop().Replace("A", " AND ").Replace("O", " OR ");
        }

        private static bool IsExpression(char exp)
        {
            return (exp == 'A' || exp == 'O');
        }

        private static bool IsNumber(char exp)
        {
            return (exp != 'A' && exp != 'O' && exp != '(' && exp != ')');
        }
    }
}
