// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SshMachineManager.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.MachineManagement.Ssh
{
    using System;
    using System.Collections.Generic;
    using Naos.MachineManagement.Domain;
    using OBeautifulCode.Assertion.Recipes;
    using Renci.SshNet;

    /// <summary>
    /// Ssh Microsoft Windows implementation of <see cref="IManageMachines" />.
    /// </summary>
    public sealed class SshMachineManager : IManageMachines
    {
        private readonly SshClient sshClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="SshMachineManager"/> class.
        /// </summary>
        /// <param name="address">Address of machine.</param>
        /// <param name="userName">User name to connect with.</param>
        /// <param name="password">Password for provided user name.</param>
        public SshMachineManager(string address, string userName, string password)
        {
            new { address }.AsArg().Must().NotBeNullNorWhiteSpace();

            this.Address = address;

            this.sshClient = new SshClient(address, userName, password);
        }

        /// <inheritdoc />
        public string Address { get; private set; }

        /// <inheritdoc />
        public MachineProtocol MachineProtocol => MachineProtocol.Ssh;

        /// <inheritdoc />
        public void Reboot(bool force = true)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void SendFile(string filePathOnTargetMachine, byte[] fileContents, bool appended = false, bool overwrite = false)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public byte[] RetrieveFile(string filePathOnTargetMachine)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public ICollection<dynamic> RunScript(string scriptBlock, ICollection<object> scriptBlockParameters = null)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2213:DisposableFieldsShouldBeDisposed", MessageId = "sshClient", Justification = "Is disposed.")]
        public void Dispose()
        {
            this.sshClient?.Dispose();
        }
    }
}
