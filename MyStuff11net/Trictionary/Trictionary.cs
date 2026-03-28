//-----------------------------------------------------------------------
// <copyright file="Trictionary.cs" company="None">
//     Copyright (c) Nish Sivakumar. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace MyStuff11net
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Represents a dictionary with two distinct typed values per key
    /// </summary>
    /// <typeparam name="TKey">The type of the dictionary key</typeparam>
    /// <typeparam name="TValue1">The type of the first value</typeparam>
    /// <typeparam name="TValue2">The type of the second value</typeparam>
    [Serializable]
    public class Trictionary<TKey, TValue1, TValue2> : Dictionary<TKey, DualObject<TValue1, TValue2>>
    {
        /// <summary>
        /// Initializes a new instance of the Trictionary class
        /// </summary>
        public Trictionary()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Trictionary class for use with serialization
        /// </summary>
        /// <param name="info">SerializationInfo objects that holds the required information for serialization</param>
        /// <param name="context">StreamingContext structure for serialization</param>
        protected Trictionary(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        /// <summary>
        /// Gets or sets the values associated with the specified key
        /// </summary>
        /// <param name="key">The key of the values to get or set</param>
        /// <returns>Returns the DualObject associated with this key</returns>
        public new DualObject<TValue1, TValue2> this[TKey key]
        {
            get
            {
                return base[key];
            }

            set
            {
                if (ContainsKey(key))
                {
                    base[key].Set(value);
                }
                else
                {
                    base[key] = value;
                }
            }
        }
    }
}
