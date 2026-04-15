// <copyright file="SpreadsheetTests.cs" company="SpreadsheetEngine_Tests">
// Copyright (c) SpreadsheetEngine_Tests. All rights reserved.
// </copyright>

namespace SpreadsheetEngine_Tests
{
    using NUnit.Framework;
    using SpreadsheetEngine;

    /// <summary>
    /// Unit tests for the Spreadsheet and Cell classes.
    /// </summary>
    [TestFixture]
    public class SpreadsheetTests
    {
        /// <summary>
        /// The spreadsheet instance used for testing.
        /// </summary>
        private Spreadsheet spreadsheet;

        /// <summary>
        /// Sets up a fresh spreadsheet before each test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.spreadsheet = new Spreadsheet(50, 26);
        }

        // -----------------------------------------------------------------------
        // GetCell tests
        // -----------------------------------------------------------------------

        /// <summary>
        /// Tests that GetCell returns a non-null cell for a valid index.
        /// </summary>
        [Test]
        public void GetCell_ValidIndex_ReturnsCell()
        {
            Cell? cell = this.spreadsheet.GetCell(0, 0);
            Assert.That(cell, Is.Not.Null);
        }

        /// <summary>
        /// Tests that GetCell returns null for a negative row index.
        /// </summary>
        [Test]
        public void GetCell_NegativeRow_ReturnsNull()
        {
            Cell? cell = this.spreadsheet.GetCell(-1, 0);
            Assert.That(cell, Is.Null);
        }

        /// <summary>
        /// Tests that GetCell returns null for a negative column index.
        /// </summary>
        [Test]
        public void GetCell_NegativeColumn_ReturnsNull()
        {
            Cell? cell = this.spreadsheet.GetCell(0, -1);
            Assert.That(cell, Is.Null);
        }

        /// <summary>
        /// Tests that GetCell returns null when the row index equals the row count.
        /// </summary>
        [Test]
        public void GetCell_RowIndexEqualToRowCount_ReturnsNull()
        {
            Cell? cell = this.spreadsheet.GetCell(50, 0);
            Assert.That(cell, Is.Null);
        }

        /// <summary>
        /// Tests that GetCell returns null when the column index equals the column count.
        /// </summary>
        [Test]
        public void GetCell_ColumnIndexEqualToColumnCount_ReturnsNull()
        {
            Cell? cell = this.spreadsheet.GetCell(0, 26);
            Assert.That(cell, Is.Null);
        }

        /// <summary>
        /// Tests that GetCell returns a valid cell at the last valid index.
        /// </summary>
        [Test]
        public void GetCell_LastValidIndex_ReturnsCell()
        {
            Cell? cell = this.spreadsheet.GetCell(49, 25);
            Assert.That(cell, Is.Not.Null);
        }

        // -----------------------------------------------------------------------
        // Cell default value tests
        // -----------------------------------------------------------------------

        /// <summary>
        /// Tests that a new cell has an empty Text property by default.
        /// </summary>
        [Test]
        public void Cell_DefaultText_IsEmpty()
        {
            Cell? cell = this.spreadsheet.GetCell(0, 0);
            Assert.That(cell?.Text, Is.EqualTo(string.Empty));
        }

        /// <summary>
        /// Tests that a new cell has an empty Value property by default.
        /// </summary>
        [Test]
        public void Cell_DefaultValue_IsEmpty()
        {
            Cell? cell = this.spreadsheet.GetCell(0, 0);
            Assert.That(cell?.Value, Is.EqualTo(string.Empty));
        }

        // -----------------------------------------------------------------------
        // Cell RowIndex and ColumnIndex tests
        // -----------------------------------------------------------------------

        /// <summary>
        /// Tests that a cell's RowIndex matches the index it was created with.
        /// </summary>
        [Test]
        public void Cell_RowIndex_MatchesCreatedIndex()
        {
            Cell? cell = this.spreadsheet.GetCell(5, 0);
            Assert.That(cell?.RowIndex, Is.EqualTo(5));
        }

        /// <summary>
        /// Tests that a cell's ColumnIndex matches the index it was created with.
        /// </summary>
        [Test]
        public void Cell_ColumnIndex_MatchesCreatedIndex()
        {
            Cell? cell = this.spreadsheet.GetCell(0, 5);
            Assert.That(cell?.ColumnIndex, Is.EqualTo(5));
        }

        // -----------------------------------------------------------------------
        // Cell Text and Value tests
        // -----------------------------------------------------------------------

        /// <summary>
        /// Tests that setting plain text updates the cell Value to match.
        /// </summary>
        [Test]
        public void Cell_SetPlainText_ValueMatchesText()
        {
            Cell? cell = this.spreadsheet.GetCell(0, 0);
            cell!.Text = "Hello";
            Assert.That(cell.Value, Is.EqualTo("Hello"));
        }

        /// <summary>
        /// Tests that setting different text fires PropertyChanged.
        /// </summary>
        [Test]
        public void Cell_SetDifferentText_FiresPropertyChanged()
        {
            Cell? cell = this.spreadsheet.GetCell(0, 0);
            int eventCount = 0;
            cell!.PropertyChanged += (s, e) => eventCount++;
            cell.Text = "Hello";
            Assert.That(eventCount, Is.EqualTo(1));
        }

        /// <summary>
        /// Tests that setting text to empty string updates Value to empty.
        /// </summary>
        [Test]
        public void Cell_SetEmptyText_ValueIsEmpty()
        {
            Cell? cell = this.spreadsheet.GetCell(0, 0);
            cell!.Text = "Hello";
            cell.Text = string.Empty;
            Assert.That(cell.Value, Is.EqualTo(string.Empty));
        }

        // -----------------------------------------------------------------------
        // Cell reference formula tests
        // -----------------------------------------------------------------------

        /// <summary>
        /// Tests that a formula referencing another cell copies its value.
        /// </summary>
        [Test]
        public void Cell_FormulaReference_CopiesReferencedCellValue()
        {
            this.spreadsheet.GetCell(0, 1)!.Text = "TestValue";
            this.spreadsheet.GetCell(0, 0)!.Text = "=B1";
            Assert.That(this.spreadsheet.GetCell(0, 0)!.Value, Is.EqualTo("TestValue"));
        }

        /// <summary>
        /// Tests that a formula with a bad reference returns an error string.
        /// </summary>
        [Test]
        public void Cell_FormulaWithBadReference_ReturnsError()
        {
            this.spreadsheet.GetCell(0, 0)!.Text = "=ZZZ99";
            Assert.That(this.spreadsheet.GetCell(0, 0)!.Value, Is.EqualTo("!(bad reference)"));
        }

        /// <summary>
        /// Tests that a formula referencing an empty cell returns empty string.
        /// </summary>
        [Test]
        public void Cell_FormulaReferencingEmptyCell_ReturnsEmpty()
        {
            this.spreadsheet.GetCell(0, 0)!.Text = "=B1";
            Assert.That(this.spreadsheet.GetCell(0, 0)!.Value, Is.EqualTo(string.Empty));
        }

        /// <summary>
        /// Tests that a formula referencing the last valid cell works correctly.
        /// </summary>
        [Test]
        public void Cell_FormulaReferencingLastCell_ReturnsCorrectValue()
        {
            this.spreadsheet.GetCell(49, 25)!.Text = "LastCell";
            this.spreadsheet.GetCell(0, 0)!.Text = "=Z50";
            Assert.That(this.spreadsheet.GetCell(0, 0)!.Value, Is.EqualTo("LastCell"));
        }

        // -----------------------------------------------------------------------
        // Spreadsheet RowCount and ColumnCount tests
        // -----------------------------------------------------------------------

        /// <summary>
        /// Tests that RowCount returns the value passed to the constructor.
        /// </summary>
        [Test]
        public void Spreadsheet_RowCount_MatchesConstructorArgument()
        {
            Assert.That(this.spreadsheet.RowCount, Is.EqualTo(50));
        }

        /// <summary>
        /// Tests that ColumnCount returns the value passed to the constructor.
        /// </summary>
        [Test]
        public void Spreadsheet_ColumnCount_MatchesConstructorArgument()
        {
            Assert.That(this.spreadsheet.ColumnCount, Is.EqualTo(26));
        }

        /// <summary>
        /// Tests that a spreadsheet can be created with minimum dimensions of 1x1.
        /// </summary>
        [Test]
        public void Spreadsheet_MinimumSize_CreatesSuccessfully()
        {
            Spreadsheet small = new Spreadsheet(1, 1);
            Assert.That(small.GetCell(0, 0), Is.Not.Null);
        }
    }
}