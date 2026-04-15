// <copyright file="RobustnessAndExceptionTests.cs" company="WSU">
// Copyright (c) WSU. All rights reserved.
// </copyright>

namespace SpreadsheetEngine_Tests
{
    using System;
    using System.Linq;
    using SpreadsheetEngine;

    /// <summary>
    /// Tests exception paths and robustness behavior.
    /// </summary>
    [TestFixture]
    public class RobustnessAndExceptionTests
    {
        /// <summary>
        /// Verifies null expression is rejected.
        /// </summary>
        [Test]
        public void ExpressionTree_NullExpression_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ExpressionTree(null!, _ => "0"));
        }

        /// <summary>
        /// Verifies whitespace expression is rejected.
        /// </summary>
        [Test]
        public void ExpressionTree_WhitespaceExpression_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ExpressionTree("   ", _ => "0"));
        }

        /// <summary>
        /// Verifies null resolver is rejected.
        /// </summary>
        [Test]
        public void ExpressionTree_NullResolver_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new ExpressionTree("1+1", null!));
        }

        /// <summary>
        /// Verifies invalid variable resolver output throws invalid operation.
        /// </summary>
        [Test]
        public void ExpressionTree_InvalidResolverValue_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => new ExpressionTree("A1+1", _ => "not-a-number"));
        }

        /// <summary>
        /// Verifies variable dependencies are captured for referenced variables.
        /// </summary>
        [Test]
        public void ExpressionTree_GetDependencies_ReturnsExpectedVariables()
        {
            ExpressionTree tree = new ExpressionTree("A1+B2+A1", name => name == "A1" ? "1" : "2");
            var dependencies = tree.GetDependancies();

            Assert.That(dependencies, Has.Count.EqualTo(2));
            Assert.That(dependencies, Contains.Item("A1"));
            Assert.That(dependencies, Contains.Item("B2"));
        }

        /// <summary>
        /// Verifies SetVariable validates variable names.
        /// </summary>
        [Test]
        public void SetVariable_WhitespaceName_ThrowsArgumentException()
        {
            ExpressionTree tree = new ExpressionTree("A1", _ => "0");
            Assert.Throws<ArgumentException>(() => tree.SetVariable(" ", 1));
        }

        /// <summary>
        /// Verifies whitespace in expressions is ignored during evaluation.
        /// </summary>
        [Test]
        public void ExpressionTree_WhitespaceInExpression_EvaluatesCorrectly()
        {
            ExpressionTree tree = new ExpressionTree(" 2 + 3 * 4 ");
            Assert.That(tree.Evaluate(), Is.EqualTo(14));
        }

        /// <summary>
        /// Verifies the parser's current behavior for unmatched opening parenthesis.
        /// </summary>
        [Test]
        public void ExpressionTree_UnmatchedOpeningParenthesis_EvaluatesWithCurrentBehavior()
        {
            ExpressionTree tree = new ExpressionTree("(2+3", _ => "0");
            Assert.That(tree.Evaluate(), Is.EqualTo(5));
        }

        /// <summary>
        /// Verifies command purpose validation throws on invalid purpose values.
        /// </summary>
        [Test]
        public void Command_WhitespacePurpose_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new TestCommand(" "));
        }

        /// <summary>
        /// Verifies command bus rejects null command input.
        /// </summary>
        [Test]
        public void CommandBus_SendNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => CommandBus.Send(null!));
        }

        /// <summary>
        /// Verifies revision command bus rejects null input.
        /// </summary>
        [Test]
        public void CommandBus_SendRevisionNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => CommandBus.SendRevision(null!));
        }

        /// <summary>
        /// Verifies revision command rejects null direction.
        /// </summary>
        [Test]
        public void RevisionCommand_NullDirection_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new RevisionCommand(null!));
        }

        /// <summary>
        /// Verifies revision command rejects unsupported direction value.
        /// </summary>
        [Test]
        public void RevisionCommand_InvalidDirection_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new RevisionCommand("LEFT"));
        }

        /// <summary>
        /// Verifies cell update command validates null and invalid property inputs.
        /// </summary>
        [Test]
        public void CellUpdateCommand_InvalidArguments_ThrowExpectedExceptions()
        {
            Spreadsheet spreadsheet = new Spreadsheet(2, 2);
            Cell cell = spreadsheet.GetCell(0, 0)!;

            Assert.Throws<ArgumentNullException>(() => new CellUpdateCommand<string>(null!, "Text", "a", "b", "Edit"));
            Assert.Throws<ArgumentException>(() => new CellUpdateCommand<string>(cell, " ", "a", "b", "Edit"));
            Assert.Throws<ArgumentException>(() => new CellUpdateCommand<string>(cell, "Color", "a", "b", "Edit"));
        }

        private sealed class TestCommand : Command
        {
            public TestCommand(string purpose)
                : base(purpose)
            {
            }
        }
    }
}
