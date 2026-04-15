// <copyright file="UndoRedoAndColorTests.cs" company="WSU">
// Copyright (c) WSU. All rights reserved.
// </copyright>

namespace SpreadsheetEngine_Tests
{
    using System.ComponentModel;
    using SpreadsheetEngine;

    /// <summary>
    /// Tests undo/redo history behavior and cell color updates.
    /// </summary>
    [TestFixture]
    public class UndoRedoAndColorTests
    {
        private Spreadsheet spreadsheet = null!;

        /// <summary>
        /// Creates a fresh spreadsheet for each test.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.spreadsheet = new Spreadsheet(10, 10);
        }

        /// <summary>
        /// Verifies executing a command, undoing, and redoing restores expected text values.
        /// </summary>
        [Test]
        public void UndoRedo_TextCommand_RestoresExpectedValues()
        {
            Cell cell = this.spreadsheet.GetCell(0, 0)!;
            cell.Text = "before";

            CommandBus.Send(new CellUpdateCommand<string>(cell, "Text", "before", "after", "Edit Cell Text"));

            Assert.That(cell.Text, Is.EqualTo("after"));
            Assert.That(this.spreadsheet.Manager.CanUndo(), Is.True);

            this.spreadsheet.Manager.DoUndo();
            Assert.That(cell.Text, Is.EqualTo("before"));
            Assert.That(this.spreadsheet.Manager.CanRedo(), Is.True);

            this.spreadsheet.Manager.DoRedo();
            Assert.That(cell.Text, Is.EqualTo("after"));
        }

        /// <summary>
        /// Verifies issuing a new command clears redo history.
        /// </summary>
        [Test]
        public void NewCommandAfterUndo_ClearsRedoHistory()
        {
            Cell cell = this.spreadsheet.GetCell(0, 0)!;
            CommandBus.Send(new CellUpdateCommand<string>(cell, "Text", string.Empty, "first", "Edit 1"));

            this.spreadsheet.Manager.DoUndo();
            Assert.That(this.spreadsheet.Manager.CanRedo(), Is.True);

            CommandBus.Send(new CellUpdateCommand<string>(cell, "Text", cell.Text, "second", "Edit 2"));

            Assert.That(this.spreadsheet.Manager.CanRedo(), Is.False);
        }

        /// <summary>
        /// Verifies undo/redo methods are safe on empty history.
        /// </summary>
        [Test]
        public void UndoRedo_EmptyHistory_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => this.spreadsheet.Manager.DoUndo());
            Assert.DoesNotThrow(() => this.spreadsheet.Manager.DoRedo());
            Assert.That(this.spreadsheet.Manager.CanUndo(), Is.False);
            Assert.That(this.spreadsheet.Manager.CanRedo(), Is.False);
        }

        /// <summary>
        /// Verifies revision commands sent through the bus are handled by command manager.
        /// </summary>
        [Test]
        public void RevisionCommandThroughBus_PerformsUndoAndRedo()
        {
            Cell cell = this.spreadsheet.GetCell(1, 1)!;
            cell.Text = "original";
            CommandBus.Send(new CellUpdateCommand<string>(cell, "Text", "original", "updated", "Edit Cell Text"));

            CommandBus.SendRevision(new RevisionCommand("UNDO"));
            Assert.That(cell.Text, Is.EqualTo("original"));

            CommandBus.SendRevision(new RevisionCommand("REDO"));
            Assert.That(cell.Text, Is.EqualTo("updated"));
        }

        /// <summary>
        /// Verifies command purposes are exposed for both undo and redo stacks.
        /// </summary>
        [Test]
        public void UndoRedoPurpose_IsTracked()
        {
            Cell cell = this.spreadsheet.GetCell(0, 2)!;
            CommandBus.Send(new CellUpdateCommand<string>(cell, "Text", string.Empty, "x", "Edit Cell Text"));

            Assert.That(this.spreadsheet.Manager.GetUndoPurpose(), Is.EqualTo("Edit Cell Text"));

            this.spreadsheet.Manager.DoUndo();

            Assert.That(this.spreadsheet.Manager.GetRedoPurpose(), Is.EqualTo("Edit Cell Text"));
        }

        /// <summary>
        /// Verifies color command updates color and is undoable and redoable.
        /// </summary>
        [Test]
        public void ColorCommand_UndoRedo_Works()
        {
            Cell cell = this.spreadsheet.GetCell(2, 2)!;
            uint initialColor = cell.Color;
            uint newColor = 0xFF00FF00;

            CommandBus.Send(new CellUpdateCommand<uint>(cell, "Color", initialColor, newColor, "Edit Cell Color"));
            Assert.That(cell.Color, Is.EqualTo(newColor));

            this.spreadsheet.Manager.DoUndo();
            Assert.That(cell.Color, Is.EqualTo(initialColor));

            this.spreadsheet.Manager.DoRedo();
            Assert.That(cell.Color, Is.EqualTo(newColor));
        }

        /// <summary>
        /// Verifies spreadsheet forwards color change notifications.
        /// </summary>
        [Test]
        public void Spreadsheet_ForwardsColorPropertyChanged()
        {
            Cell cell = this.spreadsheet.GetCell(3, 3)!;
            int colorEventCount = 0;

            this.spreadsheet.CellPropertyChanged += (_, e) =>
            {
                if (e.PropertyName == "Color")
                {
                    colorEventCount++;
                }
            };

            CommandBus.Send(new CellUpdateCommand<uint>(cell, "Color", cell.Color, 0xFFFF0000, "Edit Cell Color"));

            Assert.That(colorEventCount, Is.GreaterThan(0));
        }

        /// <summary>
        /// Verifies setting same color does not raise duplicate cell color change event.
        /// </summary>
        [Test]
        public void Cell_SetSameColor_DoesNotRaiseColorEvent()
        {
            Cell cell = this.spreadsheet.GetCell(4, 4)!;
            int colorEventCount = 0;

            cell.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == nameof(Cell.Color))
                {
                    colorEventCount++;
                }
            };

            uint currentColor = cell.Color;
            cell.Color = currentColor;

            Assert.That(colorEventCount, Is.EqualTo(0));
        }
    }
}
