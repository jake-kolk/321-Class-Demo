// <copyright file="VariableNode.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>Represents a variable in the expression tree.</summary>
    internal class VariableNode : ExpressionTreeNode
    {
        /// <summary>The name of the variable.</summary>
        private readonly string name;

        /// <summary>Reference to the shared variables dictionary.</summary>
        private readonly Dictionary<string, double> variables;

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableNode"/> class.Initializes a new instance of VariableNode.</summary>
        /// <param name="name">The variable name.</param>
        /// <param name="variables">The shared variables dictionary.</param>
        public VariableNode(string name, Dictionary<string, double> variables)
        {
            this.name = name;
            this.variables = variables;
        }

        /// <summary>Evaluates this node by looking up the variable value.</summary>
        /// <returns>The variable's value, or 0 if not set.</returns>
        public override double Evaluate()
        {
            if (this.variables.TryGetValue(this.name, out double value))
            {
                return value;
            }

            return 0.0;
        }
    }
}
