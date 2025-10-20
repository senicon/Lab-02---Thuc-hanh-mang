using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Code_NT106.Q13._1_Lab02_24520592
{
    public partial class Bai03 : Form
    {
        public Bai03()
        {
            InitializeComponent();
        }

        private bool IsValidExpression(string s)
        {
            return Regex.IsMatch(s ?? "", @"^[0-9\.,\+\-\*\/\(\)\s]+$");
        }

        private bool TryCalculate(string expr, out string? result)
        {
            result = null;
            if (string.IsNullOrWhiteSpace(expr))
            {
                result = "Biểu thức rỗng";
                return false;
            }

            expr = expr.Replace(',', '.');

            if (!IsValidExpression(expr))
            {
                result = "Chứa ký tự không hợp lệ";
                return false;
            }

            try
            {
                expr = NormalizeUnaryMinus(expr);
                var rpn = ToRPN(expr);
                double value = EvalRPN(rpn);
                result = value.ToString(CultureInfo.InvariantCulture);
                return true;
            }
            catch (DivideByZeroException)
            {
                result = "Lỗi: chia cho 0";
                return false;
            }
            catch
            {
                result = "Cú pháp không hợp lệ";
                return false;
            }
        }

        private string NormalizeUnaryMinus(string s)
        {
            var sb = new System.Text.StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c == '-')
                {
                    if (i == 0)
                    {
                        sb.Append("0-");
                        continue;
                    }
                    int j = i - 1;
                    while (j >= 0 && char.IsWhiteSpace(s[j])) j--;
                    if (j < 0 || s[j] == '(' || s[j] == '+' || s[j] == '-' || s[j] == '*' || s[j] == '/')
                    {
                        sb.Append("0-");
                        continue;
                    }
                }
                sb.Append(c);
            }
            return sb.ToString();
        }

        private int Precedence(string op)
        {
            if (op == "+" || op == "-") return 1;
            if (op == "*" || op == "/") return 2;
            return 0;
        }

        private bool IsOperator(string token) => token == "+" || token == "-" || token == "*" || token == "/";

        private List<string> ToRPN(string expr)
        {
            var output = new List<string>();
            var ops = new Stack<string>();

            for (int i = 0; i < expr.Length;)
            {
                char c = expr[i];
                if (char.IsWhiteSpace(c)) { i++; continue; }

                if (char.IsDigit(c) || c == '.')
                {
                    int j = i;
                    while (j < expr.Length && (char.IsDigit(expr[j]) || expr[j] == '.')) j++;
                    string number = expr.Substring(i, j - i);
                    output.Add(number);
                    i = j;
                    continue;
                }

                if (c == '(')
                {
                    ops.Push("(");
                    i++;
                    continue;
                }

                if (c == ')')
                {
                    while (ops.Count > 0 && ops.Peek() != "(")
                    {
                        output.Add(ops.Pop());
                    }
                    if (ops.Count == 0) throw new Exception("Mismatched parentheses");
                    ops.Pop();
                    i++;
                    continue;
                }

                if (c == '+' || c == '-' || c == '*' || c == '/')
                {
                    string op = c.ToString();
                    while (ops.Count > 0 && IsOperator(ops.Peek()) && Precedence(ops.Peek()) >= Precedence(op))
                    {
                        output.Add(ops.Pop());
                    }
                    ops.Push(op);
                    i++;
                    continue;
                }

                throw new Exception("Ký tự không hợp lệ");
            }

            while (ops.Count > 0)
            {
                var t = ops.Pop();
                if (t == "(" || t == ")") throw new Exception("Mismatched parentheses");
                output.Add(t);
            }

            return output;
        }

        private double EvalRPN(List<string> rpn)
        {
            var st = new Stack<double>();
            foreach (var token in rpn)
            {
                if (IsOperator(token))
                {
                    if (st.Count < 2) throw new Exception("Cú pháp không hợp lệ");
                    double b = st.Pop();
                    double a = st.Pop();
                    double res;
                    switch (token)
                    {
                        case "+": res = a + b; break;
                        case "-": res = a - b; break;
                        case "*": res = a * b; break;
                        case "/":
                            if (Math.Abs(b) < 1e-12) throw new DivideByZeroException();
                            res = a / b; break;
                        default: throw new Exception("Operator unknown");
                    }
                    st.Push(res);
                }
                else
                {
                    if (!double.TryParse(token, NumberStyles.Float, CultureInfo.InvariantCulture, out double v))
                        throw new Exception("Số không hợp lệ");
                    st.Push(v);
                }
            }
            if (st.Count != 1) throw new Exception("Cú pháp không hợp lệ");
            return st.Pop();
        }
    }
}