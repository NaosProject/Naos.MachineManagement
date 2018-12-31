// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IManageMachines.cs" company="Naos">
//    Copyright (c) Naos 2017. All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.MachineManagement.Domain
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Interface to perform actions to manage a machine.
    /// </summary>
    public interface IManageMachines : IDisposable
    {
        /// <summary>
        /// Address of the machine.
        /// </summary>
        string Address { get; }

        /// <summary>
        /// Protocol of the machine.
        /// </summary>
        MachineProtocol MachineProtocol { get; }

        /// <summary>
        /// Executes a user initiated reboot.
        /// </summary>
        /// <param name="force">Can override default behavior of a forceful reboot (kick users off).</param>
        void Reboot(bool force = true);

        /// <summary>
        /// Sends a file to the remote machine at the provided file path on that target computer.
        /// </summary>
        /// <param name="filePathOnTargetMachine">File path to write the contents to on the remote machine.</param>
        /// <param name="fileContents">Payload to write to the file.</param>
        /// <param name="appended">Optionally writes the bytes in appended mode or not (default is NOT).</param>
        /// <param name="overwrite">Optionally will overwrite a file that is already there [can NOT be used with 'appended'] (default is NOT).</param>
        void SendFile(string filePathOnTargetMachine, byte[] fileContents, bool appended = false, bool overwrite = false);

        /// <summary>
        /// Retrieves a file from the remote machines and returns a checksum verified byte array.
        /// </summary>
        /// <param name="filePathOnTargetMachine">File path to fetch the contents of on the remote machine.</param>
        /// <returns>Bytes of the specified files (throws if missing).</returns>
        byte[] RetrieveFile(string filePathOnTargetMachine);
        
        /// <summary>
        /// Runs an arbitrary script block.
        /// </summary>
        /// <param name="scriptBlock">Script block.</param>
        /// <param name="scriptBlockParameters">Parameters to be passed to the script block.</param>
        /// <returns>Collection of objects that were the output from the script block.</returns>
        ICollection<dynamic> RunScript(string scriptBlock, ICollection<object> scriptBlockParameters = null);
    }
}
