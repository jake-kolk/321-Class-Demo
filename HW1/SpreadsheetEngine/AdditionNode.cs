// <copyright file="AdditionNode.cs" company="WSU">
// Copyright (c) WSU. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>
    /// Represents an addition operator node in the expression tree.
    /// </summary>
    internal class AdditionNode : OperatorNode
    {
        /// <summary>
        /// Sets operator to '+'.
        /// </summary>
        public static new readonly char Operator = '+';

        /// <summary>
        /// Initializes a new instance of the <see cref="AdditionNode"/> class.
        /// </summary>
        public AdditionNode()
        {
        }

        /// <summary>
        /// Evaluates this node by adding left and right children.
        /// </summary>
        /// <returns>The sum of the left and right children.</returns>
        public override double Evaluate()
        {
            return this.Left!.Evaluate() + this.Right!.Evaluate();
        }
    }
}