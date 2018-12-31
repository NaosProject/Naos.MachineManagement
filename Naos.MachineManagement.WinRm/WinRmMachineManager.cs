// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WinRmMachineManager.cs" company="Naos">
//    Copyright (c) Naos 2017. All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.MachineManagement.WinRm
{
    using System.Collections.Generic;
    using Naos.MachineManagement.Domain;
    using Naos.Recipes.WinRM;
    using OBeautifulCode.Validation.Recipes;

    using IManageMachines = Naos.MachineManagement.Domain.IManageMachines;

    /// <summary>
    /// Microsoft WinRm protocol implementation of <see cref="IManageMachines" />
    /// </summary>
    public sealed class WinRmMachineManager : IManageMachines
    {
        private readonly MachineManager machineManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="WinRmMachineManager"/> class.
        /// </summary>
        /// <param name="address">Address of machine.</param>
        /// <param name="userName">User name to connect with.</param>
        /// <param name="password">Password for provided user name.</param>
        public WinRmMachineManager(string address, string userName, string password)
        {
            new { address }.Must().NotBeNullNorWhiteSpace();

            this.Address = address;

            this.machineManager = new MachineManager(this.Address, userName, password.ToSecureString());
        }

        /// <inheritdoc />
        public string Address { get; private set; }

        /// <inheritdoc />
        public MachineProtocol MachineProtocol => MachineProtocol.WinRm;

        /// <inheritdoc />
        public void Reboot(bool force = true)
        {
            this.machineManager.Reboot();
        }

        /// <inheritdoc />
        public void SendFile(string filePathOnTargetMachine, byte[] fileContents, bool appended = false, bool overwrite = false)
        {
            this.machineManager.SendFile(filePathOnTargetMachine, fileContents, appended, overwrite);
        }

        /// <inheritdoc />
        public byte[] RetrieveFile(string filePathOnTargetMachine)
        {
            return this.machineManager.RetrieveFile(filePathOnTargetMachine);
        }

        /// <inheritdoc />
        public ICollection<dynamic> RunScript(string scriptBlock, ICollection<object> scriptBlockParameters = null)
        {
            return this.machineManager.RunScript(scriptBlock, scriptBlockParameters);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            /* no - op */
        }
    }
}
