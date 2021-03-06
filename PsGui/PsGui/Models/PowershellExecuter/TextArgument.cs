﻿namespace PsGui.Models.PowershellExecuter
{
    /// <summary>
    /// A class with currently no functionality. Provides
    /// a scalable solution for input logic.
    /// @Inherits from ScriptArgument.
    /// </summary>
    public class TextArgument : ScriptArgument
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="key"></param>
        /// <param name="description"></param>
        /// <param name="type"></param>
        public TextArgument(string key, string description, string type) : base(key, description, type)
        {
        }
    }
}
