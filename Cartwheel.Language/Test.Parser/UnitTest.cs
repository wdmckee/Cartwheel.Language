using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace Cartwheel.Language.Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Atom_Parse_Success()
        {
            //TestSuccess(expression, target function, return type)
            TestSuccess(":", "Parse_Colon", "Colon");
            TestSuccess("a", "Parse_Letter", "Letter");
            TestSuccess("-", "Parse_Dash", "Dash");
            TestSuccess("?", "Parse_Optional", "Optional");
            TestSuccess("|", "Parse_Pipe", "Pipe");
            TestSuccess(" ", "Parse_Whitespace", "Whitespace");
            TestSuccess("'", "Parse_Single_Quote", "Single_Quote");
        }

        [TestMethod]
        public void Atom_Parse_Failure()
        {
            TestFailure("-", "Parse_Letter");
            TestFailure("a1", "Parse_Letter");
            TestFailure("1", "Parse_Letter");
            TestFailure("*", "Parse_Pipe");
        }





        [TestMethod]
        public void Sequence_Parse_Success()
        {

            TestSuccess("a-b", "Parse_Valid_Letter_Sequence_1", "Valid_Letter_Sequence");
            TestSuccess("a-bc", "Parse_Valid_Letter_Sequence", "Valid_Letter_Sequence");
            TestSuccess("ab", "Parse_Valid_Letter_Sequence", "Valid_Letter_Sequence");
            TestSuccess("abcde-fghi", "Parse_Valid_Letter_Sequence", "Valid_Letter_Sequence");
            TestSuccess("my-rule-two", "Parse_Valid_Letter_Sequence", "Valid_Letter_Sequence");
            TestSuccess("my-r-two", "Parse_Valid_Letter_Sequence", "Valid_Letter_Sequence"); // letter-sequence-3 
            TestSuccess("     ", "Parse_Whitespace_Sequence", "Whitespace_Sequence");
            TestSuccess(" ", "Parse_Whitespace_Sequence", "Whitespace_Sequence");
            TestSuccess("my-rule", "Parse_Rule_Name_Sequence", "Rule_Name_Sequence");
            TestSuccess("'a' 'b'", "Parse_Rule_Name_Sequence", "Rule_Name_Sequence");
            TestSuccess("my-rule|my-rule", "Parse_Rule_Name_Sequence", "Rule_Name_Sequence");
            TestSuccess("my-rule|my-rule|my-rule", "Parse_Rule_Name_Sequence", "Rule_Name_Sequence");
            TestSuccess("my-rule | my-rule my-rule", "Parse_Rule_Name_Sequence", "Rule_Name_Sequence");
            TestSuccess("my-rule?|my-rule", "Parse_Rule_Name_Sequence", "Rule_Name_Sequence");
            TestSuccess("my-rule? my-rule", "Parse_Rule_Name_Sequence", "Rule_Name_Sequence");
            TestSuccess("my-rule?my-rule", "Parse_Rule_Name_Sequence", "Rule_Name_Sequence");
            TestSuccess("my-rule-two: my-rule-one ;my-rule-two: my-rule-one ;", "Parse_Production_Rule_Sequence", "Production_Rule_Sequence");
            TestSuccess("my-rule-two: my-rule-one my-rule-two;", "Parse_Production_Rule_Sequence", "Production_Rule_Sequence");

            // testing no line breaks
            TestSuccess("production-rule-sequence: production-rule-sequence? whitespace-sequence? production-rule | production-rule ;   production-rule: production-name whitespace-sequence? rule-name-sequence whitespace-sequence? semi-colon  whitespace-sequence?;   rule-name-sequence: rule-name-sequence? rule-name whitespace-sequence? pipe whitespace-sequence? rule-name| rule-name-sequence? whitespace-sequence? rule-name | rule-name-sequence whitespace-sequence? pipe whitespace-sequence? rule-name ; production-name: valid-letter-sequence colon; rule-name:valid-letter-sequence optional? | char-litteral; valid-letter-sequence:valid-letter-sequence? letter dash letter  | valid-letter-sequence? letter  | valid-letter-sequence dash letter ;  whitespace-sequence: whitespace-sequence? whitespace ;  atomic-symbol: backslash | colon | dash | double-quote | letter | optional | pipe |semi-colon | single-quote | whitespace ;  backslash:'a' 'b' ; letter: 'a' | 'b'; whitespace:' ' | '\\''r' | '\\''n' ; ", "Parse_Production_Rule_Sequence", "Production_Rule_Sequence");


            string _04 = System.IO.File.ReadAllText(@"..\\..\\..\\Scripts\\production-rule-sequence-04.txt");
            TestSuccess(_04, "Parse_Production_Rule_Sequence", "Production_Rule_Sequence");
             

        }

        [TestMethod]
        public void Sequence_Parse_Failure()
        {
            TestFailure("ab", "Parse_Valid_Letter_Sequence_1"); //_1 is not recursive, so it should fail
            TestFailure("ab-", "Parse_Valid_Letter_Sequence"); // should not be able to end in a dash
            //TestFailure("ab\"cde-fghi\\:::||", "Parse_String_Symbol_Sequence"); // the char " is not valid in this set
        }




        [TestMethod]
        public void Standard_Parse_Success()
        {
            TestSuccess("'a'", "Parse_Char_Litteral", "Char_Litteral");
            TestSuccess("'\\'", "Parse_Char_Litteral", "Char_Litteral");
            TestSuccess(":", "Parse_Atomic_Symbol", "Atomic_Symbol");
            TestSuccess("x", "Parse_Atomic_Symbol", "Atomic_Symbol");
            TestSuccess("'a'", "Parse_Rule_Name", "Rule_Name");
            TestSuccess("myrule", "Parse_Rule_Name", "Rule_Name");
            TestSuccess("my-rule", "Parse_Rule_Name", "Rule_Name");
            TestSuccess("myrule?", "Parse_Rule_Name", "Rule_Name");
            TestSuccess("my-rule?", "Parse_Rule_Name", "Rule_Name");
            TestSuccess("my-rule-two?", "Parse_Rule_Name", "Rule_Name");
            TestSuccess("my-rule-two:", "Parse_Production_Name", "Production_Name");
            TestSuccess("my-rule-two: my-rule-one ;", "Parse_Production_Rule", "Production_Rule");
            //TestSuccess("letter: 'a' | 'b';", "Parse_Production_Rule", "Production_Rule");
        }

        [TestMethod]
        public void Standard_Parse_Failure()
        {
            TestFailure("my-rule-", "Parse_Rule_Name");
            TestFailure("my-rule2:", "Parse_Rule_Name");
            TestFailure("my-rule-two:", "Parse_Rule_Name");
            TestFailure("my-rule-two?:", "Parse_Production_Name");
            TestFailure("my-rule-two: my-rule-one ", "Parse_Production_Rule");
        }



        [TestMethod]
        public void Syntax_Visit_Success()
        {
           
            // This could be moved to Test.Syntax unit tests but then I'd have to move "Eval" to its own file
            string _04 = System.IO.File.ReadAllText(@"..\\..\\..\\Scripts\\production-rule-sequence-04.txt");
            var tst = Eval(_04);

            List<string> return_items = new List<string>();

            Action<Syntax> track_specific = delegate (Syntax node) { node.ObjectName = node.ObjectName.ToUpper(); var x = node.ObjectName + "(" + node.Id + ")" + "(" + node.OrderedId + ")" + " " + node.ExpressionFragment; if (node.ObjectName == "PRODUCTION-NAME" || node.ObjectName == "RULE-NAME" || node.ObjectName == "PIPE" || node.ObjectName == "SEMI-COLON" || node.ObjectName == "OPTIONAL") { return_items.Add(x); } };
            tst.Syntax.Visit(track_specific);

            var result = String.Join(Environment.NewLine + ">>> ", return_items.ToArray());

            Assert.AreEqual(return_items.Count, 196); // does not include node we start from

        }

        [TestMethod]
        public void Syntax_Linq_Success()
        {
            string _04 = System.IO.File.ReadAllText(@"..\\..\\..\\Scripts\\production-rule-sequence-04.txt");
            var tst = Eval(_04);

            var items = tst.Syntax.Where(i => i.ObjectName == "production-rule");

            Assert.AreEqual(items.Count(), 19);

        }


        [TestMethod]
        public void GeneralDebug ()
        {
            string _04 = System.IO.File.ReadAllText(@"..\\..\\..\\Scripts\\production-rule-sequence-04.txt");
            var tst = Eval(_04);

               





        }











        #region TEST ENTRY METHODS
        internal void TestSuccess(string expression, string function, string ParseTreePath)
        {
            var testResult = Helper_CallMethod(expression, function);
            if (testResult != null)
            {
                var baseType = Helper_GetBaseType(testResult, ParseTreePath.Split(',')); // will throw an error if path is not correct
                Assert.AreEqual(expression, testResult.ExpressionFragment);
            }
            else
            { Assert.AreEqual(0, 1); }// if we hit this, we probably forgot to add the token to the scanner
        }

        internal void TestFailure(string expression, string function)
        {
            var testResult = Helper_CallMethod(expression, function);
            Assert.AreNotEqual(expression, testResult?.ExpressionFragment);
        }
        #endregion


        #region HELPER METHODS
        public ParseResult Eval(string expr)
        {
            // USED LIKE THE BELOW. HOWEVER, I'M NOT SURE WE WILL USE IT
            //var testResult = Eval(expression);  eval only calls a result, we want to avoid a result for now - just functions

            Scanner scanner = new Scanner();
            var scanresult = scanner.Scan(expr);

            Parser parser = new Parser(ref scanresult);
            var result = parser.Parse();
            return result;
        }

        public Type Helper_GetBaseType(dynamic result, string[] TypeTree)
        {
            Type type = null;
            int index = 0;
            while (index < TypeTree.Length)
            {
                // if we are not on an atom, we want to look in the properties to get the value result
                // but if we are on an atom we just use the result we already have
                if (result.GetType().Name == TypeTree[index])
                {
                    type = result.GetType();
                    index++;
                }
                else
                {
                    result = result.GetType().GetProperty(TypeTree[index]).GetValue(result, null);
                    type = result.GetType();
                    index++;
                }

            }

            return type;
        }

        public dynamic Helper_CallMethod(string expression, string function)
        {

            Scanner scanner = new Scanner();
            var scanresult = scanner.Scan(expression);

            if (!scanresult.ScanError.HasScanError)
            {

                Parser parser = new Parser(ref scanresult);

                Type type = parser.GetType();//typeof(Parser.Parser);
                MethodInfo method = type.GetMethod(function, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

                object[] parameters = Helper_CreateMissingTypeOfSize(method.GetParameters().Length);


                dynamic result = method.Invoke(parser, parameters);  //new object[] { Type.Missing}

                return result;
            }
            else
            {
                return null;
            }
        }

        public static object[] Helper_CreateMissingTypeOfSize(int size)
        {
            object[] array = new object[size];
            for (var i = 0; i < size; i++)
            {
                array[i] = Type.Missing;
            }
            return array;

        }



        // not sure what to do with this - but I like it
        public class Builder<T> where T : new()
        {
            public static IList<T> CreateListOfSize(int size)
            {
                List<T> list = new List<T>();
                for (int i = 0; i < size; i++)
                    list.Add(new T());
                return list;
            }
        }
        #endregion








    }
}
