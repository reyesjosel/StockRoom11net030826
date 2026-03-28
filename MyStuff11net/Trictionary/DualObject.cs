//-----------------------------------------------------------------------
// <copyright file="DualObject.cs" company="None">
//     Copyright (c) Nish Sivakumar. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace MyStuff11net
{
    using System;

    /// <summary>
    /// Represents a class that can hold two types values
    /// </summary>
    /// <typeparam name="TValue1">The first type</typeparam>
    /// <typeparam name="TValue2">The second type</typeparam>
    [Serializable]
    public class DualObject<TValue1, TValue2> : IEquatable<DualObject<TValue1, TValue2>>
    {
        /// <summary>
        /// Initializes a new instance of the DualObject class
        /// </summary>
        /// <param name="value1">First value</param>
        /// <param name="value2">Second value</param>
        public DualObject(TValue1 value1, TValue2 value2)
        {
            Placements = value1;
            NumberOfPlacements = value2;
        }

        /// <summary>
        /// Initializes a new instance of the DualObject class
        /// </summary>
        /// <param name="value2">Second value</param>
        /// <param name="value1">First value</param>
        public DualObject(TValue2 value2, TValue1 value1) : this(value1, value2)
        {
        }

        /// <summary>
        /// Initializes a new instance of the DualObject class
        /// </summary>
        /// <param name="value">First value</param>
        public DualObject(TValue1 value)
        {
            Placements = value;
        }

        /// <summary>
        /// Initializes a new instance of the DualObject class
        /// </summary>
        /// <param name="value">Second value</param>
        public DualObject(TValue2 value)
        {
            NumberOfPlacements = value;
        }

        private bool isFirstValueSet;

        private TValue1 firstValue;

        private TValue1 Placements
        {
            get
            {
                return firstValue;
            }

            set
            {
                firstValue = value;
                isFirstValueSet = true;
            }
        }

        private bool isSecondValueSet;

        private TValue2 secondValue;

        private TValue2 NumberOfPlacements
        {
            get
            {
                return secondValue;
            }

            set
            {
                secondValue = value;
                isSecondValueSet = true;
            }
        }

        /// <summary>
        /// Implicit conversion operator to convert to T1
        /// </summary>
        /// <param name="dualObject">The DualObject to convert from</param>
        /// <returns>The converted object</returns>
        public static implicit operator TValue1(DualObject<TValue1, TValue2> dualObject)
        {
            return dualObject.Placements;
        }

        /// <summary>
        /// Implicit conversion operator to convert to T2
        /// </summary>
        /// <param name="dualObject">The DualObject to convert from</param>
        /// <returns>The converted object</returns>
        public static implicit operator TValue2(DualObject<TValue1, TValue2> dualObject)
        {
            return dualObject.NumberOfPlacements;
        }

        /// <summary>
        /// Implicit conversion operator to convert from T1
        /// </summary>
        /// <param name="value">The object to convert from</param>
        /// <returns>The converted DualObject</returns>
        public static implicit operator DualObject<TValue1, TValue2>(TValue1 value)
        {
            return new DualObject<TValue1, TValue2>(value);
        }

        /// <summary>
        /// Implicit conversion operator to convert from T2
        /// </summary>
        /// <param name="value">The object to convert from</param>
        /// <returns>The converted DualObject</returns>
        public static implicit operator DualObject<TValue1, TValue2>(TValue2 value)
        {
            return new DualObject<TValue1, TValue2>(value);
        }

        /// <summary>
        /// Sets the value for the first type
        /// </summary>
        /// <param name="value">The value to set</param>
        public void Set(TValue1 value)
        {
            Placements = value;
        }

        /// <summary>
        ///  Sets the value for the second type
        /// </summary>
        /// <param name="value">The value to set</param>
        public void Set(TValue2 value)
        {
            NumberOfPlacements = value;
        }

        /// <summary>
        /// Sets the values from another DualObject
        /// </summary>
        /// <param name="dualObject">The DualObject to copy the values from</param>
        public void Set(DualObject<TValue1, TValue2> dualObject)
        {
            if (dualObject.isFirstValueSet)
            {
                Placements = dualObject.Placements;
            }

            if (dualObject.isSecondValueSet)
            {
                NumberOfPlacements = dualObject.NumberOfPlacements;
            }
        }

        #region IEquatable<DualObject<T1,T2>> Members

        /// <summary>
        /// Indicates whether the current DualObject is equal to another DualObject
        /// Note : This will return true if either one of the values are equal.
        /// </summary>
        /// <param name="other">The DualObject to compare with</param>
        /// <returns>True if the objects are equal</returns>
        public bool Equals(DualObject<TValue1, TValue2> other)
        {
            bool firstEqual = Placements == null ? other.Placements == null : Placements.Equals(other.Placements);
            bool secondEqual = NumberOfPlacements == null ? other.NumberOfPlacements == null : NumberOfPlacements.Equals(other.NumberOfPlacements);
            return firstEqual || secondEqual;
        }

        #endregion
    }
}
