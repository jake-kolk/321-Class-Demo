// <copyright file="DivisionNode.cs" company="WSU">
// Copyright (c) WSU. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>
    /// Represents a division operator node in the expression tree.
    /// </summary>
    internal class DivisionNode : OperatorNode
    {
        /// <summary>
        /// Sets operator to '/'.
        /// </summary>
        public static new readonly char Operator = '/';

        /// <summary>
        /// Initializes a new instance of the <see cref="DivisionNode"/> class.
        /// </summary>
        public DivisionNode()
        {
        }

        /// <summary>
        /// Evaluates this node by dividing left child by right child.
        /// </summary>
        /// <returns>The quotient of the left and right children.</returns>
        public override double Evaluate()
        {
            return this.Left!.Evaluate() / this.Right!.Evaluate();
        }
    }
}