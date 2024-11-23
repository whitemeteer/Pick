#region COPYRIGHT
//
//     THIS IS GENERATED BY TEMPLATE
//     
//     AUTHOR  :     ROYE
//     DATE       :     2010
//
//     COPYRIGHT (C) 2010, TIANXIAHOTEL TECHNOLOGIES CO., LTD. ALL RIGHTS RESERVED.
//
#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace System.Text.Template
{
    internal class TokenNode
    {
        private TokenNodeCollection _ChildNodes;

        public TokenNode()
        {
            _ChildNodes = new TokenNodeCollection();
        }

        public virtual void Evaluate(IExpressionParser parser, ITemplateContext context, StringBuilder output)
        {
        }

        public string Render(IExpressionParser parser, ITemplateContext context)
        {
            StringBuilder output = new StringBuilder();
            this.Render(parser, context, output);
            return output.ToString();
        }

        public void Render(IExpressionParser parser, ITemplateContext context, StringBuilder output)
        {
            foreach (TokenNode node in this.ChildNodes)
            {
                node.Evaluate(parser, context, output);
            }
        }

        public TokenNodeCollection ChildNodes
        {
            get { return this._ChildNodes; }
            set { this._ChildNodes = value; }
        }

        public class TokenNodeCollection : List<TokenNode>
        {
            public T Add<T>(T item) where T : TokenNode
            {
                base.Add(item);
                return item;
            }

            public new TokenNode Add(TokenNode item)
            {
                base.Add(item);
                return item;
            }
        }
    }
}