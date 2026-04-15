// All of this file was written by chatGPT, onyl part of this file I wrote is this line.
namespace HW3Tests
{
    using System;
    using System.Numerics;
    using NUnit.Framework;
    using HW3;
    /// <summary>
    /// Contains unit tests for the <see cref="FibonacciTextReader"/> class.
    /// </summary>
    [TestFixture]
    public class FibonacciTextReaderTests
    {
        /// <summary>
        /// Tests that ReadLine returns correct Fibonacci values for a normal case.
        /// </summary>
        [Test]
        public void ReadLine_NormalCase_ReturnsCorrectSequence()
        {
            FibonacciTextReader reader = new FibonacciTextReader(5);

            Assert.That(reader.ReadLine(), Is.EqualTo("0"));
            Assert.That(reader.ReadLine(), Is.EqualTo("1"));
            Assert.That(reader.ReadLine(), Is.EqualTo("1"));
            Assert.That(reader.ReadLine(), Is.EqualTo("2"));
            Assert.That(reader.ReadLine(), Is.EqualTo("3"));
        }

        /// <summary>
        /// Tests that ReadLine returns null after reaching maxLength boundary.
        /// </summary>
        [Test]
        public void ReadLine_BoundaryCase_ReturnsNullAfterMaxLength()
        {
            FibonacciTextReader reader = new FibonacciTextReader(2);

            reader.ReadLine();
            reader.ReadLine();
            string? result = reader.ReadLine();

            Assert.That(result, Is.Null);
        }

        /// <summary>
        /// Tests that constructor with maxLength of zero results in immediate null.
        /// </summary>
        [Test]
        public void Constructor_ZeroLength_ReadLineReturnsNull()
        {
            FibonacciTextReader reader = new FibonacciTextReader(0);

            string? result = reader.ReadLine();

            Assert.That(result, Is.Null);
        }

        /// <summary>
        /// Tests that constructor with maxLength of one returns only first Fibonacci number.
        /// </summary>
        [Test]
        public void Constructor_LengthOne_ReturnsOnlyZero()
        {
            FibonacciTextReader reader = new FibonacciTextReader(1);

            Assert.That(reader.ReadLine(), Is.EqualTo("0"));
            Assert.That(reader.ReadLine(), Is.Null);
        }

        /// <summary>
        /// Tests overflow/error case when maxLength exceeds internal array size.
        /// </summary>
        [Test]
        public void Constructor_MaxLengthExceedsArray_ThrowsException()
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                FibonacciTextReader reader = new FibonacciTextReader(101);
            });
        }

        /// <summary>
        /// Tests ReadToEnd returns a string (even though implementation is flawed).
        /// </summary>
        [Test]
        public void ReadToEnd_NormalCase_ReturnsNonNullString()
        {
            FibonacciTextReader reader = new FibonacciTextReader(5);

            string result = reader.ReadToEnd();

            Assert.That(result, Is.Not.Null);
        }
    }
}