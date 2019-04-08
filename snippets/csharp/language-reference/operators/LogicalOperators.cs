using System;

namespace operators
{
    public static class LogicalOperators
    {
        public static void Examples()
        {
            Console.WriteLine("==== ! operator");
            Negation();

            Console.WriteLine("==== &, |, ^ operators");
            And();
            Or();
            Xor();

            Console.WriteLine("==== && and || operators");
            ConditionalAnd();
            ConditionalOr();

            Console.WriteLine("==== Compound assignment and precedence");
            CompoundAssignment();
            Precedence();
        }

        private static void Negation()
        {
            // <SnippetNegation>
            bool passed = false;
            Console.WriteLine(!passed);  // output: True
            Console.WriteLine(!true);    // output: False
            // </SnippetNegation>
        }

        private static void And()
        {
            // <SnippetAnd>
            bool SecondOperand() 
            {
                Console.WriteLine("Second operand is evaluated.");
                return true;
            }
            
            bool test = false & SecondOperand();
            Console.WriteLine(test);
            // Output:
            // Second operand is evaluated.
            // False
            // </SnippetAnd>
        }

        private static void Or()
        {
            // <SnippetOr>
            bool SecondOperand() 
            {
                Console.WriteLine("Second operand is evaluated.");
                return false;
            }
            
            bool test = true | SecondOperand();
            Console.WriteLine(test);
            // Output:
            // Second operand is evaluated.
            // True
            // </SnippetOr>
        }

        private static void Xor()
        {
            // <SnippetXor>
            Console.WriteLine(true ^ true);    // output: False
            Console.WriteLine(true ^ false);   // output: True
            Console.WriteLine(false ^ true);   // output: True
            Console.WriteLine(false ^ false);  // output: False
            // </SnippetXor>
        }

        private static void ConditionalAnd()
        {
            // <SnippetConditionalAnd>
            bool SecondOperand()
            {
                Console.WriteLine("Second operand is evaluated.");
                return true;
            }

            bool a = false && SecondOperand();
            Console.WriteLine(a);
            // Output:
            // False

            bool b = true && SecondOperand();
            Console.WriteLine(b);
            // Output:
            // Second operand is evaluated.
            // True
            // </SnippetConditionalAnd>
        }

        private static void ConditionalOr()
        {
            // <SnippetConditionalOr>
            bool SecondOperand()
            {
                Console.WriteLine("Second operand is evaluated.");
                return true;
            }

            bool a = true || SecondOperand();
            Console.WriteLine(a);
            // Output:
            // True

            bool b = false || SecondOperand();
            Console.WriteLine(b);
            // Output:
            // Second operand is evaluated.
            // True
            // </SnippetConditionalOr>
        }

        private static void CompoundAssignment()
        {
            // <SnippetCompoundAssignment>
            bool test = true;
            test &= false;
            Console.WriteLine(test);  // output: False

            test |= true;
            Console.WriteLine(test);  // output: True

            test ^= false;
            Console.WriteLine(test);  // output: True
            // </SnippetCompoundAssignment>
        }

        private static void Precedence()
        {
            // <SnippetPrecedence>
            Console.WriteLine(true | true & false);   // output: True
            Console.WriteLine((true | true) & false); // output: False
            
            bool Operand(string name, bool value)
            {
                Console.WriteLine($"Operand {name} is evaluated.");
                return value;
            }

            var byDefaultPrecedence = Operand("A", true) || Operand("B", true) && Operand("C", false);
            Console.WriteLine(byDefaultPrecedence);
            // Output:
            // Operand A is evaluated.
            // True

            var changedOrder = (Operand("A", true) || Operand("B", true)) && Operand("C", false);
            Console.WriteLine(changedOrder);
            // Output:
            // Operand A is evaluated.
            // Operand C is evaluated.
            // False
            // </SnippetPrecedence>
        }
    }
}