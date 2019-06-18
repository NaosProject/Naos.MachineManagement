// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocalMachineManager.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.MachineManagement.Local
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Naos.MachineManagement.Domain;
    using Naos.Recipes.WinRM;

    using static System.FormattableString;
    using IManageMachines = Naos.MachineManagement.Domain.IManageMachines;

    /// <summary>
    /// Local Microsoft Windows implementation of <see cref="IManageMachines" />.
    /// </summary>
    public sealed class LocalMachineManager : IManageMachines
    {
        private readonly MachineManager machineManager;

        /// <summary>
        /// Constant to use for localhost execution.
        /// </summary>
        public const string LocalhostAddress = "localhost";

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalMachineManager"/> class.
        /// </summary>
        public LocalMachineManager()
        {
            this.machineManager = new MachineManager(LocalhostAddress, "user", "password".ToSecureString());
        }

        /// <inheritdoc />
        public string Address => LocalhostAddress;

        /// <inheritdoc />
        public MachineProtocol MachineProtocol => MachineProtocol.Local;

        /// <inheritdoc />
        public void Reboot(bool force = true)
        {
            var forceAddIn = force ? " -Force" : string.Empty;
            var restartScriptBlock = "{ Restart-Computer" + forceAddIn + " }";
            this.RunScript(restartScriptBlock);
        }

        /// <inheritdoc />
        public void SendFile(string filePathOnTargetMachine, byte[] fileContents, bool appended = false, bool overwrite = false)
        {
            if (!appended && overwrite)
            {
                var directory = Path.GetDirectoryName(filePathOnTargetMachine) ?? throw new ArgumentException(Invariant($"Could not get directory from {filePathOnTargetMachine}."));
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                File.WriteAllBytes(filePathOnTargetMachine, fileContents);
            }
            else
            {
                throw new NotSupportedException("Only supports un-appended and overwritten.");
            }
        }

        /// <inheritdoc />
        public byte[] RetrieveFile(string filePathOnTargetMachine)
        {
            return File.ReadAllBytes(filePathOnTargetMachine);
        }

        /// <inheritdoc />
        public ICollection<dynamic> RunScript(string scriptBlock, ICollection<object> scriptBlockParameters = null)
        {
            return this.machineManager.RunScriptOnLocalhost(scriptBlock, scriptBlockParameters);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            /* no - op */
        }
    }
}
