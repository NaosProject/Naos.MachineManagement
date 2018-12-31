// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MachineProtocol.cs" company="Naos">
//    Copyright (c) Naos 2017. All Rights Reserved.
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
        WinRm,

        /// <summary>
        /// Secure shell.
        /// </summary>
        Ssh,
    }
}
