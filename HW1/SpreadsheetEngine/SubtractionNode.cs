// <copyright file="SubtractionNode.cs" company="WSU">
// Copyright (c) WSU. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>
    /// Represents a subtraction operator node in the expression tree.
    /// </summary>
    internal class SubtractionNode : OperatorNode
    {
        /// <summary>
        /// Sets operator to '-'.
        /// </summary>
        public static new readonly char Operator = '-';

        /// <summary>
        /// Initializes a new instance of the <see cref="SubtractionNode"/> class.
        /// </summary>
        public SubtractionNode()
            : base('-')
        {
        }

        /// <summary>
        /// Evaluates this node by subtracting right child from left child.
        /// </summary>
        /// <returns>The difference of the left and right children.</returns>
        public override double Evaluate()
        {
            return this.Left!.Evaluate() - this.Right!.Evaluate();
        }
    }
}