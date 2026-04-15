// <copyright file="ExpressionTreeNode.cs" company="WSU">
// Copyright (c) WSU. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    using System;

    /// <summary>Abstract base class for all expression tree nodes.</summary>
    internal abstract class ExpressionTreeNode
    {
        /// <summary>Evaluates this node and returns a double value.</summary>
        /// <returns>The evaluated double value.</returns>
        public abstract double Evaluate();
    }
}