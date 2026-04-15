// <copyright file="OperatorNode.cs" company="WSU">
// Copyright (c) WSU. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>
    /// Abstract base class for all binary operator nodes.
    /// </summary>
    internal abstract class OperatorNode : ExpressionTreeNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OperatorNode"/> class.
        /// </summary>
        /// <param name="op">The operator character.</param>
        public OperatorNode(char op)
        {
            this.Operator = op;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OperatorNode"/> class.
        /// </summary>
        public OperatorNode()
        {
        }

        /// <summary>Gets the operator character.</summary>
        public char Operator { get; }

        /// <summary>Gets or sets the left child node.</summary>
        public ExpressionTreeNode? Left { get; set; }

        /// <summary>Gets or sets the right child node.</summary>
        public ExpressionTreeNode? Right { get; set; }
    }
}