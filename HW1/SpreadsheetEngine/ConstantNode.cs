// <copyright file="ConstantNode.cs" company="WSU">
// Copyright (c) WSU. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    /// <summary>Represents a constant numerical value in the expression tree.</summary>
    internal class ConstantNode : ExpressionTreeNode
    {
        /// <summary>The constant value stored in this node.</summary>
        private readonly double value;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstantNode"/> class.
        /// </summary>
        /// <param name="value">The value double.</param>
        public ConstantNode(double value)
        {
            this.value = value;
        }

        /// <summary>Evaluates this node by returning the constant value.</summary>
        /// <returns>The constant double value.</returns>
        public override double Evaluate() => this.value;
    }
}
