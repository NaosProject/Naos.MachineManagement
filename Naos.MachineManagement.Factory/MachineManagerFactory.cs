// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MachineManagerFactory.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.MachineManagement.Factory
{
    using System;
    using Naos.MachineManagement.Domain;
    using Naos.MachineManagement.Local;
    using Naos.MachineManagement.Ssh;
    using Naos.MachineManagement.WinRm;
    using OBeautifulCode.Assertion.Recipes;

    using static System.FormattableString;

    /// <summary>
    /// Factory to build appropriate implementation of. <see cref="IManageMachines" />.
    /// </summary>
    public class MachineManagerFactory : ICreateMachineManagers
    {
        /// <inheritdoc />
        public IManageMachines CreateMachineManager(MachineProtocol machineProtocol, string address, string userName, string password)
        {
            new { machineProtocol }.AsArg().Must().NotBeEqualTo(MachineProtocol.Invalid);

            switch (machineProtocol)
            {
                case MachineProtocol.Local:
                    return new LocalMachineManager();
                case MachineProtocol.Ssh:
                    return new SshMachineManager(address, userName, password);
                case MachineProtocol.WinRm:
                    return new WinRmMachineManager(address, userName, password, true);
                default:
                    throw new NotSupportedException(Invariant($"{nameof(MachineProtocol)} - {machineProtocol} is not supported."));
            }
        }
    }
}
