// <copyright file="ExpressionTreeTests.cs" company="WSU">
// Copyright (c) WSU. All rights reserved.
// </copyright>

namespace ExpressionTreeTests
{
    using NUnit.Framework;
    using SpreadsheetEngine;

    /// <summary>
    /// Contains unit tests for the ExpressionTree class.
    /// </summary>
    [TestFixture]
    public class ExpressionTreeTests
    {
        // =====================================================================
        // Addition Tests
        // =====================================================================

        /// <summary>
        /// Tests that a simple addition of two constants evaluates correctly.
        /// </summary>
        [Test]
        public void EvaluateAdditionTwoConstants()
        {
            ExpressionTree tree = new ExpressionTree("5+3");
            Assert.That(tree.Evaluate(), Is.EqualTo(8.0));
        }

        /// <summary>
        /// Tests addition with multiple constants in one expression.
        /// </summary>
        [Test]
        public void EvaluateAdditionMultipleConstants()
        {
            ExpressionTree tree = new ExpressionTree("1+2+3+4");
            Assert.That(tree.Evaluate(), Is.EqualTo(10.0));
        }

        /// <summary>
        /// Tests addition where one operand is zero (boundary case).
        /// </summary>
        [Test]
        public void EvaluateAdditionWithZero()
        {
            ExpressionTree tree = new ExpressionTree("0+5");
            Assert.That(tree.Evaluate(), Is.EqualTo(5.0));
        }

        // =====================================================================
        // Subtraction Tests
        // =====================================================================

        /// <summary>
        /// Tests that a simple subtraction of two constants evaluates correctly.
        /// </summary>
        [Test]
        public void EvaluateSubtractionTwoConstants()
        {
            ExpressionTree tree = new ExpressionTree("10-3");
            Assert.That(tree.Evaluate(), Is.EqualTo(7.0));
        }

        /// <summary>
        /// Tests subtraction with multiple constants evaluates left to right.
        /// </summary>
        [Test]
        public void EvaluateSubtractionMultipleConstants()
        {
            ExpressionTree tree = new ExpressionTree("20-5-3");
            Assert.That(tree.Evaluate(), Is.EqualTo(12.0));
        }

        /// <summary>
        /// Tests subtraction that results in a negative number (boundary case).
        /// </summary>
        [Test]
        public void EvaluateSubtractionResultingInNegative()
        {
            ExpressionTree tree = new ExpressionTree("3-10");
            Assert.That(tree.Evaluate(), Is.EqualTo(-7.0));
        }

        /// <summary>
        /// Tests subtraction where result is zero (boundary case).
        /// </summary>
        [Test]
        public void EvaluateSubtractionResultingInZero()
        {
            ExpressionTree tree = new ExpressionTree("5-5");
            Assert.That(tree.Evaluate(), Is.EqualTo(0.0));
        }

        // =====================================================================
        // Multiplication Tests
        // =====================================================================

        /// <summary>
        /// Tests that a simple multiplication of two constants evaluates correctly.
        /// </summary>
        [Test]
        public void EvaluateMultiplicationTwoConstants()
        {
            ExpressionTree tree = new ExpressionTree("4*3");
            Assert.That(tree.Evaluate(), Is.EqualTo(12.0));
        }

        /// <summary>
        /// Tests multiplication with multiple constants.
        /// </summary>
        [Test]
        public void EvaluateMultiplicationMultipleConstants()
        {
            ExpressionTree tree = new ExpressionTree("2*3*4");
            Assert.That(tree.Evaluate(), Is.EqualTo(24.0));
        }

        /// <summary>
        /// Tests multiplication by zero (boundary case).
        /// </summary>
        [Test]
        public void EvaluateMultiplicationByZero()
        {
            ExpressionTree tree = new ExpressionTree("5*0");
            Assert.That(tree.Evaluate(), Is.EqualTo(0.0));
        }

        /// <summary>
        /// Tests multiplication by one (boundary case).
        /// </summary>
        [Test]
        public void EvaluateMultiplicationByOne()
        {
            ExpressionTree tree = new ExpressionTree("7*1");
            Assert.That(tree.Evaluate(), Is.EqualTo(7.0));
        }

        // =====================================================================
        // Division Tests
        // =====================================================================

        /// <summary>
        /// Tests that a simple division of two constants evaluates correctly.
        /// </summary>
        [Test]
        public void EvaluateDivisionTwoConstants()
        {
            ExpressionTree tree = new ExpressionTree("10/2");
            Assert.That(tree.Evaluate(), Is.EqualTo(5.0));
        }

        /// <summary>
        /// Tests division resulting in a decimal value (boundary case).
        /// </summary>
        [Test]
        public void EvaluateDivisionResultingInDecimal()
        {
            ExpressionTree tree = new ExpressionTree("7/2");
            Assert.That(tree.Evaluate(), Is.EqualTo(3.5));
        }

        /// <summary>
        /// Tests division by zero returns infinity (overflow/error case).
        /// </summary>
        [Test]
        public void EvaluateDivisionByZero()
        {
            ExpressionTree tree = new ExpressionTree("5/0");
            Assert.That(tree.Evaluate(), Is.EqualTo(double.PositiveInfinity));
        }

        /// <summary>
        /// Tests division of zero by a number (boundary case).
        /// </summary>
        [Test]
        public void EvaluateDivisionOfZero()
        {
            ExpressionTree tree = new ExpressionTree("0/5");
            Assert.That(tree.Evaluate(), Is.EqualTo(0.0));
        }

        // =====================================================================
        // Operator Precedence Tests
        // =====================================================================

        /// <summary>
        /// Tests that multiplication is evaluated before addition (normal precedence case).
        /// </summary>
        [Test]
        public void EvaluatePrecedenceMultiplicationBeforeAddition()
        {
            // Should be 2 + (3*4) = 14, not (2+3)*4 = 20
            ExpressionTree tree = new ExpressionTree("2+3*4");
            Assert.That(tree.Evaluate(), Is.EqualTo(14.0));
        }

        /// <summary>
        /// Tests that division is evaluated before subtraction (normal precedence case).
        /// </summary>
        [Test]
        public void EvaluatePrecedenceDivisionBeforeSubtraction()
        {
            // Should be 10 - (6/2) = 7, not (10-6)/2 = 2
            ExpressionTree tree = new ExpressionTree("10-6/2");
            Assert.That(tree.Evaluate(), Is.EqualTo(7.0));
        }

        /// <summary>
        /// Tests that multiplication is evaluated before subtraction (normal precedence case).
        /// </summary>
        [Test]
        public void EvaluatePrecedenceMultiplicationBeforeSubtraction()
        {
            // Should be 10 - (2*3) = 4, not (10-2)*3 = 24
            ExpressionTree tree = new ExpressionTree("10-2*3");
            Assert.That(tree.Evaluate(), Is.EqualTo(4.0));
        }

        /// <summary>
        /// Tests that division is evaluated before addition (normal precedence case).
        /// </summary>
        [Test]
        public void EvaluatePrecedenceDivisionBeforeAddition()
        {
            // Should be 1 + (8/4) = 3, not (1+8)/4 = 2.25
            ExpressionTree tree = new ExpressionTree("1+8/4");
            Assert.That(tree.Evaluate(), Is.EqualTo(3.0));
        }

        /// <summary>
        /// Tests a complex expression with multiple operator types and precedence.
        /// </summary>
        [Test]
        public void EvaluatePrecedenceComplexExpression()
        {
            // Should be (2*3) + (4/2) - 1 = 6 + 2 - 1 = 7
            ExpressionTree tree = new ExpressionTree("2*3+4/2-1");
            Assert.That(tree.Evaluate(), Is.EqualTo(7.0));
        }

        // =====================================================================
        // Parentheses Tests
        // =====================================================================

        /// <summary>
        /// Tests that parentheses override default precedence (normal case).
        /// </summary>
        [Test]
        public void EvaluateParenthesesOverridePrecedence()
        {
            // Should be (2+3)*4 = 20, not 2+(3*4) = 14
            ExpressionTree tree = new ExpressionTree("(2+3)*4");
            Assert.That(tree.Evaluate(), Is.EqualTo(20.0));
        }

        /// <summary>
        /// Tests parentheses with subtraction override (normal case).
        /// </summary>
        [Test]
        public void EvaluateParenthesesWithSubtraction()
        {
            // Should be (10-3)*2 = 14, not 10-(3*2) = 4
            ExpressionTree tree = new ExpressionTree("(10-3)*2");
            Assert.That(tree.Evaluate(), Is.EqualTo(14.0));
        }

        /// <summary>
        /// Tests nested parentheses evaluate correctly (boundary case).
        /// </summary>
        [Test]
        public void EvaluateNestedParentheses()
        {
            // Should be ((2+3)*2)+1 = 11
            ExpressionTree tree = new ExpressionTree("((2+3)*2)+1");
            Assert.That(tree.Evaluate(), Is.EqualTo(11.0));
        }

        /// <summary>
        /// Tests that redundant parentheses around a single value still work (boundary case).
        /// </summary>
        [Test]
        public void EvaluateRedundantParentheses()
        {
            ExpressionTree tree = new ExpressionTree("(5)");
            Assert.That(tree.Evaluate(), Is.EqualTo(5.0));
        }

        /// <summary>
        /// Tests parentheses wrapping the entire expression (boundary case).
        /// </summary>
        [Test]
        public void EvaluateParenthesesAroundWholeExpression()
        {
            ExpressionTree tree = new ExpressionTree("(2+3)");
            Assert.That(tree.Evaluate(), Is.EqualTo(5.0));
        }

        /// <summary>
        /// Tests multiple separate parenthesized groups (normal case).
        /// </summary>
        [Test]
        public void EvaluateMultipleParenthesesGroups()
        {
            // Should be (2+3) * (4-1) = 5*3 = 15
            ExpressionTree tree = new ExpressionTree("(2+3)*(4-1)");
            Assert.That(tree.Evaluate(), Is.EqualTo(15.0));
        }

        // =====================================================================
        // Variable Tests
        // =====================================================================

        /// <summary>
        /// Tests that a single variable defaults to zero when not set.
        /// </summary>
        [Test]
        public void EvaluateVariableDefaultsToZero()
        {
            ExpressionTree tree = new ExpressionTree("A1");
            Assert.That(tree.Evaluate(), Is.EqualTo(0.0));
        }

        /// <summary>
        /// Tests that a variable evaluates correctly after being set.
        /// </summary>
        [Test]
        public void EvaluateVariableAfterSet()
        {
            ExpressionTree tree = new ExpressionTree("A1");
            tree.SetVariable("A1", 5.0);
            Assert.That(tree.Evaluate(), Is.EqualTo(5.0));
        }

        /// <summary>
        /// Tests that multiple variables evaluate correctly after being set.
        /// </summary>
        [Test]
        public void EvaluateMultipleVariablesAfterSet()
        {
            ExpressionTree tree = new ExpressionTree("A1+B1+C1");
            tree.SetVariable("A1", 1.0);
            tree.SetVariable("B1", 2.0);
            tree.SetVariable("C1", 3.0);
            Assert.That(tree.Evaluate(), Is.EqualTo(6.0));
        }

        /// <summary>
        /// Tests that a multi-character variable name is supported.
        /// </summary>
        [Test]
        public void EvaluateMultiCharacterVariableName()
        {
            ExpressionTree tree = new ExpressionTree("Hello+World");
            tree.SetVariable("Hello", 10.0);
            tree.SetVariable("World", 20.0);
            Assert.That(tree.Evaluate(), Is.EqualTo(30.0));
        }

        /// <summary>
        /// Tests that creating a new expression clears old variables (boundary case).
        /// </summary>
        [Test]
        public void EvaluateNewExpressionClearsVariables()
        {
            ExpressionTree tree = new ExpressionTree("A1+B1");
            tree.SetVariable("A1", 5.0);
            tree.SetVariable("B1", 5.0);

            // Create a new tree — old variables should be gone
            tree = new ExpressionTree("A1+B1");
            Assert.That(tree.Evaluate(), Is.EqualTo(0.0));
        }

        /// <summary>
        /// Tests that a variable can be overwritten with a new value.
        /// </summary>
        [Test]
        public void EvaluateVariableOverwrite()
        {
            ExpressionTree tree = new ExpressionTree("A1");
            tree.SetVariable("A1", 5.0);
            tree.SetVariable("A1", 99.0);
            Assert.That(tree.Evaluate(), Is.EqualTo(99.0));
        }

        /// <summary>
        /// Tests that variables persist across multiple evaluations (normal case).
        /// </summary>
        [Test]
        public void EvaluateVariablesPersistAcrossEvaluations()
        {
            ExpressionTree tree = new ExpressionTree("A1+B1");
            tree.SetVariable("A1", 3.0);
            tree.SetVariable("B1", 4.0);

            // Evaluate twice — variables should not reset
            tree.Evaluate();
            Assert.That(tree.Evaluate(), Is.EqualTo(7.0));
        }

        /// <summary>
        /// Tests that variables work correctly inside parentheses.
        /// </summary>
        [Test]
        public void EvaluateVariablesInsideParentheses()
        {
            ExpressionTree tree = new ExpressionTree("(A+B)*C");
            tree.SetVariable("A", 2.0);
            tree.SetVariable("B", 3.0);
            tree.SetVariable("C", 4.0);
            Assert.That(tree.Evaluate(), Is.EqualTo(20.0));
        }

        // =====================================================================
        // Mixed Tests
        // =====================================================================

        /// <summary>
        /// Tests an expression mixing constants and variables.
        /// </summary>
        [Test]
        public void EvaluateMixedConstantsAndVariables()
        {
            ExpressionTree tree = new ExpressionTree("A1+5");
            tree.SetVariable("A1", 3.0);
            Assert.That(tree.Evaluate(), Is.EqualTo(8.0));
        }

        /// <summary>
        /// Tests a single constant with no operator (boundary case).
        /// </summary>
        [Test]
        public void EvaluateSingleConstant()
        {
            ExpressionTree tree = new ExpressionTree("42");
            Assert.That(tree.Evaluate(), Is.EqualTo(42.0));
        }

        /// <summary>
        /// Tests a large expression with many operands (stress case).
        /// </summary>
        [Test]
        public void EvaluateLargeExpression()
        {
            ExpressionTree tree = new ExpressionTree("1+1+1+1+1+1+1+1+1+1");
            Assert.That(tree.Evaluate(), Is.EqualTo(10.0));
        }

        /// <summary>
        /// Tests very large numbers to check for overflow behavior (overflow case).
        /// </summary>
        [Test]
        public void EvaluateVeryLargeNumbers()
        {
            ExpressionTree tree = new ExpressionTree("A+B");
            tree.SetVariable("A", double.MaxValue);
            tree.SetVariable("B", double.MaxValue);
            Assert.That(tree.Evaluate(), Is.EqualTo(double.PositiveInfinity));
        }
    }
}