using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Cartwheel.Language.Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Node_Add_Success()
        {
            Syntax syntax = new Syntax();
            syntax.Add(syntax);
            Assert.AreEqual(syntax.Children.Count, 1);

        }

        [TestMethod]
        public void Node_Add_Failure()
        {
            var _exception = string.Empty;
            try
            {
                Syntax syntax = new Syntax();
                syntax.Add(syntax);
                syntax.Add(syntax); // Item failes since we can't have an item with the same key added to the dictionary
            }catch(Exception ex)
            {
                _exception = ex.Message;
            }
             Assert.AreEqual(_exception.StartsWith("An item with the same key has already been added"), true);

        }


        [TestMethod]
        public void Node_Visit_Success()
        {
            // This test both the action and function in one test
            // the action is recursive while the func<t> is not. 

            #region Scaffolding
            // create  linked nodes
            Syntax syntax = new Syntax();
            syntax.Add(new Syntax()); // add one
            syntax.Add(new Syntax()); // add the same node again

            #endregion

            List<string> return_items = new List<string>();

            //// Create an action & Func<T>
            Func<Syntax, string> selector = delegate (Syntax node) { var x = node.Id.ToString(); return x; };
            Action<Syntax> actor = delegate (Syntax node) { var x = node.Id.ToString(); var y = node.Visit(selector); return_items.Add(y); };


            syntax.Visit(actor);

            Assert.AreEqual(return_items.Count, 2); // does not include node we start from

        }


    }
}
