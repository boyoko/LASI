﻿namespace LASI.Interop.ContractHelperTypes.Base
{
    using Lexicon = LASI.Core.Lexicon;
    using ResourceLoadEventArgs = LASI.Core.ResourceLoadEventArgs;

    /// <summary>
    /// Provides for the subscription of events involving the loading of core resources.
    /// </summary>
    class SystemResourceNotifier : SystemResourceNotifierDualizer
    {
        /// <summary>
        /// Initializes a new instance of the SystemResourceNotifier class which provides
        /// for the subscription of events corresponding to resource loading events.
        /// </summary>
        public SystemResourceNotifier() : base(messageAdjunct: "Loaded") =>
            Lexicon.ResourceLoaded += (sender, e) => OnReport(e);

        /// <summary>
        /// Raised when a System Core resource begins loading.
        /// </summary>
        public event System.EventHandler<ResourceLoadEventArgs> ProgressChanging
        {
            add => loadingProvider.ProgressChanged += value;
            remove => loadingProvider.ProgressChanged -= value;
        }
        readonly SystemResourceLoadingNotifier loadingProvider = new SystemResourceLoadingNotifier();
    }
}
