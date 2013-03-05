﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace LASI.Algorithm
{
    /// <summary>
    /// Represents a particle such as "about". Note that the distintion between particle and prepositions can sometimes be tricky and is heavily dependent on nuances of grammatical usage.
    /// </summary>
    public class Particle : Word, IPrepositional
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Particle class.
        /// </summary>
        /// <param name="text">The literal text content of the particle.</param>
        public Particle(string text)
            : base(text) {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the IprepositionLinkable construct on the right-hand-side of the Preposition.
        /// </summary>
        public IPrepositionLinkable OnRightSide {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the IprepositionLinkable construct on the left-hand-side of the Preposition.
        /// </summary>
        public IPrepositionLinkable OnLeftSide {
            get;
            set;
        }

        #endregion

        public override XElement Serialize() {
            throw new NotImplementedException();
        }
    }
}