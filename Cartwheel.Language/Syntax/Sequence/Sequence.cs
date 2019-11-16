using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Cartwheel.Language
{
    public class Sequence : Syntax
    {

        public enum RecursiveProperty { Left, Right }
        
        private string AscLoopExpressionFragment(Syntax syntax)
        {
            StringBuilder sb = new StringBuilder();
            foreach(var Child in syntax.Children.OrderBy(i => i.Value.OrderedId))
            {
                sb.Append(Child.Value?.ExpressionFragment);
            }
            return sb.ToString();
        }
        private string DescLoopExpressionFragment(Syntax syntax)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var Child in syntax.Children.OrderByDescending(i => i.Value.OrderedId))
            {
                sb.Append(Child.Value?.ExpressionFragment);
            }
            return sb.ToString();
        }

        private int AscLoopIndex(Syntax syntax)
        {
            int index=0;
            foreach (var Child in syntax.Children.OrderBy(i => i.Value.OrderedId))
            {
                if (Child.Value!=null)
                index = Child.Value.EndIndex;
            }
            return index;
        }
        private int DescLoopIndex(Syntax syntax)
        {
            int index = 0;
            foreach (var Child in syntax.Children.OrderByDescending(i => i.Value.OrderedId))
            {
                if (Child.Value != null)
                    index = Child.Value.BeginIndex;
            }
            return index;
        }



        private void SetParentProperties()
        {
            foreach (var Child in this.Children)
            {
                Child.Value.ParentId = this.Id;
                Child.Value.SequenceTag = this.SequenceTag?.ToString() + "." + Child.Value.Id;
            }
        }

        internal void UpdateProperties(string Object_Name, RecursiveProperty Recursion)
        {
            EndIndex = AscLoopIndex(this);
            BeginIndex = DescLoopIndex(this);
            ExpressionFragment = Recursion == RecursiveProperty.Right ? AscLoopExpressionFragment(this): DescLoopExpressionFragment(this);
            IsValidated = true;
            ObjectName = Object_Name;
            Id = Guid.NewGuid();
            SequenceTag = Id.ToString();  // new @@@@@@@
            SetParentProperties();
        }
    }
}
