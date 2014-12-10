﻿using System;

namespace LASI.Interop
{
    /// <summary>
    /// A LASI.Core.Interop.Reporting.ReportEventArgs implementation providing updates on an ongoing operation.
    /// </summary>
    [Serializable]
    public class AnalysisUpdateEventArgs : Core.Interop.ReportEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the ProgressReportEventArgs class.
        /// </summary>
        /// <param name="message">The message pertaining to an ongoing operation</param>
        /// <param name="percentOfWorkRepresented">The numerical increase in the progress of the operation since the event was last raised.</param>
        public AnalysisUpdateEventArgs(string message, double percentOfWorkRepresented) : base(message, percentOfWorkRepresented) { }

    }
}