// <copyright file="OperatorNodeFactory.cs" company="WSU">
// Copyright (c) WSU. All rights reserved.
// </copyright>

namespace SpreadsheetEngine
{
    using System.Reflection;

    /// <summary>
    /// Factory class responsible for creating the correct OperatorNode subtype.
    /// The ExpressionTree only needs to know about OperatorNode, not the subclasses.
    /// </summary>
    internal class OperatorNodeFactory
    {
        /// <summary>
        /// List of valid operator types.
        /// </summary>
        private readonly List<Type> operatorTypes = new ();

        /// <summary>
        /// Initializes a new instance of the <see cref="OperatorNodeFactory"/> class.
        /// Loads all classes that inherit from OperatorNode into a list.
        /// </summary>
        /// <exception cref="InvalidOperationException">Throws error when operators not found.</exception>
        public OperatorNodeFactory()
        {
            Type operatorNodeType = typeof(OperatorNode);

            // Iterate over all loaded assemblies
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                // Get all types that inherit from our OperatorNode class
                var types = assembly.GetTypes();
                this.operatorTypes.AddRange(types.Where(type => type.IsSubclassOf(operatorNodeType)));
            }

            if (this.operatorTypes.Count == 0)
            {
                throw new InvalidOperationException("No valid operator types found!");
            }
        }

        /// <summary>
        /// Returns the precedence of the given operator.
        /// Higher number means higher precedence.
        /// </summary>
        /// <param name="op">The operator character.</param>
        /// <returns>An integer representing the precedence level.</returns>
        public static int GetPrecedence(char op)
        {
            return op switch
            {
                '+' => 1,
                '-' => 1,
                '*' => 2,
                '/' => 2,
                _ => 0,
            };
        }

        /// <summary>
        /// Returns true if the given character is a supported operator.
        /// </summary>
        /// <param name="op">The character to check.</param>
        /// <returns>True if supported operator, false otherwise.</returns>
        public static bool IsOperator(char op)
        {
            return op == '+' || op == '-' || op == '*' || op == '/';
        }

        /// <summary>
        /// Creates the appropriate OperatorNode subclass for the given operator.
        /// This is the only place in the codebase that knows about concrete operator types.
        /// </summary>
        /// <param name="op">The operator character (+, -, *, /).</param>
        /// <returns>The appropriate OperatorNode subclass instance.</returns>
        /// <exception cref="InvalidOperationException">Thrown when operator is not supported.</exception>
        public OperatorNode CreateOperatorNode(char op)
        {
            // Iterate over those subclasses of OperatorNode
            foreach (var type in this.operatorTypes)
            {
                // For each subclass, retrieve the Operator property
                FieldInfo? operatorField = type.GetField(
                    "Operator",
                    BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

                if (operatorField != null)
                {
                    // Get the character of the Operator
                    object? value = operatorField.GetValue(null);
                    if (value?.ToString()?[0] == op)
                    {
                        ConstructorInfo? constructor = type.GetConstructor(Type.EmptyTypes);
                        if (constructor != null)
                        {
                            return (OperatorNode)constructor.Invoke(Array.Empty<object>());
                        }
                    }
                }
            }

            throw new InvalidOperationException($"Unsupported operator: {op}");
        }
    }
}