using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics; // remove in production for Debug.WriteLine
using System.IO;
using System.Linq;

namespace Cartwheel.Language
{
    public class Syntax : IEnumerable<Syntax>
    {

        #region Properties
        public string ExpressionFragment { get; set; }
        public string ObjectName { get; set; }
        public int BeginIndex { get; set; }
        public int EndIndex { get; set; }
        public bool IsValidated { get; set; }
        public Token Token { get; set; }
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
        public int OrderedId { get; set; }
        public Dictionary<Guid, Syntax> Children { get; private set; } = new Dictionary<Guid, Syntax>();
        public object Tag { get; set; }
        public string Information { get; set; }
        public string SequenceTag { get; set; }// only go through parent
        #endregion

        #region Core Methods
        public Syntax()
        {
            Id = Guid.NewGuid();            
        }

        public void Add(Syntax Result)
        {
            if (Result != null)
            {

                if (Result.GetType() == this.GetType())
                {
                    Result.OrderedId = -1; // if we are a Self_*, we want to evaluate first
                }
                else
                {
                    Result.OrderedId = Children.Count;
                }

                //Children.Add(Guid.NewGuid(), Result);
                //Result.ParentId = this.Id;
                Children.Add(Result.Id, Result);
            }
        }



        #region Action methods
        public void Visit(Action<Syntax> action)
        {
            foreach (var item in Children.OrderBy(i => i.Value.OrderedId))
            {
                action(item.Value);                
                Visit(action, item.Value);  // recursive call              
            }
        }
        private void Visit(Action<Syntax> action, Syntax value)
        {
            foreach (var item in value.Children.OrderBy(i => i.Value.OrderedId))
            {
                action(item.Value);
                Visit(action, item.Value);  // recursive call             
            }
        }

        // should be called from within an action visitor loop
        public T Visit<T>(Func<Syntax, T> fn)
        {
            return fn(this);
        }
        #endregion



        #endregion
        


        #region Enumerator Logic

        public IEnumerator<Syntax> GetEnumerator()
        {
            List<Syntax> return_items = new List<Syntax>();
            Action<Syntax> actor = delegate (Syntax node) { return_items.Add(node);  };
            Visit(actor);
            return return_items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }



        #endregion



       


        public string Emit()
        {
            List<string> return_items = new List<string>();

            Action<Syntax> track_specific = delegate (Syntax node) { node.ObjectName = node.ObjectName.ToUpper(); var x = node.ObjectName + "(" + node.Id + ")" + "(" + node.OrderedId + ")" + "[" + node.Information + "]" + " " + node.ExpressionFragment; if (node.ObjectName == "PRODUCTION-RULE" || node.ObjectName == "PRODUCTION-NAME" || node.ObjectName == "RULE-NAME" || node.ObjectName == "PIPE" || node.ObjectName == "SEMI-COLON" || node.ObjectName == "OPTIONAL") { return_items.Add(x); } };
            Visit(track_specific);

            var result = String.Join(Environment.NewLine + ">>> ", return_items.ToArray());
            return result;
        }

    }
}
