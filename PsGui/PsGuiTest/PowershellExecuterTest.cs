﻿using System;
using PsGui.ViewModels;
using PsGui.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PsGuiTest
    {
    [TestClass]
    public class PowershellExecuterTest
        {
        /// <summary>
        /// When the program launches. One shall not be able to 
        /// execute a script. The selected script shall be set 
        /// to an empty string. A modulepath shall be set to a existing
        /// folder structure at the same directory level as the program.
        /// </summary>
        [TestMethod]
        public void InitialTest()
            {
            string modulePath = ".";
            PsExecViewModel psExec = new PsExecViewModel(modulePath);
            Assert.AreEqual(true, DirectoryNameBrowser.IsEmpty());
            Assert.AreEqual(false, psExec.IsScriptSelected);
            Assert.AreEqual(false, psExec.CanExecute(this));
            Assert.AreEqual("", psExec.SelectedScript);
            Assert.IsNotNull(psExec.ModulePath);
            }

        /// <summary>
        /// When a category is chosen. The script shall be cleared from
        /// the dropdown menu.
        /// </summary>
        [TestMethod]
        public void CategoryChosenEmptyListTest()
            {
            string modulePath = ".";
            PsExecViewModel psExec = new PsExecViewModel(modulePath);
            psExec.DirectoryNameBrowser.Add("Active Directory");

            Assert.AreEqual(false, psExec.IsScriptSelected);
            Assert.AreEqual(true, psExec.ScriptVariables.IsEmpty());
            }



        /// <summary>
        /// A script must be chosen before script input fields can be shown.
        /// There shall be a script input field matching each of the defined
        /// script command line arguments in the script header file.
        /// </summary>
        [TestMethod]
        public void ScriptChosenEmptyInputFieldsTest()
            {
            string modulePath = ".";
            PsExecViewModel psExec = new PsExecViewModel(modulePath);

            // Script exists, empty input fields
            psExec.SelectedScript = "SomeTestScript.ps1";
            Assert.AreEqual(true, psExec.IsScriptSelected);
            Assert.AreEqual(true, psExec.ScriptVariables.IsEmpty());


            // Script not exists
            psExec.SelectedScript = "";
            Assert.AreEqual(false, psExec.IsScriptSelected);
            }


        /// <summary>
        /// Before a powershell script is launched, all argument input
        /// fields must contain legal values.
        /// </summary>
        [TestMethod]
        public void ScriptArgumentTest()
            {
            string modulePath = ".";
            PsExecViewModel psExec = new PsExecViewModel(modulePath);

            }

        /// <summary>
        /// A module path leading to a non-existing folder structure
        /// will produce a PsExecException
        /// </summary>
        [TestMethod]
        public void BadModulepathTest()
            {
            // test senere
           // PsExecViewModel psExec = new PsExecViewModel();
           // Assert.ThrowsException<PsExecException>();
            }
        }
    }
