﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LASI.Algorithm;

namespace LASI.FileSystem
{
    /// <summary>
    /// Represents a tagset-to-runtime-type-mapping context which translates between a Part Of Speech
    /// Tagger's provided tags and their runtime type equivalents. 
    /// This class represents the tagset => runtime-type mapping for
    /// the tagset used SharpNLP, a derrivative of the Brown Tagset, and may not be extended.
    /// If a new tagset is to be used, derrive from the base class TaggingContext
    /// <see cref="TagsetMap"/>
    ///<see cref="WordTagParser"/>
    /// <example>
    /// 
    /// var constructorFunction = myContext["TAG"];
    /// var runtimeWord = constructorFunction(itemText);
    /// 
    /// </example>
    /// </summary>
    public abstract class TagsetMap
    {
        #region Properties and Indexers
        /// <summary>
        /// When overriden in a derrived class, Provides POS-Tag indexed access to a constructor function which can be invoked to create an instance of the class which provides its run-time representation.
        /// </summary>
        /// <param name="tag">The textual representation of a Part Of Speech tag.</param>
        /// <returns>A function which creates an isntance of the run-time type associated with the textual tag.</returns>
        /// <exception cref="UnknownPOSException">Implementors should Throw this exception if and only if when the index string is not a tag defined by the tagset being provided.</exception>
        public abstract Func<string, Word> this[string tag] {
            get;
        }
        /// <summary>
        /// When overriden in a derrived class, Gets a Read Only Dictionary which represents the mapping between Part Of Speech tags and the cunstructors which instantiate their run-time representations.
        /// </summary>
        public abstract IReadOnlyDictionary<string, Func<string, Word>> TypeDictionary {
            get;
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the TaggingContext class.
        /// </summary>
        public TagsetMap() {
        }
        #endregion
    }
}