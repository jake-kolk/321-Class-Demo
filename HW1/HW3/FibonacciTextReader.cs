// <copyright file="FibonacciTextReader.cs" company="WSU">
// Copyright (c) WSU. All rights reserved.
// </copyright>

namespace HW3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using static System.Windows.Forms.LinkLabel;

    /// <summary>
    /// This class is for reading fib numbers into the program.
    /// </summary>
    public class FibonacciTextReader : TextReader
    {
        private int maxLength = 0;
        private int linesRead = 0;
        private BigInteger[] fibNumbers = new BigInteger[100];

        /// <summary>
        /// Initializes a new instance of the <see cref="FibonacciTextReader"/> class.
        /// </summary>
        /// <param name="maxLen">The number of Fibonacci numbers to calculate.</param>
        public FibonacciTextReader(int maxLen)
        {
            this.maxLength = maxLen;

            // Calculate Fib numbers
            this.fibNumbers[0] = 0;
            this.fibNumbers[1] = 1;
            for (int i = 2; i < maxLen; i++)
            {
                this.fibNumbers[i] = this.fibNumbers[i - 1] + this.fibNumbers[i - 2];
            }

            return;
        }

        /// <summary>
        /// This reads the next Fib number.
        /// </summary>
        /// <returns>the next fib number.</returns>
        public override string? ReadLine()
        {
            if (this.maxLength == this.linesRead)
            {
                return null;
            }

            BigInteger number = this.fibNumbers[this.linesRead];
            this.linesRead++;
            return number.ToString();
        }

        /// <summary>
        /// This overrided function converts all the fib numbers into a long string.
        /// </summary>
        /// <returns>A long string of the requested fib numbers.</returns>
        public override string ReadToEnd()
        {
            string[] fib = new string[this.maxLength];
            string result = string.Join(Environment.NewLine, fib);
            return result;
        }
    }
}
