// <copyright file="MultiplicationNode.cs" company="WSU">
// Copyright (c) WSU. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Represents a multiplication operator node in the expression tree.
    /// </summary>
    internal class MultiplicationNode : OperatorNode
    {
        /// <summary>
        /// Stores the operator of this class.
        /// </summary>
        public static new readonly char Operator = '*';

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiplicationNode"/> class.
        /// </summary>
        public MultiplicationNode()
        {
        }

        /// <summary>
        /// Evaluates this node by multiplying left and right children.
        /// </summary>
        /// <returns>The product of the left and right children.</returns>
        public override double Evaluate()
        {
            return this.Left!.Evaluate() * this.Right!.Evaluate();
        }
    }
}