using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlabamaTax
{
    class ValidationError
    {
        public String Category;
        public String Message;
        public String RuleNumber;
        public String Severity;
        public ValidationError(String category, String message, String ruleno, String severity)
        {
            Category = category;
            Message = message;
            RuleNumber = ruleno;
            Severity = severity;
        }
        public override string ToString()
        {
            return String.Format("{0}: {1} ({2}:{3})", RuleNumber, Message, Category, Severity);
        }
    }
}
