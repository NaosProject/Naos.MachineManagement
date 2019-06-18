// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MachineProtocol.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.MachineManagement.Domain
{
    /// <summary>
    /// Machine protocols.
    /// </summary>
    public enum MachineProtocol
    {
        /// <summary>
        /// Invalid default.
        /// </summary>
        Invalid,

        /// <summary>
        /// Unknown protocol.
        /// </summary>
        Unknown,

        /// <summary>
        /// Local Microsoft Windows.
        /// </summary>
        Local,

        /// <summary>
        /// Microsoft Windows Remote Management.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Rm", Justification = "Name/spelling is correct.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Rm", Justification = "Name/spelling is correct.")]
        WinRm,

        /// <summary>
        /// Secure shell.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Ssh", Justification = "Name/spelling is correct.")]
        Ssh,
    }
}
