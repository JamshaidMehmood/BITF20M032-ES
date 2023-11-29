using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{
    internal class Interpreter
    {

        // Abstract Expression
        public interface IDateExpression
        {
            DateTime Interpret();
        }

        // Terminal Expression 1: Year
        public class YearExpression : IDateExpression
        {
            private readonly int _year;

            public YearExpression(int year)
            {
                _year = year;
            }

            public DateTime Interpret()
            {
                return new DateTime(_year, 1, 1);
            }
        }

        // Terminal Expression 2: Month
        public class MonthExpression : IDateExpression
        {
            private readonly IDateExpression _year;
            private readonly int _month;

            public MonthExpression(IDateExpression year, int month)
            {
                _year = year;
                _month = month;
            }

            public DateTime Interpret()
            {
                DateTime yearDate = _year.Interpret();
                return new DateTime(yearDate.Year, _month, 1);
            }
        }

        // Terminal Expression 3: Day
        public class DayExpression : IDateExpression
        {
            private readonly IDateExpression _month;
            private readonly int _day;

            public DayExpression(IDateExpression month, int day)
            {
                _month = month;
                _day = day;
            }

            public DateTime Interpret()
            {
                DateTime monthDate = _month.Interpret();
                return new DateTime(monthDate.Year, monthDate.Month, _day);
            }
        }

        //----------------------------------------------------------------------

        // Abstract Expression
        public interface IExpression
        {
            int Interpret();
        }

        // Terminal Expression 1: Number
        public class Number : IExpression
        {
            private readonly int _value;

            public Number(int value)
            {
                _value = value;
            }

            public int Interpret()
            {
                return _value;
            }
        }

        // Non-terminal Expression 2: Addition
        public class Addition : IExpression
        {
            private readonly IExpression _left;
            private readonly IExpression _right;

            public Addition(IExpression left, IExpression right)
            {
                _left = left;
                _right = right;
            }

            public int Interpret()
            {
                return _left.Interpret() + _right.Interpret();
            }
        }

        // Non-terminal Expression 3: Subtraction
        public class Subtraction : IExpression
        {
            private readonly IExpression _left;
            private readonly IExpression _right;

            public Subtraction(IExpression left, IExpression right)
            {
                _left = left;
                _right = right;
            }

            public int Interpret()
            {
                return _left.Interpret() - _right.Interpret();
            }
        }
    }
}
