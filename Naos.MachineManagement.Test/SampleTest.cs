// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SampleTest.cs" company="Naos Project">
//    Copyright (c) Naos Project 2019. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Naos.MachineManagement.Test
{
    using OBeautifulCode.Assertion.Recipes;
    using Xunit;

    /// <summary>
    /// Test class.
    /// </summary>
    public static class SampleTest
    {
        /// <summary>
        /// This is an example of how to use this logic to connect to another computer and run a script.
        /// </summary>
        [Fact(Skip = "Example to connect to another machine.")]
        public static void ExampleToConnectToAnotherMachine()
        {
            var machineManager = new Naos.MachineManagement.WinRm.WinRmMachineManager("10.0.0.1", "Administrator", "Password", true);
            var output = machineManager.RunScript("ls c:/");
            output.MustForTest().NotBeNull();
        }
    }
}
