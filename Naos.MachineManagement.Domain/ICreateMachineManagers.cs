// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICreateMachineManagers.cs" company="Naos">
//    Copyright (c) Naos 2017. All Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.MachineManagement.Domain
{
    /// <summary>
    /// Interface for <see cref="IManageMachines" /> factory.
    /// </summary>
    public interface ICreateMachineManagers
    {
        /// <summary>
        /// Create a new <see cref="IManageMachines" /> for supplied <see cref="MachineProtocol" /> using supplied credentials.
        /// </summary>
        /// <param name="machineProtocol">Protocol to use.</param>
        /// <param name="address">Address of machine.</param>
        /// <param name="userName">User name to connect with.</param>
        /// <param name="password">Password for supplied user name.</param>
        /// <returns>Appropriate implementation of <see cref="IManageMachines" />.</returns>
        IManageMachines CreateMachineManager(MachineProtocol machineProtocol, string address, string userName, string password);
    }
}
