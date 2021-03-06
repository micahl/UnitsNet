// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/InitialForce/SIUnits
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using NUnit.Framework;

// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

// ReSharper disable once CheckNamespace
namespace UnitsNet.Tests
{
    /// <summary>
    /// Test of RotationalSpeed.
    /// </summary>
    [TestFixture]
    public abstract partial class RotationalSpeedTestsBase
    {
        protected virtual double Delta { get { return 1E-5; } }

        public abstract double RevolutionsPerMinuteInOneRevolutionPerSecond { get; }
        public abstract double RevolutionsPerSecondInOneRevolutionPerSecond { get; }

        [Test]
        public void RevolutionPerSecondToRotationalSpeedUnits()
        {
            RotationalSpeed revolutionpersecond = RotationalSpeed.FromRevolutionsPerSecond(1);
            Assert.AreEqual(RevolutionsPerMinuteInOneRevolutionPerSecond, revolutionpersecond.RevolutionsPerMinute, Delta);
            Assert.AreEqual(RevolutionsPerSecondInOneRevolutionPerSecond, revolutionpersecond.RevolutionsPerSecond, Delta);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            RotationalSpeed revolutionpersecond = RotationalSpeed.FromRevolutionsPerSecond(1); 
            Assert.AreEqual(1, RotationalSpeed.FromRevolutionsPerMinute(revolutionpersecond.RevolutionsPerMinute).RevolutionsPerSecond, Delta);
            Assert.AreEqual(1, RotationalSpeed.FromRevolutionsPerSecond(revolutionpersecond.RevolutionsPerSecond).RevolutionsPerSecond, Delta);
        }

        [Test]
        public void ArithmeticOperators()
        {
            RotationalSpeed v = RotationalSpeed.FromRevolutionsPerSecond(1);
            Assert.AreEqual(-1, -v.RevolutionsPerSecond, Delta);
            Assert.AreEqual(2, (RotationalSpeed.FromRevolutionsPerSecond(3)-v).RevolutionsPerSecond, Delta);
            Assert.AreEqual(2, (v + v).RevolutionsPerSecond, Delta);
            Assert.AreEqual(10, (v*10).RevolutionsPerSecond, Delta);
            Assert.AreEqual(10, (10*v).RevolutionsPerSecond, Delta);
            Assert.AreEqual(2, (RotationalSpeed.FromRevolutionsPerSecond(10)/5).RevolutionsPerSecond, Delta);
            Assert.AreEqual(2, RotationalSpeed.FromRevolutionsPerSecond(10)/RotationalSpeed.FromRevolutionsPerSecond(5), Delta);
        }

        [Test]
        public void ComparisonOperators()
        {
            RotationalSpeed oneRevolutionPerSecond = RotationalSpeed.FromRevolutionsPerSecond(1);
            RotationalSpeed twoRevolutionsPerSecond = RotationalSpeed.FromRevolutionsPerSecond(2);

            Assert.True(oneRevolutionPerSecond < twoRevolutionsPerSecond);
            Assert.True(oneRevolutionPerSecond <= twoRevolutionsPerSecond);
            Assert.True(twoRevolutionsPerSecond > oneRevolutionPerSecond);
            Assert.True(twoRevolutionsPerSecond >= oneRevolutionPerSecond);

            Assert.False(oneRevolutionPerSecond > twoRevolutionsPerSecond);
            Assert.False(oneRevolutionPerSecond >= twoRevolutionsPerSecond);
            Assert.False(twoRevolutionsPerSecond < oneRevolutionPerSecond);
            Assert.False(twoRevolutionsPerSecond <= oneRevolutionPerSecond);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            RotationalSpeed revolutionpersecond = RotationalSpeed.FromRevolutionsPerSecond(1);
            Assert.AreEqual(0, revolutionpersecond.CompareTo(revolutionpersecond));
            Assert.Greater(revolutionpersecond.CompareTo(RotationalSpeed.Zero), 0);
            Assert.Less(RotationalSpeed.Zero.CompareTo(revolutionpersecond), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            RotationalSpeed revolutionpersecond = RotationalSpeed.FromRevolutionsPerSecond(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            revolutionpersecond.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        { 
            RotationalSpeed revolutionpersecond = RotationalSpeed.FromRevolutionsPerSecond(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            revolutionpersecond.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            RotationalSpeed a = RotationalSpeed.FromRevolutionsPerSecond(1);
            RotationalSpeed b = RotationalSpeed.FromRevolutionsPerSecond(2);

// ReSharper disable EqualExpressionComparison
            Assert.True(a == a); 
            Assert.True(a != b);

            Assert.False(a == b);
            Assert.False(a != a);
// ReSharper restore EqualExpressionComparison
        }

        [Test]
        public void EqualsIsImplemented()
        {
            RotationalSpeed v = RotationalSpeed.FromRevolutionsPerSecond(1);
            Assert.IsTrue(v.Equals(RotationalSpeed.FromRevolutionsPerSecond(1)));
            Assert.IsFalse(v.Equals(RotationalSpeed.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            RotationalSpeed revolutionpersecond = RotationalSpeed.FromRevolutionsPerSecond(1);
            Assert.IsFalse(revolutionpersecond.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            RotationalSpeed revolutionpersecond = RotationalSpeed.FromRevolutionsPerSecond(1);
            Assert.IsFalse(revolutionpersecond.Equals(null));
        }
    }
}
